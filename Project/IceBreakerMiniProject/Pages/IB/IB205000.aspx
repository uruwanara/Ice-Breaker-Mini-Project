<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormDetail.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="IB205000.aspx.cs" Inherits="Page_IB205000" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/MasterPages/FormDetail.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" runat="Server">
    <px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="IceBreakerMiniProject.IBMPProductionOrderMaint"
        PrimaryView="ProductionOrders">
        <CallbackCommands>
        </CallbackCommands>
    </px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" runat="Server">
    <px:PXFormView ID="form" runat="server" DataSourceID="ds" DataMember="ProductionOrders" Width="100%" Height="180px" AllowAutoHide="false">
        <Template>
            <px:PXLayoutRule ID="PXLayoutRule1" runat="server" StartRow="True"></px:PXLayoutRule>
            <px:PXSelector runat="server" ID="CstPXSelector7" DataField="ProductionOrderCD"></px:PXSelector>
            <px:PXSelector CommitChanges="True" runat="server" ID="CstPXSelector5" DataField="Partid"></px:PXSelector>
            <px:PXNumberEdit CommitChanges="True" runat="server" ID="CstPXNumberEdit11" DataField="Qty"></px:PXNumberEdit>
            <px:PXDateTimeEdit runat="server" ID="CstPXDateTimeEdit1" DataField="OrderDate"></px:PXDateTimeEdit>
            <px:PXDateTimeEdit runat="server" ID="CstPXDateTimeEdit3" DataField="RequiredDate"></px:PXDateTimeEdit>
            <px:PXTextEdit runat="server" ID="CstPXTextEdit4" DataField="Status"></px:PXTextEdit>
        </Template>
    </px:PXFormView>
    <px:PXTab runat="server" ID="CstPXTab9">
        <Items>
            <px:PXTabItem Text="BOM">
                <Template>
                    <px:PXGrid SkinID="Details" Width="100%" AutoAdjustColumns="True" runat="server" ID="CstPXGrid10">
                        <Levels>
                            <px:PXGridLevel DataMember="ProductionBom">
                                <Columns>
                                    <px:PXGridColumn DataField="ComponentID" Width="140"></px:PXGridColumn>
                                    <px:PXGridColumn DataField="ComponentID_description" Width="180"></px:PXGridColumn>
                                    <px:PXGridColumn CommitChanges="True" DataField="Qty" Width="70"></px:PXGridColumn>
                                    <px:PXGridColumn CommitChanges="True" DataField="TotalQty" Width="70"></px:PXGridColumn>
                                    <px:PXGridColumn CommitChanges="True" Type="CheckBox" DataField="Available" Width="60"></px:PXGridColumn>
                                </Columns>
                            </px:PXGridLevel>
                        </Levels>
                        <AutoSize Enabled="True"></AutoSize>
                    </px:PXGrid>
                </Template>
            </px:PXTabItem>
	<px:PXTabItem Text="Inventory">
		<Template>
			<px:PXFormView Width="100%" runat="server" ID="CstFormView32" DataMember="Inventory">
				<Template>
					<px:PXLayoutRule runat="server" ID="CstPXLayoutRule33" StartRow="True" ></px:PXLayoutRule>
					<px:PXSelector CommitChanges="True" runat="server" ID="CstPXSelector34" DataField="LocationID" ></px:PXSelector></Template></px:PXFormView></Template></px:PXTabItem></Items>
    </px:PXTab>
    <%-- <px:PXSmartPanel runat="server" ID="CstSmartPanel14" Key="LocationSmartPanel" AutoCallBack-Target="CstPXGrid15" AutoCallBack-Command="Refresh">
        <px:PXGrid runat="server" ID="CstPXGrid15">
            <Levels>
                <px:PXGridLevel DataMember="LocationSmartPanel">
                    <Columns>
                        <px:PXGridColumn DataField="LocationID" Width="140"></px:PXGridColumn>
                    </Columns>
                </px:PXGridLevel>
            </Levels>
        </px:PXGrid>
        <px:PXPanel runat="server" ID="PXUpSalePnl">
            <px:PXButton runat="server" ID="CstButton5" Text="Add &amp; Close" DialogResult="OK" />
            <px:PXButton runat="server" ID="CstButton6" Text="Cancel" DialogResult="Cancel" />
        </px:PXPanel>
    </px:PXSmartPanel>--%>
</asp:Content>

