<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.SocialGroups" %>
<%@ OutputCache Duration="1200" VaryByParam="Language" VaryByCustom="PortalId" %>
<ul class="skin-socialgroups">
    <li>
        <a class="skin-social-button skin-social-vk" href="http://vk.com/<%= Config.Vk.Group %>" target="_blank" title="<%= Localizer.GetString ("VKontakte.Title") %>" aria-label="<%= Localizer.GetString ("VKontakte.Title") %>" ></a>
    </li>
    <% if (!MobileView) { %>
    <li>
        <a class="skin-social-button skin-social-fb" href="http://www.facebook.com/<%= Config.Facebook.Group %>" rel="nofollow" target="_blank" title="<%= Localizer.GetString ("Facebook.Title") %>" aria-label="<%= Localizer.GetString ("Facebook.Title") %>"></a>
    </li>
    <li>
        <a class="skin-social-button skin-social-tw" href="http://twitter.com/<%= Config.Twitter.Group %>" rel="nofollow" target="_blank" title="<%= Localizer.GetString ("Twitter.Title") %>" aria-label="<%= Localizer.GetString ("Twitter.Title") %>"></a>
    </li>
    <li>
        <a class="skin-social-button skin-social-gp" href="http://plus.google.com/<%= Config.Google.Group %>" target="_blank" title="<%= Localizer.GetString ("GooglePlus.Title") %>" aria-label="<%= Localizer.GetString ("GooglePlus.Title") %>"></a>
    </li>
    <li>
        <a class="skin-social-button skin-social-ok" href="http://www.odnoklassniki.ru/group/<%= Config.Ok.Group %>" rel="nofollow" target="_blank" title="<%= Localizer.GetString ("Odnoklassniki.Title") %>" aria-label="<%= Localizer.GetString ("Odnoklassniki.Title") %>"></a>
    </li>
    <li>
        <a class="skin-social-button skin-social-yt" href="http://www.youtube.com/channel/<%= Config.Youtube.Group %>" rel="nofollow" target="_blank" title="<%= Localizer.GetString ("Youtube.Title") %>" aria-label="<%= Localizer.GetString ("Youtube.Title") %>"></a>
    </li>
    <% } %>
</ul>
