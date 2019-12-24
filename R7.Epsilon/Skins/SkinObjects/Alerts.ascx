<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%
var moduleId = default (int?);
if (!string.IsNullOrEmpty (Request.QueryString ["mid"])) {
	moduleId = int.Parse (Request.QueryString ["mid"]);
}
else if (!string.IsNullOrEmpty (Request.QueryString ["moduleid"])) {
	moduleId = int.Parse (Request.QueryString ["moduleid"]);
}
if (moduleId != null && string.IsNullOrEmpty (Request.QueryString ["ctl"])) {
	var content = T.GetString ("PartialContentAlert_Template.Text");
	content = content.Replace ("[TabUrl]",  DotNetNuke.Common.Globals.NavigateURL (ActiveTab.TabID));
	content = content.Replace ("[TabName]", ActiveTab.TabName);
	content = content.Replace ("[ModuleId]", moduleId.ToString ());
%>
<div class="container">
	<div class="row">
		<div class="col">
			<div class="alert alert-info" role="alert">
				<h4 class="alert-heading"><i class="fas fa-info-circle"></i> <%: T.GetString ("PartialContentAlert_Title.Text") %></h4>
				<%= content %>
			</div>
		</div>
	</div>
</div>
<% } %>
<% if (ActiveTab.EndDate != null && ActiveTab.EndDate <= DateTime.Now) { %>
<div class="container">
	<div class="row">
		<div class="col">
			<div class="alert alert-warning" role="alert">
				<h4 class="alert-heading"><i class="fas fa-exclamation-triangle"></i> <%: T.GetString ("PageNotPublishedAlert_Title.Text") %></h4>
				<p class="mb-0"><%: T.GetString ("PageNotPublishedAlert_Body.Text") %></p>
			</div>
		</div>
	</div>
</div>
<% } %>
