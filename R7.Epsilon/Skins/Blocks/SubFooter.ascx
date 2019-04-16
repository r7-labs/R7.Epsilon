<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Register TagPrefix="skin" TagName="FEEDBACKBUTTON" Src="../SkinObjects/FeedbackButton.ascx" %>
<%@ Register TagPrefix="skin" TagName="SHAREDSCRIPTS" Src="../SkinObjects/SharedScripts.ascx" %>
<%@ Register TagPrefix="skin" TagName="SEARCHMODAL" Src="../SkinObjects/SearchModal.ascx" %>
<div class="skin-float-button-wrapper">
    <asp:HyperLink runat="server" href="#" CssClass="skin-float-button skin-float-button-up" Style="display:none" ToolTip='<%# Localizer.GetString ("ButtonUp.Title") %>' data-toggle="tooltip" data-placement="left" data-container="body" />
    <skin:FEEDBACKBUTTON runat="server" CssClass="skin-float-button skin-float-button-feedback" />
</div>
<skin:SEARCHMODAL runat="server" />
<skin:SHAREDSCRIPTS runat="server" />