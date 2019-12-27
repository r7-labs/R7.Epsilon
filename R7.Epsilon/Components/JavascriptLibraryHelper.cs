using System;
using System.Linq;
using DotNetNuke.Common;
using DotNetNuke.Framework.JavaScriptLibraries;

namespace R7.Zeta.Components
{
    public static class JavascriptLibraryHelper
    {
        /// <summary>
        /// Port the <see cref="DotNetNuke.Framework.JavaScriptLibraries.JavaScript.GetHighestVersionLibrary" /> private method.
        /// </summary>
        public static JavaScriptLibrary GetHighestVersionLibrary (string jsname)
        {
            // if in install process, then do not use JSL but all use the legacy versions.
            if (Globals.Status == Globals.UpgradeStatus.Install) {
                return null;
            }
            try {
                return JavaScriptLibraryController.Instance.GetLibraries (jsl => jsl.LibraryName.Equals (jsname, StringComparison.OrdinalIgnoreCase))
                                                           .OrderByDescending (jsl => jsl.Version)
                                                           .FirstOrDefault();
            }
            catch (Exception) {
                // no library found (install or upgrade)
                return null;
            }
        }
    }
}
