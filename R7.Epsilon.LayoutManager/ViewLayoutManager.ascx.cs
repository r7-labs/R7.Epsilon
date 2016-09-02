//
//  ViewLayoutManager.ascx.cs
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
using System.Collections.Generic;
using System.Linq;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.UI.Skins;
using DotNetNuke.UI.Skins.Controls;
using R7.Epsilon.Components;

namespace R7.Epsilon.LayoutManager
{
    public partial class ViewLayoutManager : PortalModuleBase
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

        protected void BindLayouts (int portalId)
        {
            var layouts = LayoutHelper.GetPortalLayoutFiles (portalId);
            gridLayouts.DataSource = layouts;
            gridLayouts.DataBind ();

            // add / remove "empty" CSS class
            if (!layouts.Any ()) {
                gridLayouts.CssClass = gridLayouts.CssClass + " " + "empty";
            } else {
                gridLayouts.CssClass = gridLayouts.CssClass.Replace ("empty", "").TrimEnd ();
            }
        }

        protected void WarningMessage (string messageResource)
        {
            Skin.AddModuleMessage (this, LocalizeString (messageResource), ModuleMessage.ModuleMessageType.YellowWarning);
        }
    }
}
