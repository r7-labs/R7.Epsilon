<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Import Namespace="R7.Epsilon.Components" %>
<%@ Import Namespace="R7.Epsilon.Models" %>
<div class="skin-follow-us">
	<h6><%: T.GetString ("FollowUs.Text") %></h6>
	<ul class="list-inline">
		<% foreach (var group in Config.SocialGroups.Where (g => g.IsPrimary)) { %>
			<li class="list-inline-item">
				<a class="" href="<%: group.Url %>" target="_blank">
					<i class="<%: group.GetIconCssClass () %> skin-social-group-icon"></i>
					<% if (!string.IsNullOrEmpty (group.Label)) { %>
						<span class="skin-custom-content" data-title="<%: group.Label %>">
							<%: T.GetStringIfKey (group.Label) %>
						</span>
					<% } else { %>
						<%: T.GetString (group.Type + ".Text") %>
					<% } %>
				</a>
			</li>
		<% } %>
	</ul>
</div>
