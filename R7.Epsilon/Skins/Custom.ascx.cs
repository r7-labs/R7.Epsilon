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

namespace R7.Epsilon
{
    public partial class Custom : EpsilonSkinBase
    {
        // TODO: Move to the EpsilonSkinBase class
        protected PlaceHolder placeDynamicPanes;

        protected override void OnInit (EventArgs e)
        {
            if (placeDynamicPanes != null) {

                try {
                    // load layout file
                    var layoutMarkup = File.ReadAllText (
                        Path.Combine (Globals.HostMapPath, "Skins\\R7.Epsilon\\Layouts\\Layout1.xml")
                    );

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
                    Exceptions.ProcessPageLoadException (new Exception ("Cannot load layout", ex));
                }
            }

            base.OnInit (e);

            /*
            var tabSettings = TabController.Instance.GetTabSettings (TabId);

            foreach (var paneKey in Panes.Keys)
            {
                // panekey in setting / db must be in lowercase: TopPane => r7_Epsilon_toppane_CssClass

                var setting = tabSettings ["r7_Epsilon_" + paneKey + "_CssClass"];
                if (setting != null)
                {
                    var pane = (HtmlControl) FindControl (paneKey);
                    if (pane != null)
                    {
                        pane.Attributes.Add ("class", (string) setting);
                    }
                }
            }*/
        }

        protected void buttonTestPostBack_Click (object sender, EventArgs e)
        {
        }
    }
}