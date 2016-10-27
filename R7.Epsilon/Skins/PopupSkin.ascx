<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PopupSkin.ascx.cs" Inherits="R7.Epsilon.PopupSkin" %>
<%@ Register TagPrefix="dnn" TagName="META" Src="~/Admin/Skins/Meta.ascx" %>
<%@ Register TagPrefix="skin" TagName="JSVARIABLES" Src="Controls/JsVariables.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>

<dnn:META ID="mobileScale" runat="server" Name="viewport" Content="width=device-width,initial-scale=1" />
<dnn:DnnJsInclude ID="skinJS" runat="server" FilePath="js/skin.min.js" PathNameAlias="SkinPath" ForceProvider="DnnFormBottomProvider" />

<skin:JSVARIABLES runat="server" />
<div id="ContentPane" runat="server" class="col-md-12" />
