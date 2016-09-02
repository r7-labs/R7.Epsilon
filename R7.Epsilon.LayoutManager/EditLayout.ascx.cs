//
//  EditLayout.ascx.cs
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
using System.IO;
using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Log.EventLog;
using DotNetNuke.UI.Skins;
using DotNetNuke.UI.Skins.Controls;
using R7.Epsilon.Components;
using R7.Epsilon.LayoutManager.Components;

namespace R7.Epsilon.LayoutManager
{
    public partial class EditLayout : PortalModuleBase
    {
        #region Properties

        protected bool InPopup
        {
            get { return Request.QueryString ["popup"] != null; }
        }

        #endregion

        #region Handlers

        /// <summary>
        /// Handles Init event for a control.
        /// </summary>
        /// <param name="e">Event args.</param>
        protected override void OnInit (EventArgs e)
        {
            base.OnInit (e);

            // set url for Cancel link
            if (InPopup) {
                linkCancel.Attributes.Add ("onclick", "javascript:return " +
                    UrlUtils.ClosePopUp (refresh: false, url: "", onClickEvent: true));
            } else {
                linkCancel.NavigateUrl = Globals.NavigateURL ();
            }

            var layoutNameStr = Request.QueryString ["layoutname"];
            if (!string.IsNullOrEmpty (layoutNameStr)) {
                if (layoutNameStr == "Default") {
                    // don't delete default layout
                    buttonDelete.Visible = false;
                } 
                else {
                    // add confirmation dialog to delete button
                    buttonDelete.Attributes.Add ("onClick", "javascript:return confirm('"
                                                 + string.Format (LocalizeString ("DeleteItem.Format"), layoutNameStr)
                                                 + "');");
                }
            } 
        }

        /// <summary>
        /// Handles Load event for a control.
        /// </summary>
        /// <param name="e">Event args.</param>
        protected override void OnLoad (EventArgs e)
        {
            base.OnLoad (e);

            try {
                if (!IsPostBack) {
                    var layoutNameStr = Request.QueryString ["layoutname"];
                    var layoutPortalIdStr = Request.QueryString ["layoutportalid"];

                    // at least portalid should be specified
                    if (!string.IsNullOrEmpty (layoutPortalIdStr)) {

                        var layoutName = layoutNameStr;
                        var layoutPortalId = int.Parse (layoutPortalIdStr);

                        var codePrefix = string.Empty;
                        var layoutFile = string.Empty;

                        if (!string.IsNullOrEmpty (layoutName)) {
                            layoutFile = LayoutHelper.GetLayoutFileName (layoutName, layoutPortalId);
                        } 
                        else {
                            // new template
                            codePrefix = "<!-- Default layout template -->" + Environment.NewLine;
                            layoutFile = LayoutHelper.GetLayoutFileName ("Default", layoutPortalId);

                            // if it already host portal, don't do anything
                            if (layoutPortalId != Const.HOST_PORTAL_ID && !File.Exists (layoutFile)) {
                                layoutFile = LayoutHelper.GetLayoutFileName ("Default", Const.HOST_PORTAL_ID);
                            }

                            // cannot delete unsaved layout
                            buttonDelete.Visible = false;
                        }

                        if (File.Exists (layoutFile)) {
                            layoutEditor.Text = codePrefix + File.ReadAllText (layoutFile);
                            textLayoutName.Text = layoutName;

                            // store request values
                            hiddenLayoutName.Value = layoutName;
                            hiddenPortalId.Value = layoutPortalId.ToString ();
                        } 
                        else {
                            // layout file not found, but don't expose it to end-user
                            EventLogController.Instance.AddLog (
                                "R7.Epsilon.LayoutManager.EditLayout",
                                string.Format ("Cannot find specified layout file '{0}'.", layoutFile),
                                EventLogController.EventLogType.HOST_ALERT
                            );

                            Response.Redirect (Globals.NavigateURL (), true);
                        }
                    } 
                    else {
                        // layoutportalid argument is required, but don't expose it to end-user
                        EventLogController.Instance.AddLog (
                            "R7.Epsilon.LayoutManager.EditLayout", 
                            "Querystring is invalid, The 'layoutportalid' argument is required.", 
                            EventLogController.EventLogType.HOST_ALERT
                        );
                        
                        Response.Redirect (Globals.NavigateURL (), true);
                    }
                }
            } 
            catch (Exception ex) {
                Exceptions.ProcessModuleLoadException (this, ex);
            }
        }

        /// <summary>
        /// Handles Click event for Update button
        /// </summary>
        /// <param name='sender'>
        /// Sender.
        /// </param>
        /// <param name='e'>
        /// Event args.
        /// </param>
        protected void buttonUpdate_Click (object sender, EventArgs e)
        {
            try {
                var layoutName = textLayoutName.Text.Trim ();
                var originalLayoutName = hiddenLayoutName.Value;
                var layoutPortaId = int.Parse (hiddenPortalId.Value);
                var layoutFile = LayoutHelper.GetLayoutFileName (layoutName, layoutPortaId);

                if (layoutName != originalLayoutName && File.Exists (layoutFile)) {
                    WarningMessage ("LayoutFileAlreadyExists.Warning");
                    return;
                }

                File.WriteAllText (layoutFile, layoutEditor.Text);

                R7.Epsilon.Components.LayoutManager.Instance.ResetLayout (layoutPortaId, layoutName);
                ModuleController.SynchronizeModule (ModuleId);
                Response.Redirect (Globals.NavigateURL (), true);
            } 
            catch (Exception ex) {
                Exceptions.ProcessModuleLoadException (this, ex);
            }
        }

        /// <summary>
        /// Handles Click event for Delete button
        /// </summary>
        /// <param name='sender'>
        /// Sender.
        /// </param>
        /// <param name='e'>
        /// Event args.
        /// </param>
        protected void buttonDelete_Click (object sender, EventArgs e)
        {
            try {
                var layoutName = hiddenLayoutName.Value;
                var layoutPortaId = int.Parse (hiddenPortalId.Value);

                if (LayoutHelper.IsLayoutInUse (layoutName, layoutPortaId)) {
                    WarningMessage ("LayoutIsInUse.Warning");
                    return;
                }

                var layoutFile = LayoutHelper.GetLayoutFileName (layoutName, layoutPortaId);
                File.Delete (layoutFile);

                R7.Epsilon.Components.LayoutManager.Instance.ResetLayout (layoutPortaId, layoutName);
                ModuleController.SynchronizeModule (ModuleId);
                Response.Redirect (Globals.NavigateURL (), true);
            } 
            catch (Exception ex) {
                Exceptions.ProcessModuleLoadException (this, ex);
            }
        }

        #endregion

        protected void WarningMessage (string messageResource)
        {
            Skin.AddModuleMessage (this, LocalizeString (messageResource), ModuleMessage.ModuleMessageType.YellowWarning);
        }
    }
}
