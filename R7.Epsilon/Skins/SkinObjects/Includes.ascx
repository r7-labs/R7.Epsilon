<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.Includes" %>
<%@ Import Namespace="DotNetNuke.Web.Client" %>
<%@ Register TagPrefix="dnn" TagName="jQuery" Src="~/Admin/Skins/jQuery.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>

<dnn:DnnCssInclude runat="server" Name="dnndefault" FilePath="~/Resources/Shared/stylesheets/dnndefault/8.0.0/default.css"
    Priority="<%# FileOrder.Css.DefaultCss %>" Version="8.0.0" />
<dnn:jQuery id="dnnjQuery" runat="server" jQueryHoverIntent="true" />

