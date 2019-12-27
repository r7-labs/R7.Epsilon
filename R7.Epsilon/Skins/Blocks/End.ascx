<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Zeta.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Register TagPrefix="skin" TagName="SEARCHMODAL" Src="~/Portals/_default/Skins/R7.Zeta/SkinObjects/SearchModal.ascx" %>
<%@ Register TagPrefix="skin" TagName="PERMALINKSMODAL" Src="~/Portals/_default/Skins/R7.Zeta/SkinObjects/PermalinksModal.ascx" %>
<%@ Register TagPrefix="skin" TagName="SHAREDSCRIPTS" Src="~/Portals/_default/Skins/R7.Zeta/SkinObjects/SharedScripts.ascx" %>
<%@ Register TagPrefix="skin" TagName="BLUEIMPGALLERY" Src="~/Portals/_default/Skins/R7.Zeta/SkinObjects/BlueimpGallery.ascx" %>
<%@ Register TagPrefix="skin" TagName="FLOATBUTTONS" Src="~/Portals/_default/Skins/R7.Zeta/SkinObjects/FloatButtons.ascx" %>
<%@ Register TagPrefix="skin" TagName="TOASTS" Src="~/Portals/_default/Skins/R7.Zeta/SkinObjects/Toasts.ascx" %>
<skin:FLOATBUTTONS runat="server" />
<skin:TOASTS runat="server" />
<skin:SEARCHMODAL runat="server" />
<skin:PERMALINKSMODAL runat="server" />
<skin:BLUEIMPGALLERY runat="server" />
<skin:SHAREDSCRIPTS runat="server" />
<%= T.GetString ("CustomMarkup_End.Text") %>
