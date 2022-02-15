<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormTab.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="IB202000.aspx.cs" Inherits="Page_IB202000" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/FormTab.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" Runat="Server">
	<px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="IceBreakerMiniProject.IBMPStockItemsMaint"
        PrimaryView="StockItems"
        >
		<CallbackCommands>
			<px:PXDSCallbackCommand Name="Last" ></px:PXDSCallbackCommand>
			<px:PXDSCallbackCommand Visible="True" Name="Save" ></px:PXDSCallbackCommand>
		</CallbackCommands>
	</px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" Runat="Server">
	<px:PXFormView ID="form" runat="server" DataSourceID="ds" DataMember="StockItems" Width="99%" Height="150px" AllowAutoHide="false">
		<Template>
			<px:PXLayoutRule ID="PXLayoutRule1" runat="server" StartRow="True"></px:PXLayoutRule>
			<px:PXSelector runat="server" ID="CstPXSelector12" DataField="InventoryCD" ></px:PXSelector>
			<px:PXTextEdit runat="server" ID="CstPXTextEdit1" DataField="Description" ></px:PXTextEdit>
			<px:PXDropDown runat="server" ID="CstPXDropDown13" DataField="PartType" ></px:PXDropDown>
			<px:PXNumberEdit runat="server" ID="CstPXNumberEdit4" DataField="Price" ></px:PXNumberEdit></Template>
	
		<ContentLayout AutoSizeControls="False" ></ContentLayout></px:PXFormView>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" Runat="Server">
	<px:PXTab ID="tab" runat="server" Width="99%" Height="150px" DataSourceID="ds" AllowAutoHide="false">
		<Items>
			<px:PXTabItem Text="Warehouse Locations">
				<Template>
					<px:PXGrid Width="100%" SkinID="Details" runat="server" ID="CstPXGrid11" AutoAdjustColumns="True">
						<Levels>
							<px:PXGridLevel DataMember="InventoryLocations" >
								<Columns>
									<px:PXGridColumn DataField="IBMPWarehouseLocation__LocationCD" Width="140" ></px:PXGridColumn>
									<px:PXGridColumn DataField="QtyReserved" Width="70" ></px:PXGridColumn>
									<px:PXGridColumn DataField="QtyHand" Width="70" ></px:PXGridColumn></Columns></px:PXGridLevel></Levels>
						<AutoSize Enabled="True" ></AutoSize>
						<Mode InitNewRow="True" ></Mode></px:PXGrid></Template>
			</px:PXTabItem></Items>
		<AutoSize Container="Window" Enabled="True" MinHeight="150" ></AutoSize>
	</px:PXTab>
</asp:Content>
