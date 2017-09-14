<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ OutputCache Duration="1200" VaryByParam="TabId;Language" %>
<%
var vk = Config.SocialNetworks.FirstOrDefault (n => n.Name == "VKontakte" && n.ShareEnabled);
var fb = Config.SocialNetworks.FirstOrDefault (n => n.Name == "Facebook" && n.ShareEnabled);
var tw = Config.SocialNetworks.FirstOrDefault (n => n.Name == "Twitter" && n.ShareEnabled);
var gp = Config.SocialNetworks.FirstOrDefault (n => n.Name == "GooglePlus" && n.ShareEnabled);
%>
<div class="skin-social-share-buttons">
    <% if (vk != null) { %><div id="vk_like"></div><% } %>
    <% if (fb != null) { %><div class="fb-like" data-href="<%= PortalSettings.ActiveTab.FullUrl %>" data-layout="button_count" data-action="like" data-show-faces="false" data-share="false"></div><% } %>
    <% if (tw != null) { %><a class="twitter-share-button" href="https://twitter.com/share" data-url="<%= PortalSettings.ActiveTab.FullUrl %>" data-lang="<%= CultureInfo.CurrentCulture.TwoLetterISOLanguageName %>" data-via="<%= tw.Params [0] %>">Tweet</a><% } %>
    <% if (gp != null) { %><div class="g-plusone" data-size="medium"></div><% } %>
</div>

