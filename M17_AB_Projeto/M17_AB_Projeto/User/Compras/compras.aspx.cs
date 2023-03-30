using M17_AB_Projeto.Admin.Compras;
using M17_AB_Projeto.Admin.Produtos;
using M17_AB_Projeto.Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace M17_AB_Projeto.User
{
    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CompradorLogin.ValidarSessao(Session, Request, "1") == false)
                Response.Redirect("~/index.aspx");
            ConfigurarGrid();
            AtualizarGrid();
        }

        private void ConfigurarGrid()
        {
            gvprodutos.RowCommand += Gvprodutos_RowCommand; 
        }

        private void Gvprodutos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int linha = int.Parse(e.CommandArgument.ToString());
            int nproduto = int.Parse(gvprodutos.Rows[linha].Cells[1].Text);
            int idcompradores = int.Parse(Session["id"].ToString());
            if (e.CommandName == "Comprar")
            {
                Models.Compras comp = new Models.Compras();
                comp.adicionarCompra(nproduto, idcompradores, DateTime.Now);
                AtualizarGrid();
            }
        }

        private void AtualizarGrid()
        {
            gvprodutos.Columns.Clear();
            gvprodutos.DataSource = null;
            gvprodutos.DataBind();

            Models.Produto produto = new Models.Produto();
            gvprodutos.DataSource = produto.listaProdutosDisponiveis();

            //botão Comprar
            ButtonField bt = new ButtonField();
            bt.HeaderText = "Comprar";
            bt.Text = "Comprar";
            bt.ButtonType = ButtonType.Button;
            bt.CommandName = "Comprar";
            bt.ControlStyle.CssClass = "btn btn-danger";
            gvprodutos.Columns.Add(bt);

            gvprodutos.DataBind();
        }
    }
}