<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.Banners.BannerWrapper" %>
<%@ Register TagPrefix="dnn" TagName="BANNER" Src="~/admin/Skins/banner.ascx" %>
<dnn:BANNER runat="server" GroupName="<%# GroupName %>" BannerTypeId="<%# BannerTypeId %>" BannerCount="<%# BannerCount %>" Orientation="<%# Orientation %>" AllowNullBannerType="true" />

