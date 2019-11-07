//
//  File: EpsilonSkinBase.cs
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
using System.Linq;
using System.Reflection;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using DotNetNuke.Common;
using DotNetNuke.Entities.Tabs;
using DotNetNuke.Framework.JavaScriptLibraries;
using DotNetNuke.UI.Skins;
using R7.Epsilon.Components;

namespace R7.Epsilon.Skins
{
    public class EpsilonSkinBase : Skin, ILocalizableControl, IConfigurableControl
    {
        public EpsilonSkinOptions Options  { get; set; } = new EpsilonSkinOptions ();

        protected bool IsErrorPage {
            get {
                var activeTabId = ActiveTab.TabID;
                return activeTabId == PortalSettings.ErrorPage404 || activeTabId == PortalSettings.ErrorPage500;
            }
        }

        protected TabInfo ActiveTab => PortalSettings.ActiveTab;

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

        #region ILocalizableControl implementation

        protected ControlLocalizer localizer;

        public ControlLocalizer T {
            get { return localizer ?? (localizer = new ControlLocalizer (this)); }
        }

        #endregion

        #region IConfigurableControl implementation

        protected EpsilonPortalConfig config;

        public EpsilonPortalConfig Config {
            get { return config ?? (config = EpsilonConfig.GetInstance (PortalSettings.PortalId)); }
        }

        #endregion

        protected override void OnInit (EventArgs e)
        {
            base.OnInit (e);

            if (SetCookiesByQueryString ()) {
                Response.Redirect (Globals.NavigateURL (), false);
                return;
            }
            // add canonical URL link
            // TODO: Add support for blogs and forums
            var linkCanonicalUrl = new HtmlLink ();
            linkCanonicalUrl.Attributes.Add ("rel", "canonical");
            linkCanonicalUrl.Href = Globals.NavigateURL ();
            Page.Header.Controls.Add (linkCanonicalUrl);

            RegisterCdns ();
        }

        protected bool SetCookiesByQueryString ()
        {
            var themeArg = Request.QueryString ["theme"];
            if (themeArg != null) {
                A11yHelper.SetThemeCookie (Response, themeArg);
                return true;
            }

            var a11yArg = Request.QueryString ["quickA11y"];
            if (a11yArg != null) {
                if (a11yArg == "enable" || a11yArg == "true") {
                    A11yHelper.SetA11yCookies (Response, Config.Themes);
                    return true;
                }
                if (a11yArg == "reset" || a11yArg == "false") {
                    A11yHelper.ResetA11yCookies (Response, Config.Themes);
                    return true;
                }
            }

            return false;
        }

        protected void RegisterCdns ()
        {
            foreach (var cdn in Config.Cdns.Where (c => c.Location == "PageHead")) {
                if (cdn.Href.EndsWith (".css")) {
                    var link = new HtmlLink ();
                    link.Attributes.Add ("rel", "stylesheet");
                    link.Attributes.Add ("crossorigin", "anonymous");
                    link.Attributes.Add ("integrity", cdn.Integrity);
                    link.Href = cdn.Href;
                    Page.Header.Controls.Add (link);
                }
            }
        }

        protected void SetBodyCssClassForTheme ()
        {
            var body = (HtmlGenericControl) this.Page.FindControl ("Body");
            body.Attributes.Add ("class", "theme-" + (Config.GetTheme (Request) ?? Config.Themes [0]).Name + " " + body.Attributes ["class"]);
        }

        protected override void OnLoad (EventArgs e)
        {
            base.OnLoad (e);

            SetBodyCssClassForTheme ();
        }
    }
}
