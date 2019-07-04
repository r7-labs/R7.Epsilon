<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Register TagPrefix="dnn" TagName="LANGUAGE" Src="~/Admin/Skins/Language.ascx" %>
<%@ Import Namespace="R7.Epsilon.Components" %>
<div class="dropdown-menu skin-languages">
	<dnn:LANGUAGE runat="server" ShowLinks="true" ShowMenu="true" />
	<% var altWebsites = Config.Websites.Where (s => s.IsAltWebsite).ToList (); %>
	<% if (altWebsites.Count > 0) { %>
		<div class="dropdown-divider"></div>
		<% foreach (var site in altWebsites) { %>
			<a class="dropdown-item" href="<%: site.Url %>" hreflang="<%: site.Hreflang %>"	target="_blank">
				<span class="skin-custom-content" data-resource-key="<%: site.Name %>">
					<strong><%: site.Hreflang.ToUpperInvariant () %></strong>
					<%: Localizer.GetStringOrKey (site.Name) %>
				</span>
			</a>
		<% } %>
	<% } %>
	<div class="dropdown-divider"></div>
	<a class="dropdown-item" href="javascript:skinGoogleTranslatePage('<%= CultureInfo.CurrentCulture.TwoLetterISOLanguageName %>')">
		<i class="fab fa-google"></i>
		<%: Localizer.GetString ("GoogleTranslate.Text") %>
	</a>
</div>
