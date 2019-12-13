<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Register TagPrefix="skin" TagName="META" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/Meta.ascx" %>
<%@ Register TagPrefix="skin" TagName="INCLUDES" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/Includes.ascx" %>
<%@ Register TagPrefix="skin" TagName="JSVARIABLES" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/JsVariables.ascx" %>
<skin:META runat="server" />
<skin:INCLUDES runat="server" />
<%= T.GetString ("CustomMarkup_Start.Text") %>
<skin:JSVARIABLES runat="server" />
<% if (!Skin.Options.DisableSocialShare) { %>
	<div id="vk_api_transport"></div>
	<div id="fb-root"></div>
<% } %>
