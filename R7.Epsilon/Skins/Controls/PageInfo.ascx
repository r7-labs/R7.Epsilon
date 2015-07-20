<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.PageInfo" %>
<%@ OutputCache Duration="1200" VaryByParam="TabId;Language" %>
<div class="skin-page-info">
    <% if (ShowPageInfo) { %>
    <small><%: PublishedMessage %></small>
    <% } %>
</div>