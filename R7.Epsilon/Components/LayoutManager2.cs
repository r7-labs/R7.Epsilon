//
//  LayoutManager2.cs
//
//  Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2016 Roman M. Yagodin
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Concurrent;
using R7.Epsilon.Components;
using System.IO;
using DotNetNuke.Common;
using DotNetNuke.Entities.Portals;

namespace R7.Epsilon.Components
{
    public static class LayoutManager2
    {
        private static ConcurrentDictionary<string,Lazy<Layout>> layouts = 
            new ConcurrentDictionary<string,Lazy<Layout>> ();

        public static Layout GetLayout (int portalId, string layoutName)
        {
            return layouts.GetOrAdd (portalId + ":" + layoutName, key => 
                new Lazy<Layout> (() => GetLayoutByKey (key))
            ).Value;
        }

        const string layoutsFolder = "Skins\\R7.Epsilon\\Layouts\\";

        private static Layout GetLayoutByKey (string key) 
        {
            var keyParts = key.Split (new [] {':'}, StringSplitOptions.RemoveEmptyEntries);
            var portalId = int.Parse (keyParts [0]);
            var layoutName = keyParts [1];

            var portalHomeDirectory = PortalController.Instance.GetPortal (portalId).HomeSystemDirectoryMapPath;
            var portalLayoutFile = Path.Combine (portalHomeDirectory, layoutsFolder, layoutName + ".xml");
            var hostLayoutFile = Path.Combine (Globals.HostMapPath, layoutsFolder, layoutName + ".xml");

            string layoutFile = null;
            if (File.Exists (portalLayoutFile)) {
                layoutFile = portalLayoutFile;
            }
            else if (File.Exists (hostLayoutFile)) {
                layoutFile = hostLayoutFile;
            }

            if (layoutFile != null) {
                try {
                    return MarkupParser.ParseLayout (File.ReadAllText (layoutFile));
                }
                catch (Exception ex) {
                    // TODO: Log layout loading error
                    throw new Exception (string.Format ("Cannot find layout file \"{0}.xml\"", Path.GetFileNameWithoutExtension (layoutFile)), ex);
                }
            }

            return null;
        }

        public static void Reset ()
        {
            layouts = new ConcurrentDictionary<string,Lazy<Layout>> ();
        }
    }
}

