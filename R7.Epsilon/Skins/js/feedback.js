(function ($, window, document) {

    function getLocationOrigin (location) {
        return (!!location.origin) 
            ? location.origin
            : location.protocol + "//" + location.hostname + (location.port ? ":" + location.port: "");
    }

    function setupFeedbackModule () {
        if (!!epsilon.queryParams ["feedbackmid"]) {
            var feedbackContent = "";
            if (!!epsilon.queryParams ["returntabid"]) {
                feedbackContent += epsilon.localization ["feedbackPageTemplate"]
                    .replace (/\{origin\}/, getLocationOrigin (window.location))
                    .replace (/\{page\}/, epsilon.queryParams ["returntabid"]);

                if (!!epsilon.queryParams ["feedbackselection"]) {
                    feedbackContent += epsilon.localization ["feedbackSelectionTemplate"].replace (/\{selection\}/, epsilon.queryParams ["feedbackselection"]);
                }

                var moduleSelector = "#dnn_ctr" + epsilon.queryParams ["feedbackmid"] + "_ContentPane";
                $(moduleSelector + " textarea").first ()
                    .val (epsilon.localization ["feedbackTemplate"].replace (/\{content\}/, feedbackContent))
                    .trigger ("change").trigger ("keyup");
            }
        }
    }

    $(function () {
        setupFeedbackModule ();
    });

}) (jQuery, window, document);
