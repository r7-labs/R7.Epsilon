<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.FooterContent" %>
<%@ OutputCache Duration="1200" VaryByParam="TabId;Language" %>
<div class="<%= CssClass %>"><%= Localizer.GetString (ResourceKey) %></div>