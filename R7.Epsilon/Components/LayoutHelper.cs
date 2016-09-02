//
//  LayoutHelper.cs
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
using System.Data;
using System.Diagnostics.Contracts;
using System.IO;
using DotNetNuke.Common;
using DotNetNuke.Data;
using DotNetNuke.Entities.Portals;

namespace R7.Epsilon.Components
{
    public static class LayoutHelper
    {
        public static string GetLayoutFileName (string layoutName, int portalId)
        {
            Contract.Requires (!string.IsNullOrEmpty (layoutName));
            Contract.Requires (portalId == Const.HOST_PORTAL_ID || portalId >= 0);

            var mapPath = (portalId == Const.HOST_PORTAL_ID)
                ? Globals.HostMapPath
                : PortalController.Instance.GetPortal (portalId).HomeSystemDirectoryMapPath;

            return Path.Combine (mapPath, Const.LAYOUTS_FOLDER, layoutName + ".xml");
        }

        public static bool IsLayoutInUse (string layoutName, int portalId)
        {
            Contract.Requires (!string.IsNullOrEmpty (layoutName));
            Contract.Requires (portalId == Const.HOST_PORTAL_ID || portalId >= 0);

            const string hostSqlQuery = @"SELECT COUNT (*) FROM {databaseOwner}[{objectQualifier}TabSettings] AS TS
                                    WHERE TS.SettingName LIKE @0 AND TS.SettingValue = @1";

            const string portalSqlQuery = @"SELECT COUNT (*) FROM {databaseOwner}[{objectQualifier}TabSettings] AS TS
                                    INNER JOIN {databaseOwner}[{objectQualifier}Tabs] AS T ON TS.TabID = T.TabID
                                    WHERE T.PortalID = @0 AND TS.SettingName LIKE @1 AND TS.SettingValue = @2";

            using (var db = DataContext.Instance ()) {
                if (portalId == Const.HOST_PORTAL_ID) {
                    return 0 < db.ExecuteScalar<int> (CommandType.Text, hostSqlQuery,
                                                      Const.LAYOUT_TAB_SETTING_NAME_BASE + "%",
                                                      Const.GetSettingValuePrefix (portalId) + layoutName);
                } else {
                    return 0 < db.ExecuteScalar<int> (CommandType.Text, portalSqlQuery, portalId,
                                                      Const.LAYOUT_TAB_SETTING_NAME_BASE + "%",
                                                      Const.GetSettingValuePrefix (portalId) + layoutName);
                }
            }
        }
    }
}
