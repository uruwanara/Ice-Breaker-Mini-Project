<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormDetail.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="IB205000.aspx.cs" Inherits="Page_IB205000" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/FormDetail.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" Runat="Server">
	<px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="IceBreakerMiniProject.IBMPProductionOrderMaint"
        PrimaryView="StockItems"
        >
		<CallbackCommands>

		</CallbackCommands>
	</px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" Runat="Server">
	<px:PXFormView ID="form" runat="server" DataSourceID="ds" DataMember="ProductionOrders" Width="100%" Height="180px" AllowAutoHide="false">
		<Template>
			<px:PXLayoutRule ID="PXLayoutRule1" runat="server" StartRow="True"></px:PXLayoutRule>
			<px:PXSelector runat="server" ID="CstPXSelector7" DataField="ProductionOrderCD" ></px:PXSelector>
			<px:PXSelector runat="server" ID="CstPXSelector5" DataField="Partid" ></px:PXSelector>
			<px:PXDateTimeEdit runat="server" ID="CstPXDateTimeEdit1" DataField="OrderDate" ></px:PXDateTimeEdit>
			<px:PXDateTimeEdit runat="server" ID="CstPXDateTimeEdit3" DataField="RequiredDate" ></px:PXDateTimeEdit>
			<px:PXTextEdit runat="server" ID="CstPXTextEdit4" DataField="Status" ></px:PXTextEdit></Template>
	</px:PXFormView>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" Runat="Server"></asp:Content>
