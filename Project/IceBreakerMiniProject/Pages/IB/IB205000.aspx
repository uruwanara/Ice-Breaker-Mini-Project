<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormDetail.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="IB205000.aspx.cs" Inherits="Page_IB205000" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/FormDetail.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" Runat="Server">
	<px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="IceBreakerMiniProject.IBMPProductionOrderMaint"
        PrimaryView="ProductionOrders"
        >
		<CallbackCommands>

		</CallbackCommands>
	</px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" Runat="Server">
	<px:PXFormView ID="form" runat="server" DataSourceID="ds" DataMember="ProductionOrders" Width="100%" Height="130px" AllowAutoHide="false">
		<Template>
			<px:PXLayoutRule ID="PXLayoutRule1" runat="server" StartRow="True"></px:PXLayoutRule>
			<px:PXSelector runat="server" ID="CstPXSelector2" DataField="ProductionOrderCD" ></px:PXSelector>
			<px:PXDateTimeEdit runat="server" ID="CstPXDateTimeEdit1" DataField="OrderDate" ></px:PXDateTimeEdit>
			<px:PXDateTimeEdit runat="server" ID="CstPXDateTimeEdit3" DataField="RequiredDate" ></px:PXDateTimeEdit>
			<px:PXTextEdit runat="server" ID="CstPXTextEdit4" DataField="Status" ></px:PXTextEdit></Template>
	</px:PXFormView>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" Runat="Server">
	<px:PXGrid AutoAdjustColumns="True" ID="grid" runat="server" DataSourceID="ds" Width="99%" Height="150px" SkinID="Details" AllowAutoHide="false">
		<Levels>
			<px:PXGridLevel DataMember="ProductionOrderLines">
			    <Columns>
				<px:PXGridColumn DataField="InventoryID" Width="70" ></px:PXGridColumn>
				<px:PXGridColumn DataField="Status" Width="140" ></px:PXGridColumn>
				<px:PXGridColumn DataField="Qty" Width="70" ></px:PXGridColumn></Columns>
			</px:PXGridLevel>
		</Levels>
		<AutoSize Container="Window" Enabled="True" MinHeight="150" ></AutoSize>
		<ActionBar >
		</ActionBar>
	
		<Mode InitNewRow="True" ></Mode></px:PXGrid>
</asp:Content>
