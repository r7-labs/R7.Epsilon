//
// ViewR7.Epsilon.LayoutManager.ascx.cs
//
// Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
// Copyright (c) 2016 Roman M. Yagodin
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using DotNetNuke.Common;
using DotNetNuke.Entities.Icons;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.UI.Skins;
using DotNetNuke.UI.Skins.Controls;
using R7.Epsilon.LayoutManager.Models;
using R7.Epsilon.LayoutManager.Components;

namespace R7.Epsilon.LayoutManager
{
    public partial class ViewLayoutManager : PortalModuleBase, IActionable
    {
        #region Handlers

        /// <summary>
        /// Handles Init event for a control
        /// </summary>
        /// <param name="e">Event args.</param>
        protected override void OnInit (EventArgs e)
        {
            base.OnInit (e);

            comboPortal.DataSource = GetManageablePortals ();
            comboPortal.DataBind ();
        }

        protected IEnumerable<PortalInfo> GetManageablePortals ()
        {
            if (UserInfo.IsSuperUser) {
                // host can manage all portals plus host "portal"
                var portals = PortalController.Instance.GetPortals ();
                portals.Insert (0, new PortalInfo { PortalID = Const.HOST_PORTAL_ID, PortalName = LocalizeString ("Host.Text") });

                return portals.Cast<PortalInfo> ();
            }

            if (UserInfo.IsInRole ("Administrators")) {
                // admin can manage its portal only
                var portals = new PortalInfo [] {
                    new PortalInfo { PortalID = PortalId, PortalName = PortalSettings.Current.PortalName }
                };

                return portals;
            }

            return Enumerable.Empty<PortalInfo> ();
        }

        /// <summary>
        /// Handles Load event for a control
        /// </summary>t
        /// <param name="e">Event args.</param>
        protected override void OnLoad (EventArgs e)
        {
            base.OnLoad (e);

            try {
                if (comboPortal.Items.Count == 0) {
                    WarningMessage ("NotAllowed.Warning");
                    panelViewLayoutManager.Visible = false;
                    return;
                }

                // setup "Add Layout" link
                linkAddLayout.NavigateUrl = EditUrl ("layoutportalid", comboPortal.SelectedValue, "Edit");

                if (!IsPostBack) {
                    BindLayouts (int.Parse (comboPortal.SelectedValue));
                }
            } 
            catch (Exception ex) {
                Exceptions.ProcessModuleLoadException (this, ex);
            }
        }

        protected void comboPortals_SelectedIndexChanged (object sender, EventArgs e)
        {
            var portalId = int.Parse (comboPortal.SelectedValue);
            BindLayouts (portalId);
        }

        #endregion

        #region IActionable implementation

        public ModuleActionCollection ModuleActions {
            get {
                var actions = new ModuleActionCollection ();

                actions.Add (new ModuleAction (
                    GetNextActionID (),
                    LocalizeString ("AddLayout.Action"),
                    ModuleActionType.AddContent,
                    "",
                    IconController.IconURL ("Add"),
                    EditUrl ("Edit"),
                    "",
                    false,
                    DotNetNuke.Security.SecurityAccessLevel.Admin,
                    true
                ));

                return actions;
            }
        }

        #endregion

        protected void BindLayouts (int portalId)
        {
            var layouts = LayoutController.GetLayouts (portalId);
            gridLayouts.DataSource = layouts;
            gridLayouts.DataBind ();

            // add / remove "empty" CSS class
            if (!layouts.Any ()) {
                gridLayouts.CssClass = gridLayouts.CssClass + " " + "empty";
            } else {
                gridLayouts.CssClass = gridLayouts.CssClass.Replace ("empty", "").TrimEnd ();
            }
        }

        protected void ErrorMessage (string messageResource)
        {
            Skin.AddModuleMessage (this, LocalizeString (messageResource), ModuleMessage.ModuleMessageType.RedError);
        }

        protected void WarningMessage (string messageResource)
        {
            Skin.AddModuleMessage (this, LocalizeString (messageResource), ModuleMessage.ModuleMessageType.YellowWarning);
        }
    }
}
