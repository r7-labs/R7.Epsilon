<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.SocialShareButtons" %>
<%@ OutputCache Duration="1200" VaryByParam="TabId;Language" %>
<div class="skin-social-share-buttons">
    <% if (Config.VkShareEnabled) { %><div id="vk_like"></div><% } %>
    <% if (Config.FacebookShareEnabled) { %><div class="fb-like" data-href="<%= PortalSettings.ActiveTab.FullUrl %>" data-layout="button_count" data-action="like" data-show-faces="false" data-share="false"></div><% } %>
    <% if (Config.TwitterShareEnabled) { %><a class="twitter-share-button" href="https://twitter.com/share" data-url="<%= PortalSettings.ActiveTab.FullUrl %>" data-lang="<%= CultureInfo.CurrentCulture.TwoLetterISOLanguageName %>" data-via="<%= Config.TwitterVia %>">Tweet</a><% } %>
    <% if (Config.GoogleShareEnabled) { %><div class="g-plusone" data-size="medium"></div><% } %>
</div>

