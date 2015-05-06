//
// EpsilonConfig.cs
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

namespace R7.Epsilon
{
    public class EpsilonConfig: EpsilonConfigBase
    {
        public EpsilonConfig (int portalId): base (portalId)
        {
        }

        #region Portal config properties

        public string SkinCss
        {
            get { return PortalConfig.Get ("SkinCss", "default-skin.min.css"); }
        }

        public string SkinA11yCss
        {
            get { return PortalConfig.Get ("SkinA11yCss", "a11y-skin.min.css"); }
        }

        public int FeedbackTabId
        {
            get { return PortalConfig.GetInt ("FeedbackTabId", -1); }
        }

        public string PrimaryMenuNodeSelector
        {
            get { return PortalConfig.Get ("PrimaryMenuNodeSelector", "*,0,2"); }
        }

        public string PrimaryMenuIncludeNodes
        {
            get { return PortalConfig.Get ("PrimaryMenuIncludeNodes", string.Empty); }
        }

        public string SecondaryMenuNodeSelector
        {
            get { return PortalConfig.Get ("SecondaryMenuNodeSelector", "*,0,2"); }
        }

        public string SecondaryMenuIncludeNodes
        {
            get { return PortalConfig.Get ("SecondaryMenuIncludeNodes", string.Empty); }
        }

        public string FooterButtonsGroupName
        {
            get { return PortalConfig.Get ("FooterButtonsGroupName", "FooterButtons"); }
        }

        public bool VkShareEnabled 
        {
            get { return PortalConfig.GetBoolean ("VkShareEnabled", false); }
        }

        public string VkApiId
        {
            get { return PortalConfig.Get ("VkApiId", string.Empty); }
        }

        public string VkGroup
        {
            get { return PortalConfig.Get ("VkGroup", string.Empty); }
        }

        public string FacebookGroup
        {
            get { return PortalConfig.Get ("FacebookGroup", string.Empty); }
        }

        public string TwitterGroup
        {
            get { return PortalConfig.Get ("TwitterGroup", string.Empty); }
        }

        public string TwitterVia
        {
            get { return PortalConfig.Get ("TwitterVia", TwitterGroup); }
        }

        public string OkGroup
        {
            get { return PortalConfig.Get ("OkGroup", string.Empty); }
        }

        public string GoogleGroup
        {
            get { return PortalConfig.Get ("GoogleGroup", string.Empty); }
        }

        public string YoutubeGroup
        {
            get { return PortalConfig.Get ("YoutubeGroup", string.Empty); }
        }

        public string AdsenseClient
        {
            get { return PortalConfig.Get ("AdsenseClient", string.Empty); }
        }

        public string AdsenseSlot
        {
            get { return PortalConfig.Get ("AdsenseSlot", string.Empty); }
        }

        public bool ShowTerms
        {
            get { return PortalConfig.GetBoolean ("ShowTerms", false); }
        }

        public bool ShowPrivacy
        {
            get { return PortalConfig.GetBoolean ("ShowPrivacy", false); }
        }

        public int MenuUrlType
        {
            get { return PortalConfig.GetInt ("MenuUrlType", 0); }
        }

        public bool UseObrnadzorMicroformats
        {
            get { return PortalConfig.GetBoolean ("UseObrnadzorMicroformats", false); }
        }

        #endregion
    }
}

