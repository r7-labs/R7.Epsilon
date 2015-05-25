function splitSubMenu(controlId, columns) {
	jQuery("ul#" + controlId + " .sub").each(function (i) {
		var items = jQuery(this).find('ul');
		var blockCount = columns;
		for (var i = 0; i < items.length; i += blockCount) {
			var slice = items.slice(i, i + blockCount);
			slice.wrapAll("<div class=\"megarow\"></div>");
		}
	});
}

// called by hoverIntent and on top level menu links focus
function megaHoverOver() {
    var sub = jQuery(this).find(".sub");

    // show only if not showed
    if (sub.not(':visible')) {
        sub.stop().fadeTo('fast', 1).show()
            .prev().addClass("megahover");
    }

    // hide other submenus - in all menus!
    // jQuery(this).parents ("ul.megamenu") - only this menu
    jQuery("ul.megamenu").find('.sub').each (function () {
        if (!sub.is (this)) {
            jQuery(this).stop().css("opacity", 0).hide()
                .prev().removeClass("megahover");
        }
    });
}

// called by hoverIntent
function megaHoverOut() {
    // hide only if not focused
    if (jQuery(this).find(":focus").length === 0) {
        jQuery(this).find(".sub").stop().css("opacity", 0).hide()
            .prev().removeClass("megahover");
    }
}

jQuery(document).ready(function () {

	// calculate height of top level menu and set top style for menu placement
	jQuery('ul.megamenu .sub').css('top', jQuery('ul.megamenu > li').height());

	// set hover class to parent item
    // REVIEW: Move to megaHoverOver/Out?
    /*
	jQuery('li.level0 > .sub').mouseover(function () {
        jQuery(this).closest('li.level0 > a').addClass("megahover")
    }).mouseout(function () {
        jQuery(this).closest('li.level0 > a').removeClass("megahover")
	});*/

    // open submenu by focusing
    jQuery('li.level0 > a').focus(function () {
        jQuery(this).parent().each (function () { megaHoverOver.call(this); });
    });

    // hoverIntent options
    var config = {
		sensitivity: 2, // number = sensitivity threshold (must be 1 or higher)    
		interval: 100, // number = milliseconds for onMouseOver polling interval    
		over: megaHoverOver, // function = onMouseOver callback (REQUIRED)    
		timeout: 100, // number = milliseconds delay before onMouseOut    
		out: megaHoverOut // function = onMouseOut callback (REQUIRED)    
	};

    // invoke hoverIntent
	jQuery("ul.megamenu > li").hoverIntent(config);

    // mark current tab link
    if (epsilon.tabName) {
        jQuery("ul.megamenu li.level0 >  a:contains('" + epsilon.tabName + "')").filter (function() {
            return $(this).text () == epsilon.tabName;
        }).addClass ("current");
    }
});
