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
using System.Dynamic;

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

        public VkConfig Vk { get; set; }
       
        public FacebookConfig Facebook { get; set; }

        public TwitterConfig Twitter { get; set; }

        public GooglePlusConfig Google { get; set; }

        public OkConfig Ok { get; set; }

        public YoutubeConfig Youtube{ get; set; }

        public AdsenseConfig Adsense { get; set; }

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

    public class AdsenseConfig
    {
        public string Client { get; set; }

        public string Slot { get; set; }
    }

    public abstract class SocialNetworkConfig
    {
        public bool ShareEnabled { get; set; }

        public string Group { get; set; }
    }

    public class VkConfig: SocialNetworkConfig
    {
        public string ApiId { get; set; }
    }

    public class FacebookConfig: SocialNetworkConfig
    {
        public string AppId { get; set; }
    }

    public class TwitterConfig: SocialNetworkConfig
    {
        public string Via { get; set; }
    }

    public class GooglePlusConfig: SocialNetworkConfig
    {
    }

    public class OkConfig
    {
        public string Group { get; set; }
    }

    public class YoutubeConfig
    {
        public string Group { get; set; }
    }
}

