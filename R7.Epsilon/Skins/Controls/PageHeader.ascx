<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.PageHeader" %>
<%@ OutputCache Duration="1200" VaryByParam="TabId;Language" %>
<h1>
    <a href="<%= PortalSettings.ActiveTab.FullUrl %>" title="<%: PortalSettings.ActiveTab.Title %>"><%: PortalSettings.ActiveTab.TabName %></a>
    <small><%: TagLine %></small>
</h1>