<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Register TagPrefix="dnn" TagName="LOGO" Src="~/Admin/Skins/Logo.ascx" %>
<%@ Register TagPrefix="dnn" TagName="USER" Src="~/Admin/Skins/User.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LOGIN" Src="~/Admin/Skins/Login.ascx" %>
<%@ Register TagPrefix="skin" TagName="BROWSERCHECK" Src="../SkinObjects/BrowserCheck.ascx" %>
<%@ Register TagPrefix="skin" TagName="FUNCTIONS" Src="../SkinObjects/Functions.ascx" %>
<%@ Register TagPrefix="skin" TagName="SOCIALGROUPS" Src="../SkinObjects/SocialGroups.ascx" %>
<%@ Register TagPrefix="skin" TagName="PRIMARYMENU" Src="../SkinObjects/PrimaryMenu.ascx" %>
<%@ Register TagPrefix="skin" TagName="SECONDARYMENU" Src="../SkinObjects/SecondaryMenu.ascx" %>
<%@ Register TagPrefix="skin" TagName="FOUNDERS" Src="../SkinObjects/Founders.ascx" %>
<%@ Register TagPrefix="skin" TagName="LOGOTITLE" Src="../SkinObjects/LogoTitle.ascx" %>
<%@ Register TagPrefix="skin" TagName="LOGOMOBILE" Src="../SkinObjects/LogoMobile.ascx" %>
<%@ Register TagPrefix="skin" TagName="CUSTOMCONTENT" Src="../SkinObjects/CustomContent.ascx" %>
<%@ Register TagPrefix="skin" TagName="LANGUAGES" Src="../SkinObjects/Languages.ascx" %>

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
        <div class="col-md-3 col-sm-4 col-xs-6 skin-functions-wrapper">
            <div class="skin-functions">
                <skin:FUNCTIONS runat="server" />
                <asp:HyperLink id="linkA11yVersion" runat="server" CssClass="skin-functions-icon skin-functions-icon-a11y" data-toggle="tooltip" data-placement="bottom" />
            </div>
        </div>
        <div class="col-md-3 col-sm-12">
            <div class="dropdown">
                <button type="button" class="btn btn-outline-secondary skin-languages-btn dropdown-toggle"
                    data-toggle="dropdown"
                    title='<%: Localizer.GetString("Languages.Text") %>'>
                    <strong><%: System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToUpperInvariant() %></strong>
                </button>
                <skin:LANGUAGES runat="server" />
            </div>
            <button type="button" role="search" class="btn btn-outline-secondary skin-search-btn"
                data-toggle="modal" data-target="#searchModal"
                title='<%: Localizer.GetString("SearchModalButton.Text") %>'>
                <i class="fas fa-search"></i>
            </button>
			<div class="dropdown">
                <button type="button" class="btn btn-outline-secondary skin-a11y-btn dropdown-toggle"
                    data-toggle="dropdown"
                    title='<%: Localizer.GetString("A11y.Text") %>'>
                    <i class="fas fa-universal-access"></i>
                </button>
				<div class="dropdown-menu">
					<% if (Config.Themes.Count > 1) { %>
						<% for (var i = 0; i < Config.Themes.Count; i++) {
							var theme = Config.Themes [i];
							var isCurrentTheme = (Config.GetTheme (Request) ?? Config.Themes [0]).Name;
							%>
							<a class='<%: theme.Name == isCurrentTheme ? "dropdown-item disabled" : "dropdown-item"  %>'
								href="?theme=<%: theme.Name %>">
								<span style="color: <%: theme.Color %>">
									<i class='<%: theme.IsA11yTheme ? "fas fa-adjust" : "fas fa-circle" %>'></i>
								</span>
								<%: Localizer.GetString ("Theme_" + theme.Name + ".Text") %>
								<% if (i == 0) { %>
									<%: Localizer.GetString ("DefaultTheme.Text") %>
								<% } %>
							</a>
						<% } %>
						<div class="dropdown-divider"></div>
					<% } %>
					<a class="dropdown-item" href="javascript:skinA11y.increaseFontSize()">
						<i class="fas fa-font"></i><i class="fas fa-arrow-up"></i> <%: Localizer.GetString("A11yIncreaseFontSize.Text") %></a>
					<a class="dropdown-item" href="javascript:skinA11y.decreaseFontSize()">
						<i class="fas fa-font"></i><i class="fas fa-arrow-down"></i> <%: Localizer.GetString("A11yDecreaseFontSize.Text") %></a>
					<div class="dropdown-divider"></div>
    				<a id="lnkDisablePopups" role="checkbox" class="dropdown-item" href="javascript:skinA11y.disablePopups()">
						<i class="far fa-square"></i> <%: Localizer.GetString("A11yDisablePopups.Text") %></a>
					<a id="lnkReEnablePopups" role="checkbox" class="dropdown-item d-none" href="javascript:skinA11y.reEnablePopups()">
						<i class="fas fa-check-square"></i>	<%: Localizer.GetString("A11yDisablePopups.Text") %></a>
					<div class="dropdown-divider"></div>
						<a class="dropdown-item" href="javascript:skinA11y.restoreDefaults()">
						<i class="fas fa-undo"></i></i> <%: Localizer.GetString("A11yRestoreDefaults.Text") %></a>
  				</div>
			</div>
        </div>
        <div class="col-md-3 col-sm-6 col-xs-4 skin-socialgroups-wrapper">
            <skin:SOCIALGROUPS runat="server" />
        </div>
    </div>
</div>
<nav class="navbar navbar-expand-md bg-dark navbar-dark --sticky-top navbar-1 --skin-primary-navbar">
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



<div class="skin-login-full">
    <dnn:LOGIN CssClass="LoginLink" runat="server" LegacyMode="false" />
    <dnn:USER runat="server" LegacyMode="false" />
</div>
