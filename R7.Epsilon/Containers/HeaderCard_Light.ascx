<%@ Control Language="C#" AutoEventWireup="false" Inherits="R7.Epsilon.Containers.EpsilonContainerBase" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>
<div class="card bg-light text-light cnt cnt-card">
	<div class="card-header"><dnn:TITLE ID="dnnTITLE" runat="server" /></div>
	<div class="bg-white text-body rounded-bottom">
		<div id="ContentPane" runat="server" class="card-body"></div>
	</div>
</div>
