<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.BrowserCheck" %>
<% if (!IsCompatibleBrowser) { %>
<div class="alert alert-warning alert-dismissible" role="alert">
    <button type="button" class="close" data-dismiss="alert" aria-label="<%: T.GetString ("Close.Text") %>">
        <span aria-hidden="true">&times;</span>
    </button>
    <%= T.GetString ("BrowserCheck.Warning") %>
</div>
<% } %>
