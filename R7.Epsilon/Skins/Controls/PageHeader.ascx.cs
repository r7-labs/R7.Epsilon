//
//  PageHeader.ascx.cs
//
//  Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2015 Roman M. Yagodin
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
using System.Web.UI;
using DotNetNuke.Entities.Portals;
using System.Web.UI.WebControls;
using System.Web.Security;
using DotNetNuke.UI.WebControls;
using DotNetNuke.Entities.Users;
using R7.Epsilon.Components;

namespace R7.Epsilon
{
    public class PageHeader : EpsilonSkinObjectBase
    {
        // REVIEW: Convert to control attribute?
        // chars to trim, including en and em dashes
        private static char [] trimSeparators = { ' ', '-', '\u2013', '\u2014',  '.', ':', '/', '\\' };

        protected string Title
        {
            get
            {
                // if Title ends with TabName, use Title instead of TabName
                var activeTab = PortalSettings.ActiveTab;
                if (!string.IsNullOrWhiteSpace (activeTab.Title))
                {
                    if (activeTab.Title.EndsWith (activeTab.TabName, StringComparison.CurrentCultureIgnoreCase))
                        return activeTab.Title;
                }

                return activeTab.TabName;
            }
        }

        protected string TagLine
        {
            get
            { 
                // if Title starts with TabName, use varying Title part as tagline,
                // else if Title ends with TabName, return empty string,
                // or use Title as tagline by default.
                var activeTab = PortalSettings.ActiveTab;
                if (!string.IsNullOrWhiteSpace (activeTab.Title))
                {
                    if (activeTab.Title.StartsWith (activeTab.TabName, StringComparison.CurrentCultureIgnoreCase))
                        return activeTab.Title.Substring (activeTab.TabName.Length).TrimStart (trimSeparators);

                    if (activeTab.Title.EndsWith (activeTab.TabName, StringComparison.CurrentCultureIgnoreCase))
                        return string.Empty;

                    return activeTab.Title;
                }
            
                return string.Empty;
            }
        }
    }
}
