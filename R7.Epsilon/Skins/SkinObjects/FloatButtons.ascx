<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Register TagPrefix="skin" TagName="FEEDBACKBUTTON" Src="FeedbackButton.ascx" %>
<div class="skin-float-box-vertical">
	<a href="#" class="skin-float-btn skin-float-btn-up skin-bg-primary-3" style="display:none" title='<%: Localizer.GetString ("ButtonUp_Title.Text") %>' data-toggle="tooltip" data-placement="left" data-container="body">
		<i class="fas fa-chevron-up"></i>
	</a>
	<a href='<%: Localizer.GetString ("AgeRating_Link.Text") %>' target="_blank" class="skin-float-btn skin-float-btn-age-rating"
			style='background-color:<%= Localizer.GetString ("AgeRating_Color.Text") %>'
			title='<%: Localizer.GetString ("AgeRating_Title.Text") %>' data-toggle="tooltip" data-placement="left" data-container="body">
		<%: Localizer.GetString ("AgeRating.Text") %>
	</a>
    <skin:FEEDBACKBUTTON runat="server" CssClass="skin-float-btn skin-float-btn-feedback skin-bg-secondary-1-3" />
</div>
