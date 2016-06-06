<%@ Application Inherits="DotNetNuke.Web.Common.Internal.DotNetNukeHttpApplication" Language="C#" %>
<%@ Import Namespace="DotNetNuke.Entities.Portals" %>
<%@ Import Namespace="DotNetNuke.Entities.Users" %>
<%@ Import Namespace="R7.Epsilon.Components" %>
<script runat="server">
public override string GetVaryByCustomString (HttpContext context, string arg)
{
    var result = string.Empty;
    foreach (var part in arg.Split (';'))
    {
        if (part == "PortalId") {
            result += "portalid=" + PortalSettings.Current.PortalId;
        }
        else if (part == "UserRoles") {
            if (Request.IsAuthenticated) {
                var user = UserController.GetCurrentUserInfo ();
                if (user != null)
                    result += "userroles=" + Utils.FormatList (",", (Array)user.Roles);
            }
        }
        else {
            result += base.GetVaryByCustomString (context, arg);
        }
    }

    return result;
}
</script>