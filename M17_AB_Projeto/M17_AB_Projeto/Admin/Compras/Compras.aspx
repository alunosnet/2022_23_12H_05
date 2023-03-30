﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="M17_AB_Projeto.Admin.Compras.Compras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h5><asp:Gridview runat = "server" ID = "gv_compras" ></asp:Gridview></h5>
    <h2> Registar nova Compra </h2>
    Produto:<asp:DropdownList runat = "server" ID = "dd_produto" ></asp:DropdownList><br />
    <br/>
    Comprador:<asp:DropdownList runat = "server" ID = "dd_comprador" ></asp:DropdownList><br />
    <br />
    Data Compra:<asp:TextBox runat = "server" ID = "tb_data" TextMode = "Date" ></asp:TextBox><br />
    <br />
    <asp:Button CssClass="btn btn-danger" runat ="server" ID = "bt_registar" Text = "Vender" OnClick="bt_registar_Click"/>
    <br />
    <asp:Label runat = "server" ID = "lb_erro" ></asp:Label>
</asp:Content>
