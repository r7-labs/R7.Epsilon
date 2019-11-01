//
//  File: Permalinks.ascx.cs
//  Project: R7.Epsilon
//
//  Author: Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2019 Roman M. Yagodin, R7.Labs
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

using System.Text.RegularExpressions;
using DotNetNuke.Common;
using DotNetNuke.Entities.Portals;

namespace R7.Epsilon.Skins.SkinObjects
{
    public class Permalinks : EpsilonSkinObjectBase
    {
        // TODO: Test this
        // TODO: Support first args (? instead of &)
        /// <summary>
        /// Replaces "{?arg}" in permalink format strings with the &amp;arg=value in resulting permalink
        /// if current querystring contains this argument
        /// </summary>
        protected string ReplaceOptionalArguments (string url)
        {
            var argFormats = Regex.Matches (url, @"\{\?\w+\}", RegexOptions.IgnoreCase);
            foreach (Match argFormat in argFormats) {
                if (argFormat.Success) {
                    var arg = argFormat.Value.Substring (2, argFormat.Value.Length - 3);
                    if (Request.QueryString [arg] != null) {
                        url = url.Replace (argFormat.Value, "&" + arg + "=" + Request.QueryString [arg].ToString ());
                    }
                    else {
                        url = url.Replace (argFormat.Value, string.Empty);
                    }
                }
            }

            return url;
        }
    }
}
