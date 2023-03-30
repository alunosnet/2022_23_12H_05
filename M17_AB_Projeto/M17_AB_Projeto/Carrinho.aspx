<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Carrinho.aspx.cs" Inherits="M17_AB_Projeto.Carrinho" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Bem-Vindo ao Carrinho do Gasto</h3>
    <br />
    <br />
    <br />
    <br />
    <h5>Adicionado com sucesso..</h5>
    <asp:GridView runat="server" ID="gvCarrinho"></asp:GridView><br />
</asp:Content>
