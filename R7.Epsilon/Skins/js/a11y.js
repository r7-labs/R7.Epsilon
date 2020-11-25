import Cookies from "js-cookie";

export default class A11y {

    get defaultFontSize () { return 16; }

    init () {

        if (epsilon.enablePopups) {
            if (this.getPopupsDisabled ()) {
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
        const fontSize = Cookies.get (epsilon.cookiePrefix + "FontSize");
        if (typeof fontSize !== "undefined") {
            const fontSizeInt = parseInt (fontSize);
            if (fontSizeInt >= 2 || fontSizeInt <= 64) {
                return fontSizeInt;
            }
        }
        return this.defaultFontSize;
    }

    setFontSize (fontSize) {
        document.documentElement.style = "font-size:" + fontSize + "px;";
        Cookies.set (epsilon.cookiePrefix + "FontSize", fontSize, {expires: 7, domain: "." + epsilon.portalAlias, hostOnly: false});
    }

    increaseFontSize () {
        this.setFontSize (this.getFontSize () + 2);
    }

    decreaseFontSize () {
        this.setFontSize (this.getFontSize () - 2);
    }

    getPopupsDisabled () {
        return Cookies.get (epsilon.cookiePrefix + "DisablePopups") === "true";
    }

    disablePopups () {
        // TODO: Also disable popups for feedback button

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

        Cookies.set (epsilon.cookiePrefix + "DisablePopups", true, {expires: 7, domain: "." + epsilon.portalAlias, hostOnly: false});
    }

    disableTooglePopups () {
        $("a#lnkDisablePopups").addClass ("d-none")
            .prev ("div.dropdown-divider").addClass ("d-none");
        $("a#lnkReEnablePopups").addClass ("d-none");
    }

    /** @deprecated Unused */
    reEnablePopups () {
        $("a.popup-href-link").each (function () {
            $(this).attr ("href", $(this).data ("popupHref")).removeData ("popupHref");
        });
        $("a.popup-onclick-link").each (function () {
            $(this).attr ("onclick", $(this).data ("popupOnClick")).removeData ("popupOnClick");
        });

        $("a#lnkDisablePopups").removeClass ("d-none");
        $("a#lnkReEnablePopups").addClass ("d-none");

        Cookies.remove (epsilon.cookiePrefix + "DisablePopups");
    }

    /** @deprecated Unused */
    restoreDefaults () {
        this.setFontSize (this.defaultFontSize);
        this.reEnablePopups ();
    }
};
