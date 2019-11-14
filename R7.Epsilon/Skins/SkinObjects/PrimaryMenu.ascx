<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.PrimaryMenu" %>
<%@ Register TagPrefix="dnn" TagName="MENU" Src="~/DesktopModules/DDRMenu/Menu.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.DDRMenu.TemplateEngine" Assembly="DotNetNuke.Web.DDRMenu" %>
<div id="<%: menuPrimary.ClientID %>" class="skin-main-nav skin-primary-menu">
	<dnn:MENU id="menuPrimary" runat="server" MenuStyle="Mega2Epsilon" />
</div>
