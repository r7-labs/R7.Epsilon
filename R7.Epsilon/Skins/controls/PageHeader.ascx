<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.PageHeader" %>

<%-- TODO: Display permalink on hover --%>
 
<h1>
    <a href="<%= PortalSettings.ActiveTab.FullUrl %>" alt="<%: PortalSettings.ActiveTab.Title %>" title="<%: PortalSettings.ActiveTab.Title %>"><%: PortalSettings.ActiveTab.TabName %></a>
    <small><%: TagLine %></small>
</h1>
<small><%: PublishedMessage %></small>