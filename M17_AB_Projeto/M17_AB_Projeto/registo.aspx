<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="registo.aspx.cs" Inherits="M17_AB_Projeto.registo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://www.google.com/recaptcha/api.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <h2>Registo</h2>
    Nome:<asp:TextBox CssClass="form-control"  runat="server" ID="tb_nome"></asp:TextBox><br />
    Email:<asp:TextBox CssClass="form-control" runat="server" ID="tb_email"></asp:TextBox><br />
    Morada:<asp:TextBox CssClass="form-control" runat="server" ID="tb_morada"></asp:TextBox><br />
    Nif:<asp:TextBox CssClass="form-control" runat="server" ID="tb_nif" MaxLength="9"></asp:TextBox><br />
    Password:<asp:TextBox CssClass="form-control" runat="server" ID="tb_password" TextMode="Password"></asp:TextBox><br />
    <asp:Button CssClass="btn btn-danger" runat="server" ID="bt_guardar" Text="Registar" OnClick="bt_guardar_Click"/><br />
    <asp:Label runat="server" ID="lb_erro"></asp:Label>
    <!--recaptcha-->
    <div class = "g-recaptcha" data-sitekey="6LczdM8jAAAAAMje4BXy1d-vly027TN18ZuO0YcK"></div>

</asp:Content>
