<%@ Control Language="C#" AutoEventWireup="true" Inherits="R7.Epsilon.Skins.PopupSkin" %>
<%@ Register TagPrefix="dnn" TagName="META" Src="~/Admin/Skins/Meta.ascx" %>
<%@ Register TagPrefix="skin" TagName="JSVARIABLES" Src="SkinObjects/JsVariables.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>

<dnn:META ID="bootstrapIECompat" runat="server" Name="X-UA-Compatible" Content="IE=edge" />
<dnn:META ID="mobileScale" runat="server" Name="viewport" Content="width=device-width,initial-scale=1" />
<%-- Required to setup feedback module in popup --%>
<dnn:DnnJsInclude ID="skinJS" runat="server" FilePath="js/skin.min.js" PathNameAlias="SkinPath" ForceProvider="DnnFormBottomProvider" />

<skin:JSVARIABLES runat="server" />
<div id="ContentPane" runat="server" class="col-md-12" />