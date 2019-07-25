<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Import Namespace="DnnGlobals=DotNetNuke.Common.Globals" %>
<%@ Register TagPrefix="dnn" TagName="LOGO" Src="~/Admin/Skins/Logo.ascx" %>
<%@ Register TagPrefix="dnn" TagName="USER" Src="~/Admin/Skins/User.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LOGIN" Src="~/Admin/Skins/Login.ascx" %>
<%@ Register TagPrefix="skin" TagName="BROWSERCHECK" Src="../SkinObjects/BrowserCheck.ascx" %>
<%@ Register TagPrefix="skin" TagName="FUNCTIONS" Src="../SkinObjects/Functions.ascx" %>
<%@ Register TagPrefix="skin" TagName="SOCIALGROUPS" Src="../SkinObjects/SocialGroups.ascx" %>
<%@ Register TagPrefix="skin" TagName="A11YFUNCTIONS" Src="../SkinObjects/A11yFunctions.ascx" %>
<%@ Register TagPrefix="skin" TagName="LANGUAGES" Src="../SkinObjects/Languages.ascx" %>
<%@ Register TagPrefix="skin" TagName="WEBSITES" Src="../SkinObjects/Websites.ascx" %>
<%@ Register TagPrefix="skin" TagName="PRIMARYMENU" Src="../SkinObjects/PrimaryMenu.ascx" %>
<%@ Register TagPrefix="skin" TagName="SECONDARYMENU" Src="../SkinObjects/SecondaryMenu.ascx" %>
<%@ Register TagPrefix="skin" TagName="FOUNDERS" Src="../SkinObjects/Founders.ascx" %>
<%@ Register TagPrefix="skin" TagName="LOGOTITLE" Src="../SkinObjects/LogoTitle.ascx" %>
<%@ Register TagPrefix="skin" TagName="LOGOMOBILE" Src="../SkinObjects/LogoMobile.ascx" %>
<%@ Register TagPrefix="skin" TagName="CUSTOMCONTENT" Src="../SkinObjects/CustomContent.ascx" %>

<div class="container">
    <div class="row">
		<a href='<%= DnnGlobals.NavigateURL ("", "quickA11y", "enable") %>' class="sr-only sr-only-focusable" itemprop="copy"><%: Localizer.GetString ("A11yWebsiteVersion.Text") %></a>
		<a href="#content" class="sr-only sr-only-focusable"><%: Localizer.GetString ("SkipToContent.Text") %></a>
		<skin:BROWSERCHECK runat="server" />
    </div>
</div>
<div class="container --sticky-top">
    <div class="row">
        <div class="col-md-3 col-sm-4 d-xs-none">
            <div class="navbar-brand skin-navbar-brand-logo">
                <dnn:LOGO runat="server" id="dnnLOGO" />
            </div>
        </div>
		<div class="col-md-2 col-sm-4 col-xs-6 skin-functions-wrapper">
            <div class="skin-functions">
				<skin:FUNCTIONS runat="server" />
            </div>
        </div>
        <div class="col-md-7 col-sm-12 text-md-right text-sm-center">
			<button type="button" role="search" class="btn btn-lg skin-search-btn" style="display:inline-block"
                data-toggle="modal" data-target="#searchModal"
                title='<%: Localizer.GetString("SearchModalButton.Text") %>'>
                <i class="fas fa-search"></i>
            </button>
			<div class="card card-body bg-light p-2 mr-2 mb-2" style="display:inline-block">
            	<skin:A11YFUNCTIONS runat="server" />
				<skin:LANGUAGES runat="server" />
			</div>
			<div class="card card-body bg-light p-2 mb-2" style="display:inline-block">
				<% if (Config.Websites.Count > 0) { %>
					<skin:WEBSITES runat="server" />
				<% } %>
				<% if (Config.SocialGroups.Count > 0) { %>
					<skin:SOCIALGROUPS runat="server" />
				<% } %>
			</div>
			<div class="dropdown skin-login" style="display:inline-block">
				<button type="button" class="btn btn-lg dropdown-toggle" data-toggle="dropdown" title='<%: Localizer.GetString ("UserProfile.Text") %>'>
					<i class="fas fa-user"></i>
				</button>
				<div class="dropdown-menu">
					<dnn:LOGIN runat="server" LegacyMode="false" />
					<dnn:USER runat="server" LegacyMode="false" />
				</div>
			</div>
        </div>
    </div>
</div>
<nav class="navbar navbar-expand-md bg-dark navbar-dark --sticky-top navbar-1 --skin-primary-navbar">
    <div class="container">

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

<nav class="navbar navbar-expand-md bg-dark navbar-dark --sticky-top navbar-2 --skin-primary-navbar">
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


