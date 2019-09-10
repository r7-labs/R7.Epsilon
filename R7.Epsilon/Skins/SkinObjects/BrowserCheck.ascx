<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.BrowserCheck" %>
<% if (!IsCompatibleBrowser) { %>
<div class="alert alert-warning alert-dismissible" role="alert">
    <button type="button" class="close" data-dismiss="alert" aria-label="<%: Localizer.GetString ("Close.Text") %>">
        <span aria-hidden="true">&times;</span>
    </button>
    <%= Localizer.GetString ("BrowserCheck.Warning") %>
</div>
<% } %>
