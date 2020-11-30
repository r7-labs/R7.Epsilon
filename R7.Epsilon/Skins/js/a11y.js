import Cookies from "js-cookie";

export default class A11y {

    get defaultFontSize () { return 16; }

    init () {

        const themeName = this.getTheme ();
        this.setTheme (themeName);

        if (epsilon.enablePopups) {
            if (this.getPopupsDisabled ()) {
                this.disablePopups ();
            }
        }
        else {
            this.disableTooglePopups ();
        }

        this.setFontSize (this.getFontSize ());

        return this;
    }

    setA11yCookie (cookieName, cookieValue) {
        Cookies.set (epsilon.cookiePrefix + cookieName, cookieValue, {expires: 7, hostOnly: false, domain: "." + epsilon.portalAlias});
    }

    getTheme () {
        const themeName = Cookies.get (epsilon.cookiePrefix + "Theme");
        if (typeof themeName !== "undefined") {
            return themeName;
        }
        return epsilon.defaultThemeName;
    }

    setTheme (themeName) {
        const currentThemeName = $("#skinTheme").attr ("data-theme");
        if (currentThemeName !== themeName) {
            $("#skinTheme").attr("data-theme", themeName)
                .attr("href", "/Portals/_default/Skins/R7.Epsilon/css/" + epsilon.themes [themeName].css);
        }
        this.updateThemeButtons (themeName);
        this.updateBodyClass (themeName);
        this.setA11yCookie ("Theme", themeName);
    }

    updateBodyClass (themeName) {
        $("body").removeClass (function (i, className) {
            if (className.startsWith ("theme-")) {
                return className;
            }
        }).addClass ("theme-" + themeName);
    }

    updateThemeButtons (themeName) {
        $(".skin-btn-theme").each (function (i, btn) {
            const btnThemeName = $(btn).data ("theme");
            if (btnThemeName === themeName) {
                $(btn).addClass ("active disabled");
            }
            else {
                $(btn).removeClass ("active disabled");
            }
        });
    }

    btnThemeClick (target) {
        const themeName = $(target).data ("theme");
        this.setTheme (themeName);
    }

    getFontSize () {
        const fontSize = Cookies.get (epsilon.cookiePrefix + "FontSize");
        if (typeof fontSize !== "undefined") {
            const fontSizeInt = parseInt (fontSize);
            if (fontSizeInt >= 2 || fontSizeInt <= 64) {
                return fontSizeInt;
            }
        }
        return this.defaultFontSize;
    }

    setFontSize (fontSize) {
        document.documentElement.style = "font-size:" + fontSize + "px;";
        this.setA11yCookie ("FontSize", fontSize);
    }

    increaseFontSize () {
        this.setFontSize (this.getFontSize () + 2);
    }

    decreaseFontSize () {
        this.setFontSize (this.getFontSize () - 2);
    }

    getPopupsDisabled () {
        return Cookies.get (epsilon.cookiePrefix + "DisablePopups") === "true";
    }

    disablePopups () {
        // TODO: Also disable popups for feedback button

        // replace all popup links with simple ones
        $("a[href^='javascript:dnnModal']").each (function () {
            const url = $(this).attr ("href");
            const urlEnd = url.indexOf ("?popUp=");
            const urlStart = url.indexOf ("http://");
            if (urlStart >= 0 && urlEnd >= 0) {
                $(this).data ("popupHref", url)
                    .attr ("href", url.substring (urlStart, urlEnd))
                    .addClass ("popup-href-link");
            }
        });

        // disable onclick handlers from login/register links
        $("a[id$='_loginLink'], a[id$='_enhancedLoginLink'], a[id$='_enhancedRegisterLink']").filter("[onclick]").each (function () {
            const onclick = $(this).attr ("onclick");
            // check if onclick handler is not disabled via custom auth provider
            if (onclick !== "this.disabled=true;") {
                $(this).data ("popupOnClick", onclick)
                    .attr ("onclick", "this.disabled=true;")
                    .addClass ("popup-onclick-link");
            }
        });

        $("#lnkDisablePopups").addClass ("d-none");
        $("#lnkReEnablePopups").removeClass ("d-none");

        this.setA11yCookie ("DisablePopups", true);
    }

    disableTooglePopups () {
        $("#lnkDisablePopups").addClass ("d-none")
            .prev ("div.dropdown-divider").addClass ("d-none");
        $("#lnkReEnablePopups").addClass ("d-none");
    }

    reEnablePopups () {
        $("a.popup-href-link").each (function () {
            $(this).attr ("href", $(this).data ("popupHref")).removeData ("popupHref");
        });
        $("a.popup-onclick-link").each (function () {
            $(this).attr ("onclick", $(this).data ("popupOnClick")).removeData ("popupOnClick");
        });

        $("#lnkDisablePopups").removeClass ("d-none");
        $("#lnkReEnablePopups").addClass ("d-none");

        this.setA11yCookie ("DisablePopups", false);
    }

    restoreDefaults () {
        this.setFontSize (this.defaultFontSize);
        this.setTheme (epsilon.defaultThemeName);
        this.reEnablePopups ();
    }
};
