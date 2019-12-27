//
//  File: EpsilonUrlHelper.cs
//  Project: R7.Zeta
//
//  Author: Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2014-2019 Roman M. Yagodin, R7.Labs
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
using System.Collections.Specialized;
using System.Web;
using System.Text.RegularExpressions;
using DotNetNuke.Common;
using DotNetNuke.Entities.Portals;

namespace R7.Zeta.Components
{
    public static class EpsilonUrlHelper
    {
        public static string FullUrl (string url)
        {
            return Globals.AddHTTP (PortalSettings.Current.PortalAlias.HTTPAlias + url);
        }

        public static string FormatUrl (string url, int tabId,  int portalId)
        {
            return url.Replace ("{tabid}", tabId.ToString ())
                      .Replace ("{portalid}", portalId.ToString ())
                      .Replace ("{taburl}", Globals.NavigateURL ());
        }

        /// <summary>
        /// Replaces "{?arg}" or "{&amp;arg}" in link format strings with the "&amp;arg=value" (or "?arg=value" at the beginning),
        /// replaces "{/arg}" with the "/arg/value" - if current querystring contains this argument
        /// </summary>
        public static string FormatUrlWithOptArgs (string url, NameValueCollection queryString)
        {
            var argFormats = Regex.Matches (url, @"\{[\?&/]\w+\}", RegexOptions.IgnoreCase);
            foreach (Match argFormat in argFormats) {
                if (argFormat.Success) {
                    var arg = argFormat.Value.Substring (2, argFormat.Value.Length - 3);
                    if (queryString [arg] != null) {
                        if (argFormat.Value.IndexOf ("/", StringComparison.InvariantCulture) == 1) {
                            url = url.Replace (argFormat.Value, "/" + arg + "/" + queryString [arg].ToString ());
                        }
                        else {
                            url = url.Replace (argFormat.Value, "&" + arg + "=" + queryString [arg].ToString ());
                        }
                    }
                    else {
                        url = url.Replace (argFormat.Value, string.Empty);
                    }
                }
            }

            if (!url.Contains ("?")) {
                // replace first & with ?
                var ampIndex = url.IndexOf ("&", StringComparison.InvariantCulture);
                if (ampIndex >= 0) {
                    url = url.Substring (0, ampIndex) + "?" + url.Substring (ampIndex + 1);
                }
            }

            return url;
        }

        public static string FormatUrl (string url, int tabId,  int portalId, NameValueCollection queryString)
        {
            url = FormatUrl (url, tabId, portalId);
            if (url.IndexOf ("{") >= 0) {
                url = FormatUrlWithOptArgs (url, queryString);
            }

            return url;
        }

        // TODO: Move to the base library
        /// <summary>
        /// Checks if browser is InternetExplorer
        /// </summary>
        /// <returns><c>true</c>, if browser is InternetExplorer, <c>false</c> otherwise.</returns>
        /// <param name="request">Request.</param>
        public static bool IsIeBrowser (HttpRequest request)
        {
            var browserName = request.Browser.Browser.ToUpperInvariant ();
            if (browserName.StartsWith ("IE", StringComparison.Ordinal)
                || browserName.Contains ("MSIE")
                || browserName == "INTERNETEXPLORER") {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if browser is Edge
        /// </summary>
        /// <returns><c>true</c>, if browser is Edge, <c>false</c> otherwise.</returns>
        /// <param name="request">Request.</param>
        public static bool IsEdgeBrowser (HttpRequest request)
        {
            return request.UserAgent.Contains ("Edge");
        }
    }
}
