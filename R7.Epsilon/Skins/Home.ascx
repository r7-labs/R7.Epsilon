<%@ Control Language="C#" AutoEventWireup="true" Inherits="R7.Epsilon.Skins.EpsilonSkinBase" %>
<%@ Register TagPrefix="skin" TagName="START" Src="Blocks/Start.ascx" %>
<%@ Register TagPrefix="skin" TagName="HEADER" Src="Blocks/Header.ascx" %>
<%@ Register TagPrefix="skin" TagName="SUBHEADER" Src="Blocks/SubHeader.ascx" %>
<%@ Register TagPrefix="skin" TagName="PARTIALCONTENTALERT" Src="SkinObjects/PartialContentAlert.ascx" %>
<%@ Register TagPrefix="skin" TagName="SUPFOOTER" Src="Blocks/SupFooter.ascx" %>
<%@ Register TagPrefix="skin" TagName="FOOTER" Src="Blocks/Footer.ascx" %>
<%@ Register TagPrefix="skin" TagName="END" Src="Blocks/End.ascx" %>

<div class="skin-home">
	<skin:START runat="server" />
	<header>
		<skin:HEADER runat="server" />
	</header>
	<skin:SUBHEADER runat="server" />
	<!--#include file="Layouts/_home.ascx" -->
	<footer class="footer skin-footer">
		<skin:FOOTER runat="server" />
	</footer>
	<skin:END runat="server" />
</div>
