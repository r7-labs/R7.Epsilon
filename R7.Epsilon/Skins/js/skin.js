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

window.skinOpenFeedback = function (button, $, feedbackModuleId) {
    const selection = encodeURIComponent (rangy.getSelection ().toString ().replace (/(\n|\r)/gm," ").replace (/\s+/g, " ").replace (/\"/g, "").trim ().substring (0,100));
    const baseFeedbackUrl = $(button).data ("feedback-url");
    const feedbackParams = "returntabid=" + epsilon.queryParams ["TabId"] + "&feedbackmid=" + feedbackModuleId;

    const feedbackSelection = ((!!selection)? "&feedbackselection=" + selection : "");

    if (epsilon.enablePopups && window.skinA11y.getPopupsDisabled () === false && $(button).data ("feedback-open-in-popup") === true) {
        const popupFeedbackUrl = baseFeedbackUrl + "/mid/" + feedbackModuleId + "?" + feedbackParams + "&popup=true" + feedbackSelection;
        dnnModal.show (popupFeedbackUrl, false, 550, 950, false, "");
    }
    else {
        const rawFeedbackUrl = baseFeedbackUrl + "?" + feedbackParams + "&" + feedbackSelection;
        window.open (rawFeedbackUrl, "_blank");
    }
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

    function initBootstrapTooltips () {
        if (typeof ($.fn.tooltip) !== "undefined") {
            $("[data-toggle='tooltip']").tooltip ();
        }
    }

    function initBootstrapPopovers () {
        if (typeof ($.fn.popover) !== "undefined") {
            $("[data-toggle='popover']").popover ();
        }
    }

    function alterLogin () {
        $(".skin-login li.userDisplayName > a").addClass ("dropdown-item");
        $(".skin-login div.loginGroup > a").addClass ("dropdown-item");
        $(".skin-login li.userMessages > a").addClass ("dropdown-item");
        $(".skin-login li.userNotifications > a").addClass ("dropdown-item");
        $(".skin-login li.userProfileImg > a").addClass ("dropdown-item");

        const loginGroup = $(".skin-login .loginGroup").first ().detach ();
        const divider = "<li class='dropdown-divider'></li>";

        const profileImg = $(".skin-login li.userProfileImg > a > img");
        if (profileImg.length > 0) {
            profileImg.attr ("src", profileImg.attr ("src").replace ("h=32&w=32", "h=64&w=64"));

            const profileLinkBlock = $(".skin-login li.userDisplayName").first ().detach ();
            const profileImgBlock = $(".skin-login li.userProfileImg").first ().detach ();

            $(".skin-login ul.buttonGroup")
                .prepend (divider)
                .prepend (profileLinkBlock)
                .prepend (profileImgBlock)
                .append (divider)
                .append (loginGroup);
        }
        else {
            $(".skin-login ul.buttonGroup")
                .append (divider)
                .append (loginGroup);
        }
    }

    $(function () {
        initBootstrapTooltips ();
        initBootstrapPopovers ();

        if (! epsilon.inPopup) {
            emptyLayoutRows ();
            initBreadcrumb ();
            initUpButton (320, 500);
            initLanguage ();
            alterLogin ();
            window.skinA11y = new A11y ().init ();
        }
    });

}) (jQuery, window, document);
