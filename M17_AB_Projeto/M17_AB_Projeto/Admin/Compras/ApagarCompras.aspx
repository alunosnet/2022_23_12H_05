<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ApagarCompras.aspx.cs" Inherits="M17_AB_Projeto.Admin.Compras.ApagarCompras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Confirmar apagar registo</h1>
    Nº Compra:<asp:Label runat="server" ID="lbNcompra" CssClass="form-control"></asp:Label>
    <br />Nome:<asp:Label runat="server" ID="lbNome" CssClass="form-control"></asp:Label>
    <br />
    <asp:Button CssClass="btn btn-lg btn-danger" runat="server" ID="btRemover" Text="Remover" OnClick="btRemover_Click"/>
    <asp:Button CssClass="btn btn-lg btn-info" runat="server" ID="btVoltar" Text="Voltar" OnClick="btVoltar_Click"/>
    <br /><asp:Label runat="server" ID="lbErro"></asp:Label>
</asp:Content>
