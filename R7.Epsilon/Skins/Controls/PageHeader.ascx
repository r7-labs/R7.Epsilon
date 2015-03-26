<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.PageHeader" %>
<%@ Register TagPrefix="dnn" TagName="MENU" Src="~/DesktopModules/DDRMenu/Menu.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.DDRMenu.TemplateEngine" Assembly="DotNetNuke.Web.DDRMenu" %>
<div class="skin-local-menu">
    <dnn:MENU id="menuLocal" runat="server" MenuStyle="Mega2Epsilon" NodeSelector="-1,0,2" IncludeNodes="<%# PortalSettings.ActiveTab.TabID %>">
        <TemplateArguments> 
            <dnn:TemplateArgument Name="hamburgerMenu" Value="1" />
            <dnn:TemplateArgument Name="subMenuColumns" Value="1" />
        </TemplateArguments>
    </dnn:MENU>
</div>
<h1>
    <a href="<%= PortalSettings.ActiveTab.FullUrl %>" alt="<%: PortalSettings.ActiveTab.Title %>" title="<%: PortalSettings.ActiveTab.Title %>"><%: PortalSettings.ActiveTab.TabName %></a>
    <small><%: TagLine %></small>
</h1>
<div class="skin-page-info">
    <small><%: PublishedMessage %></small>
    <% if (EnableSocialShare) { %> <%-- TODO: Add link@rel='canonical' --%> <div class="skin-page-share-buttons">
        <% if (Config.VkShareEnabled) { %><div id="vk_like"></div><% } %>
        <div class="fb-like" data-href="<%= PortalSettings.ActiveTab.FullUrl %>" data-layout="button_count" data-action="like" data-show-faces="false" data-share="false"></div>
        <a class="twitter-share-button" href="https://twitter.com/share" data-url="<%= PortalSettings.ActiveTab.FullUrl %>" data-lang="<%= CultureInfo.CurrentCulture.TwoLetterISOLanguageName %>" data-via="<%= Config.TwitterVia %>">Tweet</a>
        <div class="g-plusone" data-size="medium"></div>
    </div><% } %>
</div>