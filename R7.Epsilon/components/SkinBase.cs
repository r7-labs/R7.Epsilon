using System;
using System.Web.UI.WebControls;
using DotNetNuke.Common;
using DotNetNuke.Framework;
using DotNetNuke.Services.Localization;
using DotNetNuke.Web.Client.ClientResourceManagement;
using DotNetNuke.Web.Client;

namespace R7.Epsilon
{
    public class SkinBase : DotNetNuke.UI.Skins.Skin, ILocalizableControl
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

        #region ILocalizableControl implementation

        private ControlLocalizer localizer;

        public ControlLocalizer Localizer
        {
            get { return localizer ?? (localizer = new ControlLocalizer (this)); } 
        }

        #endregion

        protected override void OnLoad (EventArgs e)
        {
            base.OnLoad (e);

            RegisterJavaScript();

            if (skinCSS != null && A11yEnabled)
            {
                skinCSS.FilePath = "css/a11y-skin.min.css";

                // load a11y script
                ClientResourceManager.RegisterScript (Page, "/Portals/_default/Skins/R7.Epsilon/js/a11y.min.js", FileOrder.Js.DefaultPriority, "DnnFormBottomProvider");
            }

            // A11y button localization
            // REVIEW: Move this to concrete skin?
            linkA11yButton.Text = Localizer.GetString ("A11y.Text");
            linkA11yButton.ToolTip = Localizer.GetString ("A11y.Title");
        }

        private void RegisterJavaScript()
        {
            jQuery.RequestRegistration();
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
    }
}