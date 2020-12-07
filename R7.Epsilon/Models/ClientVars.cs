using System.Collections.Generic;
using Newtonsoft.Json;

namespace R7.Epsilon.Models
{
    public class ClientVars
    {
        public int ActiveTabId { get; set; }

        public string PortalAlias { get; set; }

        public bool EnablePopups { get; set; }

        public bool InPopup { get; set; }

        public string CookiePrefix { get; set; }

        public bool IsEditMode { get; set; }

        public string FeedbackUrl { get; set; }

        public int FeedbackTabId { get; set; }

        public int FeedbackModuleId { get; set; }

        public bool IsSuperUser { get; set; }

        public bool IsAdmin { get; set; }

        public string DefaultThemeName { get; set; }

        public IDictionary<string, object> Themes { get; set; }

        [JsonProperty ("localization")] public IDictionary<string, string> Resources { get; set; }

        public IDictionary<string, string> QueryParams { get; set; }
    }
}
