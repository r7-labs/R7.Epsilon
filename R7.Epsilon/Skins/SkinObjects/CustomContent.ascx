<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.CustomContent" %>
<%@ OutputCache Duration="1200" VaryByParam="Language" VaryByCustom="PortalId" %>
<div class="skin-custom-content <%= CssClass %>" data-resource-key="<%= ResourceKey %>"><%= Localizer.GetString (ResourceKey) %></div>
