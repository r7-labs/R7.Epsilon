using System;
using System.Web.UI.WebControls;
using DotNetNuke.Common;
using DotNetNuke.Framework;
using DotNetNuke.Services.Localization;
using DotNetNuke.Web.Client.ClientResourceManagement;

namespace R7.Epsilon
{
    public class SkinBase : DotNetNuke.UI.Skins.Skin
    {
        #region Controls

        // each skin should have this!

        protected DnnCssInclude skinCSS;

        protected LinkButton linkA11yButton;

        #endregion

        private bool A11yEnabled 
        {
            get 
            { 
                var obj = Session ["A11YEnabled"];
                return obj != null ? (bool) obj : false;
            }
            set
            {
                Session ["A11YEnabled"] = value;
            }
        }

        protected override void OnLoad (EventArgs e)
        {
            base.OnLoad (e);

            RegisterJavaScript();

            if (skinCSS != null && A11yEnabled)
                skinCSS.FilePath = "css/a11y-skin.min.css";

            // A11y button localization
            // REVIEW: Move this to concrete skin?
            linkA11yButton.Text = LocalizeString ("A11y.Text");
            linkA11yButton.ToolTip = LocalizeString ("A11y.Title");
        }

        private void RegisterJavaScript()
        {
            jQuery.RequestRegistration();
            //ClientResourceManager.RegisterScript(Page, "/portals/_default/skins/hammerflex/js/jquery.blueimp-gallery.min.js", FileOrder.Js.jQuery, "DnnFormBottomProvider"); // default priority and provider
            //ClientResourceManager.RegisterScript(Page, "/portals/_default/skins/hammerflex/js/bootstrap-image-gallery.min.js", FileOrder.Js.jQuery, "DnnFormBottomProvider"); // default priority and provider           
        }

        #region Handlers

        protected virtual void linkA11yButton_Click (object sender, EventArgs e)
        {
            // toggle accessibility
            A11yEnabled = !A11yEnabled;

            // reload page
            Response.Redirect (Globals.NavigateURL ());
        }

        #endregion

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