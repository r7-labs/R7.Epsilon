//
//  LayoutController.cs
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

using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using DotNetNuke.Common;
using DotNetNuke.Data;
using DotNetNuke.Entities.Portals;
using R7.Epsilon.Components;
using R7.Epsilon.LayoutManager.Models;

namespace R7.Epsilon.LayoutManager.Components
{
    public static class LayoutController
    {
        public static IEnumerable<LayoutFile> GetPortalLayoutFiles (int portalId)
        {
            Contract.Requires (portalId == Const.HOST_PORTAL_ID || portalId >= 0);
            Contract.Ensures (Contract.Result<IEnumerable<LayoutFile>> () != null);

            var mapPath = (portalId != Const.HOST_PORTAL_ID)
              ? PortalController.Instance.GetPortal (portalId).HomeSystemDirectoryMapPath
              : Globals.HostMapPath;

            var layoutDirectory = Path.Combine (mapPath, Const.LAYOUTS_FOLDER);
            if (Directory.Exists (layoutDirectory)) {
                var layoutFiles = Directory.GetFiles (layoutDirectory, "*.xml");
                if (layoutFiles != null) {
                    return layoutFiles.Select (lf => new LayoutFile (lf, portalId));
                }
            }

            return Enumerable.Empty<LayoutFile> ();
        }

        /// <summary>
        /// Gets all available layouts for portal, including host layouts
        /// </summary>
        /// <returns>The layouts.</returns>
        /// <param name="portalId">Portal identifier.</param>
        public static IEnumerable<LayoutFile> GetLayoutFiles (int portalId)
        {
            Contract.Requires (portalId >= 0);

            return GetPortalLayoutFiles (Const.HOST_PORTAL_ID).Concat (GetPortalLayoutFiles (portalId));
        }
    }
}
