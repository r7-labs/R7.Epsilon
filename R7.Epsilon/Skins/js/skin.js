function skin_gtranslate (fromLang) {
    window.open ("http://translate.google.com/translate?hl=en&sl=" + fromLang + "&u=" + encodeURI (document.location));
}

$(function() {
    $(".skin-local-menu a.level0").html ("<span class='sr-only'>Toggle navigation</span>" +
        "<span class='icon-bar'></span>" +
        "<span class='icon-bar'></span>" +
        "<span class='icon-bar'></span>");
});

// Up button
$(function() {
    var offset = 320;
    var duration = 500;
    jQuery(window).scroll(function() {
        if (jQuery(this).scrollTop() > offset) {
            jQuery('#skin-button-up').fadeIn(duration);
        } else {
            jQuery('#skin-button-up').fadeOut(duration);
        }
    });
    
    jQuery('#skin-button-up').click(function(event) {
        event.preventDefault();
        jQuery('html, body').animate({scrollTop: 0}, duration);
        return false;
    })
});