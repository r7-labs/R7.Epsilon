<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit.ascx.cs" Inherits="R7.Epsilon.Edit" %>
<%@ Register TagPrefix="dnn" TagName="LOGO" Src="~/Admin/Skins/Logo.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LANGUAGE" Src="~/Admin/Skins/Language.ascx" %>
<%@ Register TagPrefix="dnn" TagName="SEARCH" Src="~/Admin/Skins/Search.ascx" %>
<%@ Register TagPrefix="dnn" TagName="USER" Src="~/Admin/Skins/User.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LOGIN" Src="~/Admin/Skins/Login.ascx" %>
<%@ Register TagPrefix="dnn" TagName="PRIVACY" Src="~/Admin/Skins/Privacy.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TERMS" Src="~/Admin/Skins/Terms.ascx" %>
<%@ Register TagPrefix="dnn" TagName="COPYRIGHT" Src="~/Admin/Skins/Copyright.ascx" %>
<%@ Register TagPrefix="dnn" TagName="JQUERY" Src="~/Admin/Skins/jQuery.ascx" %>
<%@ Register TagPrefix="dnn" TagName="META" Src="~/Admin/Skins/Meta.ascx" %>
<%@ Register TagPrefix="dnn" TagName="BANNER" Src="~/Admin/Skins/Banner.ascx" %>
<%@ Register TagPrefix="dnn" TagName="BREADCRUMB" Src="~/Admin/Skins/BreadCrumb.ascx" %>
<%@ Register TagPrefix="skin" TagName="FUNCTIONS" Src="Controls/Functions.ascx" %>
<%@ Register TagPrefix="skin" TagName="SOCIALGROUPS" Src="Controls/SocialGroups.ascx" %>
<%@ Register TagPrefix="skin" TagName="FOUNDERS" Src="Controls/Founders.ascx" %>
<%@ Register TagPrefix="skin" TagName="LOGOTITLE" Src="Controls/LogoTitle.ascx" %>
<%@ Register TagPrefix="skin" TagName="LOGOMOBILE" Src="Controls/LogoMobile.ascx" %>
<%@ Register TagPrefix="skin" TagName="FEEDBACKBUTTON" Src="Controls/FeedbackButton.ascx" %>
<%@ Register TagPrefix="skin" TagName="FOOTERCONTENT" Src="Controls/FooterContent.ascx" %>
<%@ Register TagPrefix="skin" TagName="YCYCOUNTER" Src="Controls/YCycounter.ascx" %>
<%@ Register TagPrefix="skin" TagName="PRIMARYMENU" Src="Controls/PrimaryMenu.ascx" %>
<%@ Register TagPrefix="skin" TagName="SECONDARYMENU" Src="Controls/SecondaryMenu.ascx" %>
<%@ Register TagPrefix="skin" TagName="JSVARIABLES" Src="Controls/JsVariables.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>

<dnn:META ID="bootstrapIECompat" runat="server" Name="X-UA-Compatible" Content="IE=edge" />
<dnn:META ID="mobileScale" runat="server" Name="viewport" Content="width=device-width,initial-scale=1" />
<dnn:DnnCssInclude ID="bootStrapCSS" runat="server" FilePath="css/bootstrap.min.css" PathNameAlias="SkinPath" Priority="14" />
<dnn:DnnCssInclude ID="bootStrapThemeCSS" runat="server" FilePath="css/bootstrap-theme.min.css" PathNameAlias="SkinPath" Priority="14" />
<dnn:DnnCssInclude id="skinCSS" runat="server" FilePath="<%# Config.SkinCss %>" PathNameAlias="SkinPath" />
<dnn:DnnCssInclude runat="server" FilePath="~/Resources/Shared/components/flowplayer/skin/minimalist.css" />
<dnn:JQUERY ID="dnnjQuery" runat="server" jQueryHoverIntent="true" />
<dnn:DnnJsInclude ID="bootstrapJS" runat="server" FilePath="js/bootstrap.min.js" PathNameAlias="SkinPath" Priority="10" ForceProvider="DnnFormBottomProvider" />
<dnn:DnnJsInclude ID="menuJS" runat="server" FilePath="js/menu.min.js" PathNameAlias="SkinPath" ForceProvider="DnnFormBottomProvider" />
<dnn:DnnJsInclude ID="skinJS" runat="server" FilePath="js/skin.min.js" PathNameAlias="SkinPath" ForceProvider="DnnFormBottomProvider" />
<dnn:DnnJsInclude runat="server" FilePath="rangy/rangy-core.js" PathNameAlias="SharedScripts" ForceProvider="DnnFormBottomProvider" />
<dnn:DnnJsInclude runat="server" FilePath="~/Resources/Shared/components/flowplayer/flowplayer.min.js" ForceProvider="DnnFormBottomProvider" />

<skin:JSVARIABLES runat="server" BreadCrumbsRemoveLastLink="false" />
<header>
    <div class="container">
        <div class="row">
            <asp:HyperLink runat="server" href="#content" CssClass="sr-only sr-only-focusable" Text='<%# Localizer.GetString ("SkipToContent.Text") %>' />
        </div>
        <div class="row">
            <div class="col-md-4 col-sm-4 col-xs-10 skin-functions-wrapper">
                <div class="skin-language">
                    <dnn:LANGUAGE runat="server" ShowLinks="True" ShowMenu="False" />
                </div>
                <div class="skin-functions">
                    <skin:FUNCTIONS runat="server" />
                    <asp:HyperLink id="linkA11yVersion" runat="server" CssClass="skin-functions-icon skin-functions-icon-a11y" data-toggle="tooltip" data-placement="bottom" />
                </div>
            </div>
            <div class="visible-xs col-xs-2 skin-socialgroups-wrapper">
                <skin:SOCIALGROUPS runat="server" MobileView="true" />
            </div>
            <div class="col-md-4 col-sm-3 col-xs-12 skin-search" role="search">
                <dnn:SEARCH runat="server" ShowSite="false" ShowWeb="false" />
            </div>
            <div class="col-md-4 col-sm-5 hidden-xs skin-socialgroups-wrapper">
                <skin:SOCIALGROUPS runat="server" MobileView="false" />
            </div>
        </div>
    </div>
    <nav class="navbar skin-primary-navbar">
        <div class="container">
            <div class="navbar-brand skin-navbar-brand-link visible-xs">
                <skin:LOGOMOBILE runat="server" />
            </div>
            <button type="button" class="navbar-toggle skin-top-menu-toggle" data-toggle="collapse" data-target=".skin-top-menu">
                <asp:Label runat="server" CssClass="sr-only" Text='<%# Localizer.GetString ("ToggleNavigation.Text") %>' />
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <div class="skin-login-simple visible-xs">
                <dnn:USER runat="server" LegacyMode="false" />
                <dnn:LOGIN runat="server" CssClass="skin-login-link" />
            </div>
            <div class="navbar-collapse collapse dnnClear skin-top-menu" role="navigation">
                <skin:PRIMARYMENU runat="server" />
            </div>
            <div class="navbar-collapse collapse skin-primary-navbar-main">
                <div class="skin-founders-wrapper">
                    <skin:FOUNDERS runat="server" Target="_blank" />
                </div>
                <div class="navbar-brand skin-navbar-brand-logo">
                    <dnn:LOGO runat="server" id="dnnLOGO" />
                </div>
                <div class="skin-logo-title-wrapper hidden-xs">
                    <skin:LOGOTITLE runat="server" />
                </div>
                <div class="skin-login-full">
                    <dnn:LOGIN CssClass="LoginLink" runat="server" LegacyMode="false" />
                    <dnn:USER runat="server" LegacyMode="false" />
                </div>
            </div>
        </div>
    </nav>
    <nav class="navbar skin-secondary-navbar" role="navigation">
        <div class="container">
            <div class="navbar-collapse collapse dnnClear skin-top-menu">
                <skin:SECONDARYMENU runat="server" />   
            </div>
        </div>
    </nav>
    <nav class="navbar skin-local-navbar" role="navigation">
        <div class="container">
            <div class="breadcrumb">
                <dnn:BREADCRUMB id="dnnBREADCRUMB" runat="server" CssClass="skin-breadcrumb-link" RootLevel="-1" Separator="/" />
            </div>
        </div>
    </nav>
</header>
<a id="content" name="content"></a>
<div class="container">
    <div class="row">
        <div id="ContentPane" runat="server" class="col-md-12" />
    </div>
</div>
<footer class="footer skin-footer">
    <div class="skin-footer-main">
        <div class="container">
            <div class="row">
                <div class="col-lg-8 col-md-10 col-sm-12">
                    <div class="row">
                        <div class="skin-footer-buttons col-sm-6 hidden-xs">
                            <dnn:BANNER id="dnnBanner1" runat="server" GroupName="<%# Config.FooterButtonsGroupName %>" BannerTypeId="4" BannerCount="3" Orientation="H" AllowNullBannerType="true" />    
                        </div>
                        <skin:FOOTERCONTENT runat="server" CssClass="skin-footer-content col-sm-6" ResourceKey="FooterPane1.Content" />
                    </div>
                </div>
                <skin:FOOTERCONTENT runat="server" CssClass="col-lg-2 col-md-2 col-sm-6 skin-footer-content" ResourceKey="FooterPane2.Content" />
                <skin:FOOTERCONTENT runat="server" CssClass="col-lg-2 col-sm-6 skin-footer-content" ResourceKey="FooterPane3.Content" />
            </div>
        </div>
    </div>
    <div class="skin-footer-last">
        <div class="container">
            <div class="row">
                <div class="col-md-2 col-sm-4 col-xs-12 skin-footer-88x31-buttons">
                    <skin:YCYCOUNTER runat="server" />
                </div>
                <div class="col-md-10 col-sm-8 col-xs-12 skin-terms">
                    <div>
                        <dnn:COPYRIGHT runat="server" /> |
                        <asp:Label runat="server" CssClass="skin-copyright" Text='<%# Localizer.GetString ("SkinCopyright.Text") %>' />
                        <% if (Config.ShowTerms) { %> | <dnn:TERMS runat="server" /> <% } %>
                        <% if (Config.ShowPrivacy) { %> | <dnn:PRIVACY runat="server" /> <% } %>
                    </div>
                    <div><%= Localizer.GetString ("CopyrightNote.Text") %></div>
                </div>
            </div>
        </div>
    </div>
</footer>
<div class="skin-float-button-wrapper">
    <asp:HyperLink runat="server" href="#" CssClass="skin-float-button skin-float-button-up" Style="display:none" ToolTip='<%# Localizer.GetString ("ButtonUp.Title") %>' data-toggle="tooltip" data-placement="left" data-container="body" />
    <skin:FEEDBACKBUTTON runat="server" CssClass="skin-float-button skin-float-button-feedback" Target="_blank" />
</div>