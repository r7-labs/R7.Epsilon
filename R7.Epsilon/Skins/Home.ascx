<%@ Control Language="C#" AutoEventWireup="true" Inherits="R7.Epsilon.Skins.EpsilonSkinBase" %>
<%@ Register TagPrefix="dnn" TagName="LOGO" Src="~/Admin/Skins/Logo.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LANGUAGE" Src="~/Admin/Skins/Language.ascx" %>
<%@ Register TagPrefix="dnn" TagName="SEARCH" Src="~/Admin/Skins/Search.ascx" %>
<%@ Register TagPrefix="dnn" TagName="USER" Src="~/Admin/Skins/User.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LOGIN" Src="~/Admin/Skins/Login.ascx" %>
<%@ Register TagPrefix="dnn" TagName="PRIVACY" Src="~/Admin/Skins/Privacy.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TERMS" Src="~/Admin/Skins/Terms.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TAGS" Src="~/Admin/Skins/Tags.ascx" %>
<%@ Register TagPrefix="dnn" TagName="COPYRIGHT" Src="~/Admin/Skins/Copyright.ascx" %>
<%@ Register TagPrefix="dnn" TagName="JQUERY" Src="~/Admin/Skins/jQuery.ascx" %>
<%@ Register TagPrefix="dnn" TagName="META" Src="~/Admin/Skins/Meta.ascx" %>
<%@ Register TagPrefix="dnn" TagName="BREADCRUMB" Src="~/Admin/Skins/BreadCrumb.ascx" %>
<%@ Register TagPrefix="dnn" TagName="JavaScriptLibraryInclude" Src="~/admin/Skins/JavaScriptLibraryInclude.ascx" %>
<%@ Register TagPrefix="skin" TagName="FUNCTIONS" Src="SkinObjects/Functions.ascx" %>
<%@ Register TagPrefix="skin" TagName="GADSENSE" Src="SkinObjects/GAdsense.ascx" %>
<%@ Register TagPrefix="skin" TagName="SOCIALGROUPS" Src="SkinObjects/SocialGroups.ascx" %>
<%@ Register TagPrefix="skin" TagName="SOCIALSHAREBUTTONS" Src="SkinObjects/SocialShareButtons.ascx" %>
<%@ Register TagPrefix="skin" TagName="SHAREDSCRIPTS" Src="SkinObjects/SharedScripts.ascx" %>
<%@ Register TagPrefix="skin" TagName="FOUNDERS" Src="SkinObjects/Founders.ascx" %>
<%@ Register TagPrefix="skin" TagName="LOGOTITLE" Src="SkinObjects/LogoTitle.ascx" %>
<%@ Register TagPrefix="skin" TagName="LOGOMOBILE" Src="SkinObjects/LogoMobile.ascx" %>
<%@ Register TagPrefix="skin" TagName="BROWSERCHECK" Src="SkinObjects/BrowserCheck.ascx" %>
<%@ Register TagPrefix="skin" TagName="FEEDBACKBUTTON" Src="SkinObjects/FeedbackButton.ascx" %>
<%@ Register TagPrefix="skin" TagName="FOOTERCONTENT" Src="SkinObjects/FooterContent.ascx" %>
<%@ Register TagPrefix="skin" TagName="YCYCOUNTER" Src="SkinObjects/YCycounter.ascx" %>
<%@ Register TagPrefix="skin" TagName="PRIMARYMENU" Src="SkinObjects/PrimaryMenu.ascx" %>
<%@ Register TagPrefix="skin" TagName="SECONDARYMENU" Src="SkinObjects/SecondaryMenu.ascx" %>
<%@ Register TagPrefix="skin" TagName="HEADERSMENU" Src="SkinObjects/HeadersMenu.ascx" %>
<%@ Register TagPrefix="skin" TagName="JSVARIABLES" Src="SkinObjects/JsVariables.ascx" %>
<%@ Register TagPrefix="skin" TagName="BANNER" Src="SkinObjects/Banners/BannerLoader.ascx" %>
<%@ Register TagPrefix="skin" TagName="PARTIALCONTENTALERT" Src="SkinObjects/PartialContentAlert.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>

<dnn:META ID="bootstrapIECompat" runat="server" Name="X-UA-Compatible" Content="IE=edge" />
<dnn:META ID="mobileScale" runat="server" Name="viewport" Content="width=device-width,initial-scale=1" />
<dnn:DnnCssInclude ID="bootStrapCSS" runat="server" Name="bootstrap" Version="4.3.1" FilePath="css/bootstrap.min.css" PathNameAlias="SkinPath" Priority="14" />
<dnn:DnnCssInclude id="skinCSS" runat="server" FilePath="<%# Config.SkinCss %>" PathNameAlias="SkinPath" />
<dnn:JQUERY ID="dnnjQuery" runat="server" jQueryHoverIntent="true" />
<dnn:DnnJsInclude ID="bootstrapJS" runat="server" Name="bootstrap" Version="4.3.1" FilePath="js/bootstrap.min.js" PathNameAlias="SkinPath" Priority="10" ForceProvider="DnnFormBottomProvider" />
<dnn:DnnJsInclude runat="server" FilePath="js/bootstrap-init.min.js" PathNameAlias="SkinPath" ForceProvider="DnnFormBottomProvider" />
<dnn:DnnJsInclude ID="menuJS" runat="server" FilePath="js/menu.min.js" PathNameAlias="SkinPath" ForceProvider="DnnFormBottomProvider" />
<dnn:DnnJsInclude ID="skinJS" runat="server" FilePath="js/skin.min.js" PathNameAlias="SkinPath" ForceProvider="DnnFormBottomProvider" />
<dnn:DnnJsInclude runat="server" FilePath="js/feedback.min.js" PathNameAlias="SkinPath" ForceProvider="DnnFormBottomProvider" />
<dnn:JavaScriptLibraryInclude runat="server" Name="LazyAds" />
<dnn:JavaScriptLibraryInclude runat="server" Name="Rangy" />

<skin:JSVARIABLES runat="server" />
<div id="vk_api_transport"></div>
<div id="fb-root"></div>
<header>
    <div class="container">
        <div class="row">
            <asp:HyperLink runat="server" href="#content" CssClass="sr-only sr-only-focusable" Text='<%# Localizer.GetString ("SkipToContent.Text") %>' />
            <skin:BROWSERCHECK runat="server" />
        </div>
        <div class="row">
            <div class="col-md-4 col-md-push-4 col-sm-12 skin-search" role="search">
                <dnn:SEARCH runat="server" ShowSite="false" ShowWeb="false" />
            </div>
            <div class="col-md-4 col-md-pull-4 col-sm-6 col-xs-6 skin-functions-wrapper">
                <div class="skin-language">
                    <dnn:LANGUAGE runat="server" ShowLinks="True" ShowMenu="False" />
                </div>
                <div class="skin-functions">
                    <skin:FUNCTIONS runat="server" />
                    <asp:HyperLink id="linkA11yVersion" runat="server" CssClass="skin-functions-icon skin-functions-icon-a11y" data-toggle="tooltip" data-placement="bottom" />
                </div>
            </div>
            <div class="col-md-4 col-sm-6 col-xs-6 skin-socialgroups-wrapper">
                <skin:SOCIALGROUPS runat="server" />
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
                <div class="skin-header-content hidden-sm">
                    <skin:LOGOTITLE runat="server" />
                </div>
                <skin:FOOTERCONTENT runat="server" CssClass="skin-header-content hidden-xs" ResourceKey="HeaderPane1.Content" />
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
			<h1 class="sr-only"><%# PortalSettings.ActiveTab.LocalizedTabName %></h1>
            <skin:HEADERSMENU runat="server" PassDefaultTemplateArgs="false" />
            <div id="skin-separator-1" class="hidden-xs hidden-local">&nbsp;</div>
            <skin:SOCIALSHAREBUTTONS runat="server" />
        </div>
    </nav>
</header>
<a id="content" name="content"></a>
<div id="CarouselPane" runat="server" class="carousel slide" containertype="G" containername="R7.Epsilon" containersrc="Blank.ascx" />
<div class="container">
    <div class="row">
        <div id="TopPane" runat="server" class="col-md-12" />
    </div>
    <div class="row">
        <div id="TopLeftPane" runat="server" class="col-md-8" />
        <div id="TopRightPane" runat="server" class="col-md-4" />
    </div>
    <div class="row">
        <div id="TopPane11" runat="server" class="col-md-4" />
        <div id="TopPane12" runat="server" class="col-md-4" />
        <div id="TopPane13" runat="server" class="col-md-4" />
    </div>
    <div class="row">
        <div id="TopPane21" runat="server" class="col-md-4" />
        <div id="TopPane22" runat="server" class="col-md-4" />
        <div id="TopPane23" runat="server" class="col-md-4" />
    </div>
    <div class="row">
        <div id="TopPane31" runat="server" class="col-md-4" />
        <div id="TopPane32" runat="server" class="col-md-4" />
        <div id="TopPane33" runat="server" class="col-md-4" />
    </div>
	<skin:PARTIALCONTENTALERT runat="server" />
    <div class="row">
        <div id="ContentPane" runat="server" class="col-md-9 col-sm-7" />
        <div id="RightPane" runat="server" class="col-md-3 col-sm-5" />
    </div>
    <div class="row"> 
        <div id="LeftPane" runat="server" class="col-md-3 col-sm-5" />
        <div id="ContentLeftPane" runat="server" class="col-md-9 col-sm-7" />
    </div>
    <div class="row">
        <div id="ContentPane2" runat="server" class="col-md-9 col-sm-7" />
        <div id="RightPane2" runat="server" class="col-md-3 col-sm-5" />
    </div>
    <div class="row"> 
        <div id="LeftPane2" runat="server" class="col-md-3 col-sm-5" />
        <div id="ContentLeftPane2" runat="server" class="col-md-9 col-sm-7" />
    </div>
    <div class="row">
        <div id="MiddlePane11" runat="server" class="col-md-4" />
        <div id="MiddlePane12" runat="server" class="col-md-4" />
        <div id="MiddlePane13" runat="server" class="col-md-4" />
    </div>    
    <div class="row">
        <div id="MiddlePane" runat="server" class="col-md-12" />
    </div>
    <div class="row">
        <div id="MiddlePane21" runat="server" class="col-md-4" />
        <div id="MiddlePane22" runat="server" class="col-md-4" />
        <div id="MiddlePane23" runat="server" class="col-md-4" />
    </div>
    <div class="row">
        <div id="ContentPane3" runat="server" class="col-md-9 col-sm-7" />
        <div id="RightPane3" runat="server" class="col-md-3 col-sm-5" />
    </div>
    <div class="row"> 
        <div id="LeftPane3" runat="server" class="col-md-3 col-sm-5" />
        <div id="ContentLeftPane3" runat="server" class="col-md-9 col-sm-7" />
    </div>
    <div class="row">
        <div id="ContentPane4" runat="server" class="col-md-9 col-sm-7" />
        <div id="RightPane4" runat="server" class="col-md-3 col-sm-5" />
    </div>
    <div class="row"> 
        <div id="LeftPane4" runat="server" class="col-md-3 col-sm-5" />
        <div id="ContentLeftPane4" runat="server" class="col-md-9 col-sm-7" />
    </div>
    <div class="row">
        <div id="BottomPane11" runat="server" class="col-md-4" />
        <div id="BottomPane12" runat="server" class="col-md-4" />
        <div id="BottomPane13" runat="server" class="col-md-4" />
    </div>
    <div class="row">
        <div id="BottomPane21" runat="server" class="col-md-4" />
        <div id="BottomPane22" runat="server" class="col-md-4" />
        <div id="BottomPane23" runat="server" class="col-md-4" />
    </div>
    <div class="row">
        <div id="BottomPane31" runat="server" class="col-md-4" />
        <div id="BottomPane32" runat="server" class="col-md-4" />
        <div id="BottomPane33" runat="server" class="col-md-4" />
    </div>
    <div class="row">
        <div id="BottomLeftPane" runat="server" class="col-md-6" />
        <div id="BottomRightPane" runat="server" class="col-md-6" />
    </div>
    <div class="row">
        <div id="BottomPane" runat="server" class="col-md-12" />
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="skin-tags">
                <dnn:TAGS runat="server" AllowTagging="false" Separator=" " />
            </div>
        </div>
    </div>
</div>
<footer class="footer skin-footer">
    <div class="skin-footer-main">
        <div class="container">
            <div class="row">
                <div class="col-lg-8 col-md-10 col-sm-12">
                    <div class="skin-banner">
                        <skin:GADSENSE runat="server" />
                    </div>
                    <div class="row">
                        <div class="skin-footer-buttons col-sm-6 hidden-xs">
                            <skin:BANNER runat="server" GroupName="<%# Config.FooterButtonsGroupName %>" BannerTypeId="4" BannerCount="3" Orientation="H" />
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
                <div class="col-md-2 col-sm-3 col-xs-12 skin-footer-88x31-buttons">
                    <skin:YCYCOUNTER runat="server" />
                </div>
                <div class="col-md-10 col-sm-9 col-xs-12 skin-terms">
                    <div>
                        <dnn:COPYRIGHT runat="server" /> |
                        <asp:Label runat="server" CssClass="skin-copyright" Text='<%# SkinCopyright %>' />
                        <asp:Literal runat="server" Visible='<%# Config.ShowTerms %>' Text="|" />
                        <dnn:TERMS   runat="server" Visible='<%# Config.ShowTerms %>' />
                        <asp:Literal runat="server" Visible='<%# Config.ShowPrivacy %>' Text="|" />
                        <dnn:PRIVACY runat="server" Visible='<%# Config.ShowPrivacy %>' />
                    </div>
                    <div>
                        <asp:Label runat="server" Text='<%# Localizer.GetString ("CopyrightNote.Text") %>' />
                    </div>
                </div>
            </div>
        </div>
    </div>
</footer>
<div class="skin-float-button-wrapper">
    <asp:HyperLink runat="server" href="#" CssClass="skin-float-button skin-float-button-up" Style="display:none" ToolTip='<%# Localizer.GetString ("ButtonUp.Title") %>' data-toggle="tooltip" data-placement="left" data-container="body" />
    <skin:FEEDBACKBUTTON runat="server" CssClass="skin-float-button skin-float-button-feedback" />
</div>
<skin:SHAREDSCRIPTS runat="server" />