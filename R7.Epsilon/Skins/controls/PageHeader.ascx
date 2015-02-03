<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.PageHeader" %>
<%@ Register TagPrefix="dnn" TagName="MENU" Src="~/DesktopModules/DDRMenu/Menu.ascx" %>

<%-- TODO: Need to use some kind of skin config for this --%>
<%
    var vk_apiId = 4754730;
    var vk_group = "volgau_com";
    var vk_share_enabled = false;
    var fb_group = "volgau";
    var tw_via = "volgau_com";
    var tw_group = "volgau_com";
    var ok_group = "51992191172689";
    var gp_group = "102055464309901341034/communities/113661705633931940712";
    var yt_group = "UCYPMmQknVPxosuY4iPCfVDg";
%>

<h1>
    <div class="local-menu">
        <dnn:MENU MenuStyle="Mega2Epsilon" runat="server" NodeSelector="-1,0,2" IncludeNodes="<%# PortalSettings.ActiveTab.TabID %>" />
    </div>
    <a href="<%= PortalSettings.ActiveTab.FullUrl %>" alt="<%: PortalSettings.ActiveTab.Title %>" title="<%: PortalSettings.ActiveTab.Title %>"><%: PortalSettings.ActiveTab.TabName %></a>
    <small><%: TagLine %></small>
</h1>
<div class="skin-page-info">
    <small><%: PublishedMessage %></small>

    <%-- TODO: Add link@rel='canonical' --%>
    <div class="skin-page-share-buttons">
        <% if (vk_share_enabled) { %><div id="vk_like"></div><% } %>
        <div class="fb-like" data-href="<%= PortalSettings.ActiveTab.FullUrl %>" data-layout="button_count" data-action="like" data-show-faces="false" data-share="false"></div>
        <a href="https://twitter.com/share" class="twitter-share-button" data-url="<%= PortalSettings.ActiveTab.FullUrl %>" data-lang="<%= CultureInfo.CurrentCulture.TwoLetterISOLanguageName %>" data-via="<%= tw_via %>">Tweet</a>
        <div class="g-plusone" data-size="medium"></div>
    </div>
</div>