<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Produtos.aspx.cs" Inherits="M17_AB_Projeto.Admin.Produtos.Produtos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Gerir Produtos</h2>
    <asp:GridView ID="gvProdutos" runat="server" CssClass="table" />
    <h2>Adicionar Produto</h2>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbNome">Nome:</label>
        <asp:TextBox CssClass="form-control" ID="tbNome" runat="server" MaxLength="100" Required placeholder="Nome do produto" /><br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbReferência">Referência:</label>
        <asp:TextBox CssClass="form-control" ID="tbReferência" runat="server" /><br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbPreco">Preço:</label>
        <asp:TextBox ID="tbPreco" CssClass="form-control" runat="server" /><br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_dpTipo">Tipo:</label>
        <asp:DropDownList CssClass="form-select" ID="dpTipo" runat="server">
            <asp:ListItem Text="Capacetes" Value="capacetes" />
            <asp:ListItem Text="Acessórios" Value="acessórios" />
            <asp:ListItem Text="Manutenção" Value="manutenção" />
         </asp:DropDownList>
    </div><br />
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbstock">Stock:</label>
        <asp:TextBox ID="tbstock" CssClass="form-control" runat="server" /><br />
    </div>
    <div class="form-group">
        <label for="ContentPlaceHolder1_fuCapa">Capa:</label>
        <asp:FileUpload ID="fuCapa" runat="server" CssClass="form-control" />
    </div> 
    <br />
    <asp:Button CssClass="btn btn-danger" runat="server" ID="bt" Text="Adicionar" OnClick="bt_Click"/>
    <asp:Label runat="server" ID="lbErro" />
</asp:Content>
