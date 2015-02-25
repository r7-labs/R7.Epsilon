function splitSubMenu(controlId, columns) {
	jQuery("ul#" + controlId + " div.sub").each(function (i) {
		var items = jQuery(this).find('ul');
		var blockCount = columns;
		for (var i = 0; i < items.length; i += blockCount) {
			var slice = items.slice(i, i + blockCount);
			slice.wrapAll("<div class=\"megarow\"></div>");
		}
	});
}

jQuery(document).ready(function () {

	// calculate height of top level menu and set top style for menu placement
	jQuery('ul.megamenu li .sub').css('top', jQuery('ul.megamenu > li').height());

	// set hover class to parent item
	jQuery('li.level0 div').mouseover(function () {
		jQuery(this).closest('li.level0').find('a.level0').addClass("megahover")
	}).mouseout(function () {
	    jQuery(this).closest('li.level0').find('a.level0').removeClass("megahover")
	});

	function megaHoverOver() {
		jQuery(this).find(".sub").stop().fadeTo('slow', 1).show();

		// calculate width of all ul's
		(function (jQuery) {
			jQuery.fn.calcSubWidth = function () {
				rowWidth = 0;
				// calculate row
				$(this).find("ul").each(function () {
					rowWidth += $(this).width();
				});
			};
		})(jQuery);

		if (jQuery(this).find(".megarow").length > 0) { 
            // if row exists...
			var biggestRow = 0;
			// calculate each row
			jQuery(this).find(".row").each(function () {
				jQuery(this).calcSubWidth();
				// find biggest row
				if (rowWidth > biggestRow) {
					biggestRow = rowWidth;
				}
			});
			// set width
			jQuery(this).find(".sub").css({ 'width': biggestRow });
			jQuery(this).find(".megarow:last").css({ 'margin': '0' });
		} 
        else { 
            // if row does not exist...
			jQuery(this).calcSubWidth();
			// set width
			jQuery(this).find(".sub").css({ 'width': rowWidth });
		}
	}

	function megaHoverOut() {
		jQuery(this).find(".sub").stop().fadeTo('slow', 0, function () {
			jQuery(this).hide();
		});
	}
    
	var config = {
		sensitivity: 2, // number = sensitivity threshold (must be 1 or higher)    
		interval: 100, // number = milliseconds for onMouseOver polling interval    
		over: megaHoverOver, // function = onMouseOver callback (REQUIRED)    
		timeout: 100, // number = milliseconds delay before onMouseOut    
		out: megaHoverOut // function = onMouseOut callback (REQUIRED)    
	};

	jQuery("ul.megamenu li .sub").css({ 'opacity': '0' });
	jQuery("ul.megamenu li").hoverIntent(config);
});
