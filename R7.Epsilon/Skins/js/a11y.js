$(function() {
    // replace all popup links with simple ones
    $("a[href^='javascript:dnnModal']").each (function () {
        var url = $(this).attr ("href");
        var urlEnd = url.indexOf ("?popUp=");
        var urlStart = url.indexOf ("http");
        if (urlStart >= 0 && urlEnd >= 0) {
            $(this).attr ("href", url.substring (urlStart, urlEnd));
        }
    });
});