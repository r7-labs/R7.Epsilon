<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.JsVariables" %>
<%@ Import Namespace="DotNetNuke.Common.Utilities" %>
<script type="text/javascript">
var epsilon = {
    portalAlias:'<%= PortalSettings.Current.PortalAlias.HTTPAlias %>',
    localization:{<%= LocalizationResources %>},
    queryParams:{<%= QueryParams %>},
	enablePopups:<%= PortalSettings.EnablePopUps.ToString ().ToLowerInvariant() %>,
	inPopup:<%= UrlUtils.InPopUp ().ToString ().ToLowerInvariant () %>,
	cookiePrefix: '<%= R7.Epsilon.Components.Const.COOKIE_PREFIX %>',
	isEditMode:<%= (PortalSettings.UserMode == PortalSettings.Mode.Edit).ToString().ToLowerInvariant () %>,
	feedbackUrl: '<%= DotNetNuke.Common.Globals.NavigateURL (Config.Feedback.TabId) %>',
	feedbackTabId: <%: Config.Feedback.TabId %>,
	feedbackModuleId: <%: Config.Feedback.ModuleId %>
};
</script>

