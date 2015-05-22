<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.SecondaryMenu" %>
<%@ OutputCache Duration="10" VaryByParam="Language" VaryByCustom="PortalId" %>
<%@ Register TagPrefix="dnn" TagName="MENU" Src="~/DesktopModules/DDRMenu/Menu.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.DDRMenu.TemplateEngine" Assembly="DotNetNuke.Web.DDRMenu" %>
<div class="skin-secondary-menu">
    <dnn:MENU id="menuSecondary" runat="server" MenuStyle="Mega2Epsilon" />
</div>