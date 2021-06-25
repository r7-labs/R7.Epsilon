<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Import Namespace="R7.Epsilon.Components" %>
<%@ Import Namespace="R7.Epsilon.Models" %>
<div class="skin-follow-us">
	<h6 class="font-weight-bold"><%: T.GetString ("FollowUs.Text") %></h6>
	<ul class="list-inline">
		<% foreach (var group in Config.SocialGroups.Where (g => g.IsPrimary)) { %>
			<li class="list-inline-item">
				<a href="<%: group.Url %>" target="_blank" class="skin-social-groups-item">
					<span class="skin-social-group-icon">
						<i class="<%: group.GetIconCssClass () %>"></i>
					</span>
					<span>
						<% if (!string.IsNullOrEmpty (group.Label)) { %>
							<span class="skin-custom-content small" data-title="<%: group.Label %>">
								<%: T.GetStringIfKey (group.Label) %>
							</span>
						<% } else { %>
							<span class="small"><%: T.GetString (group.Type + ".Text") %></span>
						<% } %>
					</span>
				</a>
			</li>
		<% } %>
	</ul>
</div>
