<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Import Namespace="R7.Epsilon.Components" %>
<div class="modal fade" id="skinPermalinksModal" tabindex="-1" role="dialog" aria-labelledby="skinPermalinksModalTitle" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
				<h5 class="modal-title" id="skinPermalinksModalTitle"><%: T.GetString("Permalinks_ModalTitle.Text") %></h5>
                <button type="button" class="close" data-dismiss="modal" aria-label='<%: T.GetString("ModalClose.Text") %>'>
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
				<p class="alert alert-warning"><%: T.GetString ("Permalinks_Help.Text") %></p>
				<% var permalinkIndex = 1; %>
				<% foreach (var permalinkFormat in Config.PermalinkFormats) {
					var permalink = EpsilonUrlHelper.FullUrl (EpsilonUrlHelper.ReplaceOptionalArguments (Request.QueryString, permalinkFormat
						.Replace ("{tabid}", PortalSettings.ActiveTab.TabID.ToString ())
						.Replace ("{portalid}", PortalSettings.PortalId.ToString ())
					)); %>
					<div class="card card-body border-gray p-3 mb-2">
						<ul class="list-unstyled mb-0">
							<li class="mb-2 skin-permalink" id="skinPermalink<%: permalinkIndex %>"><%: permalink %></li>
							<li>
								<button type="button" class="btn btn-sm btn-clipboard btn-outline-primary"
										title='<%: T.GetString ("CopyPermalink_Title.Text") %>'
										data-clipboard-target="#skinPermalink<%: permalinkIndex %>">
									<i class="fas fa-copy"></i> <%: T.GetString ("CopyPermalink.Text") %>
								</button>
								<% foreach (var urlShortener in Config.UrlShorteners) { %>
									<button type="button" class="btn btn-sm btn-outline-secondary" title='<%: T.GetString ("CreateShortUrl_Title.Text") %><%: urlShortener.Label %>'
											onclick="window.open('<%= urlShortener.UrlFormat %>'.replace('{url}', encodeURIComponent('<%= permalink %>')), '_blank');">
										<%: urlShortener.Label %>
									</button>
								<% } %>
							</li>
						</ul>
					</div>
				<% permalinkIndex++; %>
				<% } %>
            </div>
        </div>
    </div>
</div>
