<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.JsVariables" %>

<script type="text/javascript">
var epsilon = {
    tabId:<%= PortalSettings.ActiveTab.TabID %>,
    tabName:'<%= PortalSettings.ActiveTab.TabName %>',
    portalId:<%= PortalSettings.Current.PortalId %>,
    breadCrumbs:<%= JsBreadCrumbsList %>,
    breadCrumbsRemoveLastLink:<%= JsBreadCrumbsRemoveLastLink %>,
	layoutManagerUrl:'<%= LayoutManagerUrl %>',
    localization:{<%= LocalizationResources %>},
    queryParams:{<%= QueryParams %>},
	menuMinHeaders:<%= R7.Epsilon.Components.EpsilonConfig.Instance.MenuMinHeaders %>,
	enablePopups:<%= PortalSettings.EnablePopUps.ToString ().ToLowerInvariant() %>,
	inPopup:<%= DotNetNuke.Common.Utilities.UrlUtils.InPopUp ().ToString ().ToLowerInvariant () %>,
	cookiePrefix: '<%= R7.Epsilon.Components.Const.COOKIE_PREFIX %>'
};
</script>
