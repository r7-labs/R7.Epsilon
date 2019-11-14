//
//  File: A11yHelper.cs
//  Project: R7.Epsilon
//
//  Author: Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2016-2019 Roman M. Yagodin, R7.Labs
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Affero General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Affero General Public License for more details.
//
//  You should have received a copy of the GNU Affero General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace R7.Epsilon.Components
{
    public static class A11yHelper
    {
        public static string GetThemeCookie (HttpRequest request)
        {
            return request.Cookies [Const.COOKIE_PREFIX + "Theme"]?.Value;
        }

        public static void SetThemeCookie (HttpResponse response, string value)
        {
            response.Cookies [Const.COOKIE_PREFIX + "Theme"].Value = value;
            response.Cookies [Const.COOKIE_PREFIX + "Theme"].Expires = DateTime.Now.AddDays (1d);
        }

        public static void SetFontSizeCookie (HttpResponse response, int value)
        {
            response.Cookies [Const.COOKIE_PREFIX + "FontSize"].Value = value.ToString ();
            response.Cookies [Const.COOKIE_PREFIX + "FontSize"].HttpOnly = false;
            response.Cookies [Const.COOKIE_PREFIX + "FontSize"].Expires = DateTime.Now.AddDays (1d);
        }

        public static void SetDisablePopupsCookie (HttpResponse response, bool value)
        {
            response.Cookies [Const.COOKIE_PREFIX + "DisablePopups"].Value = value.ToString ().ToLowerInvariant ();
            response.Cookies [Const.COOKIE_PREFIX + "DisablePopups"].HttpOnly = false;
            response.Cookies [Const.COOKIE_PREFIX + "DisablePopups"].Expires = DateTime.Now.AddDays (1d);
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

        public static void ResetA11yCookies (HttpResponse response, IEnumerable<ThemeConfig> themes)
        {
            var defaultTheme = themes.FirstOrDefault ();
            if (defaultTheme != null) {
                SetThemeCookie (response, defaultTheme.Name);
            }

            SetFontSizeCookie (response,16);
            SetDisablePopupsCookie (response, false);
        }
    }
}
