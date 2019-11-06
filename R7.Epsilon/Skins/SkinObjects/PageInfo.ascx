<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.PageInfo" %>
<div class="skin-page-info text-muted">
	<ul class="list-inline">
		<li class="list-inline-item" title='<%: Localizer.GetString ("LastModified_Title.Text") %>'>
			<span class="fas fa-calendar-alt"></span> <%: Localizer.GetString ("LastModified.Text") %> <%: LastContentModifiedOnDate %>
		</li>
		<li class="list-inline-item" title='<%: Localizer.GetString ("LastModifiedByUser_Title.Text") %>'>
			<span class="fas fa-user"></span> <%: LastContentModifiedByUserName %>
		</li>
		<li class="list-inline-item">
			<button type="button" id="btnPermalinks" class="btn btn-sm text-muted"
					title='<%: Localizer.GetString ("Permalinks_Tooltip.Text") %>'
					data-toggle="modal" data-target="#skinPermalinksModal">
				<i class="fas fa-globe"></i> <%: Localizer.GetString ("Permalinks.Text") %>
			</button>
		</li>
	</ul>
</div>
