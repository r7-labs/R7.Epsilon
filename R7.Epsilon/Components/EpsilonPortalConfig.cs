//
//  EpsilonPortalConfig.cs
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

        public InstagramConfig Instagram { get; set; }

        public LinkedinConfig Linkedin { get; set; }

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

    public abstract class SimpleSocialNetworkConfig
    {
        public string Group { get; set; }
    }

    public abstract class SocialNetworkConfig: SimpleSocialNetworkConfig
    {
        public bool ShareEnabled { get; set; }
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

    public class OkConfig: SimpleSocialNetworkConfig
    {
    }

    public class YoutubeConfig: SimpleSocialNetworkConfig
    {
    }

    public class InstagramConfig : SimpleSocialNetworkConfig
    {
    }

    public class LinkedinConfig: SimpleSocialNetworkConfig
    {
    }
}

