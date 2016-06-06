//
// MenuBase.cs
//
// Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
// Copyright (c) 2015 
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
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using DotNetNuke.Entities.Portals;
using System.Web.UI.WebControls;
using System.Web.Security;
using DotNetNuke.UI.WebControls;
using DotNetNuke.Web.DDRMenu.TemplateEngine;

// aliases
using DDRMenu = DotNetNuke.Web.DDRMenu;

namespace R7.Epsilon.Components
{
    public abstract class EpsilonMenuBase: EpsilonSkinObjectBase
    {
        #region Controls

        protected DDRMenu.SkinObject Menu;

        /*
        protected DDRMenu.SkinObject menu;

        public DDRMenu.SkinObject Menu
        {
            get
            {
                if (menu == null)
                {
                    // find menu control
                    foreach (Control control in Controls)
                    {
                        if (control.ID != null && control.ID.StartsWith ("menu", StringComparison.InvariantCultureIgnoreCase))
                        {
                            menu = (DDRMenu.SkinObject) control;
                            break;
                        }
                    }
                }

                return menu;
            }
        }
        */

        #endregion

        #region Properties

        public bool PassDefaultTemplateArgs { get; set; }

        #endregion

        protected EpsilonMenuBase ()
        {
            PassDefaultTemplateArgs = true;
        }
       
        protected override void OnInit (EventArgs e)
        {
            base.OnInit (e);

            /* 
            // init menu
            switch (Menu.ID)
            {
                case "menuLocal":
                case "menuHeaders":
                    Menu.IncludeNodes = PortalSettings.ActiveTab.TabID.ToString ();
                    break;
                case "menuPrimary":
                    Menu.NodeSelector = Config.PrimaryMenuNodeSelector;
                    Menu.IncludeNodes = Config.PrimaryMenuIncludeNodes;
                    break;
                case "menuSecondary":
                    Menu.NodeSelector = Config.SecondaryMenuNodeSelector;
                    Menu.IncludeNodes = Config.SecondaryMenuIncludeNodes;
                    break;
            }
            */

            if (PassDefaultTemplateArgs)
            {
                // configurable menu template arguments
                var menuTemplateArgs = new List<TemplateArgument> ()
                {
                    new TemplateArgument ("urlType", Config.MenuUrlType.ToString ()) 
                };

                // set menu template arguments
                SetMenuTemplateArguments (Menu, menuTemplateArgs);
            }
        }

        private void SetMenuTemplateArguments (DDRMenu.SkinObject menu, List<TemplateArgument> args)
        {
            // check if menu exists for various skin derivatives
            if (menu != null)
            {
                if (menu.TemplateArguments != null)
                    menu.TemplateArguments.AddRange (args);
                else
                    menu.TemplateArguments = args;
            }
        }
    }
}
