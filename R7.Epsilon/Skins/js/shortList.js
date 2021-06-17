// https://jsfiddle.net/gh4ez0st/3/

(function ($) {
    $.fn.shortList = function () {
        this.each (function () {
            var container = $(this);

            var n = 3;
            var dataShowItems = container.data ("show-items");
            if (typeof (dataShowItems) !== "undefined") {
                n = parseInt (dataShowItems);
            }

            var wasCollapsed = false;
            var nodeName = "";
            container.children ().each (function (i, elem) {
                if ((i + 1) > n) {
                    $(elem).hide ();
                    wasCollapsed = true;
                    nodeName = elem.nodeName;
                }
            });

            if (wasCollapsed) {
                var moreLabel = "show more&hellip;"
                var dataMoreLabel = container.data ("more-label");
                if (typeof (dataMoreLabel) !== "undefined") {
                    moreLabel = dataMoreLabel;
                }

                container.append ("<" + nodeName
                    + " class='sl-collapsed'><a href='#'>" + moreLabel + "</a>"
                    + "</" + nodeName + ">");
                container.children (".sl-collapsed").on ("click", function (e) {
                    e.preventDefault ();
                    container.children ().remove (".sl-collapsed").show ();
                });
            }
        });
        return this;
    };
} (jQuery));
