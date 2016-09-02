//
//  LayoutManager.cs
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
using System.Collections.Concurrent;
using System.IO;
using DotNetNuke.Common;
using DotNetNuke.Entities.Portals;
using R7.Epsilon.Models;

namespace R7.Epsilon.Components
{
    /// <summary>
    /// Holds layouts dictionary.
    /// </summary>
    public static class LayoutManager
    {
        private static ConcurrentDictionary<string, Lazy<Layout>> layouts =
            new ConcurrentDictionary<string, Lazy<Layout>> ();

        public static Layout GetLayout (int portalId, string layoutName)
        {
            return layouts.GetOrAdd (portalId + ":" + layoutName, key =>
                new Lazy<Layout> (() => GetLayoutByKey (key))
            ).Value;
        }

        private static Layout GetLayoutByKey (string key)
        {
            var keyParts = key.Split (new [] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            var portalId = int.Parse (keyParts [0]);
            var layoutName = keyParts [1];

            string layoutFile = null;

            if (portalId == Const.HOST_PORTAL_ID) {
                var hostLayoutFile = Path.Combine (Globals.HostMapPath, Const.LAYOUTS_FOLDER, layoutName + ".xml");
                if (File.Exists (hostLayoutFile)) {
                    layoutFile = hostLayoutFile;
                }
            } 
            else {
                var portalHomeDirectory = PortalController.Instance.GetPortal (portalId).HomeSystemDirectoryMapPath;
                var portalLayoutFile = Path.Combine (portalHomeDirectory, Const.LAYOUTS_FOLDER, layoutName + ".xml");
                if (File.Exists (portalLayoutFile)) {
                    layoutFile = portalLayoutFile;
                }
            }

            if (layoutFile != null) {
                try {
                    return MarkupParser.ParseLayout (File.ReadAllText (layoutFile));
                } catch (Exception ex) {
                    // TODO: Log layout loading error
                    throw new Exception (string.Format ("Cannot find layout file \"{0}.xml\"", Path.GetFileNameWithoutExtension (layoutFile)), ex);
                }
            }

            return null;
        }

        public static void Reset ()
        {
            layouts = new ConcurrentDictionary<string, Lazy<Layout>> ();
        }

        /// <summary>
        /// Removes layout reference from dictionary, so it can be re-added later
        /// </summary>
        /// <param name="portalId">Portal identifier.</param>
        /// <param name="layoutName">Layout name.</param>
        public static void ResetLayout (int portalId, string layoutName)
        {
            Lazy<Layout> removedLayout;
            layouts.TryRemove (portalId + ":" + layoutName, out removedLayout);
        }
    }
}
