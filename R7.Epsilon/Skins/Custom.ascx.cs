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

namespace R7.Epsilon
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
                    var layoutSetting = tabSettings ["r7_Epsilon_Layout"];

                    // TODO: Add test to ensure that default layout exists
                    var layoutName = (layoutSetting != null) ? (string)layoutSetting : "Default";

                    var layout = LayoutManager.GetLayout (PortalSettings.Current.PortalId, layoutName);
                    if (layout != null) {
                        var listPanes = layout.Panes;

                        // create and insert pane controls
                        var insertIndex = Controls.IndexOf (placeDynamicPanes);
                        foreach (var pane in listPanes) {

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

                            Controls.AddAt (insertIndex++, new LiteralControl (pane.MarkupBefore));
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
            LayoutManager.Reset ();
            Response.Redirect (Globals.NavigateURL ());
        }
    }
}