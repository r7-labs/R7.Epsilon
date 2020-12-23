using System;
using R7.Epsilon.Components;

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

        private bool? _disablePageAudit;

        public bool DisablePageAudit {
            get {
                return (_disablePageAudit ?? (_disablePageAudit = EpsilonConfig.Instance.DisablePageAudit)).Value;
            }
            set {
                _disablePageAudit = value;
            }
        }

        public bool DisablePermalinks { get; set; }

        public bool DisableLazyAds { get; set; }

        public bool DisableRangy { get; set; }
    }
}
