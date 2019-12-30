<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Import Namespace="R7.Epsilon.Components" %>
<div class="dropdown d-inline-block skin-social-groups">
	<button type="button" class="btn btn-lg dropdown-toggle" data-toggle="dropdown" title='<%: T.GetString ("SocialGroups.Text") %>'>
		<% var primaryGroup = Config.SocialGroups.FirstOrDefault (g => g.IsPrimary) ?? Config.SocialGroups.First (); %>
		<i class="fab fa-<%: SocialGroupHelper.GetFAIconName (primaryGroup.Type) %>"></i><sup>+</sup>
	</button>
	<div class="dropdown-menu">
		<% var prevGroup = default (SocialGroupConfig); %>
		<% foreach (var group in Config.SocialGroups.OrderByDescending (g => g.IsPrimary)) {
			if (prevGroup != null && !group.IsPrimary && prevGroup.IsPrimary) { %>
				<div class="dropdown-divider"></div>
			<% } %>
			<a class="dropdown-item" href="<%: group.Url %>" target="_blank">
				<i class="fab fa-<%: SocialGroupHelper.GetFAIconName (group.Type) %> brand-text brand-text-<%: group.Type.ToString ().ToLowerInvariant () %> skin-social-group-icon"
					style="<%: SocialGroupHelper.GetCustomColorStyle (group.Color) %>">
				</i>
				<% if (!string.IsNullOrEmpty (group.Name)) { %>
					<span class="skin-custom-content" data-resource-key="<%: group.Name %>">
						<%: T.GetStringOrKey (group.Name + ".Text") %>
					</span>
				<% } else { %>
					<%: T.GetString (group.Type + ".Text") %>
				<% } %>
				<% prevGroup = group; %>
			</a>
		<% } %>
	</div>
</div>
