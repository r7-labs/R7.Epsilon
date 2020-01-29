<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Zeta.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<div class="skin-float-btns">
	<a href="#" class="skin-float-btn skin-float-btn-up" style="display:none" title='<%: T.GetString ("ButtonUp_Tooltip.Text") %>' data-toggle="tooltip" data-placement="left" data-container="body">
		<i class="fas fa-chevron-up"></i>
	</a>
	<% if (Config.Feedback.IsEnabled ()) { %>
	<a id="btnSkinFeedback" role="button" tabindex="0" class="skin-float-btn skin-float-btn-feedback"
			title='<%: T.GetString ("Feedback_Title.Text") %>'
			data-content='<%= T.GetString ("Feedback_Content.Text") %>'
			data-html="true" data-toggle="popover" data-placement="left" data-container="body" data-trigger="focus">
		<i class="fas fa-comment-dots"></i>
	</a>
	<a role="button" tabindex="0" class="skin-float-btn skin-float-btn-age-rating"
			title='<%: T.GetString ("AgeRating_Title.Text") %>' data-content='<%= T.GetString ("AgeRating_Content.Text") %>'
			data-html="true" data-toggle="popover" data-placement="left" data-container="body" data-trigger="focus">
		<%: T.GetString ("AgeRating_Label.Text") %>
	</a>
	<% } %>
</div>
