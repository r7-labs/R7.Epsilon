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
});

function skin_init_breadcrumb () {
    var breadcrumb = $(".breadcrumb > span").first ();
    var links = breadcrumb.children ("a").length;

    if (links === 1) {
        // hide parent container
        breadcrumb.parent ().parent ().hide ();
    }
    else {
        // remove last link
        breadcrumb.children ("a").last ().remove ();    
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

// Feedback Button
function skin_feedback_button (obj, feedbackTabId, activeTabId) {
    $(obj).attr ("href", "/Default.aspx?tabid=" + feedbackTabId + "&errortabid=" + activeTabId);
    var errorContext = encodeURIComponent (rangy.getSelection ().toString ().replace (/(\n|\r)/gm," ").replace (/\s+/g, " ").replace (/\"/g, "").trim ().substring (0,100));
    if (!!errorContext)
        $(obj).attr ("href",  $(obj).attr ("href") + "&errorcontext=" + errorContext);
    return true;
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

/*
$(function() {
    $("body").mouseup (function(event) {
        if (rangy.getSelection ().toString())
        {
            var duration = 500;
            $(".skin-float-button-feedback").fadeIn(duration);
        }
        else
            $(".skin-float-button-feedback").fadeOut(duration);
    })
});
*/