using System;
using System.Reflection;
using System.Web.UI.HtmlControls;
using DotNetNuke.Common;
using DotNetNuke.Entities.Tabs;
using DotNetNuke.UI.Skins;
using R7.Epsilon.Components;

namespace R7.Epsilon.Skins
{
    public class EpsilonSkinBase : Skin, IEpsilonSkinPart
    {
        public EpsilonSkinOptions Options  { get; set; } = new EpsilonSkinOptions ();

        protected bool IsErrorPage {
            get {
                var activeTabId = ActiveTab.TabID;
                return activeTabId == PortalSettings.ErrorPage404 || activeTabId == PortalSettings.ErrorPage500;
            }
        }

        public string SkinCopyright => T.GetString ("SkinCopyright.Text").Replace ("{version}", GetVersionString ());

        string GetVersionString ()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly ();
            var assemblyInformationalVersion = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute> ();
            if (assemblyInformationalVersion != null) {
                return assemblyInformationalVersion.InformationalVersion;
            }

            return assembly.GetName ().Version.ToString (3);
        }

        #region IEpsilonSkinPart implementation

        public TabInfo ActiveTab => PortalSettings.ActiveTab;

        protected ControlLocalizer localizer;

        public ControlLocalizer T {
            get { return localizer ?? (localizer = new ControlLocalizer (this)); }
        }

        protected EpsilonPortalConfig config;

        public EpsilonPortalConfig Config {
            get { return config ?? (config = EpsilonConfig.GetInstance (PortalSettings.PortalId)); }
        }

        #endregion

        protected override void OnInit (EventArgs e)
        {
            base.OnInit (e);

            SetCookiesByQueryString ();

            if (!string.IsNullOrEmpty (Config.CanonicalUrlFormat)) {
                var linkCanonicalUrl = new HtmlLink ();
                linkCanonicalUrl.Attributes.Add ("rel", "canonical");
                linkCanonicalUrl.Href = EpsilonUrlHelper.FormatUrl (Config.CanonicalUrlFormat, ActiveTab.TabID, ActiveTab.PortalID, Request.QueryString);
                Page.Header.Controls.Add (linkCanonicalUrl);
            }
        }

        protected void SetCookiesByQueryString ()
        {
            var themeArg = Request.QueryString ["theme"];
            if (themeArg != null) {
                A11yHelper.SetThemeCookie (Response, themeArg);
                return;
            }

            var a11yArg = Request.QueryString ["a11y"];
            if (a11yArg != null) {
                if (string.Equals (a11yArg, "true", StringComparison.InvariantCultureIgnoreCase)) {
                    A11yHelper.SetA11yCookies (Response, Config.Themes);
                    return;
                }
                if (string.Equals (a11yArg, "false", StringComparison.InvariantCultureIgnoreCase)) {
                    A11yHelper.ResetA11yCookies (Response, Config.Themes);
                    return;
                }
            }
        }

        protected void SetBodyCssClassForTheme ()
        {
            var body = (HtmlGenericControl) this.Page.FindControl ("Body");
            body.Attributes.Add ("class", "theme-" + (Config.GetTheme (Response) ?? Config.Themes [0]).Name + " " + body.Attributes ["class"]);
        }

        protected override void OnLoad (EventArgs e)
        {
            base.OnLoad (e);

            SetBodyCssClassForTheme ();
        }
    }
}
