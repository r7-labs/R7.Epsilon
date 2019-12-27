<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.PageHeader" %>
<h1 class="skin-page-header">
    <a href="<%= ActiveTab.FullUrl %>" title="<%: ActiveTab.Title %>"><%: ActiveTab.LocalizedTabName %></a>
    <% if (!string.IsNullOrEmpty (TagLine)) { %>
		<small><%: TagLine %></small>
	<% } %>
</h1>
