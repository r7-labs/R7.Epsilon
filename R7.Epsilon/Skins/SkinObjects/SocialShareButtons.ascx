<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Import Namespace="R7.Epsilon.Components" %>
<% if (!Skin.Options.DisableSocialShare) { %>
<div class="skin-social-share-buttons">
	<% var vk = Config.SocialGroups.FirstOrDefault (g => g.Type == SocialGroupType.VKontakte && g.ShareEnabled);
    if (vk != null) { %>
		<div id="vk_like"></div>
	<% } %>
	<% var fb = Config.SocialGroups.FirstOrDefault (g => g.Type == SocialGroupType.Facebook && g.ShareEnabled);
    if (fb != null) { %>
		<div class="fb-like" data-href="<%= PortalSettings.ActiveTab.FullUrl %>" data-layout="button_count"
			data-action="like" data-show-faces="false" data-share="false"></div>
	<% } %>
	<% foreach (var tw in Config.SocialGroups.Where (g => g.Type == SocialGroupType.Twitter && g.ShareEnabled)) { %>
	    <a class="twitter-share-button" href="https://twitter.com/share" data-url="<%= PortalSettings.ActiveTab.FullUrl %>"
			data-lang="<%= CultureInfo.CurrentCulture.TwoLetterISOLanguageName %>" data-via="<%= tw.Params [0] %>">Tweet</a>
	<% } %>
</div>
<% } %>
