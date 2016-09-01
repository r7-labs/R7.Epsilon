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
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Tabs;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Log.EventLog;
using R7.Epsilon.LayoutManager.Components;
using R7.Epsilon.LayoutManager.Models;

namespace R7.Epsilon.LayoutManager
{
    public partial class SelectLayout : PortalModuleBase
    {
        #region Properties

        int? fromTabId;

        /// <summary>
        /// Identifier of tab from which module is called
        /// </summary>
        protected int? FromTabId
        {
            get {
                if (fromTabId == null) {
                    var fromTabIdStr = Request.QueryString ["fromtabid"];
                    if (!string.IsNullOrWhiteSpace (fromTabIdStr)) {
                        int fromTabIdInt;
                        if (int.TryParse (fromTabIdStr, out fromTabIdInt)) {
                            fromTabId = fromTabIdInt;
                        }
                    }
                }

                return fromTabId;
            }
        }

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
            } 
            else {
                linkCancel.NavigateUrl = GetReturnUrl ();
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

                    if (FromTabId == null) {
                        // fromtabid argument is required, but don't expose it to end-user
                        EventLogController.Instance.AddLog (
                            "R7.Epsilon.LayoutManager.SelectLayout", 
                            "Querystring is invalid. The 'fromtabid' argument is required.", 
                            EventLogController.EventLogType.HOST_ALERT
                        );
                        
                        Response.Redirect (Globals.NavigateURL (), true);
                        return;
                    }

                    BindLayouts (PortalId);

                    // select existing values
                    var tabSettings = TabController.Instance.GetTabSettings (FromTabId.Value);

                    var layoutName = (string) tabSettings [Const.LAYOUT_TAB_SETTING_NAME];
                    if (layoutName != null) {
                        comboLayout.SelectedValue = layoutName;
                    }

                    var a11yLayoutName = (string) tabSettings [Const.A11Y_LAYOUT_TAB_SETTING_NAME];
                    if (a11yLayoutName != null) {
                        comboA11yLayout.SelectedValue = a11yLayoutName;
                    }
                }
            } 
            catch (Exception ex) {
                Exceptions.ProcessModuleLoadException (this, ex);
            }
        }

        /// <summary>
        /// Handles Click event for Select button
        /// </summary>
        /// <param name='sender'>
        /// Sender.
        /// </param>
        /// <param name='e'>
        /// Event args.
        /// </param>
        protected void buttonSelect_Click (object sender, EventArgs e)
        {
            try {
                
                if (comboLayout.SelectedIndex > 0) {
                    // update tab setting
                    TabController.Instance.UpdateTabSetting (FromTabId.Value, Const.LAYOUT_TAB_SETTING_NAME, comboLayout.SelectedValue);
                }
                else {
                    // delete tab setting
                    TabController.Instance.DeleteTabSetting (FromTabId.Value, Const.LAYOUT_TAB_SETTING_NAME);
                }

                if (comboA11yLayout.SelectedIndex > 0) {
                    // update tab setting
                    TabController.Instance.UpdateTabSetting (FromTabId.Value, Const.A11Y_LAYOUT_TAB_SETTING_NAME, comboA11yLayout.SelectedValue);
                } else {
                    // delete tab setting
                    TabController.Instance.DeleteTabSetting (FromTabId.Value, Const.A11Y_LAYOUT_TAB_SETTING_NAME);
                }

                Response.Redirect (GetReturnUrl (), true);
            } 
            catch (Exception ex) {
                Exceptions.ProcessModuleLoadException (this, ex);
            }
        }

        #endregion

        protected void BindLayouts (int portalId)
        {
            var layouts = LayoutController.GetLayouts (portalId)
                                          .OrderByDescending (L => L.PortalId == Const.HOST_PORTAL_ID)
                                          .ThenBy (L => L.Name);

            FillLayoutComboBox (comboLayout, layouts);
            FillLayoutComboBox (comboA11yLayout, layouts);
        }

        protected void FillLayoutComboBox (DropDownList comboLayout, IEnumerable<LayoutInfo> layouts)
        {
            comboLayout.Items.Clear ();

            // add default item
            comboLayout.Items.Add (new ListItem (LocalizeString ("NotSelected.Text"), int.MinValue.ToString ()));

            foreach (var layout in layouts) {
                var item = new ListItem (layout.Name, LayoutController.SettingValuePrefix (layout.PortalId) + layout.Name);

                // mark host layouts
                if (layout.PortalId == Const.HOST_PORTAL_ID) {
                    item.Attributes.Add ("style", "font-weight:bold");
                }

                comboLayout.Items.Add (item);
            }
        }

        protected string GetReturnUrl ()
        {
            return (FromTabId != null)? Globals.NavigateURL (FromTabId.Value) : Globals.NavigateURL ();
        }
    }
}
