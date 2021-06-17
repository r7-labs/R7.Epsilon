<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Import Namespace="R7.Epsilon.Components" %>
<%@ Import Namespace="R7.Epsilon.Models" %>
<div class="dropdown d-inline-block skin-social-groups">
	<button type="button" class="btn btn-lg skin-btn-unstyled dropdown-toggle" data-toggle="dropdown" title='<%: T.GetString ("SocialGroups.Text") %>'>
		<% var primaryGroup = Config.SocialGroups.FirstOrDefault (g => g.IsPrimary) ?? Config.SocialGroups.First (); %>
		<i class="<%: primaryGroup.GetIconCssClass () %>"></i><sup>+</sup>
	</button>
	<div class="dropdown-menu">
		<% var prevGroup = default (SocialGroupConfig); %>
		<% foreach (var group in Config.SocialGroups.OrderByDescending (g => g.IsPrimary)) {
			if (prevGroup != null && !group.IsPrimary && prevGroup.IsPrimary) { %>
				<div class="dropdown-divider"></div>
			<% } %>
			<a class="dropdown-item skin-social-groups-item" href="<%: group.Url %>" target="_blank">
				<i class="<%: group.GetIconCssClass () %> brand-text brand-text-<%: group.Type.ToString ().ToLowerInvariant () %> skin-social-group-icon"
					style="<%: group.GetCustomColorStyle () %>">
				</i>
				<% if (!string.IsNullOrEmpty (group.Label)) { %>
					<span class="skin-custom-content" data-title="<%: group.Label %>">
						<%: T.GetStringIfKey (group.Label) %>
					</span>
				<% } else { %>
					<span><%: T.GetString (group.Type + ".Text") %></span>
				<% } %>
				<% prevGroup = group; %>
			</a>
		<% } %>
	</div>
</div>
