//
// EpsilonSkinBase.cs
//
// Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
// Copyright (c) 2015-2016 Roman M. Yagodin
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using DotNetNuke.Common;
using DotNetNuke.Framework;
using DotNetNuke.UI.Skins;
using DotNetNuke.Web.Client;
using DotNetNuke.Web.Client.ClientResourceManagement;
using DotNetNuke.Framework.JavaScriptLibraries;

namespace R7.Epsilon.Components
{
    public class EpsilonSkinBase: Skin, ILocalizableControl, IConfigurableControl
    {
        #region Controls

        // each skin should have this!

        protected DnnCssInclude skinCSS;

        protected HyperLink linkA11yVersion;

        #endregion

        protected bool IsErrorPage
        {
            get {
                var activeTabId = PortalSettings.ActiveTab.TabID;
                return activeTabId == PortalSettings.ErrorPage404 || activeTabId == PortalSettings.ErrorPage500;
            }
        }

        protected bool A11yEnabled 
        {
            get {
                // try to get a11y mode from querystring
                var a11yParamStr = Request.QueryString ["a11y"];
                if (!string.IsNullOrWhiteSpace (a11yParamStr))
                {
                    bool a11yParam;
                    if (bool.TryParse (a11yParamStr, out a11yParam))
                    {
                        // store a11y mode in the cookie
                        Response.Cookies ["a11y"].Value = a11yParam.ToString ();
                        Response.Cookies ["a11y"].Expires = DateTime.Now.AddDays (1d);
                        return a11yParam;
                    }
                }

                // no a11y was found in the querystring, so return cookie value
                var cookie = Request.Cookies ["a11y"];
                bool a11yEnabled;
                return (cookie != null && bool.TryParse (cookie.Value, out a11yEnabled)) ? a11yEnabled : false;
            }
        }

        #region ILocalizableControl implementation

        protected ControlLocalizer localizer;

        public ControlLocalizer Localizer
        {
            get { return localizer ?? (localizer = new ControlLocalizer (this)); } 
        }

        #endregion

        #region IConfigurableControl implementation

        protected EpsilonPortalConfig config;

        public EpsilonPortalConfig Config 
        {
            get { return config ?? (config = EpsilonConfig.GetInstance (PortalSettings.PortalId)); }
        }

        #endregion

        protected override void OnInit (EventArgs e)
        {
            base.OnInit (e);

            // init accessibility button
            if (linkA11yVersion != null)
            {
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

            if (linkA11yVersion != null)
            {
                // make link to toggle a11y mode
                linkA11yVersion.NavigateUrl = Globals.NavigateURL (
                    PortalSettings.ActiveTab.TabID, "", "a11y", (!A11yEnabled).ToString ());
            }

            if (skinCSS != null && A11yEnabled)
            {
                // replace current skin
                skinCSS.FilePath = Config.SkinA11yCss;

                // load a11y script
                ClientResourceManager.RegisterScript (Page, "/Portals/_default/Skins/R7.Epsilon/js/a11y.min.js", FileOrder.Js.DefaultPriority, "DnnFormBottomProvider");

                // alter look of accessibility button
                linkA11yVersion.CssClass = linkA11yVersion.CssClass + " enabled";
            }
        }

        private void RegisterJavaScript()
        {
            JavaScript.RequestRegistration (CommonJs.jQuery);
        }
    }
}