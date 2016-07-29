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
using R7.Epsilon.LayoutManager.Models;

namespace R7.Epsilon.LayoutManager
{
    public partial class ViewLayoutManager : PortalModuleBase, IActionable
    {
        #region Handlers

        const int HOST_PORTAL_ID = -1;

        /// <summary>
        /// Handles Init event for a control
        /// </summary>
        /// <param name="e">Event args.</param>
        protected override void OnInit (EventArgs e)
        {
            base.OnInit (e);

            // get portals
            var portals = PortalController.Instance.GetPortals ();

            // insert host "portal"
            portals.Insert (0, new PortalInfo { PortalID = HOST_PORTAL_ID, PortalName = LocalizeString ("Host.Text") });

            comboPortal.DataSource = portals;
            comboPortal.DataBind ();
        }

        /// <summary>
        /// Handles Load event for a control
        /// </summary>
        /// <param name="e">Event args.</param>
        protected override void OnLoad (EventArgs e)
        {
            base.OnLoad (e);

            try {
                if (!IsPostBack) {
                    BindLayouts (HOST_PORTAL_ID);
                }
            } 
            catch (Exception ex) {
                Exceptions.ProcessModuleLoadException (this, ex);
            }
        }

        protected void gridLayouts_RowDataBound (object sender, GridViewRowEventArgs e)
        {
            // show or hide actions column
            e.Row.Cells [0].Visible = IsEditable;
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

        protected IEnumerable<LayoutInfo> GetLayouts (int portalId)
        {
            var mapPath = (portalId != HOST_PORTAL_ID)
              ? PortalController.Instance.GetPortal (portalId).HomeSystemDirectoryMapPath
              : Globals.HostMapPath;

            var layoutDirectory = Path.Combine (mapPath, "Skins", "R7.Epsilon", "Layouts");
            if (Directory.Exists (layoutDirectory)) {
                var layoutFiles = Directory.GetFiles (layoutDirectory, "*.xml");
                if (layoutFiles != null) {
                    return layoutFiles.Select (lf => new LayoutInfo (lf, portalId));
                }
            }

            return Enumerable.Empty<LayoutInfo> ();
        }

        protected void BindLayouts (int portalId)
        {
            var layouts = GetLayouts (portalId);
            gridLayouts.DataSource = layouts;
            gridLayouts.DataBind ();
        }
    }
}
