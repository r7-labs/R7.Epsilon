<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.PageInfo" %>
<%@ OutputCache Duration="1200" VaryByParam="TabId;Language" %>
<div class="text-muted small skin-page-info">
	<div>
        <span class="fas fa-calendar-alt"></span> <%= Localizer.GetString ("LastModified.Text") %> <%: LastContentModifiedOnDate %>
	</div>
    <div>
	    <span class="fas fa-user"></span> <%: LastContentModifiedByUserName %>
	</div>
    <div>
	    <span class="fas fa-globe"></span> <%= Localizer.GetString ("Permalink.Text") %> <%: PagePermalink %>
	</div>
</div>
