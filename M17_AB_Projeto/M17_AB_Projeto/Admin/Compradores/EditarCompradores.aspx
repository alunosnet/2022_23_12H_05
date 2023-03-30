<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditarCompradores.aspx.cs" Inherits="M17_AB_Projeto.Admin.Compradores.EditarCompradores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Editar Compradores</h1>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbNome">Nome:</label>
        <asp:TextBox CssClass="form-control" ID="tbNome" runat="server" MaxLength="100" Required placeholder="Nome" /><br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbEmail">Email:</label>
        <asp:TextBox CssClass="form-control" ID="tbEmail" runat="server" MaxLength="100" Required placeholder="email" /><br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbMorada">Morada:</label>
        <asp:TextBox CssClass="form-control" ID="tbMorada" runat="server" MaxLength="100" Required placeholder="Morada" /><br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbNif">Nif:</label>
        <asp:TextBox CssClass="form-control" ID="tbNif" runat="server" MaxLength="100" Required placeholder="Nif" /><br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbPassword">Password:</label>
        <asp:TextBox CssClass="form-control" ID="tbPassword" runat="server" MaxLength="100" Required placeholder="Password" /><br />
    </div>
    <br />
    <asp:Button runat="server" ID="btAtualizar" CssClass="btn btn-lg btn-success" Text="Atualizar" OnClick="btAtualizar_Click" />
    <asp:Button runat="server" ID="btVoltar" CssClass="btn btn-lg btn-info" Text="Voltar" PostBackUrl="~/Admin/Compradores/Compradores.aspx" />
    <br />
    <asp:Label ID="lbErro" runat="server"></asp:Label>
</asp:Content>
