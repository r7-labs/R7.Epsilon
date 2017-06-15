//
//  EpsilonUrlHelper.cs
//
//  Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2017 Roman M. Yagodin
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
    public static class EpsilonUrlHelper
    {
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
