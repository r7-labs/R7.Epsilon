//
//  File: a11y.js
//  Project: R7.Epsilon
//
//  Author: Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2015-2019 Roman M. Yagodin, R7.Labs
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Affero General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Affero General Public License for more details.
//
//  You should have received a copy of the GNU Affero General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

import Cookies from "js-cookie";

export default class A11y {

    get defaultFontSize () { return 16; }

    init () {
        if (epsilon.enablePopups) {
            if (Cookies.get ("r7Epsilon_A11yDisablePopups") === "true") {
                this.disablePopups ();
            }
        }
        else {
            this.disableTooglePopups ();
        }

        this.setFontSize (this.getFontSize ());

        return this;
    }

    getFontSize () {
        const fontSize = Cookies.get ("r7Epsilon_A11yFontSize");
        if (typeof fontSize === "undefined" || fontSize < 2 || fontSize > 64) {
            return this.defaultFontSize;
        }
        return parseInt (fontSize);
    }

    setFontSize (fontSize) {
        document.documentElement.style = "font-size:" + fontSize + "px;";
        Cookies.set ("r7Epsilon_A11yFontSize", fontSize, {expires: 1});
    }

    increaseFontSize () {
        this.setFontSize (this.getFontSize () + 2);
    }

    decreaseFontSize () {
        this.setFontSize (this.getFontSize () - 2);
    }

    disablePopups () {
        // replace all popup links with simple ones
        $("a[href^='javascript:dnnModal']").each (function () {
            const url = $(this).attr ("href");
            const urlEnd = url.indexOf ("?popUp=");
            const urlStart = url.indexOf ("http://");
            if (urlStart >= 0 && urlEnd >= 0) {
                $(this).data ("popupHref", url)
                    .attr ("href", url.substring (urlStart, urlEnd))
                    .addClass ("popup-href-link");
            }
        });

        // disable onclick handlers from login/register links
        $("a[id$='_loginLink'], a[id$='_enhancedLoginLink'], a[id$='_enhancedRegisterLink']").filter("[onclick]").each (function () {
            const onclick = $(this).attr ("onclick");
            // check if onclick handler is not disabled via custom auth provider
            if (onclick !== "this.disabled=true;") {
                $(this).data ("popupOnClick", onclick)
                    .attr ("onclick", "this.disabled=true;")
                    .addClass ("popup-onclick-link");
            }
        });

        $("a#lnkDisablePopups").addClass ("d-none");
        $("a#lnkReEnablePopups").removeClass ("d-none");

        Cookies.set ("r7Epsilon_A11yDisablePopups", true, {expires: 1});
    }

    reEnablePopups () {
        $("a.popup-href-link").each (function () {
            $(this).attr ("href", $(this).data ("popupHref")).removeData ("popupHref");
        });
        $("a.popup-onclick-link").each (function () {
            $(this).attr ("onclick", $(this).data ("popupOnClick")).removeData ("popupOnClick");
        });

        $("a#lnkDisablePopups").removeClass ("d-none");
        $("a#lnkReEnablePopups").addClass ("d-none");

        Cookies.remove ("r7Epsilon_A11yDisablePopups");
    }

    disableTooglePopups () {
        $("a#lnkDisablePopups").addClass ("d-none")
            .prev ("div.dropdown-divider").addClass ("d-none");
        $("a#lnkReEnablePopups").addClass ("d-none");
    }

    restoreDefaults () {
        this.setFontSize (this.defaultFontSize);
        this.reEnablePopups ();
    }
};
