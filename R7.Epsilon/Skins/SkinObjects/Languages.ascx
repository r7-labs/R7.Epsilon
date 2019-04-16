<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Register TagPrefix="dnn" TagName="LANGUAGE" Src="~/Admin/Skins/Language.ascx" %>
<%@ Import Namespace="R7.Epsilon.Components" %>
<div class="dropdown-menu skin-languages">
	<dnn:LANGUAGE runat="server" ShowLinks="true" ShowMenu="false" />
<% if (EpsilonConfig.Instance.Functions.EnableAltWebsite) {
	var altWebsiteUrl = EpsilonConfig.Instance.Functions.AltWebsiteUrl;
	var altWebsiteCulture = EpsilonConfig.Instance.Functions.AltWebsiteCulture; %>
	<div class="dropdown-divider"></div>
	<a class="dropdown-item"
        href="<%= altWebsiteUrl %>"
	    hreflang="<%: altWebsiteCulture %>"
	    target="_blank">
		<%= Localizer.GetString ("AltWebsite.Icon") %>
		<%: Localizer.GetString ("AltWebsite.Text") %>
	</a>
<% } %>
	<div class="dropdown-divider"></div>
	<a class="dropdown-item" href="javascript:skinGoogleTranslatePage('<%= CultureInfo.CurrentCulture.TwoLetterISOLanguageName %>')">
		<i class="fab fa-google"></i>
		<%: Localizer.GetString ("GoogleTranslate.Text") %>
	</a>
</div>
