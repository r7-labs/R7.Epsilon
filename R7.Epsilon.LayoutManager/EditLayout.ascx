<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="EditLayout.ascx.cs" Inherits="R7.Epsilon.LayoutManager.EditLayout" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/labelcontrol.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx"%>
<%@ Register TagPrefix="dnn" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.UI.WebControls" Assembly="DotNetNuke.Web" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>

<dnn:DnnCssInclude runat="server" FilePath="~/DesktopModules/R7.Epsilon/R7.Epsilon.LayoutManager/admin.css" Priority="200" />
<div class="dnnForm dnnClear">
    <fieldset>  
        <div class="dnnFormItem">
            <dnn:Label ID="lblContent" runat="server" ControlName="txtContent" />
            <dnn:TextEditor ID="txtContent" runat="server" Height="200" Width="100%" />
        </div>
    </fieldset>
    <ul class="dnnActions dnnClear">
        <li><asp:LinkButton id="buttonUpdate" runat="server" CssClass="dnnPrimaryAction" resourcekey="cmdUpdate" OnClick="buttonUpdate_Click" CausesValidation="true" /></li>
        <li><asp:LinkButton id="buttonDelete" runat="server" CssClass="dnnSecondaryAction" resourcekey="cmdDelete" OnClick="buttonDelete_Click" /></li>
        <li><asp:HyperLink id="linkCancel" runat="server" CssClass="dnnSecondaryAction" resourcekey="cmdCancel" /></li>
    </ul>
    <dnn:Audit id="ctlAudit" runat="server" />
</div>