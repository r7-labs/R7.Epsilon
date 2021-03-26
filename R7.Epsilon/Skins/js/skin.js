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
    const feedbackParams = "returntabid=" + epsilon.activeTabId + "&feedbackmid=" + epsilon.feedbackModuleId;
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
    Cookies.set (epsilon.cookiePrefix + "CookiesAlert", true, {expires: 31});
    $(e.target).closest (".toast").toast ("hide");
};

window.skinCookiesDisabledAlertButtonClick = function (e) {
    $(e.target).closest (".toast").toast ("hide");
};

window.skinBrowserAlertButtonClick = function (e) {
    Cookies.set (epsilon.cookiePrefix + "BrowserAlert", true, {expires: 14});
    $(e.target).closest (".toast").toast ("hide");
};

(function ($, window, document) {

    function getLocationOrigin (location) {
        return (!!location.origin)
            ? location.origin
            : location.protocol + "//" + location.hostname + (location.port ? ":" + location.port: "");
    }

    function hidePopoversForOtherFloatButtons (thisBtn) {
        $(".skin-float-btns > [data-toggle='popover']").each (function (i, btn) {
            if ($(btn).attr ("id") !== $(thisBtn).attr ("id")) {
                $(btn).popover ("hide");
            }
        });
    }

    function initFloatButtons () {
        $("#btnSkinFeedback").on ("inserted.bs.popover", function () {
            const thisBtn = this;
            hidePopoversForOtherFloatButtons (thisBtn);
            $("#btnSkinOpenFeedback")
                .attr ("href", skinGetBaseFeedbackUrl ())
                .attr ("target", "_blank")
                .on ("click", function (e) {
                    e.preventDefault ();
                    skinOpenFeedback ();
                    $(thisBtn).popover ("hide");
                });
        });
        $("#btnSkinAgeRating").on ("inserted.bs.popover", function () {
            const thisBtn = this;
            hidePopoversForOtherFloatButtons (thisBtn);
            $("#btnSkinOpenAgeRating").on ("click", function () {
                $(thisBtn).popover ("hide");
            });
        });
    }

    function setupFeedbackModule () {
        if (!!epsilon.queryParams ["feedbackmid"]) {

            var feedbackMessage = epsilon.localization ["feedbackMessageTemplate"];

            if (!!epsilon.queryParams ["returntabid"]) {
                feedbackMessage = feedbackMessage.replace (/\{page\}/, getLocationOrigin (window.location) + "/tabid/" + epsilon.queryParams ["returntabid"]);
            }
            else {
                feedbackMessage = feedbackMessage.replace (/\{page\}/, epsilon.localization ["notSpecified"]);
            }

            if (!!epsilon.queryParams ["feedbackselection"]) {
                feedbackMessage = feedbackMessage.replace (/\{selection\}/, epsilon.queryParams ["feedbackselection"]);
            }
            else {
                feedbackMessage = feedbackMessage.replace (/\{selection\}/, epsilon.localization ["notSpecified"]);
            }

            var moduleSelector = "#dnn_ctr" + epsilon.queryParams ["feedbackmid"] + "_ContentPane";
            $(moduleSelector + " textarea").first ().val (feedbackMessage).trigger ("change").trigger ("keyup");
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

    function emptySpecificTags () {
        $(".language-object").each (function () {
            if ($(this).children ().length === 0) {
                $(this).addClass ("d-none");
            }
        });
        $(".navbar.skin-secondary-menu .navbar-collapse").each (function () {
            if ($(this).children ().length === 0) {
                $(this).parent ().parent ().addClass ("d-none");
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

        const registrationDisabled = $(".skin-login .registerGroup").length === 0;
        if (registrationDisabled) {
            $(".skin-login .dropdown-menu")
                .append ("<div class='registerGroup'><ul class='buttonGroup'></ul></div>");
        }

        const loginGroup = $(".skin-login .loginGroup").first ().detach ();
        const divider = "<li class='dropdown-divider'></li>";
        const buttonGroup = $(".skin-login ul.buttonGroup");

        const profileImg = $(".skin-login li.userProfileImg > a > img");
        if (profileImg.length > 0) {
            profileImg.attr ("src", profileImg.attr ("src").replace ("h=32&w=32", "h=64&w=64"));

            const profileLinkBlock = $(".skin-login li.userDisplayName").first ().detach ();
            const profileImgBlock = $(".skin-login li.userProfileImg").first ().detach ();

            buttonGroup
                .prepend (divider)
                .prepend (profileLinkBlock)
                .prepend (profileImgBlock)
                .append (divider)
                .append (loginGroup.children ("a").prepend ("<i class='fas fa-lock'></i> "));

                $(".skin-login li.userMessages > a > span").addClass ("badge badge-primary");
                $(".skin-login li.userNotifications > a > span").addClass ("badge badge-secondary");
        }
        else {
            if (!registrationDisabled) {
                buttonGroup.append (divider);
            }
            buttonGroup.append (loginGroup.children ("a").prepend ("<i class='fas fa-unlock-alt'></i> "));
        }
    }

    function initCustomContent () {
        if (epsilon.isEditMode && (epsilon.isSuperUser || epsilon.isAdmin)) {
            $(".skin-custom-content").each (function () {
                $(this).prepend ("<div class='actionMenu'><ul class='dnn_mact'>"
                                + "<li class='actionMenuEdit' title='" + $(this).data ("title") + "'><a><i class='fas fa-info'></i></a></li>"
                                + "</ul></div>");
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

    function setActiveMenuItems (activeTabId) {
        $(".skin-menu [data-tabid='" + activeTabId + "']").addClass ("active");
    }

    function tweakEmptyPanes () {
        $(".row").each (function () {
            const emptyPanesCount = $(this).children (".DNNEmptyPane").not (".dnnSortable").length;
            // autoexpand single non-empty pane
            if (emptyPanesCount === 1) {
                $(this).children (".skin-autoexpand-pane").removeClass (function (idx, className) {
                    if (className.startsWith ("col-")) {
                        return className;
                    }}).addClass ("col");
            }
            // hide empty layout rows
            if (emptyPanesCount === $(this).children ().length) {
                $(this).addClass ("d-none");
            }
        });
    }

    $(function () {
        initBootstrapTooltips ();
        initBootstrapPopovers ();

        setupFeedbackModule ();

        if (! epsilon.inPopup) {
            initBootstrapToasts ();
            tweakEmptyPanes ();
            emptySpecificTags ();
            initUpButton (320, 500);
            initCustomContent ();
            initSearch ();
            initClipboard ();
            initTags ();
            initMainMenu ();
            setActiveMenuItems (epsilon.activeTabId);
            initBreadcrumb ();
            initFloatButtons ();
            alterLanguage ();
            alterLogin ();
            showToasts ();
            window.skinA11y = new A11y ().init ();
        }
    });

}) (jQuery, window, document);
