<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.SocialGroups" %>
<%@ OutputCache Duration="1200" VaryByParam="Language" VaryByCustom="PortalId" %>
<ul class="skin-socialgroups">
    <li>
        <a class="skin-social-button skin-social-vk" href="http://vk.com/<%= Config.Vk.Group %>" target="_blank" title="<%= Localizer.GetString ("VKontakte.Title") %>" aria-label="<%= Localizer.GetString ("VKontakte.Title") %>" ></a>
    </li>
	<li>
        <a class="skin-social-button skin-social-yt" href="http://www.youtube.com/channel/<%= Config.Youtube.Group %>" rel="nofollow" target="_blank" title="<%= Localizer.GetString ("Youtube.Title") %>" aria-label="<%= Localizer.GetString ("Youtube.Title") %>"></a>
    </li>
	<li>
        <a class="skin-social-button skin-social-ig" href="<%= Config.Instagram.Group %>" rel="nofollow" target="_blank" title="<%= Localizer.GetString ("Instagram.Title") %>" aria-label="<%= Localizer.GetString ("Instagram.Title") %>"></a>
    </li>
	<li class="dropdown">
		<a role="button" href="#" class="skin-social-button skin-social-more dropdown-toggle" type="button" id="dropdownSocialGroups" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"></a>
		<ul class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdownSocialGroups">
            <li>
                <a href="http://www.facebook.com/<%= Config.Facebook.Group %>" rel="nofollow" target="_blank">
				    <span class="skin-social-button skin-social-fb"></span> <%= Localizer.GetString ("Facebook.Title") %>
				</a>
            </li>
            <li>
                <a href="http://twitter.com/<%= Config.Twitter.Group %>" rel="nofollow" target="_blank">
					<span class="skin-social-button skin-social-tw"></span> <%= Localizer.GetString ("Twitter.Title") %>
				</a>
            </li>
            <li>
                <a href="http://plus.google.com/<%= Config.Google.Group %>" target="_blank">
					<span class="skin-social-button skin-social-gp"></span> <%= Localizer.GetString ("GooglePlus.Title") %>
				</a>
            </li>
            <li>
                <a href="http://www.odnoklassniki.ru/group/<%= Config.Ok.Group %>" rel="nofollow" target="_blank">
					<span class="skin-social-button skin-social-ok"></span> <%= Localizer.GetString ("Odnoklassniki.Title") %>
				</a>
            </li>
			<li>
                <a href="<%= Config.Linkedin.Group %>" rel="nofollow" target="_blank">
                    <span class="skin-social-button skin-social-in"></span> <%= Localizer.GetString ("Linkedin.Title") %>
                </a>
            </li>
        </ul>
	</li>
</ul>

