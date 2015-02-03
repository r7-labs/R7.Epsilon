function skin_gtranslate (fromLang) {
    window.open ("http://translate.google.com/translate?hl=en&sl=" + fromLang + "&u=" + encodeURI (document.location));
}

$(function() {
    $(".local-menu a.level0").html ("<span class='sr-only'>Toggle navigation</span>" +
        "<span class='icon-bar'></span>" +
        "<span class='icon-bar'></span>" +
        "<span class='icon-bar'></span>");
});