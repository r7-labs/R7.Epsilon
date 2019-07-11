<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Import Namespace="R7.Epsilon.Components" %>
<div class="dropdown" style="display:inline-block">
	<button type="button" class="btn btn-lg dropdown-toggle skin-websites-btn" data-toggle="dropdown" title='<%: Localizer.GetString ("Websites.Text") %>'>
		<i class="fas fa-globe"></i>
	</button>
	<div class="dropdown-menu">
		<% foreach (var site in Config.Websites) { %>
			<a class="dropdown-item" href="<%: site.Url %>" hreflang="<%: site.Hreflang %>" target="_blank">
				<span class="skin-custom-content" data-resource-key="<%: site.Name %>">
					<i class="fas fa-globe"></i>
					<%: Localizer.GetStringOrKey (site.Name) %>
				</span>
			</a>
		<% } %>
	</div>
</div>
