<%@ Control Language="C#" AutoEventWireup="false" Inherits="R7.Epsilon.ContainerBase" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>
<div class="ContainerWrapper dnnClear">
    <h3><dnn:TITLE ID="dnnTITLE" runat="server" CssClass="h3" /></h3>
    <div class="ContainerPane" runat="server" id="ContentPane"></div>
</div>
