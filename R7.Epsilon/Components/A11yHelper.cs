//
//  A11yHelper.cs
//
//  Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2016 Roman M. Yagodin
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
using System.Web;

namespace R7.Epsilon.Components
{
    public static class A11yHelper
    {
        public static bool? TryGetA11yParam (HttpRequest request)
        {
            // try to get a11y mode from querystring
            var a11yParamStr = request.QueryString ["a11y"];
            if (!string.IsNullOrWhiteSpace (a11yParamStr)) {
                bool a11yParam;
                if (bool.TryParse (a11yParamStr, out a11yParam)) {
                    return a11yParam;
                }
            }

            return null;
        }

        public static bool? TryGetA11yCookie (HttpRequest request)
        {
            // try to get a11y mode from cookie
            var cookie = request.Cookies ["a11y"];
            if (cookie != null) {
                bool a11yCookie;
                if (bool.TryParse (cookie.Value, out a11yCookie)) {
                    return a11yCookie;
                }
            }

            return null;
        }

        public static bool GetA11y (HttpRequest request)
        {
            // try to get a11y mode from querystring
            var a11y = TryGetA11yParam (request);
            if (a11y != null) {
                return a11y.Value;
            }

            // no a11y was found in the querystring, try to get cookie value
            a11y = TryGetA11yCookie (request);
            if (a11y != null) {
                return a11y.Value;
            }

            return false;
        }

        public static void SetA11yCookie (HttpResponse response, bool value)
        {
            response.Cookies ["a11y"].Value = value.ToString ();
            response.Cookies ["a11y"].Expires = DateTime.Now.AddDays (1d);
        }
    }
}
