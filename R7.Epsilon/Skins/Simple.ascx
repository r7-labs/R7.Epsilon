<%@ Control Language="C#" AutoEventWireup="true" Inherits="R7.Epsilon.Skins.EpsilonSkinBase" %>
<%@ Register TagPrefix="skin" TagName="START" Src="~/Portals/_default/Skins/R7.Epsilon/Blocks/Start.ascx" %>
<%@ Register TagPrefix="skin" TagName="HEADER" Src="~/Portals/_default/Skins/R7.Epsilon/Blocks/Header.ascx" %>
<%@ Register TagPrefix="skin" TagName="SUBHEADER" Src="~/Portals/_default/Skins/R7.Epsilon/Blocks/SubHeader.ascx" %>
<%@ Register TagPrefix="skin" TagName="PARTIALCONTENTALERT" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/PartialContentAlert.ascx" %>
<%@ Register TagPrefix="skin" TagName="SUPFOOTER" Src="~/Portals/_default/Skins/R7.Epsilon/Blocks/SupFooter.ascx" %>
<%@ Register TagPrefix="skin" TagName="FOOTER" Src="~/Portals/_default/Skins/R7.Epsilon/Blocks/Footer.ascx" %>
<%@ Register TagPrefix="skin" TagName="END" Src="~/Portals/_default/Skins/R7.Epsilon/Blocks/End.ascx" %>

<div class="skin-default">
	<skin:START runat="server" />
	<header class="skin-header">
		<skin:HEADER runat="server" />
	</header>
	<skin:SUBHEADER runat="server" />
	<!--#include file="~/Portals/_default/Skins/R7.Epsilon/Layouts/_simple.ascx" -->
	<skin:SUPFOOTER runat="server" />
	<footer class="skin-footer">
		<!--#include file="~/Portals/_default/Skins/R7.Epsilon/Layouts/_footer-3cols.ascx" -->
		<skin:FOOTER runat="server" />
	</footer>
	<skin:END runat="server" />
</div>
