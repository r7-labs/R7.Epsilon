<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Zeta.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Register TagPrefix="dnn" TagName="MENU" Src="~/DesktopModules/DDRMenu/Menu.ascx" %>
<%@ Register TagPrefix="skin" TagName="PAGEHEADER" Src="~/Portals/_default/Skins/R7.Zeta/SkinObjects/PageHeader.ascx" %>
<%@ Register TagPrefix="skin" TagName="BREADCRUMBMENU" Src="~/Portals/_default/Skins/R7.Zeta/SkinObjects/BreadcrumbMenu.ascx" %>
<%@ Register TagPrefix="skin" TagName="SOCIALSHAREBUTTONS" Src="~/Portals/_default/Skins/R7.Zeta/SkinObjects/SocialShareButtons.ascx" %>
<%@ Register TagPrefix="skin" TagName="ALERTS" Src="~/Portals/_default/Skins/R7.Zeta/SkinObjects/Alerts.ascx" %>
<div class="skin-subheader">
	<% if (!Skin.Options.DisableBreadCrumb || !Skin.Options.DisableSocialShare) { %>
		<div class="container">
			<div class="row">
				<div class="col">
					<div class="skin-subheader-top">
						<% if (!Skin.Options.DisableBreadCrumb) { %>
							<skin:BREADCRUMBMENU runat="server" />
						<% } %>
						<% if (!Skin.Options.DisableSocialShare) { %>
							<% if (!Skin.Options.DisableBreadCrumb) { %>
								<hr />
							<% } %>
							<skin:SOCIALSHAREBUTTONS runat="server" Visible="<%# !Skin.Options.DisableSocialShare %>" />
						<% } %>
					</div>
				</div>
			</div>
		</div>
	<% } %>
	<div class="container">
		<skin:PAGEHEADER runat="server" />
	</div>
</div>
<a id="content" name="content"></a>
<skin:ALERTS runat="server" />
