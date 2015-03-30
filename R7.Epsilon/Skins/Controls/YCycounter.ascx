<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.YCycounter" %>
<%@ OutputCache Duration="1200" VaryByParam="TabId;Language" %>
<a href="http://yandex.ru/cy?base=0&amp;host=<%= PortalSettings.PortalAlias.HTTPAlias %>">
    <img src="http://www.yandex.ru/cycounter?<%= PortalSettings.PortalAlias.HTTPAlias %>" width="88" height="31" border="0" 
        alt="<%: Localizer.GetString ("YandexCycounter.Text") %>" aria-label="<%: Localizer.GetString ("YandexCycounter.Text") %>" /></a>