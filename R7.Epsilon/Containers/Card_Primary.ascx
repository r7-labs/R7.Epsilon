<%@ Control Language="C#" AutoEventWireup="false" Inherits="R7.Epsilon.Containers.EpsilonContainerBase" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>
<div class="card card-body bg-primary text-white skin-cnt cnt-card">
	<h4 class="card-title"><dnn:TITLE ID="dnnTITLE" runat="server" CssClass="h4" /></h4>
	<div id="ContentPane" runat="server"></div>
</div>
