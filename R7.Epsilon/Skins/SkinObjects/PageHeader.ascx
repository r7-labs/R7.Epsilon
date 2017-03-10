<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.PageHeader" %>
<h1>
    <a href="<%= PortalSettings.ActiveTab.FullUrl %>" title="<%: PortalSettings.ActiveTab.Title %>"><%: Title %></a>
    <small><%: TagLine %></small>
</h1>