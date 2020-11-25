using System.Linq;
using System.Web;

namespace R7.Epsilon.Components
{
    public static class EpsilonPortalConfigExtensions
    {
        // TODO: Don't use cookies to pass data between skin components
        public static ThemeConfig GetTheme (this EpsilonPortalConfig config, HttpResponse response)
        {
            var theme = default (ThemeConfig);
            var themeName = A11yHelper.GetThemeCookie (response);
            if (themeName != null) {
                theme = config.Themes.FirstOrDefault (t => t.Name == themeName);
            }

            return theme;
        }
    }
}
