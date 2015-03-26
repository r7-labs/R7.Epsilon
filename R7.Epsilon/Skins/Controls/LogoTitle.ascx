<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.LogoTitle" %>
<%@ OutputCache Duration="1200" VaryByParam="TabId" %>
<a class="skin-logo-title" href="/<%= CultureInfo.CurrentCulture.Name.ToLowerInvariant() %>" hreflang="<%= CultureInfo.CurrentCulture.TwoLetterISOLanguageName %>"><%= Localizer.SafeGetString ("LogoTitle.Text", PortalSettings.PortalName) %></a>
<div class="skin-logo-title-motto"><%= Localizer.GetString ("LogoTitle.Motto") %></div>