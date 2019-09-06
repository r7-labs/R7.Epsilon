<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.PageHeader" %>
<h1 class="skin-page-header">
    <a href="<%= PortalSettings.ActiveTab.FullUrl %>" title="<%: PortalSettings.ActiveTab.Title %>"><%: PortalSettings.ActiveTab.LocalizedTabName %></a>
    <% if (!string.IsNullOrEmpty (TagLine)) { %>
		<small><%: TagLine %></small>
	<% } %>
</h1>
