$(function() {
    // replace all popup links with simple ones
    $("a[href^='javascript:dnnModal']").each (function () {
        var url = $(this).attr ("href");
        var urlEnd = url.indexOf ("?popUp=");
        var urlStart = url.indexOf ("http://");
        if (urlStart >= 0 && urlEnd >= 0) {
            $(this).attr ("href", url.substring (urlStart, urlEnd));
        }
    });

    // remove onclick handlers from login/register links
    $("a[id$='_loginLink']").prop ("onclick", null).off ("click");
    $("a[id$='_enhancedLoginLink']").prop ("onclick", null).off ("click");
    $("a[id$='_enhancedRegisterLink']").prop ("onclick", null).off ("click");
});