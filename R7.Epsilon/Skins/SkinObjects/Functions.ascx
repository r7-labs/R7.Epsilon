<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ OutputCache Duration="1200" VaryByParam="TabId;Language" %>
<%@ Import Namespace="R7.Epsilon.Components" %>
<a class="skin-functions-icon skin-functions-icon-gtranslate" href="javascript:skinGoogleTranslatePage('<%= CultureInfo.CurrentCulture.TwoLetterISOLanguageName %>')" title="<%: Localizer.GetString ("GoogleTranslate.Title") %>" aria-label="<%: Localizer.GetString ("GoogleTranslate.Title") %>" data-toggle="tooltip" data-placement="bottom"></a>
<%
if (EpsilonConfig.Instance.Functions.EnableAltWebsite) {
	var altWebsiteUrl = EpsilonConfig.Instance.Functions.AltWebsiteUrl;
	var altWebsiteCulture = EpsilonConfig.Instance.Functions.AltWebsiteCulture;
%><a class="skin-functions-icon skin-functions-icon-alt-website"
        href="<%= altWebsiteUrl %>"
	    hreflang="<%: altWebsiteCulture %>"
	    target="_blank"
	    title='<%: Localizer.GetString ("AltWebsite.Title") %>'
	    aria-label='<%: Localizer.GetString ("AltWebsite.Title") %>'
	    data-toggle="tooltip" data-placement="bottom"><%: altWebsiteCulture.IndexOf ("-") >= 0 ? altWebsiteCulture.Split ('-')[0] : altWebsiteCulture %></a>
<% } %>
<div class="skin-functions-icon skin-functions-icon-age-rating" data-toggle="tooltip" data-placement="bottom" title="<%: Localizer.GetString("AgeRating.Title") %>" aria-label="<%: Localizer.GetString("AgeRating.Title") %>"></div>