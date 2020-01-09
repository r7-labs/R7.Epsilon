<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.BreadcrumbMenu" %>
<%@ OutputCache Duration="1200" VaryByParam="TabId;Language" VaryByCustom="UserRoles" %>
<%@ Register TagPrefix="dnn" TagName="MENU" Src="~/DesktopModules/DDRMenu/Menu.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.DDRMenu.TemplateEngine" Assembly="DotNetNuke.Web.DDRMenu" %>
<dnn:MENU id="breadcrumbMenu" runat="server" ClientIDMode="Static" MenuStyle="DropCrumb" />
