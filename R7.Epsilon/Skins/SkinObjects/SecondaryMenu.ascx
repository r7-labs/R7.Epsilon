<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.SecondaryMenu" %>
<%@ OutputCache Duration="3600" VaryByParam="Language" VaryByCustom="PortalId;UserRoles" %>
<%@ Register TagPrefix="dnn" TagName="MENU" Src="~/DesktopModules/DDRMenu/Menu.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.DDRMenu.TemplateEngine" Assembly="DotNetNuke.Web.DDRMenu" %>
<dnn:MENU id="secondaryMenu" runat="server" ClientIDMode="Static" MenuStyle="MegaDrop" />
