//
// PageInfo.ascx.cs
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
using DotNetNuke.Entities.Users;

namespace R7.Epsilon
{
    public class PageInfo : EpsilonSkinObjectBase
    {
        public bool ShowPageInfo { get; set; }

        protected PageInfo ()
        {
            // set default values
            ShowPageInfo = true;
        }

        /// <summary>
        /// Gets page published info message.
        /// </summary>
        /// <value>The published message.</value>
        protected string PublishedMessage
        {
            get
            {
                var activeTab = PortalSettings.ActiveTab;
                var user = activeTab.CreatedByUser (PortalSettings.PortalId);

                return string.Format (Localizer.GetString ("PagePublishedMessage.Format"),  
                    activeTab.CreatedOnDate, Utils.GetUserDisplayName (user.UserID, Localizer.GetString ("SystemUser.Text"))); 
            }
        }
    }
}
