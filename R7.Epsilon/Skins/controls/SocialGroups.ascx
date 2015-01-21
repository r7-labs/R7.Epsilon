<%@ Control Language="C#" AutoEventWireup="false" Inherits="R7.Epsilon.SocialGroups" %>

<% 
var group_vkontakte = "volgau_com";
var group_odnoklassniki = "51992191172689";
var group_gplus = "102055464309901341034/communities/113661705633931940712";
var group_facebook = "volgau";
var group_twitter = "volgau_com";
var group_youtube = "UCYPMmQknVPxosuY4iPCfVDg";
%>

<%-- TODO: Convert to UL --%>
<div class="socialgroups">
   <a class="social-button social-vkontakte" href="http://vk.com/<%= group_vkontakte %>" target="_blank" title="VKontakte"></a>
   <a class="social-button social-odnoklassniki" href="http://www.odnoklassniki.ru/group/<%= group_odnoklassniki %>" rel="nofollow" target="_blank" title="Odnoklassniki"></a>
   <a class="social-button social-gplus" href="http://plus.google.com/b/<%= group_gplus %>" title="Google+" target="_blank"></a>
   <a class="social-button social-facebook" href="http://www.facebook.com/<%= group_facebook %>" rel="nofollow" target="_blank" title="Facebook"></a>
   <a class="social-button social-twitter" href="http://twitter.com/<%= group_twitter %>" rel="nofollow" target="_blank" title="Twitter"></a>
   <a class="social-button social-youtube" href="http://www.youtube.com/channel/<%= group_youtube %>" rel="nofollow" target="_blank" title="YouTube"></a>
</div>
