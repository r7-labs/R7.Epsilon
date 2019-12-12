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

// TODO: Move global functions to eplilon object

window.skinGoogleTranslatePage = function (fromLang) {
    window.open ("http://translate.google.com/translate?hl=en&sl=" + fromLang + "&u=" + encodeURI (document.location));
};

window.skinOpenFeedback = function (e, button, $, feedbackModuleId) {
    e.preventDefault ();
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

window.skinSearchExternalClick = function (e, link) {
    const searchText = $("input[id$='_dnnSearch_txtSearch']").val ();
    const urlFormat = $(link).data ("url-format");
    $(link).attr ("href", urlFormat.replace ("{website}", encodeURIComponent (epsilon.portalAlias)).replace ("{searchText}", encodeURIComponent (searchText)));
};

(function ($, window, document) {

    function initUpButton (offset, duration) {
        $(window).scroll(function() {
            if ($(this).scrollTop() > offset) {
                $('.skn-float-btn-up').fadeIn(duration);
            } else {
                $('.skn-float-btn-up').fadeOut(duration);
            }
        });

        $('.skn-float-btn-up').on ("click.epsilon", function (e) {
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
        $(".skn-languages .language-object a").each (function () {
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

    function alterLogin () {
        $(".skn-login li.userDisplayName > a").addClass ("dropdown-item");
        $(".skn-login div.loginGroup > a").addClass ("dropdown-item");
        $(".skn-login li.userMessages > a").addClass ("dropdown-item");
        $(".skn-login li.userNotifications > a").addClass ("dropdown-item");
        $(".skn-login li.userProfileImg > a").addClass ("dropdown-item");

        const loginGroup = $(".skn-login .loginGroup").first ().detach ();
        const divider = "<li class='dropdown-divider'></li>";

        const profileImg = $(".skn-login li.userProfileImg > a > img");
        if (profileImg.length > 0) {
            profileImg.attr ("src", profileImg.attr ("src").replace ("h=32&w=32", "h=64&w=64"));

            const profileLinkBlock = $(".skn-login li.userDisplayName").first ().detach ();
            const profileImgBlock = $(".skn-login li.userProfileImg").first ().detach ();

            $(".skn-login ul.buttonGroup")
                .prepend (divider)
                .prepend (profileLinkBlock)
                .prepend (profileImgBlock)
                .append (divider)
                .append (loginGroup.children ("a").prepend ("<i class='fas fa-lock'></i> "));

                $(".skn-login li.userMessages > a > span").addClass ("badge badge-primary");
                $(".skn-login li.userNotifications > a > span").addClass ("badge badge-secondary");
        }
        else {
            $(".skn-login ul.buttonGroup")
                .append (divider)
                .append (loginGroup.children ("a").prepend ("<i class='fas fa-unlock-alt'></i> "));
        }
    }

    function initCustomContent () {
        // TODO: Also check for superusers and admins
        if (epsilon.isEditMode) {
            $(".skn-custom-content").each (function () {
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
        $(".skn-tags ul.categories > li > a").addClass ("badge badge-secondary");
    }

    function initMainMenu () {
        $(".skn-main-menu .collapse-toggle").on ("click.epsilon", function (e) {
            $(this).toggleClass ("show").next (".collapse").collapse ("toggle");
            e.stopPropagation ();
            e.preventDefault ();
        });
        // hide collapses when parent dropdown hides
        $(".skn-main-menu .dropdown").on("hidden.bs.dropdown", function (e) {
            $(this).find (".collapse-toggle").removeClass ("show").next (".collapse").collapse ("hide");
        });

        // TODO: How this will work with event namespaces?
        $(".skn-main-menu .skn-submenu.collapse")
            .on ("shown.bs.collapse", function (e) {
                const parentMenuItem = $(".skn-main-menu .dropdown-toggle[href='#" + $(this).attr ("id") + "']");
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
                const parentMenuItem = $(".skn-main-menu .dropdown-toggle[href='#" + $(this).attr ("id") + "']");
                const firstMenuItem = $(this).find (".nav-link").first ();
                const lastMenuItem = $(this).find (".nav-link").last ();
                parentMenuItem.off ("keydown.epsilon");
                firstMenuItem.off ("keydown.epsilon");
                lastMenuItem.off ("keydown.epsilon");
            });
    }

    function initBreadcrumb () {
        $(".skn-breadcrumb-menu .collapse-toggle").on ("click.epsilon", function (e) {
            $(this).toggleClass ("show").next (".collapse").collapse ("toggle");
            e.stopPropagation ();
            e.preventDefault ();
        });
        // hide collapses when parent dropdown hides
        $(".skn-breadcrumb-menu .dropdown").on("hidden.bs.dropdown", function (e) {
            $(this).find (".collapse-toggle").removeClass ("show").next (".collapse").collapse ("hide");
        });
    }

    $(function () {
        initBootstrapTooltips ();
        initBootstrapPopovers ();

        if (! epsilon.inPopup) {
            emptyLayoutRows ();
            initUpButton (320, 500);
            initCustomContent ();
            initSearch ();
            initClipboard ();
            initTags ();
            initMainMenu ();
            initBreadcrumb ();
            alterLanguage ();
            alterLogin ();
            window.skinA11y = new A11y ().init ();
        }
    });

}) (jQuery, window, document);
