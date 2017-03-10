//
//  Custom.ascx.cs
//
//  Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2016 Roman M. Yagodin
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
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using DotNetNuke.Common;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Tabs;
using DotNetNuke.Services.Exceptions;
using R7.Epsilon.Components;

namespace R7.Epsilon.Skins
{
    public class Custom : EpsilonSkinBase
    {
        // TODO: Move to the EpsilonSkinBase class
        protected PlaceHolder placeDynamicPanes;

        protected override void OnInit (EventArgs e)
        {
            // check if skin supports custom layouts
            if (placeDynamicPanes != null) {

                try {
                    var tabSettings = TabController.Instance.GetTabSettings (TabId);

                    object layoutSetting = null;

                    // try use a11y layout in a11y mode
                    if (A11yEnabled) {
                        layoutSetting = tabSettings [Const.A11Y_LAYOUT_TAB_SETTING_NAME];
                    }

                    // try use standard layout (not in a11y mode or no a11y layout set)
                    if (layoutSetting == null) {
                        layoutSetting = tabSettings [Const.LAYOUT_TAB_SETTING_NAME];
                    }

                    // TODO: Add test to ensure that default host layout exists
                    // TODO: Default layout for skin could be named after skin, e.g. Home.ascx => Home.xml
                    var layoutNamePrefixed = (layoutSetting != null) ? (string) layoutSetting : "[G]Default";
                    var layoutPortalId = layoutNamePrefixed.Substring (0, 3) == "[L]" ? PortalSettings.PortalId : Const.HOST_PORTAL_ID;
                    var layoutName = layoutNamePrefixed.Substring (3);

                    var layout = LayoutManager.Instance.GetLayout (layoutPortalId, layoutName);
                    if (layout != null) {
                        // create and insert pane controls
                        var insertIndex = Controls.IndexOf (placeDynamicPanes);
                        foreach (var pane in layout.Panes) {

                            var paneControl = new HtmlGenericControl (pane.Tag);
                            paneControl.ID = pane.ID;

                            if (!string.IsNullOrEmpty (pane.CssClass)) {
                                paneControl.Attributes.Add ("class", pane.CssClass);
                            }

                            if (!string.IsNullOrEmpty (pane.ContainerType)) {
                                paneControl.Attributes.Add ("containertype", pane.ContainerType);
                            }

                            if (!string.IsNullOrEmpty (pane.ContainerName)) {
                                paneControl.Attributes.Add ("containername", pane.ContainerName);
                            }

                            if (!string.IsNullOrEmpty (pane.ContainerSrc)) {
                                paneControl.Attributes.Add ("containersrc", pane.ContainerSrc);
                            }

                            // insert controls

                            if (!string.IsNullOrEmpty (pane.MarkupBefore)) {
                                Controls.AddAt (insertIndex++, new LiteralControl (pane.MarkupBefore));
                            }

                            Controls.AddAt (insertIndex++, paneControl);

                            if (!string.IsNullOrEmpty (pane.MarkupAfter)) {
                                Controls.AddAt (insertIndex++, new LiteralControl (pane.MarkupAfter));
                            }
                        }
                    }
                } catch (Exception ex) {
                    Exceptions.ProcessPageLoadException (new Exception (ex.Message, ex));
                }
            }

            base.OnInit (e);
        }

        protected void buttonTestPostBack_Click (object sender, EventArgs e)
        {
            LayoutManager.ResetInstance ();
            Response.Redirect (Globals.NavigateURL ());
        }
    }
}