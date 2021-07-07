<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Register TagPrefix="skin" TagName="PAGEINFO" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/PageInfo.ascx" %>
<%@ Register TagPrefix="skin" TagName="SOCIALSHAREBUTTONS" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/SocialShareButtons.ascx" %>
<%@ Register TagPrefix="skin" TagName="GADSENSE" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/GAdsense.ascx" %>
<div class="container">
	<div class="row">
		<div class="col">
			<skin:GADSENSE runat="server" />
		</div>
	</div>
</div>
<div class="container skin-supfooter">
	<div class="row">
		<div class="col">
			<% if (!Skin.Options.DisableSocialShare) { %>
				<skin:SOCIALSHAREBUTTONS runat="server" Visible="<%# !Skin.Options.DisableSocialShare %>" />
			<% } %>
			<skin:PAGEINFO runat="server" />
		</div>
	</div>
</div>
