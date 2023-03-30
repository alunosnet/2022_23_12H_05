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
    public partial class Produtos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if (CompradorLogin.ValidarSessao(Session, Request, "0") == false)
            {
                Response.Redirect("~/index.aspx");
            }

            ConfigurarGrid();

            if (!IsPostBack)
            {
                AtualizarGrid();
            }
        }

        private void ConfigurarGrid()
        {
            gvProdutos.AllowPaging = true;
            gvProdutos.PageSize = 5;
            gvProdutos.PageIndexChanging += GvProdutos_PageIndexChanging;
        }

        private void GvProdutos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProdutos.PageIndex = e.NewPageIndex;
            AtualizarGrid();
        }

        protected void bt_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = tbNome.Text;
                if (nome.Trim().Length < 3)
                {
                    throw new Exception("O nome é muito pequeno.");
                }
                string referencia = tbReferência.Text;
                if (referencia.Trim().Length < 8 )
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
                    throw new Exception("A categoria não é válida");
                }

                Produto produtos = new Produto();
                produtos.nome = nome;
                produtos.preco = preco;
                produtos.referencia = referencia;
                produtos.tipo = tipo;
                produtos.stock = 1;
                int nproduto = produtos.Adicionar();

                if (fuCapa.HasFile)
                {
                    string ficheiro = Server.MapPath(@"~\Public\Imagens\");
                    ficheiro = ficheiro + nproduto + ".jpg";
                    fuCapa.SaveAs(ficheiro);
                }
            }
            catch (Exception ex)
            {
                lbErro.Text = "Ocorreu o seguinte erro: " + ex.Message;
                return;
            }
            //limpar form
            tbNome.Text = "";
            tbPreco.Text = "";
            tbReferência.Text = "";
            dpTipo.SelectedIndex = 0;

            //atualizar grid
            AtualizarGrid();
        }

        private void AtualizarGrid()
        {
            gvProdutos.Columns.Clear();
            Produto lv = new Produto();
            DataTable dados = lv.ListaTodosProdutos();

            DataColumn dcEditar = new DataColumn();
            dcEditar.ColumnName = "Editar";
            dcEditar.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcEditar);

            DataColumn dcApagar = new DataColumn();
            dcApagar.ColumnName = "Apagar";
            dcApagar.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcApagar);

            //colunas da gridview
            gvProdutos.DataSource = dados;
            gvProdutos.AutoGenerateColumns = false;

            //Editar
            HyperLinkField hlEditar = new HyperLinkField();
            hlEditar.HeaderText = "Editar";
            hlEditar.DataTextField = "Editar";
            hlEditar.Text = "Editar...";
            hlEditar.DataNavigateUrlFormatString = "EditarProduto.aspx?nproduto={0}";
            hlEditar.DataNavigateUrlFields = new string[] { "nproduto" };
            gvProdutos.Columns.Add(hlEditar);

            //Apagar
            HyperLinkField hlApagar = new HyperLinkField();
            hlApagar.HeaderText = "Apagar";
            hlApagar.DataTextField = "Apagar";
            hlApagar.Text = "Apagar...";
            hlApagar.DataNavigateUrlFormatString = "ApagarProduto.aspx?nproduto={0}";
            hlApagar.DataNavigateUrlFields = new string[] { "nproduto" };
            gvProdutos.Columns.Add(hlApagar);

            //nproduto
            BoundField bfnproduto = new BoundField();
            bfnproduto.HeaderText = "Nº Produto";
            bfnproduto.DataField = "nproduto";
            gvProdutos.Columns.Add(bfnproduto);

            //nome
            BoundField bfnome = new BoundField();
            bfnome.HeaderText = "Nome";
            bfnome.DataField = "nome";
            gvProdutos.Columns.Add(bfnome);

            //Preço
            BoundField bfpreco = new BoundField();
            bfpreco.HeaderText = "Preço";
            bfpreco.DataField = "preco";
            bfpreco.DataFormatString = "{0:C}";
            gvProdutos.Columns.Add(bfpreco);

            //Referencia
            BoundField bfreferencia = new BoundField();
            bfreferencia.HeaderText = "Referência";
            bfreferencia.DataField = "referencia";
            gvProdutos.Columns.Add(bfreferencia);

            //Categoria
            BoundField bftipo = new BoundField();
            bftipo.HeaderText = "Tipo";
            bftipo.DataField = "tipo";
            gvProdutos.Columns.Add(bftipo);

            //Estado
            BoundField bfstock = new BoundField();
            bfstock.HeaderText = "Stock";
            bfstock.DataField = "stock";
            gvProdutos.Columns.Add(bfstock);

            //Capa
            ImageField ifcapa = new ImageField();
            ifcapa.HeaderText = "Capa";
            int aleatorio = new Random().Next(99999);
            ifcapa.DataImageUrlFormatString = "~/Public/Imagens/{0}.jpg?" + aleatorio;
            ifcapa.DataImageUrlField = "nproduto";
            ifcapa.ControlStyle.Width = 200;
            gvProdutos.Columns.Add(ifcapa);

            gvProdutos.DataBind();
        }

    }
    
}