//
//  PageInfo.ascx.cs
//
//  Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2015-2017 Roman M. Yagodin
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

using DotNetNuke.Common;
using DotNetNuke.Entities.Portals;
using R7.Epsilon.Models;

namespace R7.Epsilon.Skins.SkinObjects
{
    public class PageInfo : EpsilonSkinObjectBase
    {
        protected string PublishedOnDate
        {
            get
            {
                var activeTab = PortalSettings.ActiveTab;
                return ModelHelper.PublishedOnDate (activeTab.CreatedOnDate, activeTab.StartDate)
                    .ToString (Localizer.SafeGetString ("PublishedOnDate.Format", "MM/dd/yyyy")); 
            }
        }

        protected string PublishedByUserName
        {
            get
            {
                var activeTab = PortalSettings.ActiveTab;
                var user = activeTab.CreatedByUser (PortalSettings.PortalId);
                return (user != null)? user.DisplayName : Localizer.SafeGetString ("SystemUser.Text", "System");
            }
        }

        /// <summary>
        /// Gets page permalink
        /// </summary>
        /// <value>The page permalink.</value>
        protected string PagePermalink {
            get {
                return Globals.AddHTTP (PortalSettings.Current.PortalAlias.HTTPAlias +
                    string.Format (Localizer.SafeGetString ("Permalink.Format", "/Default.aspx?TabId={0}"),
                    PortalSettings.ActiveTab.TabID));
            }
        }
    }
}
