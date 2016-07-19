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

namespace R7.Epsilon
{
    public class PaneInfo
    {
        public string Place { get; set; }
    
        public string Name { get; set; }

        public string Class { get; set; }

        // default container?
    }

    public partial class Custom : EpsilonSkinBase
    {
        public Custom ()
		{
		}

        protected PlaceHolder placeLayout;

        protected string Message { get; set; }

        protected override void OnInit (EventArgs e)
        {
            // TODO: Load from layout file
            var panes = new [] {
                new PaneInfo { Place = "panesRow1", Name = "ContentPane", Class="col-md-9 col-sm-7" },
                new PaneInfo { Place = "panesRow1", Name = "RightPane", Class="col-md-3 col-sm-5" }
            };

            var places = Controls
                .Cast<Control> ()
                .Where (c => c.GetType () == typeof (PlaceHolder))
                .Cast<PlaceHolder> ()
                .ToDictionary (p => p.ID, p => p);

            foreach (var pane in panes) {
                var paneControl = new HtmlGenericControl ("div");
                paneControl.ID = pane.Name;
                paneControl.Attributes.Add ("class", pane.Class);

                Controls.AddAt (Controls.IndexOf (places [pane.Place]), paneControl);
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
        {}
    }
}