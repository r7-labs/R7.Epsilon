<%@ Control Language="C#" AutoEventWireup="false" Inherits="R7.Epsilon.EpsilonContainerBase" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>
<div class="cnt-default dnnClear">
    <h2><dnn:TITLE ID="dnnTITLE" runat="server" class="h2" /></h2>
    <div class="ContainerPane" runat="server" id="ContentPane"></div>
</div>