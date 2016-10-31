<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.PageInfo" %>
<%@ OutputCache Duration="1200" VaryByParam="TabId;Language" %>
<% if (ShowPageInfo) { %>
<div class="skin-page-info">
    <span class="glyphicon glyphicon-calendar"></span> <%: PublishedOnDate %>
    <span class="glyphicon glyphicon-user"></span> <%: PublishedByUserName %>
</div>
<% } %>