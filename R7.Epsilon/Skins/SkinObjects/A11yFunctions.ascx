<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Import Namespace="R7.Epsilon.Components" %>
<%@ Import Namespace="DnnGlobals=DotNetNuke.Common.Globals" %>
<div class="dropdown d-inline-block">
	<button type="button" class="btn btn-lg skin-btn-unstyled dropdown-toggle skin-a11y-btn"
		data-toggle="dropdown"
		title='<%: T.GetString ("A11y_Tooltip.Text") %>'>
		<%= T.GetString ("A11y_Icon.Text") %>
	</button>
	<div class="dropdown-menu">
		<a href='<%= DotNetNuke.Common.Globals.NavigateURL ("", "a11y", "true") %>' class="dropdown-item" itemprop="copy">
			<i class="fas fa-eye"></i> <%: T.GetString ("A11yWebsiteVersion.Text") %>
		</a>
		<div class="dropdown-divider"></div>
		<% if (Config.Themes.Count > 1) { %>
			<% for (var i = 0; i < Config.Themes.Count; i++) {
				var theme = Config.Themes [i];
				%>
				<button type="button" class="skin-btn-theme dropdown-item" data-theme="<%: theme.Name %>" onclick="skinA11y.btnThemeClick(this)">
					<span style="color: <%: theme.Color %>">
						<i class='<%: theme.IsA11yTheme ? "fas fa-adjust" : "fas fa-circle" %>'></i>
					</span>
					<%: T.GetString ("Theme_" + theme.Name + ".Text") %>
					<% if (i == 0) { %>
						<%: T.GetString ("DefaultTheme.Text") %>
					<% } %>
				</button>
			<% } %>
			<div class="dropdown-divider"></div>
		<% } %>
		<button type="button" class="dropdown-item" onclick="skinA11y.increaseFontSize()">
			<i class="fas fa-font"></i><i class="fas fa-arrow-up"></i> <%: T.GetString("A11yIncreaseFontSize.Text") %>
		</button>
		<button type="button" class="dropdown-item" onclick="skinA11y.decreaseFontSize()">
			<i class="fas fa-font"></i><i class="fas fa-arrow-down"></i> <%: T.GetString("A11yDecreaseFontSize.Text") %>
		</button>
		<div class="dropdown-divider"></div>
		<button type="button" id="lnkDisablePopups" role="checkbox" class="dropdown-item" onclick="skinA11y.disablePopups()">
			<i class="far fa-square"></i> <%: T.GetString("A11yDisablePopups.Text") %>
		</button>
		<button type="button" id="lnkReEnablePopups" role="checkbox" class="dropdown-item d-none" onclick="skinA11y.reEnablePopups()">
			<i class="fas fa-check-square"></i>	<%: T.GetString("A11yDisablePopups.Text") %>
		</button>
		<div class="dropdown-divider"></div>
		<button type="button" class="dropdown-item" onclick="skinA11y.restoreDefaults()" >
			<i class="fas fa-undo"></i> <%: T.GetString("A11yRestoreDefaults.Text") %>
		</button>
	</div>
</div>
