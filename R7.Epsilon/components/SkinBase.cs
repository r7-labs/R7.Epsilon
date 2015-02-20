using System;
using DotNetNuke.Framework;
using DotNetNuke.Services.Localization;

namespace R7.Epsilon
{
    public class SkinBase : DotNetNuke.UI.Skins.Skin
    {
        protected override void OnLoad(EventArgs e)
        {
            RegisterJavaScript();
        }

        private void RegisterJavaScript()
        {
            jQuery.RequestRegistration();
            //ClientResourceManager.RegisterScript(Page, "/portals/_default/skins/hammerflex/js/jquery.blueimp-gallery.min.js", FileOrder.Js.jQuery, "DnnFormBottomProvider"); // default priority and provider
            //ClientResourceManager.RegisterScript(Page, "/portals/_default/skins/hammerflex/js/bootstrap-image-gallery.min.js", FileOrder.Js.jQuery, "DnnFormBottomProvider"); // default priority and provider           
        }

        #region Localization

        private string localResourceFile;

        protected string LocalResourceFile 
        {
            get { return localResourceFile ?? (localResourceFile = Localization.GetResourceFile (this, GetType().Name)); }
        }

        protected string LocalizeString (string key)
        {
            return Localization.GetString (key, LocalResourceFile);
        }

        #endregion
    }
}