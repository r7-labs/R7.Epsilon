<%@ Control Language="C#" AutoEventWireup="false" Inherits="R7.Epsilon.Containers.EpsilonContainerBase" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>
<div class="cnt cnt-default cnt-lined">
	<h5><dnn:TITLE ID="dnnTITLE" runat="server" CssClass="h5" /></h5>
	<div id="ContentPane" runat="server"></div>
</div>
