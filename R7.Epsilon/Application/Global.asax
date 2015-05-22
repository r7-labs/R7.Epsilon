<%@ Application Inherits="DotNetNuke.Web.Common.Internal.DotNetNukeHttpApplication" Language="C#" %>
<%@ Import Namespace="DotNetNuke.Entities.Portals" %>
<script runat="server">
public override string GetVaryByCustomString (HttpContext context, string arg)
{
    if (string.Compare (arg, "PortalId", StringComparison.InvariantCultureIgnoreCase) == 0)
    {
        return "portalid=" + PortalSettings.Current.PortalId;
    }

    return base.GetVaryByCustomString(context, arg);
}
</script>