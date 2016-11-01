//
//  EpsilonSkinBase.cs
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

using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using DotNetNuke.Common;
using DotNetNuke.Framework.JavaScriptLibraries;
using DotNetNuke.UI.Skins;
using DotNetNuke.Web.Client;
using DotNetNuke.Web.Client.ClientResourceManagement;
using R7.Epsilon.Components;

namespace R7.Epsilon.Skins
{
    public class EpsilonSkinBase : Skin, ILocalizableControl, IConfigurableControl
    {
        #region Controls

        // each skin should have this!

        protected DnnCssInclude skinCSS;

        protected HyperLink linkA11yVersion;

        #endregion

        protected bool IsErrorPage {
            get {
                var activeTabId = PortalSettings.ActiveTab.TabID;
                return activeTabId == PortalSettings.ErrorPage404 || activeTabId == PortalSettings.ErrorPage500;
            }
        }

        private int? tabId;
        protected int TabId {
            get {
                if (tabId == null) {
                    tabId = PortalSettings.ActiveTab.TabID;
                }

                return tabId.Value;
            }
        }

        public bool A11yEnabled {
            get {
                // try to get a11y mode from querystring
                var a11y = A11yHelper.TryGetA11yParam (Request);
                if (a11y != null) {
                    A11yHelper.SetA11yCookie (Response, a11y.Value);
                    return a11y.Value;
                } 

                // no a11y was found in the querystring, try to get cookie value
                a11y = A11yHelper.TryGetA11yCookie (Request);
                if (a11y != null) {
                    return a11y.Value;
                }

                return false;
            }
        }

        #region ILocalizableControl implementation

        protected ControlLocalizer localizer;

        public ControlLocalizer Localizer {
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

            // init accessibility button
            if (linkA11yVersion != null) {
                var a11yLabel = Localizer.GetString ("A11y.Title");
                linkA11yVersion.ToolTip = a11yLabel;
                linkA11yVersion.Attributes.Add ("aria-label", a11yLabel);

                // use obrnadzor.gov.ru microdata
                if (Config.UseObrnadzorMicrodata)
                    linkA11yVersion.Attributes.Add ("itemprop", "Copy");
            }

            // add canonical URL link
            // TODO: Add support for blogs and forums
            var linkCanonicalUrl = new HtmlLink ();
            linkCanonicalUrl.Attributes.Add ("rel", "canonical");
            linkCanonicalUrl.Href = Globals.NavigateURL ();
            Page.Header.Controls.Add (linkCanonicalUrl);
        }

        protected override void OnLoad (EventArgs e)
        {
            base.OnLoad (e);

            RegisterJavaScript ();

            if (linkA11yVersion != null) {
                // make link to toggle a11y mode
                linkA11yVersion.NavigateUrl = Globals.NavigateURL (
                    PortalSettings.ActiveTab.TabID, "", "a11y", (!A11yEnabled).ToString ());
            }

            if (skinCSS != null && A11yEnabled) {
                // replace current skin
                skinCSS.FilePath = Config.SkinA11yCss;

                // load a11y script
                ClientResourceManager.RegisterScript (Page, "/Portals/_default/Skins/R7.Epsilon/js/a11y.min.js", FileOrder.Js.DefaultPriority, "DnnFormBottomProvider");

                // alter look of accessibility button
                linkA11yVersion.CssClass = linkA11yVersion.CssClass + " enabled";
            }
        }

        private void RegisterJavaScript ()
        {
            JavaScript.RequestRegistration (CommonJs.jQuery);
        }
    }
}