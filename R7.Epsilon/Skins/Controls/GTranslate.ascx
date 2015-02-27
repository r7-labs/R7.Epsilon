<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.GTranslate" %>

<div class="language-object">
    <span class="Language" title="<%= Localizer.GetString ("GoogleTranslate.Title") %>" data-toggle="tooltip" data-placement="bottom">
        <a href="javascript:skin_gtranslate('<%= CultureInfo.CurrentCulture.TwoLetterISOLanguageName %>')">
            <img src="/Portals/_default/Skins/R7.Epsilon/images/gtranslate_27x18.png" alt="<%= Localizer.GetString ("GoogleTranslate.Alt") %>" />
        </a>
    </span>
</div>
