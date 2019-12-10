<%@ Control Language="C#" AutoEventWireup="false" Inherits="R7.Epsilon.Containers.EpsilonContainerBase" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>
<div class="clearfix card card-body bg-light text-body cnt-card cnt-blank">
	<% if (IsEditMode) { %>
	<h4 class="card-title"><dnn:TITLE ID="dnnTITLE" runat="server" CssClass="h4" /></h4>
	<% } %>
	<div id="ContentPane" runat="server"></div>
</div>
