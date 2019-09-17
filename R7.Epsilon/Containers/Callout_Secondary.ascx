<%@ Control Language="C#" AutoEventWireup="false" Inherits="R7.Epsilon.Containers.EpsilonContainerBase" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>
<div class="clearfix card card-body border-secondary skin-callout cnt-callout">
    <h4 class="card-title text-secondary"><dnn:TITLE ID="dnnTITLE" runat="server" CssClass="h4" /></h4>
    <div id="ContentPane" runat="server"></div>
</div>
