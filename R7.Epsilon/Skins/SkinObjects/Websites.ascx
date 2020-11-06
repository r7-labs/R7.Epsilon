<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Import Namespace="R7.Epsilon.Components" %>
<div class="dropdown skin-websites">
	<button type="button" class="btn btn-lg skin-btn-unstyled dropdown-toggle skin-websites-btn" data-toggle="dropdown" title='<%: T.GetString ("Websites.Text") %>'>
		<i class="fas fa-globe"></i>
	</button>
	<div class="dropdown-menu">
		<% foreach (var site in Config.Websites) { %>
			<a class="dropdown-item" href="<%: site.Url %>" hreflang="<%: site.Hreflang %>" target="_blank">
				<!-- TODO: Rename to data-tooltip or data-title -->
				<span class="skin-custom-content" data-resource-key="<%: site.Label %>">
					<i class="fas fa-globe"></i>
					<%: T.GetStringIfKey (site.Label) %>
				</span>
			</a>
		<% } %>
	</div>
</div>
