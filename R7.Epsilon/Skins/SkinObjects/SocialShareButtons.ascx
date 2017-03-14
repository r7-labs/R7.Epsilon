<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ OutputCache Duration="1200" VaryByParam="TabId;Language" %>
<%
var vk = Config.SocialNetworks.SingleOrDefault (n => n.Name == "VKontakte");
var fb = Config.SocialNetworks.SingleOrDefault (n => n.Name == "Facebook");
var tw = Config.SocialNetworks.SingleOrDefault (n => n.Name == "Twitter");
var gp = Config.SocialNetworks.SingleOrDefault (n => n.Name == "GooglePlus");
%>
<div class="skin-social-share-buttons">
    <% if (vk != null && vk.ShareEnabled) { %><div id="vk_like"></div><% } %>
    <% if (fb != null && fb.ShareEnabled) { %><div class="fb-like" data-href="<%= PortalSettings.ActiveTab.FullUrl %>" data-layout="button_count" data-action="like" data-show-faces="false" data-share="false"></div><% } %>
    <% if (tw != null && tw.ShareEnabled) { %><a class="twitter-share-button" href="https://twitter.com/share" data-url="<%= PortalSettings.ActiveTab.FullUrl %>" data-lang="<%= CultureInfo.CurrentCulture.TwoLetterISOLanguageName %>" data-via="<%= tw.Params [0] %>">Tweet</a><% } %>
    <% if (gp != null && gp.ShareEnabled) { %><div class="g-plusone" data-size="medium"></div><% } %>
</div>

