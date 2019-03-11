<%@ Control Language="C#" AutoEventWireup="true" Inherits="R7.Epsilon.Skins.EpsilonSkinBase" %>
<%@ Import Namespace="DotNetNuke.Web.Client" %>
<%@ Register TagPrefix="dnn" TagName="META" Src="~/Admin/Skins/Meta.ascx" %>
<%@ Register TagPrefix="dnn" TagName="JQUERY" Src="~/Admin/Skins/jQuery.ascx" %>
<%@ Register TagPrefix="skin" TagName="JSVARIABLES" Src="SkinObjects/JsVariables.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>

<dnn:DnnCssInclude runat="server" Name="dnndefault" FilePath="~/Resources/Shared/stylesheets/dnndefault/8.0.0/default.css"
    Priority="<%# FileOrder.Css.DefaultCss %>" Version="8.0.0" />
    
<dnn:META ID="bootstrapIECompat" runat="server" Name="X-UA-Compatible" Content="IE=edge" />
<dnn:META ID="mobileScale" runat="server" Name="viewport" Content="width=device-width,initial-scale=1" />

<dnn:DnnCssInclude runat="server" Name="bootstrap" FilePath="css/bootstrap.min.css" PathNameAlias="SkinPath" Priority="<%# FileOrder.Css.SkinCss %>" Version="4.3.1" />
<dnn:DnnCssInclude id="skinCss" runat="server" Name="skin" FilePath="<%# Config.SkinCss %>" PathNameAlias="SkinPath" Priority="<%# FileOrder.Css.SkinCss %>" />

<dnn:JQUERY id="dnnjQuery" runat="server" jQueryHoverIntent="true" />
<dnn:DnnJsInclude runat="server" Name="bootstrap" FilePath="js/bootstrap.min.js" PathNameAlias="SkinPath" ForceProvider="DnnFormBottomProvider" Version="4.3.1" />
<dnn:DnnJsInclude runat="server" Name="bootstrap-init" FilePath="js/bootstrap-init.min.js" PathNameAlias="SkinPath" ForceProvider="DnnFormBottomProvider" />

<dnn:DnnJsInclude runat="server" Name="feedback" FilePath="js/feedback.min.js" PathNameAlias="SkinPath" ForceProvider="DnnFormBottomProvider" />

<skin:JSVARIABLES runat="server" />
<div id="ContentPane" runat="server" class="col-md-12" />