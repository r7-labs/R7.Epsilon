<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.PageInfo" %>
<%@ OutputCache Duration="1200" VaryByParam="TabId;Language" %>
<div class="skin-page-info">
    <% if (ShowPageInfo) { %>
    <small><%: PublishedMessage %></small>
    <% } %>
    <% if (ShowShareButtons) { %> <%-- TODO: Add link@rel='canonical' --%> <div class="skin-page-share-buttons">
        <% if (Config.VkShareEnabled) { %><div id="vk_like"></div><% } %>
        <div class="fb-like" data-href="<%= PortalSettings.ActiveTab.FullUrl %>" data-layout="button_count" data-action="like" data-show-faces="false" data-share="false"></div>
        <a class="twitter-share-button" href="https://twitter.com/share" data-url="<%= PortalSettings.ActiveTab.FullUrl %>" data-lang="<%= CultureInfo.CurrentCulture.TwoLetterISOLanguageName %>" data-via="<%= Config.TwitterVia %>">Tweet</a>
        <div class="g-plusone" data-size="medium"></div>
    </div><% } %>
</div>