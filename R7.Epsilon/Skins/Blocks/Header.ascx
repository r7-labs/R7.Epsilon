<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Import Namespace="DnnGlobals=DotNetNuke.Common.Globals" %>
<%@ Register TagPrefix="dnn" TagName="LOGO" Src="~/Admin/Skins/Logo.ascx" %>
<%@ Register TagPrefix="dnn" TagName="USER" Src="~/Admin/Skins/User.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LOGIN" Src="~/Admin/Skins/Login.ascx" %>
<%@ Register TagPrefix="skin" TagName="SOCIALGROUPS" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/SocialGroups.ascx" %>
<%@ Register TagPrefix="skin" TagName="A11YFUNCTIONS" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/A11yFunctions.ascx" %>
<%@ Register TagPrefix="skin" TagName="LANGUAGES" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/Languages.ascx" %>
<%@ Register TagPrefix="skin" TagName="WEBSITES" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/Websites.ascx" %>
<%@ Register TagPrefix="skin" TagName="PRIMARYMENU" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/PrimaryMenu.ascx" %>
<%@ Register TagPrefix="skin" TagName="SECONDARYMENU" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/SecondaryMenu.ascx" %>
<%@ Register TagPrefix="skin" TagName="LOGOMOBILE" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/LogoMobile.ascx" %>
<%@ Register TagPrefix="skin" TagName="CUSTOMCONTENT" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/CustomContent.ascx" %>
<div class="container">
    <div class="row">
		<a href='<%= DnnGlobals.NavigateURL ("", "a11y", "true") %>' class="sr-only sr-only-focusable" itemprop="copy"><%: T.GetString ("A11yWebsiteVersion.Text") %></a>
		<a href="#content" class="sr-only sr-only-focusable"><%: T.GetString ("SkipToContent.Text") %></a>
    </div>
</div>
<div class="container --sticky-top">
    <div class="row">
        <div class="col-xs-12 col-md col-sm-6 col-lg-3">
            <div class="navbar-brand skn-navbar-brand-logo">
                <dnn:LOGO runat="server" id="dnnLOGO" />
            </div>
        </div>
        <div class="col-xs-12 col-sm-6 col-md col-lg-3 order-md-last text-sm-right">
			<button type="button" role="search" class="btn btn-lg skn-search-btn" style="display:inline-block"
                data-toggle="modal" data-target="#searchModal"
                title='<%: T.GetString("SearchModalButton.Text") %>'>
                <i class="fas fa-search"></i>
            </button>
			<% if (!Skin.Options.DisableLogin) { %>
				<div class="dropdown skn-login" style="display:inline-block">
					<button type="button" class="btn btn-lg dropdown-toggle" data-toggle="dropdown" title='<%: T.GetString ("UserProfile.Text") %>'>
						<i class="fas fa-user"></i>
					</button>
					<div class="dropdown-menu">
						<dnn:LOGIN runat="server" LegacyMode="false" />
						<dnn:USER runat="server" LegacyMode="false" />
					</div>
				</div>
			<% } %>
        </div>
		<hr class="w-100 d-md-none" />
		<div class="col-xs-12 col-sm-12 col-md col-lg-6 text-lg-center">
			<skin:A11YFUNCTIONS runat="server" />
			<skin:LANGUAGES runat="server" />
			<% if (Config.Websites.Count > 0) { %>
				<skin:WEBSITES runat="server" />
			<% } %>
			<% if (Config.SocialGroups.Count > 0) { %>
				<skin:SOCIALGROUPS runat="server" />
			<% } %>
		</div>
	</div>
</div>
<nav class="navbar navbar-expand-md bg-dark navbar-dark skn-menu skn-main-menu skn-primary-menu">
	<div class="container">
		<div class="navbar-brand d-md-none">
			<skin:LOGOMOBILE runat="server" />
		</div>
		<button type="button" class="navbar-toggler" data-toggle="collapse" data-target=".skn-main-menu .navbar-collapse">
			<span class="sr-only"><%: T.GetString ("ToggleNavigation.Text") %></span>
			<span class="navbar-toggler-icon"></span>
		</button>
		<div class="collapse navbar-collapse">
			<skin:PRIMARYMENU runat="server" />
		</div>
	</div>
</nav>
