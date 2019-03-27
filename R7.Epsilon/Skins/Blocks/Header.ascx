<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Register TagPrefix="dnn" TagName="BREADCRUMB" Src="~/Admin/Skins/BreadCrumb.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LOGO" Src="~/Admin/Skins/Logo.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LANGUAGE" Src="~/Admin/Skins/Language.ascx" %>
<%@ Register TagPrefix="dnn" TagName="SEARCH" Src="~/Admin/Skins/Search.ascx" %>
<%@ Register TagPrefix="dnn" TagName="USER" Src="~/Admin/Skins/User.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LOGIN" Src="~/Admin/Skins/Login.ascx" %>
<%@ Register TagPrefix="skin" TagName="BROWSERCHECK" Src="../SkinObjects/BrowserCheck.ascx" %>
<%@ Register TagPrefix="skin" TagName="FUNCTIONS" Src="../SkinObjects/Functions.ascx" %>
<%@ Register TagPrefix="skin" TagName="SOCIALGROUPS" Src="../SkinObjects/SocialGroups.ascx" %>
<%@ Register TagPrefix="skin" TagName="PAGEHEADER" Src="../SkinObjects/PageHeader.ascx" %>
<%@ Register TagPrefix="skin" TagName="PRIMARYMENU" Src="../SkinObjects/PrimaryMenu.ascx" %>
<%@ Register TagPrefix="skin" TagName="SECONDARYMENU" Src="../SkinObjects/SecondaryMenu.ascx" %>
<%@ Register TagPrefix="skin" TagName="LOCALMENU" Src="../SkinObjects/LocalMenu.ascx" %>
<%@ Register TagPrefix="skin" TagName="HEADERSMENU" Src="../SkinObjects/HeadersMenu.ascx" %>
<%@ Register TagPrefix="skin" TagName="SOCIALSHAREBUTTONS" Src="../SkinObjects/SocialShareButtons.ascx" %>
<%@ Register TagPrefix="skin" TagName="FOUNDERS" Src="../SkinObjects/Founders.ascx" %>
<%@ Register TagPrefix="skin" TagName="LOGOTITLE" Src="../SkinObjects/LogoTitle.ascx" %>
<%@ Register TagPrefix="skin" TagName="LOGOMOBILE" Src="../SkinObjects/LogoMobile.ascx" %>
<%@ Register TagPrefix="skin" TagName="CUSTOMCONTENT" Src="../SkinObjects/CustomContent.ascx" %>

<div class="container">
    <div class="row">
        <asp:HyperLink runat="server" href="#content" CssClass="sr-only sr-only-focusable" Text='<%# Localizer.GetString ("SkipToContent.Text") %>' />
        <skin:BROWSERCHECK runat="server" />
    </div>
</div>
<div class="container sticky-top">
    <div class="row">
        <div class="col-md-3 col-sm-4 d-xs-none">
            <div class="navbar-brand skin-navbar-brand-logo">
                <dnn:LOGO runat="server" id="dnnLOGO" />
            </div>
        </div>
        <div class="col-md-3 col-md-pull-4 col-sm-4 col-xs-6 skin-functions-wrapper">
            <div class="skin-language">
                <dnn:LANGUAGE runat="server" ShowLinks="True" ShowMenu="False" />
            </div>
            <div class="skin-functions">
                <skin:FUNCTIONS runat="server" />
                <asp:HyperLink id="linkA11yVersion" runat="server" CssClass="skin-functions-icon skin-functions-icon-a11y" data-toggle="tooltip" data-placement="bottom" />
            </div>
        </div>
        <div class="col-md-3 col-md-push-4 col-sm-12 skin-search" role="search">
            <dnn:SEARCH runat="server" ShowSite="false" ShowWeb="false" />
        </div>
        <div class="col-md-3 col-sm-6 col-xs-4 skin-socialgroups-wrapper">
            <skin:SOCIALGROUPS runat="server" />
        </div>
    </div>
</div>
<nav class="navbar navbar-expand-md bg-dark navbar-dark sticky-top navbar-1 ---skin-primary-navbar">
    <div class="container">
              
        <div class="skin-login-simple d-md-none">
            <dnn:USER runat="server" LegacyMode="false" />
            <dnn:LOGIN runat="server" CssClass="skin-login-link" />
        </div>

        <div class="navbar-brand skin-navbar-brand-link d-md-none">
            <skin:LOGOMOBILE runat="server" />
        </div>
        
        <button type="button" class="navbar-toggler skin-top-menu-toggle" data-toggle="collapse" data-target=".skin-top-menu">
            <asp:Label runat="server" CssClass="sr-only" Text='<%# Localizer.GetString ("ToggleNavigation.Text") %>' />
            <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse skin-top-menu" role="navigation">
            <skin:PRIMARYMENU runat="server" />
        </div>
<!--
        <div class="collapse navbar-collapse skin-top-menu" role="navigation">
            <skin:SECONDARYMENU runat="server" />
        </div>
        <div class="collapse navbar-collapse skin-primary-navbar-main d-none">
            <div class="skin-founders-wrapper d-none">
                <skin:FOUNDERS runat="server" Target="_blank" />
            </div>
            <div class="skin-header-content d-sm-none">
                <skin:LOGOTITLE runat="server" />
            </div>
            <skin:CUSTOMCONTENT runat="server" CssClass="skin-header-content d-none" ResourceKey="HeaderPane1.Content" />
        </div>
        -->
    </div>
</nav>

<nav class="navbar navbar-expand-md bg-dark navbar-dark sticky-top navbar-2 ---skin-primary-navbar">
    <div class="container">
        <div class="collapse navbar-collapse skin-top-menu" role="navigation">
            <skin:SECONDARYMENU runat="server" />
        </div>
<!--
        <div class="collapse navbar-collapse skin-primary-navbar-main d-none">
            <div class="skin-founders-wrapper d-none">
                <skin:FOUNDERS runat="server" Target="_blank" />
            </div>
          
            <div class="skin-header-content d-sm-none">
                <skin:LOGOTITLE runat="server" />
            </div>
            <skin:CUSTOMCONTENT runat="server" CssClass="skin-header-content d-none" ResourceKey="HeaderPane1.Content" />
        </div>
        -->
    </div>
</nav>



<div class="skin-login-full">
    <dnn:LOGIN CssClass="LoginLink" runat="server" LegacyMode="false" />
    <dnn:USER runat="server" LegacyMode="false" />
</div>
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