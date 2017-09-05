(function ($, window, document) {

    function initTooltips () {
        if (typeof ($.fn.tooltip) !== "undefined") {
            $('[data-toggle="tooltip"]').tooltip();
        }
    }

    function initPopovers () {
        if (typeof ($.fn.popover) !== "undefined") {
            $('[data-toggle="popover"]').popover();
        }
    }

    $(function () {
        initTooltips ();
        initPopovers ();
    });

}) (jQuery, window, document);
