<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Register TagPrefix="skin" TagName="PAGEINFO" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/PageInfo.ascx" %>
<%@ Register TagPrefix="skin" TagName="GADSENSE" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/GAdsense.ascx" %>
<div class="container">
	<div class="row">
		<div class="col">
			<skin:GADSENSE runat="server" />
		</div>
	</div>
	<div class="row">
		<div class="col">
			<skin:PAGEINFO runat="server" />
		</div>
	</div>
</div>
