<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="user.aspx.cs" Inherits="M17_AB_Projeto.User.user" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Área de Utilizador</h1>
    <div runat="server" id="divPerfil">
        Nome:<asp:Label runat="server" ID="lbNome"></asp:Label>
        <br />Email:<asp:Label runat="server" ID="lbEmail"></asp:Label>
        <br />Morada:<asp:Label runat="server" ID="lbMorada"></asp:Label>
        <br />Nif:<asp:Label runat="server" ID="lbnif"></asp:Label>
        <br />
        <asp:Button runat="server" ID="btEditar" Text="Editar Perfil" OnClick="btEditar_Click"/>
    </div>
    <div runat="server" id="divEditar">
        Nome:<asp:TextBox runat="server" ID="tbNome"></asp:TextBox>
        <br />Email:<asp:TextBox runat="server" ID="tbEmail"></asp:TextBox>
        <br />Morada<asp:TextBox runat="server" ID="tbMorada"></asp:TextBox>
        <br />Nif<asp:TextBox MaxLength="9" runat="server" ID="tbNif"></asp:TextBox>
        <br />
        <asp:Button runat="server" ID="btAtualizar" Text="Atualizar Perfil" OnClick="btAtualizar_Click"/>
        <asp:Button runat="server" ID="btCancelar" Text="Cancelar" OnClick="btCancelar_Click"/>
    </div>
</asp:Content>
