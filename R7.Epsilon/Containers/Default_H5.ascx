<%@ Control Language="C#" AutoEventWireup="false" Inherits="R7.Zeta.Containers.EpsilonContainerBase" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>
<div class="cnt-default cnt">
    <h5><dnn:TITLE ID="dnnTITLE" runat="server" CssClass="h5" /></h5>
    <div id="ContentPane" runat="server"></div>
</div>
