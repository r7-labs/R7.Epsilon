<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Zeta.Skins.SkinObjects.PrimaryMenu" %>
<%@ OutputCache Duration="3600" VaryByParam="Language" VaryByCustom="PortalId;UserRoles" %>
<%@ Register TagPrefix="dnn" TagName="MENU" Src="~/DesktopModules/DDRMenu/Menu.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.DDRMenu.TemplateEngine" Assembly="DotNetNuke.Web.DDRMenu" %>
<dnn:MENU id="primaryMenu" runat="server" ClientIDMode="Static" MenuStyle="MegaDrop" />
