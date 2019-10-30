<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.PageInfo" %>
<%@ Register TagPrefix="skin" TagName="PERMALINKS" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/Permalinks.ascx" %>
<div class="skin-page-info text-muted">
	<ul class="list-inline">
		<li class="list-inline-item" title="Last modified date is calculated based the page contents and could not be 100% accurate!" >
			<span class="fas fa-calendar-alt"></span> <%= Localizer.GetString ("LastModified.Text") %> <%: LastContentModifiedOnDate %>
		</li>
		<li class="list-inline-item" title="User who has modified the page of page settings the last.">
			<span class="fas fa-user"></span> <%: LastContentModifiedByUserName %>
		</li>
		<li class="list-inline-item">
			<skin:PERMALINKS runat="server" />
		</li>
	</ul>
</div>
