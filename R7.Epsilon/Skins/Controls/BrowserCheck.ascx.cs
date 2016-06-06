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
using R7.Epsilon.Components;

namespace R7.Epsilon
{
    public class BrowserCheck : EpsilonSkinObjectBase
    {
        #region Properties

        /// <summary>
        /// Gets or sets the minimum IE major version.
        /// </summary>
        /// <value>The minimum IE major version.</value>
        protected int MinIeVersion { get; set; }
 
        protected bool IsCompatibleBrowser
        {
            get
            { 
                // get browser
                var browser = Request.Browser;
                var browserName = browser.Browser.ToUpperInvariant();

                // default is compatible
                var compatible = true;

                // check for browser type and version 
                if (browserName.StartsWith ("IE") || browserName.Contains ("MSIE"))
                {
                    compatible = Request.Browser.MajorVersion >= MinIeVersion;
                }

                return compatible;
            }
        }

        #endregion

        protected BrowserCheck ()
        {
            // default value
            MinIeVersion = 9;
        }
    }
}
