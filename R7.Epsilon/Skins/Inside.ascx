<%@ Control Language="C#" AutoEventWireup="true" Inherits="R7.Zeta.Skins.EpsilonSkinBase" %>
<%@ Register TagPrefix="skin" TagName="START" Src="~/Portals/_default/Skins/R7.Zeta/Blocks/Start.ascx" %>
<%@ Register TagPrefix="skin" TagName="HEADER" Src="~/Portals/_default/Skins/R7.Zeta/Blocks/Header.ascx" %>
<%@ Register TagPrefix="skin" TagName="SECONDARYHEADER" Src="~/Portals/_default/Skins/R7.Zeta/Blocks/SecondaryHeader.ascx" %>
<%@ Register TagPrefix="skin" TagName="SUBHEADER" Src="~/Portals/_default/Skins/R7.Zeta/Blocks/SubHeader.ascx" %>
<%@ Register TagPrefix="skin" TagName="SUPFOOTER" Src="~/Portals/_default/Skins/R7.Zeta/Blocks/SupFooter.ascx" %>
<%@ Register TagPrefix="skin" TagName="FOOTER" Src="~/Portals/_default/Skins/R7.Zeta/Blocks/Footer.ascx" %>
<%@ Register TagPrefix="skin" TagName="END" Src="~/Portals/_default/Skins/R7.Zeta/Blocks/End.ascx" %>
<%
Options.DisableSocialShare = true;
%>
<skin:START runat="server" />
<div class="skin">
	<header class="skin-header">
		<skin:HEADER runat="server" />
		<!--#include file="~/Portals/_default/Skins/R7.Zeta/Layouts/_header.ascx"-->
		<skin:SECONDARYHEADER runat="server" />
	</header>
	<skin:SUBHEADER runat="server" />
	<!--#include file="~/Portals/_default/Skins/R7.Zeta/Layouts/_default.ascx"-->
	<skin:SUPFOOTER runat="server" />
	<footer class="skin-footer">
		<!--#include file="~/Portals/_default/Skins/R7.Zeta/Layouts/_footer.ascx"-->
		<skin:FOOTER runat="server" />
	</footer>
	<skin:END runat="server" />
</div>
