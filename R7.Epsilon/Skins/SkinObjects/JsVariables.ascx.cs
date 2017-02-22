//
//  JsVariables.ascx.cs
//
//  Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2015-2017 Roman M. Yagodin
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

using System.Linq;
using System.Text;
using System.Web.Caching;
using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Tabs;
using R7.Epsilon.Components;

namespace R7.Epsilon.Skins.SkinObjects
{
    public class JsVariables: EpsilonSkinObjectBase
    {
        #region Control properties

        private bool breadCrumbsRemoveLastLink = true;
        public bool BreadCrumbsRemoveLastLink
        {
            get { return breadCrumbsRemoveLastLink; }
            set { breadCrumbsRemoveLastLink = value; }
        }

        #endregion

        #region Bindable properties

        protected string JsBreadCrumbsRemoveLastLink
        {
            get { return breadCrumbsRemoveLastLink.ToString ().ToLowerInvariant (); }
        }

        protected string JsBreadCrumbsList
        {
            get 
            {
                return "[" + Utils.FormatList<int> (",", PortalSettings.ActiveTab.BreadCrumbs
                    .ToArray ().Select (b => ((TabInfo) b).TabID)) + "]"; 
            }
        }

        protected string LayoutManagerUrl
        {
            get {
                var layoutManager = GetLayoutManager (PortalSettings.PortalId);
                if (layoutManager != null) {
                    return Globals.NavigateURL (layoutManager.TabID, "Select", "mid", layoutManager.ModuleID.ToString ());
                }

                // TODO: Log error: no LayoutManager module found, layout selection feature is disabled
                return null;
            }
        }

        // TODO: Invalidate cache (somehow)
        protected ModuleInfo GetLayoutManager (int portalId)
        {
            // GetModuleByDefinition is very slow, so cache its result
            return DataCache.GetCachedData<ModuleInfo> (
                new CacheItemArgs ("//r7_Epsilon/LayoutManager?data=Module&portalId=" + portalId, 1200, CacheItemPriority.Normal),
                (c) => ModuleController.Instance.GetModuleByDefinition (portalId, "R7.Epsilon.LayoutManager")
            );
        }

        public string LocalizationResources
        {
            get {
                var sb = new StringBuilder ();

                sb.AppendFormat ("selectLayout:'{0}',", Localizer.GetString ("SelectLayout.Text"));
                sb.AppendFormat ("feedbackTemplate:'{0}',", Localizer.GetString ("Feedback.Template"));
                sb.AppendFormat ("feedbackPageTemplate:'{0}',", Localizer.GetString ("FeedbackPage.Template"));
                sb.AppendFormat ("feedbackSelectionTemplate:'{0}'", Localizer.GetString ("FeedbackSelection.Template"));

                return sb.ToString ();
            }
        }

        public string QueryParams
        {
            get {
                var sb = new StringBuilder (Request.RawUrl.Length);
                foreach (string key in Request.QueryString.Keys) {
                    sb.AppendFormat ("{2}{0}:'{1}'", key, Request.QueryString [key], sb.Length == 0? "" : ",");
                }
                return sb.ToString ();
            }
        }

        #endregion
    }
}
