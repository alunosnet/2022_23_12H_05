<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Compradores.aspx.cs" Inherits="M17_AB_Projeto.Admin.Compradores.Compradores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Compradores</h2>    
    <asp:GridView ID="gvCompradores" runat="server" CssClass="table" />
    <h2>Novo Comprador</h2>
    Nome:<asp:TextBox CssClass="form-control" runat="server" ID="tb_nome"></asp:TextBox><br />
    Email:<asp:TextBox CssClass="form-control" runat="server" ID="tb_email"></asp:TextBox><br />
    Morada:<asp:TextBox CssClass="form-control" runat="server" ID="tb_morada"></asp:TextBox><br />
    Nif:<asp:TextBox CssClass="form-control" runat="server" MaxLength="9" ID="tb_nif"></asp:TextBox><br />
    Password:<asp:TextBox CssClass="form-control" runat="server" ID="tb_password" TextMode="Password"></asp:TextBox><br />
    Perfil:<asp:DropDownList CssClass="form-control" runat="server" ID="dd_perfil">
            <asp:ListItem Value="0">Admin</asp:ListItem>
            <asp:ListItem Value="1">Comprador</asp:ListItem>
          </asp:DropDownList><br />
    <br />
    <asp:Button CssClass="btn btn-danger" runat="server" ID="bt_guardar" Text="Adicionar" OnClick="bt_guardar_Click"/><br />
    <asp:Label runet="server" ID="lb_erro"></asp:Label>
</asp:Content>
