<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.LogoTitle" %>
<%@ OutputCache Duration="1200" VaryByParam="TabId;Language" %>
<a href="<%= HomeTabFullUrl %>">
    <div class="skin-logo-title" ><%= Localizer.SafeGetString ("LogoTitle.Text", PortalSettings.PortalName) %></div>
    <div class="skin-logo-title-motto"><%= Localizer.GetString ("LogoTitle.Motto") %></div>
</a>