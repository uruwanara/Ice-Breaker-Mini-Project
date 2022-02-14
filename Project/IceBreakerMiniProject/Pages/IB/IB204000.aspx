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
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" Runat="Server">
	<px:PXFormView ID="form" runat="server" DataSourceID="ds" DataMember="SalesOrders" Width="100%" Height="100px" AllowAutoHide="false">
		<Template>
			<px:PXLayoutRule ID="PXLayoutRule1" runat="server" StartRow="True"></px:PXLayoutRule>
		</Template>
	</px:PXFormView>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" Runat="Server">
	<px:PXTab ID="tab" runat="server" Width="100%" Height="150px" DataSourceID="ds" AllowAutoHide="false">
		<Items>
			<px:PXTabItem Text="Order Lines">
				<Template>
					<px:PXGrid runat="server" ID="CstPXGrid2">
						<Levels>
							<px:PXGridLevel DataMember="SalesOrderLines" >
								<Columns>
									<px:PXGridColumn DataField="Status" Width="140" />
									<px:PXGridColumn DataField="Qty" Width="70" />
									<px:PXGridColumn DataField="Price" Width="100" />
									<px:PXGridColumn DataField="Partid" Width="70" /></Columns></px:PXGridLevel></Levels></px:PXGrid></Template>
			</px:PXTabItem></Items>
		<AutoSize Container="Window" Enabled="True" MinHeight="150" ></AutoSize>
	</px:PXTab>
</asp:Content>
