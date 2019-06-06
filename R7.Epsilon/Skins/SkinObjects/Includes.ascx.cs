//
//  File: Includes.ascx.cs
//  Project: R7.Epsilon
//
//  Author: Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2015-2019 Roman M. Yagodin, R7.Labs
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
using System.Linq;
using System.Text;
using System.Web.Caching;
using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Tabs;
using R7.Epsilon.Components;
using DotNetNuke.Web.Client;
using DotNetNuke.Web.Client.ClientResourceManagement;
using DotNetNuke.Framework.JavaScriptLibraries;

namespace R7.Epsilon.Skins.SkinObjects
{
    public class Includes: EpsilonSkinObjectBase
    {
        protected string SkinPath => Skin.SkinPath;

        private ThemeConfig GetTheme ()
        {
            var theme = Config.GetTheme (Request);
            if (theme != null) {
                Config.SetThemeCookie (Response, theme.Name);
                return theme;
            }
            return Config.Themes [0];
        }

        protected override void OnLoad (EventArgs e)
        {
            ClientResourceManager.RegisterStyleSheet (Page, SkinPath + "css/bootstrap.min.css", (int) FileOrder.Css.SkinCss, "DnnPageHeaderProvider", "bootstrap", "4.3.1");

            ClientResourceManager.RegisterStyleSheet (Page, SkinPath + "css/" + GetTheme ().Css, (int) FileOrder.Css.SkinCss, "DnnPageHeaderProvider", "skin", "0.0.0");

            ClientResourceManager.RegisterScript (Page, SkinPath + "js/bootstrap.bundle.min.js", (int) FileOrder.Js.DefaultPriority, "DnnFormBottomProvider", "bootstrap", "4.3.1");

            ClientResourceManager.RegisterScript (Page, SkinPath + "js/skin.min.js", (int) FileOrder.Js.DefaultPriority, "DnnFormBottomProvider", "skin", "0.0.0");

            if (Attributes ["MenuJs"] != "false") {
                ClientResourceManager.RegisterScript (Page, SkinPath + "js/menu.min.js", (int) FileOrder.Js.DefaultPriority, "DnnFormBottomProvider", "menu", "0.0.0");
            }

            ClientResourceManager.RegisterScript (Page, SkinPath + "js/feedback.min.js", (int) FileOrder.Js.DefaultPriority, "DnnFormBottomProvider", "feedback", "0.0.0");

            if (Attributes ["LazyAds"] != "false") {
                JavaScript.RequestRegistration ("LazyAds");
            }

            if (Attributes ["Rangy"] != "false") {
                JavaScript.RequestRegistration ("Rangy");
            }
        }
    }
}
