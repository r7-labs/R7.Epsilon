<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Zeta.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<a href="https://webmaster.yandex.ru/sqi?host=<%= PortalSettings.PortalAlias.HTTPAlias %>" target="_blank">
	<img width="88" height="31" border="0"
		 alt="<%: T.GetString ("YandexCycounter.Text") %>"
		 title="<%: T.GetString ("YandexCycounter.Text") %>"
		 src="https://yandex.ru/cycounter?<%= PortalSettings.PortalAlias.HTTPAlias %>&theme=light&lang=<%: CultureInfo.CurrentCulture.TwoLetterISOLanguageName %>"/></a>
