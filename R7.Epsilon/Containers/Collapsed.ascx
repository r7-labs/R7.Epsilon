<%@ Control Language="C#" AutoEventWireup="false" Inherits="R7.Epsilon.EpsilonContainerBase" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>
<div class="cnt-collapse dnnClear">
    <h2><a class="collapsed" data-toggle="collapse" data-target="#<%= ClientID %>_ContentPane">
        <dnn:TITLE ID="dnnTITLE" runat="server" CssClass="h2" /></a></h2>
    <div id="ContentPane" runat="server"
        class="cnt-content collapse" aria-expanded="false" style="height:0px;"></div>
</div>