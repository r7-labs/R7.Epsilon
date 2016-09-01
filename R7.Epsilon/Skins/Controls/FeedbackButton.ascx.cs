//
//  FeedbackButton.ascx.cs
//
//  Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2015 Roman M. Yagodin
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

using System;
using System.Web;
using System.Web.UI;
using DotNetNuke.Entities.Portals;
using System.Web.UI.WebControls;
using System.Web.Security;
using DotNetNuke.UI.WebControls;
using R7.Epsilon.Components;

namespace R7.Epsilon
{
    public class FeedbackButton : EpsilonSkinObjectBase
    {
        #region Controls

        protected HyperLink linkFeedbackButton;

        #endregion

        #region Properties

        public int FeedbackTabId { get; set; }

        public string Target { get; set; }

        public string CssClass { get; set; }

        #endregion

        protected override void OnInit (EventArgs e)
        {
            base.OnInit (e);

            // set feedback TabId here to avoid cache issues (fix for #14)
            FeedbackTabId = Config.FeedbackTabId;

            linkFeedbackButton.Target = Target;
            linkFeedbackButton.CssClass = "unselectable " + CssClass;
            linkFeedbackButton.ToolTip = Localizer.GetString ("FeedBackButton.Tooltip");
            linkFeedbackButton.Text = Localizer.GetString  ("FeedBackButton.Text");
            linkFeedbackButton.Attributes.Add ("onclick", string.Format ("javascript:return skin_feedback_button(this, {0}, {1})", 
                FeedbackTabId, PortalSettings.ActiveTab.TabID));
        }
    }
}
