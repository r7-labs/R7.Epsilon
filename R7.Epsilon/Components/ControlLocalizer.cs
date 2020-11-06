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

        public string GetStringIfKey (string key)
        {
            if (key.StartsWith ("resx:")) {
                return GetString (key.Substring (5));
            }
            return key;
        }

        #endregion
    }
}
