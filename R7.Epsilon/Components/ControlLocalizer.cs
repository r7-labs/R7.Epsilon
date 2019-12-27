//
//  File: ControlLocalizer.cs
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

using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.UI;
using DotNetNuke.Services.Localization;
using DotNetNuke.UI.Skins;

namespace R7.Epsilon.Components
{
    public class ControlLocalizer
    {
        #region Properties

        public string LocalResourceFile { get; protected set; }

        #endregion

        public ControlLocalizer (TemplateControl control)
        {
            var resourceFile = Localization.GetResourceFile (control, Path.GetFileName (control.AppRelativeVirtualPath));

            // skinobjects must use resources from parent (skins) directory
            if (control is SkinObjectBase) {
                resourceFile = resourceFile.Replace ("/SkinObjects", string.Empty).Replace ("/Blocks", string.Empty);
            }
            // skin files can be located in Portals/X-System/Skins or Portals/X/Skins, but must use resources from Portals/_default/Skins
            else if (resourceFile.IndexOf ("/_default/", StringComparison.InvariantCultureIgnoreCase) < 0) {
                if (resourceFile.IndexOf ("-System/", StringComparison.InvariantCultureIgnoreCase) >= 0) {
                    resourceFile = Regex.Replace (resourceFile, @"/Portals/\d+-System/", "/Portals/_default/", RegexOptions.IgnoreCase);
                }
                else {
                    resourceFile = Regex.Replace (resourceFile, @"/Portals/\d+/", "/Portals/_default/", RegexOptions.IgnoreCase);
                }
            }

            LocalResourceFile = resourceFile;
        }

        #region Public methods

        public string GetString (string key)
        {
            return Localization.GetString (key, LocalResourceFile);
        }

        public string GetStringOrDefault (string key, string defaultValue)
        {
            var localizedValue = GetString (key);

            return !string.IsNullOrWhiteSpace (localizedValue) ? localizedValue : defaultValue;
        }

        public string GetStringOrKey (string key)
        {
            var localizedValue = GetString (key);

            return !string.IsNullOrWhiteSpace (localizedValue) ? localizedValue : key;
        }

        #endregion
    }
}
