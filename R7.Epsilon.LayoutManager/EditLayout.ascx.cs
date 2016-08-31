//
// EditR7.Epsilon.LayoutManager.ascx.cs
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
using System.IO;
using DotNetNuke.Common;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Log.EventLog;
using DotNetNuke.UI.Skins;
using DotNetNuke.UI.Skins.Controls;
using R7.Epsilon.LayoutManager.Components;

namespace R7.Epsilon.LayoutManager
{
    public partial class EditLayout : PortalModuleBase
    {
        #region Handlers

        /// <summary>
        /// Handles Init event for a control.
        /// </summary>
        /// <param name="e">Event args.</param>
        protected override void OnInit (EventArgs e)
        {
            base.OnInit (e);

            // set url for Cancel link
            linkCancel.NavigateUrl = Globals.NavigateURL ();

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
                            layoutFile = LayoutController.GetLayoutFileName (layoutName, layoutPortalId);
                        } 
                        else {
                            // new template
                            codePrefix = "<!-- Default layout template -->" + Environment.NewLine;
                            layoutFile = LayoutController.GetLayoutFileName ("Default", layoutPortalId);

                            // if it already host portal, don't do anything
                            if (layoutPortalId != -1 && !File.Exists (layoutFile)) {
                                layoutFile = LayoutController.GetLayoutFileName ("Default", -1);
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
                            "Querystring is invalid, The layoutportalid argument is required.", 
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
                var layoutFile = LayoutController.GetLayoutFileName (layoutName, layoutPortaId);

                if (layoutName != originalLayoutName && File.Exists (layoutFile)) {
                    WarningMessage ("LayoutFileAlreadyExists.Warning");
                    return;
                }

                File.WriteAllText (layoutFile, layoutEditor.Text);

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

                if (LayoutController.IsLayoutInUse (layoutName, PortalId)) {
                    WarningMessage ("LayoutIsInUse.Warning");
                    return;
                }

                var layoutFile = LayoutController.GetLayoutFileName (layoutName, layoutPortaId);
                File.Delete (layoutFile);

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
