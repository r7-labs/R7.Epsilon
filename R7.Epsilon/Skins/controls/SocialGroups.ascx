<%@ Control Language="C#" AutoEventWireup="false" Inherits="R7.Epsilon.SocialGroups" %>

<% 
var group_vk = "volgau_com";
var group_fb = "volgau";
var group_tw = "volgau_com";
var group_gp = "102055464309901341034/communities/113661705633931940712";
var group_ok = "51992191172689";
var group_yt = "UCYPMmQknVPxosuY4iPCfVDg";
%>

<ul class="socialgroups">
    <li>
        <a class="social-button social-vk" href="http://vk.com/<%= group_vk %>" target="_blank" title="VKontakte"></a>
    </li>
    <li class="hidden-xs">
        <a class="social-button social-fb" href="http://www.facebook.com/<%= group_fb %>" rel="nofollow" target="_blank" title="Facebook"></a>
    </li>
    <li class="hidden-xs">
        <a class="social-button social-tw" href="http://twitter.com/<%= group_tw %>" rel="nofollow" target="_blank" title="Twitter"></a>
    </li>
    <li class="hidden-xs">
        <a class="social-button social-gp" href="http://plus.google.com/b/<%= group_gp %>" title="Google+" target="_blank"></a>
    </li>
    <li class="hidden-xs">
        <a class="social-button social-ok" href="http://www.odnoklassniki.ru/group/<%= group_ok %>" rel="nofollow" target="_blank" title="Odnoklassniki"></a>
    </li>
    <li class="hidden-xs">
        <a class="social-button social-yt" href="http://www.youtube.com/channel/<%= group_yt %>" rel="nofollow" target="_blank" title="YouTube"></a>
    </li>
</ul>
