<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormTab.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="IB204000.aspx.cs" Inherits="Page_IB204000" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/FormTab.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" Runat="Server">
	<px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="IceBreakerMiniProject.IBMPSalesOrderMaint"
        PrimaryView="SalesOrders"
        >
		<CallbackCommands>

		</CallbackCommands>
	</px:PXDataSource>
	<px:PXFormView Width="100%" Height="150px" DataMember="SalesOrders" runat="server" ID="form" >
		<Template>
			<px:PXLayoutRule runat="server" ID="CstPXLayoutRule11" StartRow="True" ></px:PXLayoutRule>
			<px:PXSelector runat="server" ID="CstPXSelector16" DataField="SalesOrderCD" ></px:PXSelector>
			<px:PXDateTimeEdit runat="server" ID="CstPXDateTimeEdit14" DataField="OrderDate" ></px:PXDateTimeEdit>
			<px:PXDateTimeEdit runat="server" ID="CstPXDateTimeEdit15" DataField="RequiredDate" ></px:PXDateTimeEdit>
			<px:PXTextEdit runat="server" ID="CstPXTextEdit17" DataField="Status" ></px:PXTextEdit>
			<px:PXLayoutRule runat="server" ID="CstPXLayoutRule23" StartColumn="True" ></px:PXLayoutRule>
			<px:PXSelector runat="server" ID="CstPXSelector25" DataField="CustomerID" ></px:PXSelector>
			<px:PXTextEdit runat="server" ID="CstPXTextEdit13" DataField="DeliveryAddress" ></px:PXTextEdit></Template></px:PXFormView>
	<px:PXTab Width="99%" runat="server" ID="CstPXTab26">
		<Items>
			<px:PXTabItem Text="Sales Order Line" >
				<Template>
					<px:PXGrid AutoAdjustColumns="True" runat="server" ID="CstPXGrid27" SkinID="Details">
						<Levels>
							<px:PXGridLevel DataMember="SalesOrderLines" >
								<Columns>
									<px:PXGridColumn DataField="Partid" Width="70" ></px:PXGridColumn>
									<px:PXGridColumn DataField="Status" Width="140" ></px:PXGridColumn>
									<px:PXGridColumn DataField="Qty" Width="70" ></px:PXGridColumn>
									<px:PXGridColumn DataField="Price" Width="100" ></px:PXGridColumn>
									<px:PXGridColumn DataField="TotalPrice" Width="100" ></px:PXGridColumn></Columns></px:PXGridLevel></Levels>
						<Mode InitNewRow="True" ></Mode>
						<AutoSize Enabled="True" /></px:PXGrid></Template></px:PXTabItem></Items></px:PXTab></asp:Content>

