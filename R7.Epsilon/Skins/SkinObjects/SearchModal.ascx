<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Register TagPrefix="dnn" TagName="SEARCH" Src="~/Admin/Skins/Search.ascx" %>
<%@ Import Namespace="R7.Epsilon.Components" %>
<div class="modal fade" id="searchModal" tabindex="-1" role="dialog" aria-labelledby="searchModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="searchModalLabel"><%: T.GetString("SearchModalTitle.Text") %></h5>
                <button type="button" class="close" data-dismiss="modal" aria-label='<%: T.GetString("ModalClose.Text") %>'>
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                <div class="skn-search-box">
				    <dnn:SEARCH id="dnnSearch" runat="server"
                        ShowSite="false"
                        ShowWeb="false"
						EnableTheming="true"
                        CssClass="skn-search-btn" />
				</div>
				<% if (Config.SearchEngines.Count > 0) { %>
					<hr />
					<p><%: T.GetString ("SearchEngines.Text") %></p>
					<ul class="list-inline">
						<% foreach (var engine in Config.SearchEngines) { %>
							<li class="list-inline-item mb-2">
								<a href="#" target="_blank" data-url-format="<%: engine.UrlFormat %>" onclick="skinSearchExternalClick(event,this)">
									<i class='fab fa-<%: SearchEngineHelper.GetFAIconName (engine.Type) %>'></i>
									<%: T.GetString ("SearchWith.Text") %>
									<% if (!string.IsNullOrEmpty (engine.Name)) { %>
										<span class="skn-custom-content" data-resource-key='<%: "SearchEngineType_" + engine.Name + ".Text" %>'>
											<%: T.GetStringOrKey ("SearchEngineType_" + engine.Name + ".Text") %>
										</span>
									<% } else { %>
										<%: T.GetString ("SearchEngineType_" + engine.Type + ".Text") %>
									<% } %>
								</a>
							</li>
						<% } %>
					</ul>
				<% } %>
            </div>
        </div>
    </div>
</div>
