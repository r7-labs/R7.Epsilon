<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.PageHeader" %>
<%@ OutputCache Duration="1200" VaryByParam="TabId;Language" %>
<h1>
    <a href="<%= PortalSettings.ActiveTab.FullUrl %>" title="<%: PortalSettings.ActiveTab.Title %>"><%: Title %></a>
    <small><%: TagLine %></small>
</h1>