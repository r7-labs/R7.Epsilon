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
import Cookies from "js-cookie";

const supportedBrowsers = require ("./supportedBrowsers");

// TODO: Move global functions to eplilon object?

window.skinGoogleTranslatePage = function (fromLang) {
    window.open ("http://translate.google.com/translate?hl=en&sl=" + fromLang + "&u=" + encodeURI (document.location));
};

window.skinGetBaseFeedbackUrl = function () {
    const feedbackParams = "returntabid=" + epsilon.queryParams ["TabId"] + "&feedbackmid=" + epsilon.feedbackModuleId;
    return epsilon.feedbackUrl + "?" + feedbackParams;
}

window.skinOpenFeedback = function () {
    const selection = encodeURIComponent (rangy.getSelection ().toString ().replace (/(\n|\r)/gm," ").replace (/\s+/g, " ").replace (/\"/g, "").trim ().substring (0,100));
    const feedbackSelection = ((!!selection)? "&feedbackselection=" + selection : "");
    const feedbackUrl = skinGetBaseFeedbackUrl () + feedbackSelection;
    window.open (feedbackUrl, "_blank");
};

window.skinSearchExternalClick = function (e, link) {
    const searchText = $("input[id$='_dnnSearch_txtSearch']").val ();
    const urlFormat = $(link).data ("url-format");
    $(link).attr ("href", urlFormat.replace ("{website}", encodeURIComponent (epsilon.portalAlias)).replace ("{searchText}", encodeURIComponent (searchText)));
};

window.skinCookiesAlertButtonClick = function (e) {
    Cookies.set (epsilon.cookiePrefix + "CookiesAlert", {expires: 14});
    $(e.target).closest (".toast").toast ("hide");
};

window.skinCookiesDisabledAlertButtonClick = function (e) {
    $(e.target).closest (".toast").toast ("hide");
};

window.skinBrowserAlertButtonClick = function (e) {
    Cookies.set (epsilon.cookiePrefix + "BrowserAlert", {expires: 1});
    $(e.target).closest (".toast").toast ("hide");
};

(function ($, window, document) {

    function getLocationOrigin (location) {
        return (!!location.origin)
            ? location.origin
            : location.protocol + "//" + location.hostname + (location.port ? ":" + location.port: "");
    }

    function initFeedbackButton () {
        $("#btnSkinFeedback").on ("inserted.bs.popover", function () {
            $("#btnSkinOpenFeedback")
                .attr ("href", skinGetBaseFeedbackUrl ())
                .attr ("target", "_blank")
                .click (function (e) {
                    e.preventDefault ();
                    skinOpenFeedback ();
                });
        });
    }

    function setupFeedbackModule () {
        if (!!epsilon.queryParams ["feedbackmid"]) {
            var feedbackContent = "";
            if (!!epsilon.queryParams ["returntabid"]) {
                feedbackContent += epsilon.localization ["feedbackPageTemplate"]
                    .replace (/\{origin\}/, getLocationOrigin (window.location))
                    .replace (/\{tabid\}/, epsilon.queryParams ["returntabid"]);

                if (!!epsilon.queryParams ["feedbackselection"]) {
                    feedbackContent += epsilon.localization ["feedbackSelectionTemplate"].replace (/\{selection\}/, epsilon.queryParams ["feedbackselection"]);
                }

                var moduleSelector = "#dnn_ctr" + epsilon.queryParams ["feedbackmid"] + "_ContentPane";
                $(moduleSelector + " textarea").first ()
                    .val (epsilon.localization ["feedbackTemplate"].replace (/\{content\}/, feedbackContent))
                    .trigger ("change").trigger ("keyup");
            }
        }
    }

    function initUpButton (offset, duration) {
        $(window).scroll(function() {
            if ($(this).scrollTop() > offset) {
                $('.skin-float-btn-up').fadeIn(duration);
            } else {
                $('.skin-float-btn-up').fadeOut(duration);
            }
        });

        $('.skin-float-btn-up').on ("click.epsilon", function (e) {
            e.preventDefault();
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

    function alterLanguage () {
        $(".skin-languages .language-object a").each (function () {
            const lang = $(this).parent (".Language").attr ("title");
            const langCode = $(this).closest (".language-object").find ("option").filter (function () { return $(this).text() == lang; }).val ();
            $(this).addClass ("dropdown-item")
                .html ("<strong>" + langCode + "</strong> " + lang)
                .attr ("hreflang", langCode);
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

    function initBootstrapToasts () {
        if (typeof ($.fn.toast) !== "undefined") {
            $(".toast").toast ();
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
                .append (loginGroup.children ("a").prepend ("<i class='fas fa-lock'></i> "));

                $(".skin-login li.userMessages > a > span").addClass ("badge badge-primary");
                $(".skin-login li.userNotifications > a > span").addClass ("badge badge-secondary");
        }
        else {
            $(".skin-login ul.buttonGroup")
                .append (divider)
                .append (loginGroup.children ("a").prepend ("<i class='fas fa-unlock-alt'></i> "));
        }
    }

    function initCustomContent () {
        // TODO: Also check for superusers and admins
        if (epsilon.isEditMode) {
            $(".skin-custom-content").each (function () {
                $(this).prepend ("<div class='actionMenu'>"
                                + "<ul class='dnn_mact'>"
                                // TODO: Localize label
                                // TODO: Generate actual edit URL
                                + "<li class='actionMenuEdit'><a href='#' aria-label='edit'><i class='fas fa-pencil-alt'></i></a></li>"
                                + "</ul>"
                                + "</div>");
            });
        }
    }

    function initSearch () {
        $("#searchModal").on ("shown.bs.modal", function (e) {
            $("#searchModal input[id$='_dnnSearch_txtSearch']").focus ();
        });
    }

    function initClipboard () {
        epsilon.clipboard = new ClipboardJS('.btn.btn-clipboard');
    }

    function initTags () {
        $(".skin-tags ul.categories > li > a").addClass ("badge badge-secondary");
    }

    function initMainMenu () {
        $(".skin-main-menu .collapse-toggle").on ("click.epsilon", function (e) {
            $(this).toggleClass ("show").next (".collapse").collapse ("toggle");
            e.stopPropagation ();
            e.preventDefault ();
        });
        // hide collapses when parent dropdown hides
        $(".skin-main-menu .dropdown").on("hidden.bs.dropdown", function (e) {
            $(this).find (".collapse-toggle").removeClass ("show").next (".collapse").collapse ("hide");
        });

        $(".skin-main-menu .skin-submenu.collapse")
            .on ("shown.bs.collapse", function (e) {
                const parentMenuItem = $(".skin-main-menu .dropdown-toggle[href='#" + $(this).attr ("id") + "']");
                const firstMenuItem = $(this).find (".nav-link").first ();
                const lastMenuItem = $(this).find (".nav-link").last ();
                parentMenuItem.on ("keydown.epsilon", function (e) {
                    // Tab or Down
                    if ((e.keyCode === 9 && !e.shiftKey) || e.keyCode === 40) {
                        e.preventDefault ();
                        e.stopPropagation ();
                        firstMenuItem.focus ();
                    }
                });
                firstMenuItem.on ("keydown.epsilon", function (e) {
                    // Shift-Tab or Up
                    if ((e.keyCode === 9 && e.shiftKey) || e.keyCode === 38) {
                        e.preventDefault ();
                        e.stopPropagation ();
                        parentMenuItem.focus ();
                    }
                });
                lastMenuItem.on ("keydown.epsilon", function (e) {
                    // Tab
                    if (e.keyCode === 9 && !e.shiftKey) {
                        const nextParentMenuItem = parentMenuItem.parent ().next ().children (".nav-link");
                        if (nextParentMenuItem.length > 0) {
                            e.preventDefault ();
                            e.stopPropagation ();
                            nextParentMenuItem.focus ();
                        }
                    }
                });
            })
            .on ("hidden.bs.collapse", function () {
                const parentMenuItem = $(".skin-main-menu .dropdown-toggle[href='#" + $(this).attr ("id") + "']");
                const firstMenuItem = $(this).find (".nav-link").first ();
                const lastMenuItem = $(this).find (".nav-link").last ();
                parentMenuItem.off ("keydown.epsilon");
                firstMenuItem.off ("keydown.epsilon");
                lastMenuItem.off ("keydown.epsilon");
            });
    }

    function initBreadcrumb () {
        $(".skin-breadcrumb-menu .collapse-toggle").on ("click.epsilon", function (e) {
            $(this).toggleClass ("show").next (".collapse").collapse ("toggle");
            e.stopPropagation ();
            e.preventDefault ();
        });
        // hide collapses when parent dropdown hides
        $(".skin-breadcrumb-menu .dropdown").on("hidden.bs.dropdown", function (e) {
            $(this).find (".collapse-toggle").removeClass ("show").next (".collapse").collapse ("hide");
        });
    }

    function isCookiesEnabled () {
        // borrowed from https://github.com/Modernizr/Modernizr/blob/master/feature-detects/cookies.js
        try {
            document.cookie = epsilon.cookiePrefix + "CookieTest=1;"
            var isCookiesEnabled = document.cookie.indexOf (epsilon.cookiePrefix + "CookieTest=") !== -1;
            document.cookie = epsilon.cookiePrefix + "CookieTest=1; expires=Thu, 01-Jan-1970 00:00:01 GMT";
            return isCookiesEnabled;
          }
          catch (e) {
            return false;
          }
    }

    function showToasts () {
        if (typeof Cookies.get (epsilon.cookiePrefix + "BrowserAlert") === "undefined") {
            if (! supportedBrowsers.test (navigator.userAgent)) {
                $("#skin_toastBrowserAlert").toast ("show");
            }
        }

        if (!isCookiesEnabled ()) {
            $("#skin_toastCookiesDisabledAlert").toast ("show");
        }
        else if (typeof Cookies.get (epsilon.cookiePrefix + "CookiesAlert") === "undefined") {
            $("#skin_toastCookiesAlert").toast ("show");
        }
    }

    $(function () {
        initBootstrapTooltips ();
        initBootstrapPopovers ();

        setupFeedbackModule ();

        if (! epsilon.inPopup) {
            initBootstrapToasts ();
            emptyLayoutRows ();
            initUpButton (320, 500);
            initCustomContent ();
            initSearch ();
            initClipboard ();
            initTags ();
            initMainMenu ();
            initBreadcrumb ();
            initFeedbackButton ();
            alterLanguage ();
            alterLogin ();
            showToasts ();
            window.skinA11y = new A11y ().init ();
        }
    });

}) (jQuery, window, document);
