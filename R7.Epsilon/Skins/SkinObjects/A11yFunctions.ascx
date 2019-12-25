<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Import Namespace="R7.Epsilon.Components" %>
<%@ Import Namespace="DnnGlobals=DotNetNuke.Common.Globals" %>
<div class="dropdown" style="display:inline-block">
	<button type="button" class="btn btn-lg dropdown-toggle skn-a11y-btn"
		data-toggle="dropdown"
		title='<%: T.GetString ("A11y.Text") %>'>
		<%= T.GetString ("A11yIcon.Text") %>
	</button>
	<div class="dropdown-menu">
		<% if (Config.Themes.Count > 1) { %>
			<% for (var i = 0; i < Config.Themes.Count; i++) {
				var theme = Config.Themes [i];
				var isCurrentTheme = (Config.GetTheme (Request) ?? Config.Themes [0]).Name;
				%>
				<a class='<%: theme.Name == isCurrentTheme ? "dropdown-item active disabled" : "dropdown-item"  %>'
					href='<%= DnnGlobals.NavigateURL ("", "theme", theme.Name) %>'>
					<span style="color: <%: theme.Color %>">
						<i class='<%: theme.IsA11yTheme ? "fas fa-adjust" : "fas fa-circle" %>'></i>
					</span>
					<%: T.GetString ("Theme_" + theme.Name + ".Text") %>
					<% if (i == 0) { %>
						<%: T.GetString ("DefaultTheme.Text") %>
					<% } %>
				</a>
			<% } %>
			<div class="dropdown-divider"></div>
		<% } %>
		<a class="dropdown-item" href="javascript:skinA11y.increaseFontSize()">
			<i class="fas fa-font"></i><i class="fas fa-arrow-up"></i> <%: T.GetString("A11yIncreaseFontSize.Text") %></a>
		<a class="dropdown-item" href="javascript:skinA11y.decreaseFontSize()">
			<i class="fas fa-font"></i><i class="fas fa-arrow-down"></i> <%: T.GetString("A11yDecreaseFontSize.Text") %></a>
		<div class="dropdown-divider"></div>
		<a id="lnkDisablePopups" role="checkbox" class="dropdown-item" href="javascript:skinA11y.disablePopups()">
			<i class="far fa-square"></i> <%: T.GetString("A11yDisablePopups.Text") %></a>
		<a id="lnkReEnablePopups" role="checkbox" class="dropdown-item d-none" href="javascript:skinA11y.reEnablePopups()">
			<i class="fas fa-check-square"></i>	<%: T.GetString("A11yDisablePopups.Text") %></a>
		<div class="dropdown-divider"></div>
			<a class="dropdown-item" href='<%= DnnGlobals.NavigateURL ("", "a11y", "false") %>'>
			<i class="fas fa-undo"></i></i> <%: T.GetString("A11yRestoreDefaults.Text") %></a>
	</div>
</div>
