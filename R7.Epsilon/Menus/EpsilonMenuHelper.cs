using System;
using System.Web;
using DotNetNuke.Web.DDRMenu;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Services.Localization;
using R7.Epsilon.Components;

namespace R7.Epsilon.Menus
{
    public class EpsilonMenuHelper
    {
        const string resourceFileRoot = Const.SKIN_PATH + "App_LocalResources/Fake.ascx.resx";

        readonly HtmlString EmptyHtmlString = new HtmlString ("");

        readonly string UrlFormat;

        readonly string ControlId;

        public EpsilonMenuHelper (string controlId)
        {
            ControlId = controlId;
        }

        public EpsilonMenuHelper (string controlId, string urlFormat)
        {
            ControlId = controlId;
            UrlFormat = urlFormat;
        }

        public string Id (MenuNode node, string prefix)
        {
            return ControlId + "_" + prefix + node.TabId;
        }

        public string GetString (string resourceKey)
        {
            return Localization.GetString (resourceKey, resourceFileRoot);
        }

        public string FormatDate (MenuNode node)
        {
            var date = DateTime.Parse (node.CommandArgument);
            return date.ToString (GetString ("Menu_DateFormat.Text"));
        }

        public HtmlString RenderNodeBadge (MenuNode node)
        {
            if (node.CommandName == "X-Date") {
                return new HtmlString ($"<span class=\"badge badge-primary\">{FormatDate (node)}</span> ");
            }

            return EmptyHtmlString;
        }

        public string FormatUrl (MenuNode node)
        {
            return FormatUrl (node, UrlFormat);
        }

        public string FormatUrl (MenuNode node, string urlFormat)
        {
            if (!node.Enabled) {
                // TODO: GH-204
                return "/";
            }
            if (node.TabId <= 0 || string.IsNullOrEmpty (UrlFormat)) {
                return node.Url;
            }
            return EpsilonUrlHelper.FormatUrl (UrlFormat, node.TabId, PortalSettings.Current.PortalId, HttpContext.Current.Request.QueryString);
        }

        public string FormatTabId (MenuNode node)
        {
            return (node.TabId > 0) ? node.TabId.ToString () : string.Empty;
        }

        string NodeActiveCssClass (MenuNode node)
        {
            // "active" class will be set via JS
            return string.Empty;
        }

        string NodeDisabledCssClass (MenuNode node)
        {
            return !node.Enabled ? "disabled" : string.Empty;
        }

        public string ForkNodeCssClasses (MenuNode node)
        {
            return NodeActiveCssClass (node);
        }

        public string LeafNodeCssClasses (MenuNode node)
        {
            return (NodeActiveCssClass (node) + " " + NodeDisabledCssClass (node)).Trim ();
        }
    }
}
