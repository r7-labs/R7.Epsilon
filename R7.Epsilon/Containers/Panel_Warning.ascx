<%@ Control Language="C#" AutoEventWireup="false" Inherits="R7.Epsilon.Containers.EpsilonContainerBase" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>
<div class="panel panel-warning cnt-panel dnnClear">
    <div class="panel-heading">
        <h3 class="panel-title"><dnn:TITLE ID="dnnTITLE" runat="server" /></h3>
    </div>
    <div id="ContentPane" runat="server"></div>
</div>