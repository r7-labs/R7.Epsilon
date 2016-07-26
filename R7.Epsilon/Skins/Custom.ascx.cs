//
// Custom.ascx.cs
//
// Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
// Copyright (c) 2014 
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
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Web.UI;
using R7.Epsilon.Components;
using System.IO;
using DotNetNuke.Common;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Tabs;
using DotNetNuke.Entities.Portals;

namespace R7.Epsilon
{
    public partial class Custom : EpsilonSkinBase
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
                    var layoutName = (layoutSetting != null)? (string) layoutSetting : "Default";
                   
                    // load layout
                    var layoutMarkup = File.ReadAllText (GetLayoutFile (layoutName));

                    // parse layout to list of panes
                    var listPanes = MarkupParser.ParseLayout (layoutMarkup);

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
                catch (Exception ex) {
                    Exceptions.ProcessPageLoadException (new Exception (ex.Message, ex));
                }
            }

            base.OnInit (e);
        }

        const string layoutsFolder = "Skins\\R7.Epsilon\\Layouts\\";

        protected string GetLayoutFile (string layoutName)
        {
            // REVIEW: Use HomeDirectoryMapPath instead?
            var portalLayoutFile = Path.Combine (PortalSettings.Current.HomeSystemDirectoryMapPath, layoutsFolder + layoutName + ".xml");
            if (File.Exists (portalLayoutFile)) {
                return portalLayoutFile;
            }
            else {
                var hostLayoutFile = Path.Combine (Globals.HostMapPath, layoutsFolder + layoutName + ".xml");
                if (File.Exists (hostLayoutFile)) {
                    return hostLayoutFile;
                }
            }

            throw new Exception (string.Format ("Cannot find layout file \"{0}.xml\"", layoutName));
        }

        protected void buttonTestPostBack_Click (object sender, EventArgs e)
        {
        }
    }
}