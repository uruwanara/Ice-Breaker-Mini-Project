<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormTab.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="IB204000.aspx.cs" Inherits="Page_IB204000" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/MasterPages/FormTab.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" runat="Server">
    <px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="IceBreakerMiniProject.IBMPSalesOrderMaint"
        PrimaryView="SalesOrders">
        <CallbackCommands>
            <px:PXDSCallbackCommand Name="Last"></px:PXDSCallbackCommand>
            <px:PXDSCallbackCommand Visible="True" Name="Save"></px:PXDSCallbackCommand>
        </CallbackCommands>
    </px:PXDataSource>

</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" runat="Server">
    <px:PXFormView Width="100%" Height="150px" DataMember="SalesOrders" runat="server" ID="form">
        <Template>
            <px:PXLayoutRule runat="server" ID="CstPXLayoutRule11" StartRow="True"></px:PXLayoutRule>
            <px:PXSelector runat="server" ID="CstPXSelector16" DataField="SalesOrderCD"></px:PXSelector>
            <px:PXDateTimeEdit runat="server" ID="CstPXDateTimeEdit14" DataField="OrderDate"></px:PXDateTimeEdit>
            <px:PXDateTimeEdit runat="server" ID="CstPXDateTimeEdit15" DataField="RequiredDate"></px:PXDateTimeEdit>
            <px:PXTextEdit runat="server" ID="CstPXTextEdit17" DataField="Status"></px:PXTextEdit>
            <px:PXLayoutRule runat="server" ID="CstPXLayoutRule23" StartColumn="True"></px:PXLayoutRule>
            <px:PXSelector runat="server" ID="CstPXSelector25" DataField="CustomerID"></px:PXSelector>
            <px:PXTextEdit runat="server" ID="CstPXTextEdit13" DataField="DeliveryAddress"></px:PXTextEdit>
        </Template>
    </px:PXFormView>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" runat="Server">
    <px:PXTab Height="500px" Width="99%" runat="server" ID="CstPXTab30">
        <Items>
            <px:PXTabItem Visible="True" Text="Parts">
                <Template>
                    <px:PXGrid AutoAdjustColumns="True" Width="100%" SkinID="Details" runat="server" ID="CstPXGrid31">
                        <AutoSize Enabled="True" MinHeight="200" />
                        <Levels>
                            <px:PXGridLevel DataMember="Parts">
                                <Columns>
                                    <px:PXGridColumn CommitChanges="True" DataField="Partid" Width="140"></px:PXGridColumn>
                                    <px:PXGridColumn DataField="Partid_description" Width="180"></px:PXGridColumn>
                                    <px:PXGridColumn CommitChanges="True" DataField="Price" Width="100"></px:PXGridColumn>
                                    <px:PXGridColumn CommitChanges="True" DataField="Qty" Width="70"></px:PXGridColumn>
                                    <px:PXGridColumn CommitChanges="False" DataField="TotalPrice" Width="100"></px:PXGridColumn>
                                    <px:PXGridColumn DataField="Status" Width="140"></px:PXGridColumn>
                                </Columns>
                            </px:PXGridLevel>
                        </Levels>
                        <Mode InitNewRow="True"></Mode>
                    </px:PXGrid>
                </Template>
            </px:PXTabItem>
            <px:PXTabItem Text="NoParts" Visible="True">
                <Template>
                    <px:PXGrid AutoAdjustColumns="True" Width="99%" SkinID="Details" runat="server" ID="CstPXGrid34">
                        <AutoSize Enabled="True" MinHeight="200" />
                        <Levels>
                            <px:PXGridLevel DataMember="NoParts">
                                <Columns>
                                    <px:PXGridColumn CommitChanges="True" DataField="Partid" Width="140"></px:PXGridColumn>
                                    <px:PXGridColumn DataField="Partid_description" Width="180"></px:PXGridColumn>
                                    <px:PXGridColumn DataField="Price" Width="100"></px:PXGridColumn>
                                    <px:PXGridColumn CommitChanges="True" DataField="Qty" Width="70"></px:PXGridColumn>
                                    <px:PXGridColumn DataField="TotalPrice" Width="100"></px:PXGridColumn>
                                    <px:PXGridColumn DataField="Status" Width="140"></px:PXGridColumn>
                                </Columns>
                            </px:PXGridLevel>
                        </Levels>
                        <Mode InitNewRow="True"></Mode>
                    </px:PXGrid>
                </Template>
            </px:PXTabItem>
        </Items>
        <AutoSize Container="Window" Enabled="True" MinHeight="150"></AutoSize>
    </px:PXTab>
</asp:Content>

