<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormView.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="IB404000.aspx.cs" Inherits="Page_IB404000" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/FormView.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" Runat="Server">
	<px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="IceBreakerMiniProject.IBMPSalesOrderInq"
        PrimaryView="SalesOrderView"
        >
		<CallbackCommands>

		</CallbackCommands>
	</px:PXDataSource>
</asp:Content>
<%--<asp:Content ID="cont2" ContentPlaceHolderID="phF" Runat="Server">
	<px:PXFormView ID="form" runat="server" DataSourceID="ds" DataMember="SalesOrderView" Width="100%" Height="100px" AllowAutoHide="false">
		<Template>
			<px:PXLayoutRule ID="PXLayoutRule1" runat="server" StartRow="True"/>
		</Template>
	</px:PXFormView>
</asp:Content>--%>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" Runat="Server">
	<px:PXGrid ID="grid" runat="server" DataSourceID="ds" Width="100%" Height="150px" AllowAutoHide="false">
		<Levels>
			<px:PXGridLevel DataMember="SalesOrderView">
			    <Columns>
				<px:PXGridColumn DataField="SalesOrderCD" Width="140" />
				<px:PXGridColumn DataField="SumPrice" Width="100" />
				<px:PXGridColumn DataField="Status" Width="140" />
				<px:PXGridColumn DataField="RequiredDate" Width="90" />
				<px:PXGridColumn DataField="OrderDate" Width="90" /></Columns>
			</px:PXGridLevel>
		</Levels>
		<AutoSize Container="Window" Enabled="True" MinHeight="150" />
		<ActionBar >
		</ActionBar>
	</px:PXGrid>
</asp:Content>
