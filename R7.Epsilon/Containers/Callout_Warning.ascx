<%@ Control Language="C#" AutoEventWireup="false" Inherits="R7.Zeta.Containers.EpsilonContainerBase" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>
<div class="card card-body border-warning cnt skin-callout cnt-callout">
    <h4 class="card-title text-warning"><dnn:TITLE ID="dnnTITLE" runat="server" CssClass="h4" /></h4>
    <div id="ContentPane" runat="server"></div>
</div>
