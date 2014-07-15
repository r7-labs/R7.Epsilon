<%@ Control Language="C#" AutoEventWireup="false" Inherits="R7.Epsilon.ContainerBase" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>
<div class="ContainerWrapper">
    <div class="dnnClear">
        <h2><dnn:TITLE ID="dnnTITLE" runat="server" class="Head dnnLeft" /></h2>
        
        <div class="ContainerPane" runat="server" id="ContentPane"></div>
    </div>
</div>

