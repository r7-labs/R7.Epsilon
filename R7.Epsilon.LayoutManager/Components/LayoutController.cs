//
// LayoutController.cs
//
// Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
// Copyright (c) 2016 Roman M. Yagodin
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using DotNetNuke.Common;
using DotNetNuke.Data;
using DotNetNuke.Entities.Portals;
using R7.Epsilon.LayoutManager.Models;

namespace R7.Epsilon.LayoutManager.Components
{
    public static class LayoutController
    {
        public static string GetLayoutFileName (string layoutName, int portalId)
        {
            Contract.Requires (!string.IsNullOrEmpty (layoutName));
            Contract.Requires (portalId == Const.HOST_PORTAL_ID || portalId >= 0);

            var mapPath = (portalId == Const.HOST_PORTAL_ID)
                ? Globals.HostMapPath 
                : PortalController.Instance.GetPortal (portalId).HomeSystemDirectoryMapPath;

            return Path.Combine (mapPath, "Skins", "R7.Epsilon", "Layouts", layoutName + ".xml");
        }

        public static bool IsLayoutInUse (string layoutName, int portalId)
        {
            Contract.Requires (!string.IsNullOrEmpty (layoutName));
            Contract.Requires (portalId == Const.HOST_PORTAL_ID || portalId >= 0);

            using (var db = DataContext.Instance ()) {
                var sqlQuery = @"SELECT COUNT (*) FROM {databaseOwner}[{objectQualifier}TabSettings] AS TS
                    INNER JOIN {databaseOwner}[{objectQualifier}Tabs] AS T ON TS.TabID = T.TabID
                    WHERE T.PortalID = @0 AND TS.SettingName LIKE @1 AND TS.SettingValue = @2";

                return 0 < db.ExecuteScalar<int> (CommandType.Text, sqlQuery, 
                                                  portalId, Const.LAYOUT_TAB_SETTING_NAME_BASE + "%", layoutName);
            }
        }

        public static IEnumerable<LayoutInfo> GetPortalLayouts (int portalId)
        {
            Contract.Requires (portalId == Const.HOST_PORTAL_ID || portalId >= 0);
            Contract.Ensures (Contract.Result<IEnumerable<LayoutInfo>> () != null);

            var mapPath = (portalId != Const.HOST_PORTAL_ID)
              ? PortalController.Instance.GetPortal (portalId).HomeSystemDirectoryMapPath
              : Globals.HostMapPath;

            var layoutDirectory = Path.Combine (mapPath, "Skins", "R7.Epsilon", "Layouts");
            if (Directory.Exists (layoutDirectory)) {
                var layoutFiles = Directory.GetFiles (layoutDirectory, "*.xml");
                if (layoutFiles != null) {
                    return layoutFiles.Select (lf => new LayoutInfo (lf, portalId));
                }
            }

            return Enumerable.Empty<LayoutInfo> ();
        }

        /// <summary>
        /// Gets all available layouts for portal, including host layouts not overriden on portal level
        /// </summary>
        /// <returns>The layouts.</returns>
        /// <param name="portalId">Portal identifier.</param>
        public static IEnumerable<LayoutInfo> GetLayouts (int portalId)
        {
            Contract.Requires (portalId >= 0);
            
            var hostLayouts = GetPortalLayouts (Const.HOST_PORTAL_ID);
            var portalLayouts = GetPortalLayouts (portalId);

            var layouts = new List<LayoutInfo> ();
            var layoutComparer = new LayoutEqualityComparer ();

            // add host layouts, if no overriding portal layouts exists
            foreach (var hostLayout in hostLayouts) {
                if (null == portalLayouts.FirstOrDefault (pl => layoutComparer.Equals (pl, hostLayout))) {
                    layouts.Add (hostLayout);
                }
            }

            // add all portal layouts
            layouts.AddRange (portalLayouts);

            return layouts;
        }
    }
}
