<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="EditLayout.ascx.cs" Inherits="R7.Epsilon.LayoutManager.SelectLayout" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/labelcontrol.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx"%>
<%@ Register TagPrefix="dnn" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.UI.WebControls" Assembly="DotNetNuke.Web" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>

<div class="dnnForm dnnClear">
    <fieldset>
		<div class="dnnFormItem">
            <dnn:Label id="labelLayout" runat="server" ControlName="comboLayout" />  
            <asp:DropDownList id="comboLayout" runat="server"
				DataTextField = "Name_String"
				DataValueField = "Name"
		    />
        </div>
    	<ul class="dnnActions dnnClear">
            <li><asp:LinkButton id="buttonSelect" runat="server" CssClass="dnnPrimaryAction" resourcekey="Select.Text" OnClick="buttonSelect_Click" /></li>
            <li><asp:HyperLink id="linkCancel" runat="server" CssClass="dnnSecondaryAction" resourcekey="cmdCancel" /></li>
        </ul>
    </fieldset>
</div>