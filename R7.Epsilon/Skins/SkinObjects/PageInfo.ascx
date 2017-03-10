<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.PageInfo" %>
<%@ OutputCache Duration="1200" VaryByParam="TabId;Language" %>
<div class="text-muted small skin-page-info">
	<div>
        <span class="glyphicon glyphicon-calendar"></span> <%= Localizer.GetString ("LastModified.Text") %> <%: LastContentModifiedOnDate %>
	</div>	
    <div>
	    <span class="glyphicon glyphicon-user"></span> <%: LastContentModifiedByUserName %>
	</div>
    <div>
	    <span class="glyphicon glyphicon-globe"></span> <%= Localizer.GetString ("Permalink.Text") %> <%: PagePermalink %>
	</div>
</div>