<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" %>

<%-- TODO: Need to use some kind of skin config for this --%>
<%
    var vk_apiId = 4754730;
    var vk_group = "volgau_com";
    var vk_share_enabled = false;
    var fb_group = "volgau";
    var tw_via = "volgau_com";
    var tw_group = "volgau_com";
    var ok_group = "51992191172689";
    var gp_group = "102055464309901341034/communities/113661705633931940712";
    var yt_group = "UCYPMmQknVPxosuY4iPCfVDg";
%>

<ul class="socialgroups">
    <li>
        <a class="social-button social-vk" href="http://vk.com/<%= vk_group %>" target="_blank" title="VKontakte"></a>
    </li>
    <li class="hidden-xs">
        <a class="social-button social-fb" href="http://www.facebook.com/<%= fb_group %>" rel="nofollow" target="_blank" title="Facebook"></a>
    </li>
    <li class="hidden-xs">
        <a class="social-button social-tw" href="http://twitter.com/<%= tw_group %>" rel="nofollow" target="_blank" title="Twitter"></a>
    </li>
    <li class="hidden-xs">
        <a class="social-button social-gp" href="http://plus.google.com/b/<%= gp_group %>" title="Google+" target="_blank"></a>
    </li>
    <li class="hidden-xs">
        <a class="social-button social-ok" href="http://www.odnoklassniki.ru/group/<%= ok_group %>" rel="nofollow" target="_blank" title="Odnoklassniki"></a>
    </li>
    <li class="hidden-xs">
        <a class="social-button social-yt" href="http://www.youtube.com/channel/<%= yt_group %>" rel="nofollow" target="_blank" title="YouTube"></a>
    </li>
</ul>
