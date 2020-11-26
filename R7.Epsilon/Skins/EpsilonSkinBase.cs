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

            RegisterThemeStyleSheet ();

            if (!string.IsNullOrEmpty (Config.CanonicalUrlFormat)) {
                var linkCanonicalUrl = new HtmlLink ();
                linkCanonicalUrl.Attributes.Add ("rel", "canonical");
                linkCanonicalUrl.Href = EpsilonUrlHelper.FormatUrl (Config.CanonicalUrlFormat, ActiveTab.TabID, ActiveTab.PortalID, Request.QueryString);
                Page.Header.Controls.Add (linkCanonicalUrl);
            }
        }

        protected void RegisterThemeStyleSheet ()
        {
            var linkTheme = new HtmlLink ();
            linkTheme.ID = "skinTheme";
            linkTheme.Attributes.Add ("rel", "stylesheet");
            linkTheme.Attributes.Add ("type", "text/css");
            linkTheme.Href = "/Portals/_default/Skins/R7.Epsilon/css/" + Config.Themes [0].Css;
            Page.Header.Controls.Add (linkTheme);
        }

        protected void SetCookiesByQueryString ()
        {
            var a11yArg = Request.QueryString ["a11y"];
            if (a11yArg != null) {
                if (string.Equals (a11yArg, "true", StringComparison.InvariantCultureIgnoreCase)) {
                    A11yHelper.SetA11yCookies (Response, Config.Themes);
                    return;
                }
                /*
                if (string.Equals (a11yArg, "false", StringComparison.InvariantCultureIgnoreCase)) {
                    A11yHelper.ResetA11yCookies (Response, Config.Themes);
                    return;
                }*/
            }
        }

        /*protected void SetBodyCssClassForTheme ()
        {
            var body = (HtmlGenericControl) this.Page.FindControl ("Body");
            body.Attributes.Add ("class", "theme-" + (Config.GetTheme (Request) ?? Config.Themes [0]).Name + " " + body.Attributes ["class"]);
        }

        protected override void OnLoad (EventArgs e)
        {
            base.OnLoad (e);

            SetBodyCssClassForTheme ();
        }*/
    }
}
