using R7.Epsilon.Components;

namespace R7.Epsilon.Models
{
    public static class SocialGroupConfigExtensions
    {
        static string GetDefaultIconCssClass (SocialGroupType sgType)
        {
            if (sgType == SocialGroupType.VKontakte) {
                return "fab fa-vk";
            }

            return "fab fa-" + sgType.ToString ().ToLowerInvariant ();
        }

        public static string GetIconCssClass (this SocialGroupConfig group)
        {
            if (!string.IsNullOrEmpty (group.IconCssClass)) {
                return group.IconCssClass;
            }

            return GetDefaultIconCssClass (group.Type);
        }

        public static string GetCustomColorStyle (this SocialGroupConfig group)
        {
            if (!string.IsNullOrEmpty (group.Color)) {
                return $"color:{group.Color};";
            }

            return string.Empty;
        }
    }
}
