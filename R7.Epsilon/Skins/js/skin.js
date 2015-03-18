function skin_gtranslate (fromLang) {
    window.open ("http://translate.google.com/translate?hl=en&sl=" + fromLang + "&u=" + encodeURI (document.location));
}

$(function() {
    // override !important 
    $(".searchInputContainer").attr ("style", "display:inline!important");

    // "Bootstrapify" search
    $("#dnn_dnnSearch_ClassicSearch").addClass ("input-group");
    $("#dnn_dnnSearch_txtSearch").removeClass ("NormalTextBox").addClass("form-control");
    $("#dnn_dnnSearch_cmdSearch").addClass ("btn btn-success").wrap ("<span class='input-group-btn'></span>");
});

$(function() {
    var localMenu = $(".skin-local-menu").first ();
    if (localMenu.find (".sub").length > 0)
    {
        localMenu.find ("a.level0").click (function (event) {
            event.preventDefault (); 
        });
    }
    else
        localMenu.hide ();
});

// Up Button
$(function() {
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
    })
});

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

// Feedback Button
function skin_feedback_button (obj, feedbackTabId, activeTabId) {
    $(obj).attr ("href", "/Default.aspx?tabid=" + feedbackTabId + "&errortabid=" + activeTabId);
    var errorContext = encodeURIComponent (rangy.getSelection ().toString ().replace (/(\n|\r)/gm," ").replace (/\s+/g, " ").replace (/\"/g, "").trim ().substring (0,100));
    if (!!errorContext)
        $(obj).attr ("href",  $(obj).attr ("href") + "&errorcontext=" + errorContext);
    return true;
}

// init tooltips
$(function () {
  $('[data-toggle="tooltip"]').tooltip()
})