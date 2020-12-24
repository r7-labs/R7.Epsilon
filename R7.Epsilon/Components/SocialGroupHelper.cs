namespace R7.Epsilon.Components
{
    public static class SocialGroupHelper
    {
        static string GetDefaultIconCssClass (SocialGroupType sgType)
        {
            if (sgType == SocialGroupType.VKontakte) {
                return "fab fa-vk";
            }

            return "fab fa-" + sgType.ToString ().ToLowerInvariant ();
        }

        public static string GetIconCssClass (SocialGroupConfig group)
        {
            if (!string.IsNullOrEmpty (group.IconCssClass)) {
                return group.IconCssClass;
            }

            return GetDefaultIconCssClass (group.Type);
        }

        public static string GetCustomColorStyle (string color)
        {
            if (!string.IsNullOrEmpty (color)) {
                return $"color:{color};";
            }

            return string.Empty;
        }
    }
}
