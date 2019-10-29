//
//  File: PageInfo.ascx.cs
//  Project: R7.Epsilon
//
//  Author: Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2015-2019 Roman M. Yagodin, R7.Labs
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

using System.Linq;
using DotNetNuke.Common;
using DotNetNuke.Entities.Content;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Portals;

namespace R7.Epsilon.Skins.SkinObjects
{
    public class PageInfo : EpsilonSkinObjectBase
    {
        readonly ContentItem lastModifiedContentItem;

        public PageInfo ()
        {
            lastModifiedContentItem = GetLastModifiedContentItem (PortalSettings.ActiveTab.TabID);
        }

        protected ContentItem GetLastModifiedContentItem (int tabId)
        {
            var contentController = new ContentController ();
            var contentItems = contentController.GetContentItemsByTabId (tabId);
            foreach (var module in ModuleController.Instance.GetTabModules (tabId)) {
                contentItems.Concat (contentController.GetContentItemsByModuleId (module.Value.ModuleID));
            }

            return contentItems.OrderByDescending (ci => ci.LastModifiedOnDate).FirstOrDefault ();
        }

        protected string FullUrl (string url)
        {
            return Globals.AddHTTP (PortalSettings.Current.PortalAlias.HTTPAlias + url);
        }
        protected string LastContentModifiedOnDate {
            get {
                return SafeGetLastModifiedContentItem ().LastModifiedOnDate.ToString (Localizer.SafeGetString ("PublishedOnDate.Format", "MM/dd/yyyy"));
            }
        }

        protected string LastContentModifiedByUserName {
            get {
                var user = SafeGetLastModifiedContentItem ().LastModifiedByUser (PortalSettings.PortalId);
                return (user != null) ? user.DisplayName : Localizer.SafeGetString ("SystemUser.Text", "System");
            }
        }

        protected ContentItem SafeGetLastModifiedContentItem ()
        {
            if (lastModifiedContentItem != null) {
                return lastModifiedContentItem;
            }

            // should be already among content items
            return PortalSettings.ActiveTab;
        }
    }
}
