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

namespace R7.Epsilon.Components
{
    public class EpsilonPortalConfig
    {
        #region Portal config properties

        public string SkinCss { get; set; }

        public string SkinA11yCss { get; set; }

        public int FeedbackTabId { get; set; }

        public MenuConfig PrimaryMenu { get; set; }

        public MenuConfig SecondaryMenu { get; set; }

        public string FooterButtonsGroupName { get; set; }

        public bool VkShareEnabled { get; set; }

        public string VkApiId { get; set; }

        public string VkGroup { get; set; }

        public bool FacebookShareEnabled { get; set; }

        public string FacebookAppId { get; set; }

        public string FacebookGroup { get; set; }

        public bool TwitterShareEnabled { get; set; }

        public string TwitterGroup { get; set; }

        public string TwitterVia { get; set; }

        public bool GoogleShareEnabled { get; set; }

        public string GoogleGroup { get; set; }

        public string YoutubeGroup { get; set; } 

        public string OkGroup { get; set; }

        public string AdsenseClient { get; set; }

        public string AdsenseSlot { get; set; }

        public bool ShowTerms { get; set; }

        public bool ShowPrivacy { get; set; }

        public int MenuUrlType { get; set; }

        public bool UseObrnadzorMicrodata { get; set; }

        #endregion
    }

    public class MenuConfig
    {
        public string NodeSelector { get; set; }

        public string IncludeNodes { get; set; }
    }

}

