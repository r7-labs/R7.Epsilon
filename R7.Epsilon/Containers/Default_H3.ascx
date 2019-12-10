<%@ Control Language="C#" AutoEventWireup="false" Inherits="R7.Epsilon.Containers.EpsilonContainerBase" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>
<div class="cnt-default skin-cnt">
    <h3><dnn:TITLE ID="dnnTITLE" runat="server" CssClass="h3" /></h3>
    <div id="ContentPane" runat="server"></div>
</div>
