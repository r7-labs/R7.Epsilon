<%@ Control Language="C#" AutoEventWireup="false" Inherits="R7.Epsilon.ContainerBase" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>
<div class="ContainerWrapper dnnClear dnnFormMessage dnnFormSuccess">
    <h4><dnn:TITLE ID="dnnTITLE" runat="server" class="h4" /></h4>
    <div class="ContainerPane" runat="server" id="ContentPane"></div>
</div>
