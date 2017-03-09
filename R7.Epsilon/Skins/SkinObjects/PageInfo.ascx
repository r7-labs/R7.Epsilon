<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.PageInfo" %>
<%@ OutputCache Duration="1200" VaryByParam="TabId;Language" %>
<div class="text-muted small skin-page-info">
	<div>
        <span class="glyphicon glyphicon-calendar"></span> <%= Localizer.GetString ("Published.Text") %> <%: PublishedOnDate %>
	</div>	
    <div>
	    <span class="glyphicon glyphicon-user"></span> <%: PublishedByUserName %>
	</div>
    <div>
	    <span class="glyphicon glyphicon-globe"></span> <%= Localizer.GetString ("Permalink.Text") %> <%: PagePermalink %>
	</div>
</div>