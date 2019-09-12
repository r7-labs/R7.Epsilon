<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.Blocks.SubHeader" %>
<%@ Register TagPrefix="dnn" TagName="BREADCRUMB" Src="~/Admin/Skins/BreadCrumb.ascx" %>
<%@ Register TagPrefix="dnn" TagName="MENU" Src="~/DesktopModules/DDRMenu/Menu.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.DDRMenu.TemplateEngine" Assembly="DotNetNuke.Web.DDRMenu" %>
<%@ Register TagPrefix="skin" TagName="PAGEHEADER" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/PageHeader.ascx" %>
<%@ Register TagPrefix="skin" TagName="LOCALMENU" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/LocalMenu.ascx" %>
<%@ Register TagPrefix="skin" TagName="HEADERSMENU" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/HeadersMenu.ascx" %>
<%@ Register TagPrefix="skin" TagName="SOCIALSHAREBUTTONS" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/SocialShareButtons.ascx" %>

<nav class="skin-local-navbar" role="navigation">
    <div class="container">
		<dnn:MENU id="breadcrumb" runat="server" Visible="<%# BreadCrumb %>" MenuStyle="DropCrumb" NodeSelector="*,0,5" />
		<%--
		<div class="breadcrumb">
        	<dnn:BREADCRUMB id="dnnBREADCRUMB" runat="server" CssClass="skin-breadcrumb-link" RootLevel="-1" Separator="/" />
        </div>
		--%>
    </div>
    <div class="container">
        <skin:PAGEHEADER runat="server" />
        <skin:LOCALMENU runat="server" />
        <skin:HEADERSMENU runat="server" PassDefaultTemplateArgs="false" />
        <div id="skin-separator-1" class="d-xs-none">&nbsp;</div>
        <skin:SOCIALSHAREBUTTONS runat="server" Visible="<%# !Skin.Options.DisableSocialShare %>" />
    </div>
</nav>
<a id="content" name="content"></a>
