<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormTab.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="IB201000.aspx.cs" Inherits="Page_IB201000" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/FormTab.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" Runat="Server">
	<px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="IceBreakerMiniProject.IBMPWarehouseMaint"
        PrimaryView="Warehouses"
        >
		<CallbackCommands>
			<px:PXDSCallbackCommand Name="Last" ></px:PXDSCallbackCommand>
			<px:PXDSCallbackCommand Visible="True" Name="Save" ></px:PXDSCallbackCommand></CallbackCommands>
	</px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" Runat="Server">
	<px:PXFormView SkinID="" ID="form" runat="server" DataSourceID="ds" DataMember="Warehouses" Width="100%" Height="" AllowAutoHide="false">
		<Template>
		<px:PXLayoutRule ControlSize="M" LabelsWidth="S" ID="PXLayoutRule1" runat="server" StartRow="True"></px:PXLayoutRule>
			<px:PXSelector runat="server" ID="CstPXSelector4" DataField="WarehouseCD" ></px:PXSelector>
			<px:PXTextEdit runat="server" ID="CstPXTextEdit3" DataField="Name" ></px:PXTextEdit></Template>
	</px:PXFormView>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" Runat="Server">
	<px:PXTab ID="tab" runat="server" Width="99%" Height="150px" DataSourceID="ds" AllowAutoHide="false">
		<Items>
			<px:PXTabItem Text="Locations">
				<Template>
					<px:PXGrid AutoAdjustColumns="True" Width="100%" SkinID="Details" runat="server" ID="CstPXGrid2">
						<Levels>
							<px:PXGridLevel DataMember="WarehouseLocations" >
								<Columns>
									<px:PXGridColumn CommitChanges="True" DataField="LocationCD" Width="140" ></px:PXGridColumn>
									<px:PXGridColumn DataField="Description" Width="140" ></px:PXGridColumn>
									<px:PXGridColumn DataField="Address" Width="180" ></px:PXGridColumn></Columns></px:PXGridLevel></Levels>
						<AutoSize Enabled="True" ></AutoSize>
						<Mode InitNewRow="False" ></Mode></px:PXGrid></Template>
			</px:PXTabItem></Items>
		<AutoSize Container="Window" Enabled="True" MinHeight="150" ></AutoSize>
	</px:PXTab>
</asp:Content>
