//
//  LayoutManager.cs
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
using System.Collections.Generic;
using System.IO;
using DotNetNuke.Common;
using DotNetNuke.Entities.Portals;
using System.Collections.Concurrent;

namespace R7.Epsilon.Components
{
    public class LayoutCollection: Dictionary<string,Layout>
    {}

    public static class LayoutManager
    {
        private static ConcurrentDictionary<int,Lazy<LayoutCollection>> instance = 
            new ConcurrentDictionary<int,Lazy<LayoutCollection>> ();
        
        public static Layout GetLayout (int portalId, string layoutName)
        {
            var lazyHostLayouts = instance.GetOrAdd (-1, key => 
                new Lazy<LayoutCollection> (() => InitPortalLayoutCollection (null))
            );

            var lazyPortalLayouts = instance.GetOrAdd (portalId, key => 
                new Lazy<LayoutCollection> (() => InitPortalLayoutCollection (PortalController.Instance.GetPortal (key)))
            );

            Layout layout;
            if (!lazyPortalLayouts.Value.TryGetValue (layoutName, out layout)) {
                if (!lazyHostLayouts.Value.TryGetValue (layoutName, out layout)) {
                    return null;
                }
            }

            return layout;
        }

        public static void Reset ()
        {
            instance = new ConcurrentDictionary<int,Lazy<LayoutCollection>> ();
        }

        const string layoutsFolder = "Skins\\R7.Epsilon\\Layouts\\";

        private static LayoutCollection InitPortalLayoutCollection (PortalInfo portal)
        {
            var layoutCollection = new LayoutCollection ();
            var homeDirectory = (portal != null) ? portal.HomeSystemDirectoryMapPath : Globals.HostMapPath;

            var layoutFiles = Directory.GetFiles (Path.Combine (homeDirectory, layoutsFolder), "*.xml");
            foreach (var layoutFile in layoutFiles) {
                if (File.Exists (layoutFile)) {
                    try {
                        var layout = new Layout ();
                        layout.Panes = MarkupParser.ParseLayout (File.ReadAllText (layoutFile));
                        layoutCollection.Add (Path.GetFileNameWithoutExtension (layoutFile), layout);
                    }
                    catch (Exception ex) {
                        // TODO: Log layout loading error
                        throw new Exception (string.Format ("Cannot find layout file \"{0}.xml\"", Path.GetFileNameWithoutExtension (layoutFile)), ex);
                    }
                }
            }

            return layoutCollection;
        }
    }
}

