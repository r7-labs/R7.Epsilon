//
//  ControlLocalizer.cs
//
//  Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2015-2016 Roman M. Yagodin
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

using System.IO;
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
            LocalResourceFile = Localization.GetResourceFile (control, Path.GetFileName (control.AppRelativeVirtualPath));

            // skinobjects must use resources from parent (skins) directory
            if (control is SkinObjectBase) {
                LocalResourceFile = LocalResourceFile.Replace ("/SkinObjects", string.Empty).Replace ("/Blocks", string.Empty);
            }
        }

        #region Public methods

        public string GetString (string key)
        {
            return Localization.GetString (key, LocalResourceFile);
        }

        // TODO: Remove as unused?
        public string GetString (string key, string defaultKey)
        {
            var localizedValue = GetString (key);

            return !string.IsNullOrWhiteSpace (localizedValue) ? localizedValue : GetString(defaultKey);
        }

        public string SafeGetString (string key, string defaultValue)
        {
            var localizedValue = GetString (key);

            return !string.IsNullOrWhiteSpace (localizedValue) ? localizedValue : defaultValue;
        }

        #endregion
    }
}
