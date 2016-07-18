<%@ Control Language="C#" AutoEventWireup="false" Inherits="R7.Epsilon.Components.EpsilonContainerBase" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>
<div class="cnt-default dnnClear">
    <h2><dnn:TITLE ID="dnnTITLE" runat="server" CssClass="h2" /></h2>
    <div id="ContentPane" runat="server"></div>
</div>