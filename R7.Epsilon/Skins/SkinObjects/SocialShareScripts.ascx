﻿<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ OutputCache Duration="1200" VaryByParam="TabId;Language" %>
<%-- Facebook Like --%><% if (Config.Facebook.ShareEnabled) { %>
<script>(function(d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    <% if (!string.IsNullOrWhiteSpace (Config.Facebook.AppId)) { %>
    js.src = "//connect.facebook.net/<%= CultureInfo.CurrentCulture.Name.Replace ("-", "_") %>/sdk.js#xfbml=1&version=v2.3&appId=<%: Config.Facebook.AppId %>";
    <% } else { %>
    js.src = "//connect.facebook.net/<%= CultureInfo.CurrentCulture.Name.Replace ("-", "_") %>/sdk.js#xfbml=1&version=v2.3";
    <% } %>
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));
</script><% } %>
<%-- Tweet Button --%><% if (Config.Twitter.ShareEnabled) { %><script>!function(d,s,id){var js,fjs=d.getElementsByTagName(s)[0],p=/^http:/.test(d.location)?'http':'https';if(!d.getElementById(id)){js=d.createElement(s);js.id=id;js.src=p+'://platform.twitter.com/widgets.js';fjs.parentNode.insertBefore(js,fjs);}}(document, 'script', 'twitter-wjs');</script><% } %>
<%-- Google +1 --%><% if (Config.Google.ShareEnabled) { %><script type="text/javascript">
window.___gcfg = {
    lang: '<%= CultureInfo.CurrentCulture.TwoLetterISOLanguageName %>', 
    parsetags: 'onload'
};
(function() {
    var po = document.createElement('script'); po.type = 'text/javascript'; po.async = true;
    po.src = 'https://apis.google.com/js/platform.js';
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(po, s);
})();
</script><% } %>
<%-- VK.com Widget--%><% if (Config.Vk.ShareEnabled) { %><script type="text/javascript" src="//vk.com/js/api/openapi.js?116"></script>
<script type="text/javascript">
    VK.init({apiId: <%= Config.Vk.ApiId %>, onlyWidgets: true});
    VK.Widgets.Like("vk_like", {type: "mini", height: 20});
</script><% } %>