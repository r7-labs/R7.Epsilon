<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Import Namespace="R7.Epsilon.Components" %>

<% if (!Skin.Options.DisableSocialShare) { %>
<%
var vk = Config.SocialGroups.FirstOrDefault (g => g.Type == SocialGroupType.VKontakte && g.ShareEnabled);
var fb = Config.SocialGroups.FirstOrDefault (g => g.Type == SocialGroupType.Facebook && g.ShareEnabled);
var tw = Config.SocialGroups.FirstOrDefault (g => g.Type == SocialGroupType.Twitter && g.ShareEnabled);
%>
<%-- Facebook Like --%><% if (fb != null) { %>
<script>(function(d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    <% if (!string.IsNullOrWhiteSpace (fb.ApiId)) { %>
    js.src = "//connect.facebook.net/<%= CultureInfo.CurrentCulture.Name.Replace ("-", "_") %>/sdk.js#xfbml=1&version=v2.8&appId=<%: fb.ApiId %>";
    <% } else { %>
    js.src = "//connect.facebook.net/<%= CultureInfo.CurrentCulture.Name.Replace ("-", "_") %>/sdk.js#xfbml=1&version=v2.8";
    <% } %>
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));
</script><% } %>
<%-- Tweet Button --%><% if (tw != null) { %><script>!function(d,s,id){var js,fjs=d.getElementsByTagName(s)[0],p=/^http:/.test(d.location)?'http':'https';if(!d.getElementById(id)){js=d.createElement(s);js.id=id;js.src=p+'://platform.twitter.com/widgets.js';fjs.parentNode.insertBefore(js,fjs);}}(document, 'script', 'twitter-wjs');</script><% } %>
<%-- VK.com Widget--%><% if (vk != null) { %><script type="text/javascript">
window.vkAsyncInit = function() {
    VK.init({apiId: <%= vk.ApiId %>, onlyWidgets: true});
    VK.Widgets.Like("vk_like", {type: "mini", height: 20});
};
setTimeout(function() {
    var el = document.createElement("script");
    el.type = "text/javascript";
    el.src = "https://vk.com/js/api/openapi.js?143";
    el.async = true;
    document.getElementById("vk_api_transport").appendChild(el);
},0);
</script><% } %>
<% } %>

<% if (Config.Analytics.UseSputnik) { %>
<script type="text/javascript">
  (function(d, t, p) {
    var j = d.createElement(t); j.async = true; j.type = "text/javascript";
    j.src = ("https:" == p ? "https:" : "http:") + "//stat.sputnik.ru/cnt.js";
    var s = d.getElementsByTagName(t)[0]; s.parentNode.insertBefore(j, s);
  })(document, "script", document.location.protocol);
</script><% } %>
