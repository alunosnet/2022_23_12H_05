<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="M17_AB_Projeto.Admin.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Public/chartistJS/chartist.css" rel="stylesheet" />
    <script src="/Public/chartistJS/chartist.js"></script>
    <script src="/Public/jquery/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Consultas</h2>
    <asp:DropDownList ID="ddConsultas" CssClass="form-control" AutoPostBack="true" 
        OnSelectedIndexChanged="ddConsultas_SelectedIndexChanged" runat="server">
        <asp:ListItem Value="0">Top de Produtos mais vendidos</asp:ListItem>
        <asp:ListItem Value="1">Top de Compradores</asp:ListItem>
        <asp:ListItem Value="2">Top de produtos mais vendidos do último mês</asp:ListItem>
    </asp:DropDownList>
    <asp:GridView CssClass="table" ID="gvConsultas" runat="server"></asp:GridView>
        <asp:Button runat="server" ID="btVoltar" CssClass="btn btn-danger" Text="Voltar" OnClick="btVoltar_Click"/>
</asp:Content>
