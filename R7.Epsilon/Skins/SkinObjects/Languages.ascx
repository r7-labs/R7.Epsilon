<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Zeta.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Register TagPrefix="dnn" TagName="LANGUAGE" Src="~/Admin/Skins/Language.ascx" %>
<%@ Import Namespace="R7.Zeta.Components" %>
<div class="dropdown" style="display:inline-block">
	<button type="button" class="btn btn-lg dropdown-toggle skin-languages-btn" data-toggle="dropdown"
		title='<%: T.GetString("Languages.Text") %>'>
		<% var langCodeParts = CultureInfo.CurrentCulture.IetfLanguageTag.Split (new char [] {'-'}, StringSplitOptions.RemoveEmptyEntries); %>
		<strong><%: langCodeParts [0].ToUpperInvariant () %></strong>
		<% if (langCodeParts.Length == 2) { %>
			<sup><%: langCodeParts [1].ToLowerInvariant () %></sup>
		<% } %>
	</button>
	<div class="dropdown-menu skin-languages">
		<dnn:LANGUAGE runat="server" ShowLinks="true" ShowMenu="true" />
		<% var altWebsites = Config.Websites.Where (s => s.IsAltWebsite).ToList (); %>
		<% if (altWebsites.Count > 0) { %>
			<div class="dropdown-divider"></div>
			<% foreach (var site in altWebsites) { %>
				<a class="dropdown-item" href="<%: site.Url %>" hreflang="<%: site.Hreflang %>"	target="_blank">
					<span class="skin-custom-content" data-resource-key="<%: site.Name %>">
						<strong><%: site.Hreflang %></strong>
						<%: T.GetStringOrKey (site.Name) %>
					</span>
				</a>
			<% } %>
		<% } %>
		<div class="dropdown-divider"></div>
		<a class="dropdown-item" href="javascript:skinGoogleTranslatePage('<%= CultureInfo.CurrentCulture.TwoLetterISOLanguageName %>')">
			<i class="fab fa-google"></i>
			<%: T.GetString ("GoogleTranslate.Text") %>
		</a>
	</div>
</div>
