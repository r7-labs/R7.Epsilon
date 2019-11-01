<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Import Namespace="R7.Epsilon.Components" %>
<!-- TODO: Implement copy with https://clipboardjs.com -->
<div class="dropdown">
	<button class="dropdown-toggle btn btn-sm text-muted" id="btnPermalinks"
			title='<%: Localizer.GetString ("Permalinks_Title.Text") %>'
			data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
		<span class="fas fa-globe"></span> <%= Localizer.GetString ("Permalinks.Text") %>
	</button>
	<div class="dropdown-menu" aria-labelledby="btnPermalinks">
		<% foreach (var permalinkFormat in Config.PermalinkFormats) {
			var permalink = EpsilonUrlHelper.FullUrl (EpsilonUrlHelper.ReplaceOptionalArguments (Request.QueryString, permalinkFormat
				.Replace ("{tabid}", PortalSettings.ActiveTab.TabID.ToString ())
				.Replace ("{portalid}", PortalSettings.PortalId.ToString ())
			)); %>
			<div class="dropdown-item d-flex justify-content-between skin-permalink-item" >
				<div class="pr-2 pt-1 skin-permalink"><%: permalink %></div>
				<div class="skin-permalink-buttons">
					<button class="btn btn-sm btn-outline-primary" title='<%: Localizer.GetString ("CopyPermalink_Title.Text") %>'
							onclick="alert('Not implemented!')">
						<i class="fas fa-copy"></i> <%: Localizer.GetString ("CopyPermalink.Text") %>
					</button>
					<% foreach (var urlShortener in Config.UrlShorteners) { %>
						<button class="btn btn-sm btn-outline-secondary" title="<%: Localizer.GetString ("CreateShortUrl_Title.Text") %><%: urlShortener.Label %>"
								onclick="window.open('<%= urlShortener.UrlFormat %>'.replace('{url}', encodeURIComponent('<%= permalink %>')), '_blank');">
							<%: urlShortener.Label %>
						</button>
					<% } %>
				</div>
			</div>
		<% } %>
	</div>
</div>
