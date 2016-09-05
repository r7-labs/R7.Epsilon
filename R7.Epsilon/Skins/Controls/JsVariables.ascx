<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.JsVariables" %>

<script type="text/javascript">
var epsilon = {
    tabId:<%= PortalSettings.ActiveTab.TabID %>,
    tabName:'<%= PortalSettings.ActiveTab.TabName %>',
    portalId:<%= PortalSettings.Current.PortalId %>,
    breadCrumbs:<%= JsBreadCrumbsList %>,
    breadCrumbsRemoveLastLink:<%= JsBreadCrumbsRemoveLastLink %>,
	layoutManagerUrl:'<%= LayoutManagerUrl %>',
    localization: { <%= LocalizationResources %> }
};
</script>
