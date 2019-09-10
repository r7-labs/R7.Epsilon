<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.PageInfo" %>
<ul class="list-inline text-muted small skin-page-info">
	<li class="list-inline-item">
        <span class="fas fa-calendar-alt"></span> <%= Localizer.GetString ("LastModified.Text") %> <%: LastContentModifiedOnDate %>
	</li>
    <li class="list-inline-item">
	    <span class="fas fa-user"></span> <%: LastContentModifiedByUserName %>
	</li>
    <li class="list-inline-item">
	    <span class="fas fa-globe"></span> <%= Localizer.GetString ("Permalink.Text") %> <%: PagePermalink %>
	</li>
</ul>
