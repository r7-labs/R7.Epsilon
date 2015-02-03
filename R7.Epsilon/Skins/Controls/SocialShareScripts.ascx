<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.SocialShareScripts" %>

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

<%-- Facebook Like --%>
<div id="fb-root"></div>
<script>(function(d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/en_US/sdk.js#xfbml=1&version=v2.0";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));
</script>

<%-- Tweet Button --%>
<script>!function(d,s,id){var js,fjs=d.getElementsByTagName(s)[0],p=/^http:/.test(d.location)?'http':'https';if(!d.getElementById(id)){js=d.createElement(s);js.id=id;js.src=p+'://platform.twitter.com/widgets.js';fjs.parentNode.insertBefore(js,fjs);}}(document, 'script', 'twitter-wjs');</script>

<%-- Google +1 --%>
<script type="text/javascript">
window.___gcfg = {
    lang: '<%= CultureInfo.CurrentCulture.TwoLetterISOLanguageName %>', 
    parsetags: 'onload'
};
(function() {
    var po = document.createElement('script'); po.type = 'text/javascript'; po.async = true;
    po.src = 'https://apis.google.com/js/platform.js';
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(po, s);
})();
</script>

<%-- VK.com Widget--%>

<%-- TODO: OpenAPI link should be in the HEAD! --%>
<% if (vk_share_enabled) { %>
<script type="text/javascript" src="//vk.com/js/api/openapi.js?116"></script>
<script type="text/javascript">
    VK.init({apiId: <%= vk_apiId %>, onlyWidgets: true});
    VK.Widgets.Like("vk_like", {type: "mini", height: 20});
</script>
<% } %>