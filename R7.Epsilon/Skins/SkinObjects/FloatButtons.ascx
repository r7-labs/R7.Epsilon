<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Zeta.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Register TagPrefix="skin" TagName="FEEDBACKBUTTON" Src="~/Portals/_default/Skins/R7.Zeta/SkinObjects/FeedbackButton.ascx" %>
<div class="skin-float-box-vertical">
	<a href="#" class="skin-float-btn skin-float-btn-up" style="display:none" title='<%: T.GetString ("ButtonUp_Tooltip.Text") %>' data-toggle="tooltip" data-placement="left" data-container="body">
		<i class="fas fa-chevron-up"></i>
	</a>
	<a role="button" tabindex="0" class="skin-float-btn skin-float-btn-age-rating"
			title='<%: T.GetString ("AgeRating_Title.Text") %>' data-content='<%= T.GetString ("AgeRating_Content.Text") %>' data-html="true" data-toggle="popover" data-trigger="focus" data-placement="left" data-container="body">
		<%: T.GetString ("AgeRating_Label.Text") %>
	</a>
    <skin:FEEDBACKBUTTON runat="server" CssClass="skin-float-btn skin-float-btn-feedback" />
</div>
