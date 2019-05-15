//
//  File: skin.js
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

import A11y from "./a11y";

window.skinGoogleTranslatePage = function (fromLang) {
    window.open ("http://translate.google.com/translate?hl=en&sl=" + fromLang + "&u=" + encodeURI (document.location));
};

window.skinSetupFeedbackUrl = function ($, obj, feedbackModuleId) {
    var selection = encodeURIComponent (rangy.getSelection ().toString ().replace (/(\n|\r)/gm," ").replace (/\s+/g, " ").replace (/\"/g, "").trim ().substring (0,100));
    var params = "returntabid=" + epsilon.queryParams ["TabId"] + "&feedbackmid=" + feedbackModuleId + ((!!selection)? "&feedbackselection=" + selection : "");
    var feedbackUrl = $(obj).attr ("data-feedback-url");
    if (feedbackUrl.includes ("?popUp=")) {
        $(obj).attr ("href", feedbackUrl.replace (/\?popUp=(\w+)/, "?popUp=$1&" + params));
    } else {
        $(obj).attr ("href", feedbackUrl + (feedbackUrl.includes ("?") ? "&" : "?") + params);
    }

    return true;
};

(function ($, window, document) {

    function initBreadcrumb () {
        if (epsilon.breadCrumbsRemoveLastLink) {
            // assume new style breadcrumbs with schema.org markup (DNN 8+)
            var schemaOrg = true;
            var breadcrumb = $(".breadcrumb > span > span").first ();

            if (breadcrumb.length === 0) {
                // it looks like an old style breadcrumbs
                schemaOrg = false;
                breadcrumb = $(".breadcrumb > span").first ();
            }

            // remove last link (to the current page)
            if (breadcrumb.length > 0) {
                if (schemaOrg) {
                    breadcrumb.find ("a").last ().parent ().remove ();
                } else {
                    breadcrumb.find ("a").last ().remove ();
                }
            }
        }
    }

    function initUpButton (offset, duration) {
        $(window).scroll(function() {
            if ($(this).scrollTop() > offset) {
                $('.skin-float-button-up').fadeIn(duration);
            } else {
                $('.skin-float-button-up').fadeOut(duration);
            }
        });

        $('.skin-float-button-up').click(function(event) {
            event.preventDefault();
            $(this).tooltip ('hide');
            $('html, body').animate({scrollTop: 0}, duration);
            return false;
        });
    }

    function emptyLayoutRows () {
        $('.row').each (function () {
            if ($(this).children ().length ===
                $(this).children ('.DNNEmptyPane').not ('.dnnSortable').length) {
                $(this).addClass ('hidden');
            }
        });
    }

    function initLanguage () {
        $(".skin-languages .language-object a").each (function () {
            var lang = $(this).parent (".Language").attr ("title");
            var langCode = lang.substr (0, 2).toUpperCase ();
            $(this).addClass ("dropdown-item").html ("<strong>" + langCode + "</strong> " + lang);
        });
    }

    $(function () {
        emptyLayoutRows ();
        initBreadcrumb ();
        initUpButton (320, 500);
        initLanguage ();

        window.skinA11y = new A11y ().init ();
    });

}) (jQuery, window, document);
