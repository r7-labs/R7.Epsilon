<%@ Application Inherits="DotNetNuke.Web.Common.Internal.DotNetNukeHttpApplication" Language="C#" %>
<%@ Import Namespace="System.Text" %>
<%@ Import Namespace="DotNetNuke.Entities.Portals" %>
<%@ Import Namespace="DotNetNuke.Entities.Users" %>
<%@ Import Namespace="R7.Epsilon.Components" %>
<script runat="server">
public override string GetVaryByCustomString (HttpContext context, string custom)
{
    var result = new StringBuilder ();
    foreach (var part in custom.Split (';'))
    {
        if (part == "PortalId") {
            result.Append ("portalid=");
            result.Append (PortalSettings.Current.PortalId);
        }
        else if (part == "UserRoles") {
            if (Request.IsAuthenticated) {
                var user = UserController.Instance.GetCurrentUserInfo ();
                if (user != null) {
                    result.Append ("userroles=");
                    result.Append (Utils.FormatList (",", (Array) user.Roles));
                }
            }
        }
        else {
            result.Append (base.GetVaryByCustomString (context, custom));
        }
    }

    return result.ToString ();
}
</script>