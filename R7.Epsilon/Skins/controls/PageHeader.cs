//
// PageHeader.ascx.cs
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
    public class PageHeader : CustomSkinObjectBase
    {
        public PageHeader (): base ("PageTitle.ascx")
        {
        }

        public bool EnableSocialShare { get; set; }

        // REVIEW: Convert to control attribute?
        // chars to trim, including en and em dashes
        private static char [] trimSeparators = { ' ', '-', '\u2013', '\u2014',  '.', ':', '/', '\\' };

        protected string TagLine
        {
            get
            { 
                // if Title starts with TabName, use varying Title part as tagline,
                // or use Title as tagline otherwise.

                var activeTab = PortalSettings.ActiveTab;
                           
                if (!string.IsNullOrWhiteSpace (activeTab.Title))
                {
                    if (activeTab.Title.StartsWith (activeTab.TabName, StringComparison.InvariantCultureIgnoreCase))
                        return activeTab.Title.Substring (activeTab.TabName.Length).TrimStart (trimSeparators);

                    return activeTab.Title;
                }
            
                return string.Empty;
            }
        }

        protected string PublishedMessage
        {
            get
            {
                var activeTab = PortalSettings.ActiveTab;
                return string.Format (LocalizeString ("PagePublishedMessage.Format"),  
                    activeTab.CreatedOnDate, 
                    activeTab.CreatedByUser (PortalSettings.PortalId).DisplayName); 
            }
        }
    }
}
