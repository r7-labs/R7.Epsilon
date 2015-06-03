<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.AdminPageInfo" %>
<%@ Import Namespace="DotNetNuke.Security" %>
<% if (PortalSecurity.IsInRole ("Administrators")) { %>
    <div class="skin-admin-page-info alert alert-info alert-dismissible">
        <button type="button" class="close" data-dismiss="alert"><span>&times;</span></button>
        <a class="btn btn-default" href="<%= PagePermalink %>" title="<%: Localizer.GetString ("PagePermalink.Tooltip") %>"><%= Localizer.GetString ("PagePermalink.Text") %></a>
    </div>
<% } %>