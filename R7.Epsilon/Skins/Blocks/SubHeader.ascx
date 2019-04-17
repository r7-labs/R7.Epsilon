﻿<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Register TagPrefix="dnn" TagName="BREADCRUMB" Src="~/Admin/Skins/BreadCrumb.ascx" %>
<%@ Register TagPrefix="skin" TagName="PAGEHEADER" Src="../SkinObjects/PageHeader.ascx" %>
<%@ Register TagPrefix="skin" TagName="LOCALMENU" Src="../SkinObjects/LocalMenu.ascx" %>
<%@ Register TagPrefix="skin" TagName="HEADERSMENU" Src="../SkinObjects/HeadersMenu.ascx" %>
<%@ Register TagPrefix="skin" TagName="SOCIALSHAREBUTTONS" Src="../SkinObjects/SocialShareButtons.ascx" %>

<nav class="skin-local-navbar" role="navigation">
    <div class="container">
        <div class="breadcrumb">
            <dnn:BREADCRUMB id="dnnBREADCRUMB" runat="server" CssClass="skin-breadcrumb-link" RootLevel="-1" Separator="/" />
        </div>
    </div>
    <div class="container">
        <div class="page-header">
            <skin:PAGEHEADER runat="server" />
        </div>
        <skin:LOCALMENU runat="server" />
        <skin:HEADERSMENU runat="server" PassDefaultTemplateArgs="false" />
        <div id="skin-separator-1" class="d-xs-none">&nbsp;</div>
        <skin:SOCIALSHAREBUTTONS runat="server" />
    </div>
</nav>
<a id="content" name="content"></a>