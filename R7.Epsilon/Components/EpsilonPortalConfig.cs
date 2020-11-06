using System;
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
            NodeSelector = "*"
        };

        public MenuConfig SecondaryMenu { get; set; } = new MenuConfig {
            NodeSelector = "*"
        };

        public MenuConfig BreadcrumbMenu { get; set; } = new MenuConfig {
            NodeSelector = "*"
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

        [Obsolete]
        public string Label { get; set; }

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

    // TODO: Custom feedback URL (with format?)
    public class FeedbackConfig
    {
        public int TabId { get; set; }

        public int ModuleId { get; set; }

        public bool IsEnabled () => TabId > 0 && ModuleId > 0;
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
        public string Label { get; set; }

        [Obsolete]
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
