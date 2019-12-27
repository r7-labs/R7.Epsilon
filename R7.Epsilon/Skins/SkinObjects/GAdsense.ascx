<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Zeta.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%
// HACK: GH-77 Try to resolve Google Adsense complaints about missing content
if (!string.IsNullOrEmpty (Config.Adsense.Client) && !Request.RawUrl.ToLowerInvariant ().Contains ("/login?returnurl=")) {
var adsenseScript = "<script async src=\"//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js\"></script>" +
"<ins class=\"adsbygoogle\" " +
"style=\"display:block\" " +
"data-ad-client=\"ca-" + Config.Adsense.Client + "\" " +
"data-ad-slot=\"" + Config.Adsense.Slot + "\" " +
"data-ad-format=\"auto\"></ins>" +
"<script>" +
"(adsbygoogle = window.adsbygoogle || []).push({});" +
"</script>";
%>
<%-- breakpoints from Bootstrap 4 grid system + 360px --%>
<div class="ad skin-banner" data-lazyad="" data-matchmedia="only screen and (min-width : 768px)">
    <script type="text/lazyad"><!-- <%= adsenseScript %> --></script>
</div>
<div class="ad skin-banner" data-lazyad="" data-matchmedia="only screen and (min-width : 576px) and (max-width : 768px)">
    <script type="text/lazyad"><!-- <%= adsenseScript %> --></script>
</div>
<div class="ad skin-banner" data-lazyad="" data-matchmedia="only screen and (min-width : 360px) and (max-width : 575px)">
    <script type="text/lazyad"><!-- <%= adsenseScript %> --></script>
</div>
<div class="ad skin-banner" data-lazyad="" data-matchmedia="only screen and (max-width : 359px)">
    <script type="text/lazyad"><!-- <%= adsenseScript %> --></script>
</div>
<% } %>
