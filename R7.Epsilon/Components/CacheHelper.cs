//
//  CacheHelper.cs
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
using System.Text;
using System.Web;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;

namespace R7.Epsilon.Components
{
    public static class CacheHelper
    {
        public static string GetVaryByCustomString (HttpContext context, string custom,
                                                    HttpRequest request, 
                                                    Func<HttpContext, string, string> fallbackGetVaryByCustomString)
        {
            var result = new StringBuilder ();
            foreach (var part in custom.Split (';')) {
                if (part == "PortalId") {
                    result.Append ("portalid=");
                    result.Append (PortalSettings.Current.PortalId);
                }
                else if (part == "A11y") {
                    result.Append ("a11y=");
                    result.Append (A11yHelper.GetA11y (request));
                }
                else if (part == "UserRoles") {
                    if (request.IsAuthenticated) {
                        var user = UserController.Instance.GetCurrentUserInfo ();
                        if (user != null) {
                            result.Append ("userroles=");
                            result.Append (Utils.FormatList (",", (Array)user.Roles));
                        }
                    }
                }
                else {
                    result.Append (fallbackGetVaryByCustomString (context, custom));
                }
            }

            return result.ToString ();
        }
    }
}
