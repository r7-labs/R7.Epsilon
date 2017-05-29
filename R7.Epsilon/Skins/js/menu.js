//
//  menu.js
//
//  Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2015-2017 Roman M. Yagodin
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

function skinSplitSubMenu($, controlId, columns) {
	$("ul#" + controlId + " .sub").each(function (i) {
		var items = $(this).find('ul');
		var blockCount = columns;
		for (var i = 0; i < items.length; i += blockCount) {
			var slice = items.slice(i, i + blockCount);
			slice.wrapAll("<div class=\"megarow\"></div>");
		}
	});
}

(function ($, window, document) {

    // called by hoverIntent and on top level menu links focus
    function megaHoverOver() {

        var sub = $(this).children (".sub");

        // show only if not showed
        if (sub.length !== 0 && sub.not (':visible')) {
            sub.stop ().fadeTo ('fast', 1).show ()
                .prev ("a").addClass ("megahover").focus ();
        }

        // hide other submenus - in all menus!
        // $(this).parents ("ul.megamenu") - only this menu
        $("ul.megamenu").find ('.sub').each (function () {
            if (!sub.is (this)) {
                $(this).stop ().css ("opacity", 0).hide ()
                    .prev ("a").removeClass ("megahover");
            }
        });
    }

    // called by hoverIntent
    function megaHoverOut () {
        $(this).children (".sub").stop ().css ("opacity", 0).hide ()
            .prev ("a").removeClass ("megahover");
    }

    function initModulesMenu () {
        var li0 = $('.skin-headers-menu li.level0').first();
        var thisH = li0.parents('.DnnModule').find('h2,h3,h4').first();
        var menuItems = "";
        var menuItemsCount = 0;
        $('h2,h3,h4').each(function () {
            if (!$(this).is(thisH)) {
                var title = $(this).text().trim();
                if (!!title) {
                    var anchor = $(this).children('a').attr('name');
                    if (!anchor) {
                        anchor = $(this).parents('.DnnModule').find('a').first().attr('name');
                    }
                    if (anchor) {
                        menuItems += '<div class="megarow"><ul><li><a href="#' + anchor + '">' + title + '</a></li><ul></div>';
                        menuItemsCount++;
                    } 
                }
            }
        });
        if (menuItemsCount >= 3) {
            li0.append ('<div class="sub">'
                + menuItems
                + '<a href="#" role="button" class="sub-close" title="' + epsilon.localization.subMenuCloseButtonTitle + '">&times;</a>'
                + '</div>'
            );
        } else {
            $('.skin-headers-menu').first().addClass('hidden');
            $('#skin-separator-1').first().addClass('hidden-headers');
        }
    }

    function initLocalMenu () {
        var localMenu = $(".skin-local-menu").first ();
        if (localMenu.find (".sub").length === 0) {
            localMenu.addClass ("hidden");
            $('#skin-separator-1').first().addClass('hidden-local');
        }
    }

    function initOpenSubmenuOnFocus () {
        $('li.level0 > a').focus(function () {
            var a = $(this);
            if (!a.hasClass ('megahover')) {
                a.parent ().each (function () { megaHoverOver.call (this); });
            }
        });
    }

    function initCloseButton () {
        $('li.level0 > .sub > a.sub-close').click (function (e) {
            e.preventDefault ();
            $(this).parent ().parent ().each (function () { megaHoverOut.call (this); });
        });
    }

    $(function() {
        initLocalMenu ();
        initModulesMenu ();

        // calculate height of top level menu and set top style for menu placement
        $('ul.megamenu .sub').css('top', $('ul.megamenu > li').height());

        // set hover class to parent item
        // REVIEW: Move to megaHoverOver/Out?
        /*
        $('li.level0 > .sub').mouseover(function () {
            $(this).closest('li.level0 > a').addClass("megahover")
        }).mouseout(function () {
            $(this).closest('li.level0 > a').removeClass("megahover")
        });*/

        initOpenSubmenuOnFocus ();
        initCloseButton ();

        // invoke hoverIntent
        $("ul.megamenu > li.level0").hoverIntent({
            sensitivity: 2, // number = sensitivity threshold (must be 1 or higher)    
            interval: 100, // number = milliseconds for onMouseOver polling interval    
            over: megaHoverOver, // function = onMouseOver callback (REQUIRED)    
            timeout: 500, // number = milliseconds delay before onMouseOut    
            out: megaHoverOut // function = onMouseOut callback (REQUIRED)    
        });

        // mark current tab link
        if (epsilon.breadCrumbs) {
            $("ul.megamenu a").filter (function() {
                return epsilon.breadCrumbs.indexOf (parseInt($(this).attr("data-id"))) !== -1;
            }).addClass ("current");
        }
    });
}) (jQuery, window, document);
