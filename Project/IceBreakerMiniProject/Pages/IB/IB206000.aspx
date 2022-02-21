<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormTab.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="IB206000.aspx.cs" Inherits="Page_IB206000" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/FormTab.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" Runat="Server">
	<px:PXDataSource SkinID="Detail" ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="IceBreakerMiniProject.IBMPBOMMaint"
        PrimaryView="ManufacturedProducts"
        >
		<CallbackCommands>

		</CallbackCommands>
	</px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" Runat="Server">
	<px:PXFormView ID="form" runat="server" DataSourceID="ds" DataMember="ManufacturedProducts" Width="100%" Height="100px" AllowAutoHide="false">
		<Template>
			<px:PXLayoutRule ID="PXLayoutRule1" runat="server" StartRow="True"></px:PXLayoutRule>
			<px:PXSelector runat="server" ID="CstPXSelector7" DataField="InventoryCD" ></px:PXSelector>
			<px:PXTextEdit runat="server" ID="CstPXTextEdit6" DataField="Description" ></px:PXTextEdit></Template>
	
		<AutoSize Enabled="False" ></AutoSize></px:PXFormView>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" Runat="Server">
	<px:PXTab ID="tab" runat="server" Width="100%" Height="150px" DataSourceID="ds" AllowAutoHide="false">
		<Items>
			<px:PXTabItem Text="Components">
				<Template>
					<px:PXGrid SkinID="Details" AutoAdjustColumns="True" Width="99%" runat="server" ID="CstPXGrid8">
						<Levels>
							<px:PXGridLevel DataMember="Components" >
								<Columns>
									<px:PXGridColumn DataField="ComponentID" Width="70" ></px:PXGridColumn>
									<px:PXGridColumn DataField="IBMPInventory__Description" Width="180" ></px:PXGridColumn>
									<px:PXGridColumn DataField="Qty" Width="70" ></px:PXGridColumn></Columns></px:PXGridLevel></Levels>
						<AutoSize Enabled="True" ></AutoSize>
						
						<Mode InitNewRow="True" /></px:PXGrid></Template>
			</px:PXTabItem></Items>
		<AutoSize Container="Window" Enabled="True" MinHeight="150" ></AutoSize>
	</px:PXTab>
</asp:Content>
