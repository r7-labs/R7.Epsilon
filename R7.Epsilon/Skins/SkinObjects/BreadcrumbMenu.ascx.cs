//
//  File: BreadcrumbMenu.ascx.cs
//  Project: R7.Zeta
//
//  Author: Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2014-2019 Roman M. Yagodin, R7.Labs
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
using System.Collections.Generic;
using DotNetNuke.Web.DDRMenu.TemplateEngine;
using R7.Zeta.Menus;
using DDRMenu = DotNetNuke.Web.DDRMenu;

namespace R7.Zeta.Skins.SkinObjects
{
    public class BreadcrumbMenu: EpsilonMenuBase
    {
        #region Controls

        protected DDRMenu.SkinObject breadcrumbMenu;

        #endregion

        protected override void OnInit (EventArgs e)
        {
            Menu = breadcrumbMenu;
            Menu.NodeSelector = Config.BreadcrumbMenu.NodeSelector;
            Menu.IncludeNodes = Config.BreadcrumbMenu.IncludeNodes;
            Menu.ExcludeNodes = Config.BreadcrumbMenu.ExcludeNodes ?? Config.Menu.ExcludeNodes;

            if (Menu.TemplateArguments == null) {
                Menu.TemplateArguments = new List<TemplateArgument> ();
            }

            Menu.TemplateArguments.Add (new TemplateArgument ("UrlFormat", Config.BreadcrumbMenu.UrlFormat ?? Config.Menu.UrlFormat));

            Menu.NodeManipulator = typeof (EpsilonNodeManipulator<BreadcrumbMenu>).FullName;

            base.OnInit (e);
        }
    }
}
