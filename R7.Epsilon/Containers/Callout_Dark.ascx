<%@ Control Language="C#" AutoEventWireup="false" Inherits="R7.Zeta.Containers.EpsilonContainerBase" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>
<div class="card card-body border-dark cnt skin-callout cnt-callout">
    <h4 class="card-title text-dark"><dnn:TITLE ID="dnnTITLE" runat="server" CssClass="h4" /></h4>
    <div id="ContentPane" runat="server"></div>
</div>
