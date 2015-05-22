<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.HeadersMenu" %>
<%@ OutputCache Duration="10" VaryByParam="TabId;Language" %>
<%@ Register TagPrefix="dnn" TagName="MENU" Src="~/DesktopModules/DDRMenu/Menu.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.DDRMenu.TemplateEngine" Assembly="DotNetNuke.Web.DDRMenu" %>
 <div class="skin-headers-menu">
    <dnn:MENU id="menuHeaders" runat="server" MenuStyle="Mega2Epsilon" NodeSelector="-1,0,0">
        <TemplateArguments>
            <dnn:TemplateArgument Name="hamburgerMenu" Value="1" />
            <dnn:TemplateArgument Name="subMenuColumns" Value="1" />
            <dnn:TemplateArgument Name="resourceKey" Value="HeadersMenu" />
        </TemplateArguments>
    </dnn:MENU>
</div>