<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ViewLayoutManager.ascx.cs" Inherits="R7.Epsilon.LayoutManager.ViewLayoutManager" %>
<asp:GridView id="gridLayouts" runat="server" AutoGenerateColumns="false" CssClass="dnnGrid" GridLines="None" OnRowDataBound="gridLayouts_RowDataBound">
	<HeaderStyle CssClass="dnnGridHeader" HorizontalAlign="Left" />
    <RowStyle CssClass="dnnGridItem" HorizontalAlign="Left" />
    <AlternatingRowStyle CssClass="dnnGridAltItem" />
    <EditRowStyle CssClass="dnnFormInput" />
    <SelectedRowStyle CssClass="dnnFormError" />
    <FooterStyle CssClass="dnnGridFooter" />
    <PagerStyle CssClass="dnnGridPager" />
    <Columns>
		<asp:TemplateField>
            <ItemTemplate>
                <asp:HyperLink id="linkEdit" runat="server" IconKey="Edit" NavigateUrl='<%# EditUrl ("layoutName", (string) Eval ("Name"), "Edit") %>' />
            </ItemTemplate>
        </asp:TemplateField>
		<asp:BoundField DataField="Name" HeaderText="Layout Name" />
	</Columns>
</asp:GridView>
