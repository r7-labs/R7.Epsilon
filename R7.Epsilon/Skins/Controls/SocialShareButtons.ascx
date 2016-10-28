<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Components.EpsilonSkinObjectBase" %>
<%@ OutputCache Duration="1200" VaryByParam="TabId;Language" %>
<div class="skin-social-share-buttons">
    <% if (Config.Vk.ShareEnabled) { %><div id="vk_like"></div><% } %>
    <% if (Config.Facebook.ShareEnabled) { %><div class="fb-like" data-href="<%= PortalSettings.ActiveTab.FullUrl %>" data-layout="button_count" data-action="like" data-show-faces="false" data-share="false"></div><% } %>
    <% if (Config.Twitter.ShareEnabled) { %><a class="twitter-share-button" href="https://twitter.com/share" data-url="<%= PortalSettings.ActiveTab.FullUrl %>" data-lang="<%= CultureInfo.CurrentCulture.TwoLetterISOLanguageName %>" data-via="<%= Config.Twitter.Via %>">Tweet</a><% } %>
    <% if (Config.Google.ShareEnabled) { %><div class="g-plusone" data-size="medium"></div><% } %>
</div>

