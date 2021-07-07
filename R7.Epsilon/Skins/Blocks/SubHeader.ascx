<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Register TagPrefix="dnn" TagName="MENU" Src="~/DesktopModules/DDRMenu/Menu.ascx" %>
<%@ Register TagPrefix="skin" TagName="PAGEHEADER" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/PageHeader.ascx" %>
<%@ Register TagPrefix="skin" TagName="BREADCRUMBMENU" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/BreadcrumbMenu.ascx" %>
<%@ Register TagPrefix="skin" TagName="ALERTS" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/Alerts.ascx" %>
<div class="skin-subheader">
	<% if (!Skin.Options.DisableBreadCrumb) { %>
		<div class="container">
			<div class="row">
				<div class="col">
					<div class="skin-subheader-top">
						<% if (!Skin.Options.DisableBreadCrumb) { %>
							<skin:BREADCRUMBMENU runat="server" />
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
