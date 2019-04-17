<%@ Control Language="C#" AutoEventWireup="true" Inherits="R7.Epsilon.Skins.EpsilonSkinBase" %>
<%@ Register TagPrefix="skin" TagName="START" Src="Blocks/Start.ascx" %>
<%@ Register TagPrefix="skin" TagName="HEADER" Src="Blocks/Header.ascx" %>
<%@ Register TagPrefix="skin" TagName="SUBHEADER" Src="Blocks/SubHeader.ascx" %>
<%@ Register TagPrefix="skin" TagName="PARTIALCONTENTALERT" Src="SkinObjects/PartialContentAlert.ascx" %>
<%@ Register TagPrefix="skin" TagName="SUPFOOTER" Src="Blocks/SupFooter.ascx" %>
<%@ Register TagPrefix="skin" TagName="FOOTER" Src="Blocks/Footer.ascx" %>
<%@ Register TagPrefix="skin" TagName="END" Src="Blocks/End.ascx" %>

<skin:START runat="server" />
<header>
    <skin:HEADER runat="server" />
</header>
<skin:SUBHEADER runat="server" />
<!-- Start panes code -->
<div id="CarouselPane" runat="server" class="carousel slide" containertype="G" containername="R7.Epsilon" containersrc="Blank.ascx" />
<div class="container">
    <div class="row">
        <div id="TopPane" runat="server" class="col-md-12" />
    </div>
    <div class="row">
        <div id="TopLeftPane" runat="server" class="col-md-6" />
        <div id="TopRightPane" runat="server" class="col-md-6" />
    </div>
    <div class="row">
        <div id="TopPane11" runat="server" class="col-md-4" />
        <div id="TopPane12" runat="server" class="col-md-4" />
        <div id="TopPane13" runat="server" class="col-md-4" />
    </div>
    <div class="row">
        <div id="TopPane21" runat="server" class="col-md-4" />
        <div id="TopPane22" runat="server" class="col-md-4" />
        <div id="TopPane23" runat="server" class="col-md-4" />
    </div>
    <div class="row">
        <div id="TopPane31" runat="server" class="col-md-4" />
        <div id="TopPane32" runat="server" class="col-md-4" />
        <div id="TopPane33" runat="server" class="col-md-4" />
    </div>
    <skin:PARTIALCONTENTALERT runat="server" />
    <div class="row">
        <div id="ContentPane" runat="server" class="col-md-9 col-sm-7" />
        <div id="RightPane" runat="server" class="col-md-3 col-sm-5" />
    </div>
    <div class="row"> 
        <div id="LeftPane" runat="server" class="col-md-3 col-sm-5" />
        <div id="ContentLeftPane" runat="server" class="col-md-9 col-sm-7" />
    </div>
    <div class="row">
        <div id="ContentPane2" runat="server" class="col-md-9 col-sm-7" />
        <div id="RightPane2" runat="server" class="col-md-3 col-sm-5" />
    </div>
    <div class="row"> 
        <div id="LeftPane2" runat="server" class="col-md-3 col-sm-5" />
        <div id="ContentLeftPane2" runat="server" class="col-md-9 col-sm-7" />
    </div>
    <div class="row">
        <div id="MiddlePane11" runat="server" class="col-md-4" />
        <div id="MiddlePane12" runat="server" class="col-md-4" />
        <div id="MiddlePane13" runat="server" class="col-md-4" />
    </div>
    <div class="row">
        <div id="MiddlePane" runat="server" class="col-md-12" />
    </div>
    <div class="row">
        <div id="MiddlePane21" runat="server" class="col-md-4" />
        <div id="MiddlePane22" runat="server" class="col-md-4" />
        <div id="MiddlePane23" runat="server" class="col-md-4" />
    </div>
    <div class="row">
        <div id="ContentPane3" runat="server" class="col-md-9 col-sm-7" />
        <div id="RightPane3" runat="server" class="col-md-3 col-sm-5" />
    </div>
    <div class="row"> 
        <div id="LeftPane3" runat="server" class="col-md-3 col-sm-5" />
        <div id="ContentLeftPane3" runat="server" class="col-md-9 col-sm-7" />
    </div>
    <div class="row">
        <div id="ContentPane4" runat="server" class="col-md-9 col-sm-7" />
        <div id="RightPane4" runat="server" class="col-md-3 col-sm-5" />
    </div>
    <div class="row"> 
        <div id="LeftPane4" runat="server" class="col-md-3 col-sm-5" />
        <div id="ContentLeftPane4" runat="server" class="col-md-9 col-sm-7" />
    </div>
    <div class="row">
        <div id="BottomPane11" runat="server" class="col-md-4" />
        <div id="BottomPane12" runat="server" class="col-md-4" />
        <div id="BottomPane13" runat="server" class="col-md-4" />
    </div>
    <div class="row">
        <div id="BottomPane21" runat="server" class="col-md-4" />
        <div id="BottomPane22" runat="server" class="col-md-4" />
        <div id="BottomPane23" runat="server" class="col-md-4" />
    </div>
    <div class="row">
        <div id="BottomPane31" runat="server" class="col-md-4" />
        <div id="BottomPane32" runat="server" class="col-md-4" />
        <div id="BottomPane33" runat="server" class="col-md-4" />
    </div>
    <div class="row">
        <div id="BottomLeftPane" runat="server" class="col-md-6" />
        <div id="BottomRightPane" runat="server" class="col-md-6" />
    </div>
    <div class="row">
        <div id="BottomPane" runat="server" class="col-md-12" />
    </div>
</div>
<!-- End panes code -->
<skin:SUPFOOTER runat="server" />
<footer class="footer skin-footer">
    <skin:FOOTER runat="server" />
</footer>
<skin:END runat="server" />