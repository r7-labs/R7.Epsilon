namespace R7.Epsilon.Components
{
    public static class SearchEngineHelper
    {
        static string GetDefaultIconCssClass (SearchEngineType seType)
        {
            if (seType == SearchEngineType.Yandex) {
                return "fab fa-yandex-international";
            }

            if (seType == SearchEngineType.Google) {
                return "fab fa-google";
            }

            return "fas fa-search";
        }

        public static string GetIconCssClass (SearchEngineConfig searchEngine)
        {
            if (!string.IsNullOrEmpty (searchEngine.IconCssClass)) {
                return searchEngine.IconCssClass;
            }

            return GetDefaultIconCssClass (searchEngine.Type);
        }
    }
}
