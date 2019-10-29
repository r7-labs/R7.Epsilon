<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Register TagPrefix="dnn" TagName="TAGS" Src="~/Admin/Skins/Tags.ascx" %>
<%@ Register TagPrefix="skin" TagName="PAGEINFO" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/PageInfo.ascx" %>

<div class="container">
	<div class="row">
		<div class="col">
			<div class="skin-tags">
				<dnn:TAGS runat="server" AllowTagging="false" Separator=" " />
			</div>
		</div>
	</div>
	<div class="row">
		<div class="col">
			<skin:PAGEINFO runat="server" />
		</div>
	</div>
</div>
