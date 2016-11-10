<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ OutputCache Duration="1200" VaryByParam="Language" VaryByCustom="PortalId" %>
<a href="<%= HomeTabFullUrl %>"><%= Localizer.SafeGetString ("LogoTitle.Text", PortalSettings.PortalName) %></a>
<div class="tagline"><%= Localizer.GetString ("LogoTitle.Tagline") %></div>