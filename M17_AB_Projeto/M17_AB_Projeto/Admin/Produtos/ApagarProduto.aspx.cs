using M17_AB_Projeto.Classes;
using M17_AB_Projeto.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17_AB_Projeto.Admin.Produtos
{
    public partial class ApagarProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if (CompradorLogin.ValidarSessao(Session, Request, "0") == false)
            {
                Response.Redirect("~/index.aspx");
            }

            try
            {
                //querystring nproduto
                int nproduto = int.Parse(Request["nproduto"].ToString());

                Produto lv = new Produto();
                DataTable dados = lv.devolveDadosProdutos(nproduto);
                if (dados == null || dados.Rows.Count == 0)
                {
                    //o nproduto não existe na tabela dos produtos
                    throw new Exception("O produto não existe.");
                }
                //mostrar os dados produto
                lbNproduto.Text = dados.Rows[0]["nproduto"].ToString();
                lbNome.Text = dados.Rows[0]["nome"].ToString();
                imgCapa.ImageUrl = @"~\Public\Imagens\" + nproduto + ".jpg";
                imgCapa.Width = 300;
            }
            catch
            {
                Response.Redirect("~/Admin/Produtos/Produtos.aspx");
            }
        }

        protected void btRemover_Click(object sender, EventArgs e)
        {
            try
            {
                int nproduto = int.Parse(Request["nproduto"].ToString());
                Produto lv = new Produto();
                lv.removerProduto(nproduto);

                //apagar a capa
                string ficheiro = Server.MapPath(@"~\Public\Imagens\") + nproduto + ".jpg";
                if (File.Exists(ficheiro))
                    File.Delete(ficheiro);

                //Response.Redirect("~/Admin/Livros/livros.aspx");
                lbErro.Text = "O produto foi removido com sucesso";
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redirecionar", "returnMain('Produtos.aspx')", true);
            }
            catch
            {
                Response.Redirect("~/Admin/Produtos/Produtos.aspx");

            }
        }

        protected void btVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Produtos/Produtos.aspx");
        }
    }
}