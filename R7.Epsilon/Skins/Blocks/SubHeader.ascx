<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Register TagPrefix="dnn" TagName="BREADCRUMB" Src="~/Admin/Skins/BreadCrumb.ascx" %>
<%@ Register TagPrefix="dnn" TagName="MENU" Src="~/DesktopModules/DDRMenu/Menu.ascx" %>
<%@ Register TagPrefix="skin" TagName="PAGEHEADER" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/PageHeader.ascx" %>
<%@ Register TagPrefix="skin" TagName="BREADCRUMBMENU" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/BreadcrumbMenu.ascx" %>
<%@ Register TagPrefix="skin" TagName="SOCIALSHAREBUTTONS" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/SocialShareButtons.ascx" %>

<div class="skin-subheader">
	<div class="container">
		<div class="row">
			<div class="col">
			 	<div class="skin-subheader-top">
					<% if (!Skin.Options.DisableBreadCrumb) { %>
						<skin:BREADCRUMBMENU runat="server" />
					<% } %>
					<% if (!Skin.Options.DisableSocialShare) { %>
						<hr />
						<skin:SOCIALSHAREBUTTONS runat="server" Visible="<%# !Skin.Options.DisableSocialShare %>" />
					<% } %>
				</div>
			</div>
		</div>
	</div>
	<div class="container">
		<skin:PAGEHEADER runat="server" />
	</div>
</div>
<a id="content" name="content"></a>
