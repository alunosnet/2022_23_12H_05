using M17_AB_Projeto.Classes;
using M17_AB_Projeto.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace M17_AB_Projeto.Admin.Produtos
{
    public partial class EditarProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if (CompradorLogin.ValidarSessao(Session, Request, "0") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            if (IsPostBack) return;
            try
            {
                //querystring nproduto
                int nproduto = int.Parse(Request["nproduto"].ToString());

                Produto lv = new Produto();
                DataTable dados = lv.devolveDadosProdutos(nproduto);
                if (dados == null || dados.Rows.Count == 0)
                {
                    //o nlivro não existe na tabela dos livros
                    throw new Exception("O produto não existe.");
                }

                //mostrar os dados produto
                tbNome.Text = dados.Rows[0]["nome"].ToString();
                tbReferência.Text = dados.Rows[0]["referencia"].ToString();
                tbPreco.Text = dados.Rows[0]["preco"].ToString();
                dpTipo.Text = dados.Rows[0]["tipo"].ToString();
                tbstock.Text = dados.Rows[0]["stock"].ToString();
                Random rnd = new Random();
                //imgCapa.ImageUrl = @"~\Public\Imagens\" + nproduto + ".jpg?" + rnd.Next(9999);
                //imgCapa.Width = 300;
            }
            catch
            {
                Response.Redirect("~/Admin/Produtos/Produtos.aspx");
            }
        }

        protected void btAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = tbNome.Text;
                if (nome.Trim().Length < 3)
                {
                    throw new Exception("O nome é muito pequeno.");
                }
                string referencia = tbReferência.Text;
                if (referencia.Trim().Length < 8)
                {
                    throw new Exception("A referência tem de ser maior que 8");
                }
                Decimal preco = Decimal.Parse(tbPreco.Text);
                if (preco < 0 || preco > 4000)
                {
                    throw new Exception("O preço deve estar entre 0 e 4000");
                }
                string tipo = dpTipo.SelectedValue;
                if (tipo == "")
                {
                    throw new Exception("O tipo não é válida");
                }
                int stock =int.Parse(tbstock.Text);
                if (stock < 0)
                {
                    throw new Exception("O stock tem de ser maior que 0");
                }

                Produto produtos = new Produto();
                produtos.nome = nome;
                produtos.preco = preco;
                produtos.referencia = referencia;
                produtos.tipo = tipo;
                produtos.stock = stock;
                int nproduto = int.Parse(Request["nproduto"].ToString());
                produtos.nproduto = nproduto;
                produtos.atualizaProduto();

                lbErro.Text = "O produto foi editado com sucesso.";
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                   "Redirecionar", "returnMain('Produtos.aspx')", true);

            }
            catch (Exception ex)
            {
                lbErro.Text = "Ocorreu o seguinte erro: " + ex.Message;
                return;
            }
        }
    }
}