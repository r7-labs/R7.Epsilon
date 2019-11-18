<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Register TagPrefix="dnn" TagName="BREADCRUMB" Src="~/Admin/Skins/BreadCrumb.ascx" %>
<%@ Register TagPrefix="dnn" TagName="MENU" Src="~/DesktopModules/DDRMenu/Menu.ascx" %>
<%@ Register TagPrefix="skin" TagName="PAGEHEADER" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/PageHeader.ascx" %>
<%@ Register TagPrefix="skin" TagName="BREADCRUMBMENU" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/BreadcrumbMenu.ascx" %>
<%@ Register TagPrefix="skin" TagName="SOCIALSHAREBUTTONS" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/SocialShareButtons.ascx" %>

<nav class="skin-local-navbar" role="navigation">
	<% if (!Skin.Options.DisableBreadCrumb) { %>
		<div class="container">
			<skin:BREADCRUMBMENU id="breadcrumbMenu" runat="server" />
		</div>
	<% } %>
    <div class="container">
        <skin:PAGEHEADER runat="server" />
        <div id="skin-separator-1" class="d-xs-none">&nbsp;</div>
        <skin:SOCIALSHAREBUTTONS runat="server" Visible="<%# !Skin.Options.DisableSocialShare %>" />
    </div>
</nav>
<a id="content" name="content"></a>
