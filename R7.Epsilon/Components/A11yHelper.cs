using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Entities.Portals;

namespace R7.Epsilon.Components
{
    public static class A11yHelper
    {
        /*
        public static string GetThemeCookie (HttpRequest request)
        {
            return request.Cookies [Const.COOKIE_PREFIX + "Theme"]?.Value;
        }*/

        static void SetCommonCookieOptions (HttpCookie cookie)
        {
            cookie.HttpOnly = false;
            cookie.Domain = PortalSettings.Current.PortalAlias.HTTPAlias;
            cookie.Expires = DateTime.Now.AddDays (7);
        }

        public static void SetThemeCookie (HttpResponse response, string value)
        {
            var cookie = response.Cookies [Const.COOKIE_PREFIX + "Theme"];
            cookie.Value = value;
            SetCommonCookieOptions (cookie);
        }

        public static void SetFontSizeCookie (HttpResponse response, int value)
        {
            var cookie = response.Cookies [Const.COOKIE_PREFIX + "FontSize"];
            cookie.Value = value.ToString ();
            SetCommonCookieOptions (cookie);
        }

        public static void SetDisablePopupsCookie (HttpResponse response, bool value)
        {
            var cookie = response.Cookies [Const.COOKIE_PREFIX + "DisablePopups"];
            cookie.Value = value.ToString ().ToLowerInvariant ();
            SetCommonCookieOptions (cookie);
        }

        public static void SetA11yCookies (HttpResponse response, IEnumerable<ThemeConfig> themes)
        {
            var a11yTheme = themes.FirstOrDefault (t => t.IsA11yTheme);
            if (a11yTheme != null) {
                SetThemeCookie (response, a11yTheme.Name);
            }

            SetFontSizeCookie (response, 24);
            SetDisablePopupsCookie (response, true);
        }

        /*
        public static void ResetA11yCookies (HttpResponse response, IEnumerable<ThemeConfig> themes)
        {
            var defaultTheme = themes.FirstOrDefault ();
            if (defaultTheme != null) {
                SetThemeCookie (response, defaultTheme.Name);
            }

            SetFontSizeCookie (response,16);
            SetDisablePopupsCookie (response, false);
        }*/
    }
}
