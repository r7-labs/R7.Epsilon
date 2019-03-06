//
//  PopupSkin.ascx.cs
//
//  Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2017 Roman M. Yagodin
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
using DotNetNuke.Web.Client;
using DotNetNuke.Web.Client.ClientResourceManagement;

namespace R7.Epsilon.Skins
{
    public class PopupSkin : EpsilonSkinBase
    {
        protected override void OnInit (EventArgs e)
        {
            base.OnInit (e);

            var loadThemeParam = Request.QueryString ["loadTheme"];
            if (loadThemeParam != null) {
                bool loadTheme;
                if (bool.TryParse (loadThemeParam, out loadTheme)) {
                    if (loadTheme) {
                        ClientResourceManager.RegisterStyleSheet (Page, SkinPath + "css/bootstrap.min.css", (int) FileOrder.Css.SkinCss - 1, "DnnPageHeaderProvider", "bootstrap", "4.3.1");
                        ClientResourceManager.RegisterStyleSheet (Page, SkinPath + Config.SkinCss);
                        ClientResourceManager.RegisterScript (Page, SkinPath + "js/bootstrap.min.js", (int) FileOrder.Js.jQueryUI, "DnnFormBottomProvider", "bootstrap", "4.3.1");
                    }
                }
            }
        }
    }
}