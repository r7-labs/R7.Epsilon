<%@ Control Language="C#" AutoEventWireup="true" Inherits="R7.Epsilon.Skins.EpsilonSkinBase" %>
<%@ Register TagPrefix="skin" TagName="META" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/Meta.ascx" %>
<%@ Register TagPrefix="skin" TagName="INCLUDES" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/Includes.ascx" %>
<%@ Register TagPrefix="skin" TagName="JSVARIABLES" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/JsVariables.ascx" %>
<skin:META runat="server" />
<skin:INCLUDES runat="server" LazyAds="false" Rangy="false" BlueimpGallery="false" />
<skin:JSVARIABLES runat="server" />
<div class="skin skin-popup">
	<div id="ContentPane" runat="server" />
</div>
