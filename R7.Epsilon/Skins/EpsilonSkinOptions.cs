using System;

namespace R7.Epsilon.Skins
{
    public class EpsilonSkinOptions
    {
        public bool DisableBreadCrumb { get; set; }

        public bool DisableSocialShare { get; set; }

        public bool DisableLogin { get; set; }

        [Obsolete]
        public bool DisablePageInfo {
            get {
                return DisablePageTags && DisablePageAudit && DisablePermalinks;
            }
            set {
                DisablePageTags = value;
                DisablePageAudit = value;
                DisablePermalinks = value;
            }
        }

        public bool DisablePageTags { get; set; }

        public bool DisablePageAudit { get; set; }

        public bool DisablePermalinks { get; set; }

        public bool DisableLazyAds { get; set; }

        public bool DisableRangy { get; set; }
    }
}
