<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Register TagPrefix="dnn" TagName="PRIVACY" Src="~/Admin/Skins/Privacy.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TERMS" Src="~/Admin/Skins/Terms.ascx" %>
<%@ Register TagPrefix="dnn" TagName="COPYRIGHT" Src="~/Admin/Skins/Copyright.ascx" %>
<%@ Register TagPrefix="skin" TagName="GADSENSE" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/GAdsense.ascx" %>
<%@ Register TagPrefix="skin" TagName="CUSTOMCONTENT" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/CustomContent.ascx" %>
<%@ Register TagPrefix="skin" TagName="YCYCOUNTER" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/YCycounter.ascx" %>

<div class="container">
	<div class="row">
		<div class="col-12">
			<skin:GADSENSE runat="server" />
		</div>
	</div>
	<div class="row">
		<skin:CUSTOMCONTENT runat="server" CssClass="col-12 col-md-6 skin-footer-content" ResourceKey="FooterPane1_Content.Text" />
		<skin:CUSTOMCONTENT runat="server" CssClass="col-12 col-md-6 skin-footer-content" ResourceKey="FooterPane2_Content.Text" />
		<skin:CUSTOMCONTENT runat="server" CssClass="col-12 col-md-6 skin-footer-content" ResourceKey="FooterPane3_Content.Text" />
		<skin:CUSTOMCONTENT runat="server" CssClass="col-12 col-md-6 skin-footer-content" ResourceKey="FooterPane4_Content.Text" />
	</div>
</div>
<div class="skin-footer-lastrow">
	<div class="container">
		<div class="row">
			<div class="col-md-2 col-sm-3 col-xs-12 skin-footer-88x31-buttons">
				<skin:YCYCOUNTER runat="server" />
			</div>
			<div class="col-md-10 col-sm-9 col-xs-12 skin-terms">
				<div>
					<dnn:COPYRIGHT runat="server" /> |
					<asp:Label runat="server" CssClass="skin-copyright" Text='<%# Skin.SkinCopyright %>' />
					<asp:Literal runat="server" Visible='<%# Config.ShowTerms %>' Text="|" />
					<dnn:TERMS   runat="server" Visible='<%# Config.ShowTerms %>' />
					<asp:Literal runat="server" Visible='<%# Config.ShowPrivacy %>' Text="|" />
					<dnn:PRIVACY runat="server" Visible='<%# Config.ShowPrivacy %>' />
				</div>
				<div>
					<asp:Label runat="server" Text='<%# T.GetString ("CopyrightNote.Text") %>' />
				</div>
			</div>
		</div>
	</div>
</div>
