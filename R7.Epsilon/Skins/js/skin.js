//
//  skin.js
//
//  Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2015 Roman M. Yagodin
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

function skin_gtranslate (fromLang) {
    window.open ("http://translate.google.com/translate?hl=en&sl=" + fromLang + "&u=" + encodeURI (document.location));
}

$(function() {
    skin_empty_layout_rows ();
    skin_init_search ();
    skin_init_breadcrumb ();
    skin_init_localmenu ();
    skin_init_modulesmenu ();
    skin_init_upbutton ();
    skin_init_tooltips ();
    skin_setup_feedback_module ();
});

function skin_init_breadcrumb () {
    if (epsilon.breadCrumbsRemoveLastLink) {
        var breadcrumb = $(".breadcrumb > span").first ();
        if (breadcrumb)
        {
            // remove link to current page
            breadcrumb.children ("a").last ().remove ();   
        }
    }
}

function skin_init_search () {
    // "Bootstrapify" search
    var search = $(".skin-search > span").first ();
    search.children (".searchInputContainer").attr("style", "display:table-cell !important")
        .children ("input").removeClass ("NormalTextBox").addClass ("form-control");
    search.children ("a").removeClass ("SkinObject").addClass ("btn btn-default");
    search.show ();
}

function skin_init_localmenu () {
    var localMenu = $(".skin-local-menu").first ();
    if (localMenu.find (".sub").length === 0)
    {
        localMenu.addClass ("hidden");
        $('#skin-separator-1').first().addClass('hidden-local');
    }
}

function skin_init_modulesmenu () {
    var li0 = $('.skin-headers-menu li.level0').first();
    li0.append ('<div class="sub"></div>');
    var pageContents = li0.children('div.sub').first();
    var thisH = pageContents.parents('.DnnModule').find('h2,h3,h4').first();
    var menuItems = [];
    $('h2,h3,h4').each(function () {
        if (!$(this).is(thisH)) {
            var title = $(this).text().trim();
            if (title) {
                var anchor = $(this).children('a').attr('name');
                if (!anchor) {
                    anchor = $(this).parents('.DnnModule').find('a').first().attr('name');
                }
                if (anchor) {
                    menuItems.push('<ul><li><a href="#' + anchor + '">' + title + '</a></li><ul>');
                } 
            }
        }
    });
    if (menuItems.length >= 3) {
        pageContents.append(menuItems);
    }
    else {
        $('.skin-headers-menu').first().addClass('hidden');
        $('#skin-separator-1').first().addClass('hidden-headers');
    }
}

// Up Button
function skin_init_upbutton () {
    var offset = 320;
    var duration = 500;
    jQuery(window).scroll(function() {
        if (jQuery(this).scrollTop() > offset) {
            jQuery('.skin-float-button-up').fadeIn(duration);
        } else {
            jQuery('.skin-float-button-up').fadeOut(duration);
        }
    });
    
    jQuery('.skin-float-button-up').click(function(event) {
        event.preventDefault();
        jQuery('html, body').animate({scrollTop: 0}, duration);
        return false;
    });
}

// init tooltips
function skin_init_tooltips () {
  $('[data-toggle="tooltip"]').tooltip();
}

// setup feedback url
function skin_setup_feedback_url (obj, feedbackModuleId) {
    var selection = encodeURIComponent (rangy.getSelection ().toString ().replace (/(\n|\r)/gm," ").replace (/\s+/g, " ").replace (/\"/g, "").trim ().substring (0,100));
    var params = "&returntabid=" + epsilon.queryParams ["TabId"] + "&feedbackmid=" + feedbackModuleId + ((!!selection)? "&feedbackselection=" + selection : "");
    var feedbackUrl = $(obj).attr ("data-feedback-url");
    if (feedbackUrl.includes ("?popUp=")) {
        $(obj).attr ("href", feedbackUrl.replace (/\?popUp=(\w+)/, "?popUp=$1" + params));
    }
    else {
        $(obj).attr ("href", feedbackUrl + params);
    }

    return true;
}

function getLocationOrigin (location) {
    return (!!location.origin) 
        ? location.origin
        : location.protocol + "//" + location.hostname + (location.port ? ":" + location.port: "");
}

function skin_setup_feedback_module () {
    if (!!epsilon.queryParams ["feedbackmid"]) {
        // TODO: Make format strings localizeable
        var feedbackInfo = "\n\n---";
        if (!!epsilon.queryParams ["returntabid"]) {
            feedbackInfo += "\nPage: {origin}/linkclick.aspx?link={page}"
                .replace (/\{origin\}/, getLocationOrigin (window.location))
                .replace (/\{page\}/, epsilon.queryParams ["returntabid"]);

            if (!!epsilon.queryParams ["feedbackselection"]) {
                feedbackInfo += "\nSelection: \"{selection}\"".replace (/\{selection\}/, epsilon.queryParams ["feedbackselection"]);
            }

            $("#dnn_ctr" + epsilon.queryParams ["feedbackmid"] + "_Feedback_txtBody").val (feedbackInfo).trigger ("change").trigger ("keyup");
        }
    }
}

// done with empty layout rows
function skin_empty_layout_rows ()
{
    $('.row').each (function () {
        if ($(this).children ().length ===
            $(this).children ('.DNNEmptyPane').not ('.dnnSortable').length) {
            $(this).addClass ('hidden');
        }
    });
}
