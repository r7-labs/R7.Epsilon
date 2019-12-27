//
//  File: EpsilonPortalConfig.cs
//  Project: R7.Epsilon
//
//  Author: Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2014-2019 Roman M. Yagodin, R7.Labs
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

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web;

namespace R7.Epsilon.Components
{
    public class EpsilonPortalConfig
    {
        public List<ThemeConfig> Themes { get; set; } = new List<ThemeConfig> {
            new ThemeConfig {
                Name = "green",
                Css = "green-theme.min.css",
                Color = "green",
                IsA11yTheme = false

            },
            new ThemeConfig {
                Name = "contrast",
                Css = "contrast-theme.min.css",
                Color = "black",
                IsA11yTheme = true
            }
        };

        public List<WebsiteConfig> Websites { get; set; } = new List<WebsiteConfig> ();

        public FeedbackConfig Feedback { get; set; } = new FeedbackConfig ();

        public MenuConfig Menu { get; set; } = new MenuConfig ();

        public MenuConfig PrimaryMenu { get; set; } = new MenuConfig {
            NodeSelector = "*,0,3"
        };

        public MenuConfig SecondaryMenu { get; set; } = new MenuConfig {
            NodeSelector = "*,0,3"
        };

        public MenuConfig BreadcrumbMenu { get; set; } = new MenuConfig {
            NodeSelector = "*,0,7"
        };

        public AdsenseConfig Adsense { get; set; } = new AdsenseConfig ();

        public bool ShowTerms { get; set; }

        public bool ShowPrivacy { get; set; }

        public bool UseObrnadzorMicrodata { get; set; }

        public List<SocialGroupConfig> SocialGroups { get; set; } = new List<SocialGroupConfig> ();

        public List<SearchEngineConfig> SearchEngines { get; set; } = new List<SearchEngineConfig> ();

        public AnalyticsConfig Analytics { get; set; } = new AnalyticsConfig ();

        public IList<string> PermalinkFormats { get; set; } = new List<string> {
            "/tabid/{tabid}"
        };

        public IList<UrlShortenerConfig> UrlShorteners { get; set; } = new List<UrlShortenerConfig> {
            new UrlShortenerConfig {
                Label = "tinyurl.com",
                UrlFormat = "https://tinyurl.com/create.php?url={url}"
            }
        };

        public string CanonicalUrlFormat { get; set; }
    }

    public class MenuConfig
    {
        public string NodeSelector { get; set; }

        public string IncludeNodes { get; set; }

        public string ExcludeNodes { get; set; }

        public string UrlFormat { get; set; }

        public ICollection<string> NodeManipulatorTypes { get; set; } = new Collection<string> ();

        public ICollection<object> NodeManipulators = new Collection<object> ();
    }

    public class AdsenseConfig
    {
        public string Client { get; set; }

        public string Slot { get; set; }
    }

    public class SocialGroupConfig
    {
        public SocialGroupType Type { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        public string Url { get; set; }

        public bool ShareEnabled { get; set; } = false;

        public bool IsPrimary { get; set; } = false;

        public string ApiId { get; set; } = string.Empty;

        public List<string> Params { get; set; } = new List<string> ();
    }

    public class AnalyticsConfig
    {
        public bool UseSputnik { get; set; } = false;
    }

    public class FeedbackConfig
    {
        public int TabId { get; set; } = -1;

        public string ModuleDefinitionName { get; set; } = "Feedback";

        // TODO: Rename to AllowOpenInPopup
        public bool OpenInPopup { get; set; } = true;
    }

    public class ThemeConfig
    {
        public string Name { get; set; }

        public string Css { get; set; }

        public string Color { get; set; }

        public bool IsA11yTheme { get; set; }
    }

    public class WebsiteConfig
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string Hreflang { get; set; }

        public bool IsAltWebsite { get; set; }
    }

    public class SearchEngineConfig
    {
        public string Name { get; set; }

        public SearchEngineType Type { get; set; }

        public string UrlFormat { get; set; }

        public string GetUrl (string website, string searchText)
        {
            return UrlFormat.Replace ("{website}", website).Replace ("{searchText}", HttpUtility.UrlEncode (searchText));
        }
    }

    public class UrlShortenerConfig
    {
        public string Label { get; set; }

        public string UrlFormat { get; set; }
    }
}
