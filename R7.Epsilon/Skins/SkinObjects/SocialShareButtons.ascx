<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Zeta.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Import Namespace="R7.Zeta.Components" %>
<div class="skin-social-share-buttons">
	<% var vk = Config.SocialGroups.FirstOrDefault (g => g.Type == SocialGroupType.VKontakte && g.ShareEnabled);
	if (vk != null) { %>
		<div class="skin-social-share-btn">
			<div id="vk_like"></div>
		</div>
	<% } %>
	<% var fb = Config.SocialGroups.FirstOrDefault (g => g.Type == SocialGroupType.Facebook && g.ShareEnabled);
	if (fb != null) { %>
		<div class="skin-social-share-btn">
			<div class="fb-like" data-href="<%= ActiveTab.FullUrl %>" data-layout="button_count"
				data-action="like" data-show-faces="false" data-share="false"></div>
		</div>
	<% } %>
	<% foreach (var tw in Config.SocialGroups.Where (g => g.Type == SocialGroupType.Twitter && g.ShareEnabled)) { %>
		<div class="skin-social-share-btn">
			<a class="twitter-share-button" href="https://twitter.com/share" data-url="<%= ActiveTab.FullUrl %>"
				data-lang="<%= CultureInfo.CurrentCulture.TwoLetterISOLanguageName %>" data-via="<%= tw.Params [0] %>">Tweet</a>
		</div>
	<% } %>
</div>
