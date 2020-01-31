<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.PageInfo" %>
<%@ Register TagPrefix="dnn" TagName="TAGS" Src="~/Admin/Skins/Tags.ascx" %>
<% if (!Skin.Options.DisablePageInfo) { %>
<div class="skin-page-info text-muted">
	<% if (ActiveTab.Terms != null && ActiveTab.Terms.Count > 0) { %>
		<div class="skin-tags">
			<dnn:TAGS runat="server" CssClass="test" ShowCategories="true" ShowTags="false" AllowTagging="false" Separator=" " />
		</div>
		<hr />
	<% } %>
	<ul class="list-inline">
		<li class="list-inline-item" title='<%: T.GetString ("LastModified_Tooltip.Text") %>'>
			<span class="fas fa-calendar-alt"></span> <%: T.GetString ("LastModified.Text") %> <%: LastContentModifiedOnDate %>
		</li>
		<li class="list-inline-item" title='<%: T.GetString ("LastModifiedByUser_Tooltip.Text") %>'>
			<span class="fas fa-user"></span> <%: LastContentModifiedByUserName %>
		</li>
		<li class="list-inline-item">
			<button type="button" id="btnPermalinks" class="btn btn-sm skin-btn-unstyled text-muted"
					title='<%: T.GetString ("Permalinks_Tooltip.Text") %>'
					data-toggle="modal" data-target="#skinPermalinksModal">
				<i class="fas fa-globe"></i> <%: T.GetString ("Permalinks.Text") %>
			</button>
		</li>
	</ul>
</div>
<% } %>
