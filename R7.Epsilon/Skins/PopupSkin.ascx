<%@ Control Language="C#" AutoEventWireup="true" Inherits="R7.Epsilon.Skins.EpsilonSkinBase" %>
<%@ Register TagPrefix="skin" TagName="META" Src="SkinObjects/Meta.ascx" %>
<%@ Register TagPrefix="skin" TagName="INCLUDES" Src="SkinObjects/Includes.ascx" %>
<%@ Register TagPrefix="skin" TagName="JSVARIABLES" Src="SkinObjects/JsVariables.ascx" %>

<skin:META runat="server" />
<skin:INCLUDES runat="server" SkinJs="false" MenuJs="false" LazyAds="false" Rangy="false" />

<skin:JSVARIABLES runat="server" />
<div id="ContentPane" runat="server" class="col-md-12" />