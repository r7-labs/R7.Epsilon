<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.SocialGroups" %>
<%@ OutputCache Duration="1200" VaryByParam="Language" VaryByCustom="PortalId" %>
<ul runat="server" class="skin-socialgroups">
    <asp:ListView runat="server" ItemType="R7.Epsilon.Components.SocialNetworkConfig" SelectMethod="GetPrimarySocialNetworks">
    	<LayoutTemplate>
            <div runat="server" id="itemPlaceholder"></div>
        </LayoutTemplate>
    	<ItemTemplate>
            <li>
    	        <asp:HyperLink runat="server" NavigateUrl="<%# Item.Group %>" Target="_blank" rel="nofollow"
					CssClass='<%# "skin-social-button skin-social-" + Item.Name.ToLowerInvariant () %>'
					ToolTip='<%# Localizer.GetString (Item.Name + ".Title") %>'
					aria-label='<%# Localizer.GetString (Item.Name + ".Title") %>' />
			</li>
    	</ItemTemplate>
    </asp:ListView>
	<li class="dropdown" style="<%= ShowDropdown ? string.Empty: "display:none" %>">
		<a id="dropdownSocialGroups" role="button" href="#" class="skin-social-button skin-social-more dropdown-toggle"
			data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" title="<%: Localizer.GetString ("MoreSocialGroups.Title")%>">
			<span class="fas fa-ellipsis-h"></span>
		</a>
	    <ul class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdownSocialGroups">
			<asp:ListView runat="server" ItemType="R7.Epsilon.Components.SocialNetworkConfig" SelectMethod="GetSecondarySocialNetworks">
                <LayoutTemplate>
                    <div runat="server" id="itemPlaceholder"></div>
                </LayoutTemplate>
                <ItemTemplate>
                    <li>
                        <asp:HyperLink runat="server" NavigateUrl="<%# Item.Group %>" Target="_blank" rel="nofollow">
							<span class="skin-social-button skin-social-<%# Item.Name.ToLowerInvariant () %>"></span>
						    <%# Localizer.GetString (Item.Name + ".Title") %>
						</asp:HyperLink>
					</li>
                </ItemTemplate>
            </asp:ListView>
	    </ul>
	</li>
</ul>
