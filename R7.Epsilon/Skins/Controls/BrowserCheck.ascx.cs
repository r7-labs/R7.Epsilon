//
// BrowserCheck.ascx.cs
//
// Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
// Copyright (c) 2015 
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
using System.Web;
using System.Web.UI;
using DotNetNuke.Entities.Portals;
using System.Web.UI.WebControls;
using System.Web.Security;
using DotNetNuke.UI.WebControls;

namespace R7.Epsilon
{
    public class BrowserCheck : CustomSkinObjectBase
    {
        #region Properties

        private int minIeVersion = 9;

        /// <summary>
        /// Gets or sets the minimum IE major version.
        /// </summary>
        /// <value>The minimum IE major version.</value>
        protected int MinIeVersion 
        {
            get { return minIeVersion; }
            set { minIeVersion = value; }
        }
 
        #endregion

        protected enum CompLevel { /* Error, */ Warning, OK }

        #region Controls

        protected Literal literalBrowserCheck;

        #endregion

        protected override void OnLoad (EventArgs e)
        {
            base.OnLoad (e);

            // get browser
            var browser = Request.Browser;
            var browserName = browser.Browser.ToUpperInvariant();

            // check for browser type and version 
            var compLevel = CompLevel.OK;

            if (browserName.StartsWith ("IE") || browserName.Contains ("MSIE"))
            {
                if (Request.Browser.MajorVersion < MinIeVersion)
                {
                    compLevel = CompLevel.Warning;
                }
            }
           
            // if check determines old browser, display message
            if (compLevel != CompLevel.OK)
            {
                literalBrowserCheck.Visible = true;
                literalBrowserCheck.Text = string.Format ("<div class=\"dnnFormMessage dnnFormWarning\">{0}</div>",
                    LocalizeString ("BrowserCheck.Warning")
                );
            }
        }
    }
}
