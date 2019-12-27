//
//  File: EpsilonMenuHelper.cs
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
using System.Web;
using DotNetNuke.Web.DDRMenu;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Services.Localization;
using R7.Zeta.Components;

namespace R7.Zeta.Menus
{
    public static class EpsilonMenuHelper
    {
        const string resourceFileRoot = Const.SKIN_PATH + "App_LocalResources/Fake.ascx.resx";

        static readonly HtmlString EmptyHtmlString = new HtmlString ("");

        public static string GetString (string resourceKey)
        {
            return Localization.GetString (resourceKey, resourceFileRoot);
        }

        public static string FormatDate (MenuNode node)
        {
            var date = DateTime.Parse (node.CommandArgument);
            return date.ToString (GetString ("Menu_DateFormat.Text"));
        }

        public static HtmlString RenderNodeBadge (MenuNode node)
        {
            if (node.CommandName == "X-Date") {
                return new HtmlString ($"<span class=\"badge badge-primary\">{FormatDate (node)}</span> ");
            }

            return EmptyHtmlString;
        }
        public static string FormatUrl (MenuNode node, string urlFormat)
        {
            if (!node.Enabled) {
                return "#";
            }
            if (string.IsNullOrEmpty (urlFormat)) {
                return node.Url;
            }
            return EpsilonUrlHelper.FormatUrl (urlFormat, node.TabId, PortalSettings.Current.PortalId, HttpContext.Current.Request.QueryString);
        }

        static string NodeActiveCssClass (MenuNode node)
        {
            return node.Selected ? "active" : string.Empty;
        }

        static string NodeDisabledCssClass (MenuNode node)
        {
            return !node.Enabled ? "disabled" : string.Empty;
        }

        public static string ForkNodeCssClasses (MenuNode node)
        {
            return NodeActiveCssClass (node);
        }

        public static string LeafNodeCssClasses (MenuNode node)
        {
            return (NodeActiveCssClass (node) + " " + NodeDisabledCssClass (node)).Trim ();
        }
    }
}
