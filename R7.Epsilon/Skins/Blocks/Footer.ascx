﻿<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Register TagPrefix="dnn" TagName="PRIVACY" Src="~/Admin/Skins/Privacy.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TERMS" Src="~/Admin/Skins/Terms.ascx" %>
<%@ Register TagPrefix="dnn" TagName="COPYRIGHT" Src="~/Admin/Skins/Copyright.ascx" %>
<%@ Register TagPrefix="skin" TagName="GADSENSE" Src="../SkinObjects/GAdsense.ascx" %>
<%@ Register TagPrefix="skin" TagName="CUSTOMCONTENT" Src="../SkinObjects/CustomContent.ascx" %>
<%@ Register TagPrefix="skin" TagName="YCYCOUNTER" Src="../SkinObjects/YCycounter.ascx" %>
<%@ Register TagPrefix="skin" TagName="BANNER" Src="../SkinObjects/Banners/BannerLoader.ascx" %>

<div class="skin-footer-main">
    <div class="container">
        <div class="row">
            <div class="col-lg-8 col-md-10 col-sm-12">
                <skin:GADSENSE runat="server" />
                <div class="row">
                    <div class="skin-footer-buttons col-sm-6 d-xs-none">
                        <skin:BANNER runat="server" GroupName="<%# Config.FooterButtonsGroupName %>" BannerTypeId="4" BannerCount="3" Orientation="H" />
                    </div>
                    <skin:CUSTOMCONTENT runat="server" CssClass="skin-footer-content col-sm-6" ResourceKey="FooterPane1.Content" />
                </div>
            </div>
            <skin:CUSTOMCONTENT runat="server" CssClass="col-lg-2 col-md-2 col-sm-6 skin-footer-content" ResourceKey="FooterPane2.Content" />
            <skin:CUSTOMCONTENT runat="server" CssClass="col-lg-2 col-sm-6 skin-footer-content" ResourceKey="FooterPane3.Content" />
        </div>
    </div>
</div>
<div class="skin-footer-last">
    <div class="container">
        <div class="row">
            <div class="col-md-2 col-sm-3 col-xs-12 skin-footer-88x31-buttons">
                <skin:YCYCOUNTER runat="server" />
            </div>
            <div class="col-md-10 col-sm-9 col-xs-12 skin-terms">
                <div>
                    <dnn:COPYRIGHT runat="server" /> |
                    <asp:Label runat="server" CssClass="skin-copyright" Text='<%# Skin.SkinCopyright %>' />
                    <asp:Literal runat="server" Visible='<%# Config.ShowTerms %>' Text="|" />
                    <dnn:TERMS   runat="server" Visible='<%# Config.ShowTerms %>' />
                    <asp:Literal runat="server" Visible='<%# Config.ShowPrivacy %>' Text="|" />
                    <dnn:PRIVACY runat="server" Visible='<%# Config.ShowPrivacy %>' />
                </div>
                <div>
                    <asp:Label runat="server" Text='<%# Localizer.GetString ("CopyrightNote.Text") %>' />
                </div>
            </div>
        </div>
    </div>
</div>