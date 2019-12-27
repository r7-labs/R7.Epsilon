//
//  File: Includes.ascx.cs
//  Project: R7.Zeta
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
using DotNetNuke.Common;
using DotNetNuke.Web.Client;
using DotNetNuke.Web.Client.ClientResourceManagement;
using DotNetNuke.Framework.JavaScriptLibraries;
using R7.Zeta.Components;

namespace R7.Zeta.Skins.SkinObjects
{
    public class Includes: EpsilonSkinObjectBase
    {
        protected override void OnLoad (EventArgs e)
        {
            ClientResourceManager.RegisterStyleSheet (Page, Const.SKIN_PATH + "css/bootstrap.min.css", (int) FileOrder.Css.SkinCss, "DnnPageHeaderProvider", "bootstrap", "4.3.1");

            var fontAwesome = JavascriptLibraryHelper.GetHighestVersionLibrary ("FontAwesome");
            if (fontAwesome != null) {
                ClientResourceManager.RegisterStyleSheet (Page, "/Resources/Libraries/FontAwesome/"
                    + Globals.FormatVersion (fontAwesome.Version, "00", 3, "_") + "/css/all.min.css",
                    (int) FileOrder.Css.SkinCss, "DnnPageHeaderProvider", "font-awesome", fontAwesome.Version.ToString ()
                );
            }

            JavaScript.RequestRegistration ("jQuery-BlueimpGallery");
            var blueimpLibrary = JavascriptLibraryHelper.GetHighestVersionLibrary ("jQuery-BlueimpGallery");
            if (blueimpLibrary != null) {
                ClientResourceManager.RegisterStyleSheet (Page, "/Resources/Libraries/jQuery-BlueimpGallery/"
                    + Globals.FormatVersion (blueimpLibrary.Version, "00", 3, "_") + "/css/blueimp-gallery.min.css",
                    (int) FileOrder.Css.SkinCss, "DnnPageHeaderProvider", "blueimp-gallery", blueimpLibrary.Version.ToString ()
                );
            }

            ClientResourceManager.RegisterStyleSheet (Page, Const.SKIN_PATH + "css/" + (Config.GetTheme (Request) ?? Config.Themes [0]).Css, (int) FileOrder.Css.SkinCss, "DnnPageHeaderProvider", "skin", "0.0.0");

            ClientResourceManager.RegisterScript (Page, Const.SKIN_PATH + "js/bootstrap.bundle.min.js", (int) FileOrder.Js.DefaultPriority, "DnnFormBottomProvider", "bootstrap", "4.3.1");

            ClientResourceManager.RegisterScript (Page, Const.SKIN_PATH + "js/skin.min.js", (int) FileOrder.Js.DefaultPriority, "DnnFormBottomProvider", "skin", "0.0.0");

            ClientResourceManager.RegisterScript (Page, Const.SKIN_PATH + "js/feedback.min.js", (int) FileOrder.Js.DefaultPriority, "DnnFormBottomProvider", "feedback", "0.0.0");

            ClientResourceManager.RegisterScript (Page, Const.SKIN_PATH + "js/clipboard.min.js", (int) FileOrder.Js.DefaultPriority, "DnnFormBottomProvider", "clipboard", "2.0.4");

            if (!Skin.Options.DisableLazyAds) {
                JavaScript.RequestRegistration ("LazyAds");
            }

            if (!Skin.Options.DisableRangy) {
                JavaScript.RequestRegistration ("Rangy");
            }
        }
    }
}
