<%@ Page Language="C#" MasterPageFile="~/MasterPages/ListView.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="IB207000.aspx.cs" Inherits="Page_IB207000" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/ListView.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" Runat="Server">
	<px:PXDataSource SkinID="Details" ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="IceBreakerMiniProject.IBMPCustomerMaint"
        PrimaryView="Customers"
        >
		<CallbackCommands>

		</CallbackCommands>
	</px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phL" runat="Server">
	<px:PXFormView runat="server" ID="CstFormView1" DataMember="Customers" SkinID="" Width="100%" Height="150px" >
		<Template>
			<px:PXMaskEdit runat="server" ID="CstPXMaskEdit4" DataField="CustomerCD" ></px:PXMaskEdit>
			<px:PXTextEdit runat="server" ID="CstPXTextEdit5" DataField="Name" ></px:PXTextEdit>
			<px:PXTextEdit runat="server" ID="CstPXTextEdit2" DataField="Address" ></px:PXTextEdit>
			<px:PXTextEdit runat="server" ID="CstPXTextEdit3" DataField="Contact" ></px:PXTextEdit></Template></px:PXFormView></asp:Content>
