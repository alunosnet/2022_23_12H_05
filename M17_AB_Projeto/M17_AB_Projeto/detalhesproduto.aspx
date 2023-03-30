<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="detalhesproduto.aspx.cs" Inherits="M17_AB_Projeto.detalhesproduto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Detalhes Produtos</h2>
    <asp:Image CssClass="img-fluid" ID="imgCapa" runat="server" /><br />
    <asp:Label ID="lbNome" runat="server" Text=""></asp:Label><br />
    <label >Média das Avaliações:</label> <asp:Label ID="lb_avaliacao" runat="server"></asp:Label> <br />
    <label >Avaliação:</label>
          <asp:DropDownList ID="ddavaliacao" runat="server">
            <asp:ListItem Value="1">1 - Péssimo</asp:ListItem>
            <asp:ListItem Value="2">2 - + ou -</asp:ListItem>
            <asp:ListItem Value="3">3 - Bom</asp:ListItem>
            <asp:ListItem Value="4">4 - Muito Bom</asp:ListItem>
            <asp:ListItem Value="5">5 - Excelente</asp:ListItem>
          </asp:DropDownList>
    <br /> <br /> 
    <asp:Button CssClass="btn btn-danger" ID="btAvaliar" runat="server" Text="Avaliar" OnClick="btAvaliar_Click"/><br /><br />
    <label >Último comentário:</label><br /><asp:Label ID="lb_comentario" runat="server"></asp:Label>
    <asp:TextBox ID="tb_comentario" runat="server"></asp:TextBox> <br /><br />
    <asp:Button CssClass="btn btn-danger" ID="btComentar" runat="server" Text="Comentar" OnClick="btComentar_Click"/>
    <asp:Button runat="server" ID="btVoltar" CssClass="btn btn-danger" Text="Voltar" OnClick="btVoltar_Click"/>
    <asp:Label runat="server" ID="lbErro" /><br /> 
</asp:Content>
