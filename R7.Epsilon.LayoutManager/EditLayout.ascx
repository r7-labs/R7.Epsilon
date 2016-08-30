<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="EditLayout.ascx.cs" Inherits="R7.Epsilon.LayoutManager.EditLayout" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/labelcontrol.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx"%>
<%@ Register TagPrefix="dnn" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.UI.WebControls" Assembly="DotNetNuke.Web" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>

<dnn:DnnCssInclude runat="server" FilePath="~/Resources/Shared/components/CodeEditor/lib/codemirror.css" />
<dnn:DnnCssInclude runat="server" FilePath="~/Resources/Shared/components/CodeEditor/theme/dnn-sql.css" />
<dnn:DnnCssInclude runat="server" FilePath="~/DesktopModules/R7.Epsilon/R7.Epsilon.LayoutManager/admin.css" Priority="200" />

<dnn:DnnJsInclude runat="server" FilePath="~/Resources/Shared/components/CodeEditor/lib/codemirror.js" Priority="1" />
<dnn:DnnJsInclude runat="server" FilePath="~/Resources/Shared/components/CodeEditor/mode/xml/xml.js" Priority="2" />
<dnn:DnnJsInclude runat="server" FilePath="~/Resources/Shared/components/CodeEditor/mode/javascript/javascript.js" Priority="3" />
<dnn:DnnJsInclude runat="server" FilePath="~/Resources/Shared/components/CodeEditor/mode/css/css.js" Priority="4" />
<dnn:DnnJsInclude runat="server" FilePath="~/Resources/Shared/components/CodeEditor/mode/htmlmixed/htmlmixed.js" Priority="5" />
<dnn:DnnJsInclude runat="server" FilePath="~/Resources/Shared/components/CodeEditor/addon/mode/multiplex.js" Priority="6" />
<dnn:DnnJsInclude runat="server" FilePath="~/Resources/Shared/components/CodeEditor/mode/htmlembedded/htmlembedded.js" Priority="7" />

<div class="dnnForm dnnClear">
    <fieldset>
		<div class="dnnFormItem">
            <dnn:Label ID="labelLayoutName" runat="server" ControlName="textLayoutName" />  
            <asp:TextBox ID="textLayoutName" runat="server" />
        </div>
        <div class="dnnFormItem">
            <asp:TextBox ID="layoutEditor" runat="server" TextMode="MultiLine" Rows="10" Width="100%" />
        </div>
    </fieldset>
    <ul class="dnnActions dnnClear">
        <li><asp:LinkButton id="buttonUpdate" runat="server" CssClass="dnnPrimaryAction" resourcekey="cmdUpdate" OnClick="buttonUpdate_Click" CausesValidation="true" /></li>
        <li><asp:LinkButton id="buttonDelete" runat="server" CssClass="dnnSecondaryAction" resourcekey="cmdDelete" OnClick="buttonDelete_Click" /></li>
        <li><asp:HyperLink id="linkCancel" runat="server" CssClass="dnnSecondaryAction" resourcekey="cmdCancel" /></li>
    </ul>
	<asp:HiddenField id="hiddenPortalId" runat="server" />
</div>
<script type="text/javascript">
(function ($) {
    $(function () {
        var editor = CodeMirror.fromTextArea($("textarea[id$='layoutEditor']")[0], {
            lineNumbers: true,
            matchBrackets: true,
            lineWrapping: true,
            indentWithTabs: true,
            theme: 'dnn-sql light',
            mode: 'application/x-aspx'
        });
    });
}) (jQuery);
</script>