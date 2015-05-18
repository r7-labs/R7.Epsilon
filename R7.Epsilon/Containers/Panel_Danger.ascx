<%@ Control Language="C#" AutoEventWireup="false" Inherits="R7.Epsilon.EpsilonContainerBase" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>
<div class="panel panel-danger cnt-panel dnnClear">
    <div class="panel-heading">
        <h3 class="panel-title"><dnn:TITLE ID="dnnTITLE" runat="server" /></h3>
    </div>
    <div class="ContainerPane" runat="server" id="ContentPane"></div>
</div>