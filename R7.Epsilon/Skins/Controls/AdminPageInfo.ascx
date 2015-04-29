<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.AdminPageInfo" %>
<%@ Import Namespace="DotNetNuke.Security" %>
<% if (PortalSecurity.IsInRole ("Administrators")) { %>
    <div class="skin-admin-page-info alert alert-warning">
        <a class="skin-page-permalink" href="<%= PagePermalink %>" title="<%: Localizer.GetString ("PagePermalink.Tooltip") %>"><%= Localizer.GetString ("PagePermalink.Text") %></a>
    </div>
<% } %>