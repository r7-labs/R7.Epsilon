﻿<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.LocalMenu" %>
<%@ Register TagPrefix="dnn" TagName="MENU" Src="~/DesktopModules/DDRMenu/Menu.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.DDRMenu.TemplateEngine" Assembly="DotNetNuke.Web.DDRMenu" %>
<div id="<%: menuLocal.ClientID %>" class="skin-local-menu">
    <dnn:MENU id="menuLocal" runat="server" MenuStyle="Mega2Epsilon" NodeSelector="-1,0,2">
        <TemplateArguments>
            <dnn:TemplateArgument Name="hamburgerMenu" Value="1" />
            <dnn:TemplateArgument Name="subMenuColumns" Value="1" />
        </TemplateArguments>
    </dnn:MENU>
</div>
