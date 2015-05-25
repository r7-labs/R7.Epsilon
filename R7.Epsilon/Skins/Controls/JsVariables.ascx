<%@ Control Language="C#" Inherits="R7.Epsilon.EpsilonSkinObjectBase" %>

<script type="text/javascript">
var epsilon = {
    tabId:<%= PortalSettings.ActiveTab.TabID %>,
    tabName:'<%= PortalSettings.ActiveTab.TabName %>',
    portalId:<%= PortalSettings.Current.PortalId %>
}
</script>
