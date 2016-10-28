<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Components.EpsilonSkinObjectBase" %>
<%@ OutputCache Duration="1200" VaryByParam="Language" VaryByCustom="PortalId" %>
<a href="<%= HomeTabFullUrl %>">
    <div class="skin-logo-title" ><%= Localizer.SafeGetString ("LogoTitle.Text", PortalSettings.PortalName) %></div>
    <div class="skin-logo-title-motto"><%= Localizer.GetString ("LogoTitle.Motto") %></div>
</a>