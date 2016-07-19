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
using System.Linq;
using System.Collections.Generic;
using System.Web.UI;
using R7.Epsilon.Components;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using System.IO;
using DotNetNuke.Common;

namespace R7.Epsilon
{

    public partial class Custom : EpsilonSkinBase
    {
        protected string Message { get; set; }

        protected override void OnInit (EventArgs e)
        {
            using (var textReader = new StringReader (File.ReadAllText (Path.Combine (
                                        Globals.HostMapPath,
                                        "Skins\\R7.Epsilon\\Layouts\\Layout1.yml")))) {

                var deserializer = new Deserializer (namingConvention: new HyphenatedNamingConvention ());
                var layout = deserializer.Deserialize<Layout> (textReader);
            
                var docks = Controls
                .Cast<Control> ()
                .Where (c => c.GetType () == typeof (PlaceHolder))
                .Cast<PlaceHolder> ()
                .ToDictionary (p => p.ID, p => p);

                foreach (var dock in layout.Docks) {
                    foreach (var pane in dock.Panes) {

                        var paneControl = new HtmlGenericControl ("div");
                        paneControl.ID = pane.Pane;

                        if (!string.IsNullOrWhiteSpace (pane.Class)) {
                            paneControl.Attributes.Add ("class", pane.Class);
                        }

                        if (!string.IsNullOrWhiteSpace (pane.ContainerType)) {
                            paneControl.Attributes.Add ("containertype", pane.ContainerType);
                        }

                        if (!string.IsNullOrWhiteSpace (pane.ContainerName)) {
                            paneControl.Attributes.Add ("containername", pane.ContainerName);
                        }

                        if (!string.IsNullOrWhiteSpace (pane.ContainerSrc)) {
                            paneControl.Attributes.Add ("containersrc", pane.ContainerSrc);
                        }

                        Controls.AddAt (Controls.IndexOf (docks [dock.Dock]), paneControl);
                    }
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