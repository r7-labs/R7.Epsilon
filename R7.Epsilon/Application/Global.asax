<%@ Application Inherits="DotNetNuke.Web.Common.Internal.DotNetNukeHttpApplication" Language="C#" %>
<script runat="server">
public override string GetVaryByCustomString (HttpContext context, string custom)
{
    return R7.Epsilon.Components.CacheHelper.GetVaryByCustomString (context, custom, Request, base.GetVaryByCustomString);
}
</script>