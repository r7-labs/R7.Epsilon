using System;
using R7.Epsilon.Components;

namespace R7.Epsilon.Models
{
    public static class WebsiteConfigExtensions
    {
        public static string GetIconCssClass (this WebsiteConfig website)
        {
            if (!string.IsNullOrEmpty (website.IconCssClass)) {
                return website.IconCssClass;
            }

            return "fas fa-globe";
        }
    }
}
