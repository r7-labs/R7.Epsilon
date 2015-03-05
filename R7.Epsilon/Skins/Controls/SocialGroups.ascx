<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.SocialGroups" %>

<ul class="skin-socialgroups">
    <li>
        <a class="skin-social-button skin-social-vk" href="http://vk.com/<%= Config.VkGroup %>" target="_blank" title="VKontakte"></a>
    </li>
    <li class="hidden-xs">
        <a class="skin-social-button skin-social-fb" href="http://www.facebook.com/<%= Config.FacebookGroup %>" rel="nofollow" target="_blank" title="Facebook"></a>
    </li>
    <li class="hidden-xs">
        <a class="skin-social-button skin-social-tw" href="http://twitter.com/<%= Config.TwitterGroup %>" rel="nofollow" target="_blank" title="Twitter"></a>
    </li>
    <li class="hidden-xs">
        <a class="skin-social-button skin-social-gp" href="http://plus.google.com/b/<%= Config.GoogleGroup %>" title="Google+" target="_blank"></a>
    </li>
    <li class="hidden-xs">
        <a class="skin-social-button skin-social-ok" href="http://www.odnoklassniki.ru/group/<%= Config.OkGroup %>" rel="nofollow" target="_blank" title="Odnoklassniki"></a>
    </li>
    <li class="hidden-xs">
        <a class="skin-social-button skin-social-yt" href="http://www.youtube.com/channel/<%= Config.YoutubeGroup %>" rel="nofollow" target="_blank" title="YouTube"></a>
    </li>
</ul>
