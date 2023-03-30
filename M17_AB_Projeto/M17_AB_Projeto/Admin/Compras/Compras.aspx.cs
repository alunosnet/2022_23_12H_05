using M17_AB_Projeto.Classes;
using M17_AB_Projeto.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17_AB_Projeto.Admin.Compras
{
    public partial class Compras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if (CompradorLogin.ValidarSessao(Session, Request, "0") == false)
            {
                Response.Redirect("~/index.aspx");
            }

            ConfigurarGrid();
            if (IsPostBack) return;

            AtualizarGrid();
            AtualizaDDProdutos();
            AtualizarDDCompradores();
        }

        private void ConfigurarGrid()
        {
            //Paginação
            gv_compras.AllowPaging = true;
            gv_compras.PageSize = 5;
            gv_compras.PageIndexChanging += Gv_compras_PageIndexChanging;
            //Botões de comando
            gv_compras.RowCommand += Gv_compras_RowCommand;
            gv_compras.RowDataBound += Gv_compras_RowDataBound; 
        }

        private void Gv_compras_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           /* Foi o stor que meteu assim n sei pk
            * if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DateTime datadevolve = DateTime.Parse(e.Row.Cells[6].Text);
                int estado = int.Parse(e.Row.Cells[7].Text);
                if (estado != 0)
                {
                    e.Row.Cells[0].Controls[0].Visible = true;
                    if (datadevolve < DateTime.Now)
                        e.Row.Cells[1].Controls[0].Visible = true;
                    else
                        e.Row.Cells[1].Controls[0].Visible = false;

                }
                else
                {
                    e.Row.Cells[0].Controls[0].Visible = false;
                    e.Row.Cells[1].Controls[0].Visible = false;
                }
            }*/
        }

        private void Gv_compras_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // mudar de página
            if (e.CommandName == "Page") return;

            //linha
            int linha = int.Parse(e.CommandArgument.ToString());

            //id da compra
            int idcompra = int.Parse(gv_compras.Rows[linha].Cells[1].Text);
            Compras comp = new Compras();
            if (e.CommandName == "eliminar")
            {
                Response.Redirect("ApagarCompras.aspx?id=" + idcompra);
            }
            
        }

        private void Gv_compras_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_compras.PageIndex = e.NewPageIndex;
            AtualizarGrid();
        }

        private void AtualizarGrid()
        {
            Models.Compras comp = new Models.Compras();

            DataTable dados;
                dados = comp.listaTodosComprasComNomes();
            gv_compras.Columns.Clear();
            gv_compras.DataSource = null;
            gv_compras.DataBind();
            if (dados == null || dados.Rows.Count == 0) return;
            //botões de comando
            //receber
            ButtonField bfEliminar = new ButtonField();
            bfEliminar.HeaderText = "eliminar produto";
            bfEliminar.Text = "Eliminar";
            bfEliminar.ButtonType = ButtonType.Button;
            bfEliminar.ControlStyle.CssClass = "btn btn-info";
            bfEliminar.CommandName = "eliminar";
            gv_compras.Columns.Add(bfEliminar);

           

            gv_compras.DataSource = dados;
            gv_compras.AutoGenerateColumns = true;
            gv_compras.DataBind();
        }

        private void AtualizaDDProdutos()
        {
            Produto pd = new Produto();
            dd_produto.Items.Clear();
            DataTable dados = pd.listaProdutosDisponiveis();
            foreach (DataRow linha in dados.Rows)
                dd_produto.Items.Add(
                    new ListItem(linha["nome"].ToString(), linha["nproduto"].ToString())
                    );
        }

        private void AtualizarDDCompradores()
        {
            Comprador c = new Comprador();
            dd_comprador.Items.Clear();
            DataTable dados = c.listaTodosCompradoresDisponiveis();
            foreach (DataRow linha in dados.Rows)
                dd_comprador.Items.Add(
                    new ListItem(linha["nome"].ToString(), linha["id"].ToString())
                    );
        }

        protected void bt_registar_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Compras comp = new Models.Compras();
                int nproduto = int.Parse(dd_produto.SelectedValue);
                int ncomprador = int.Parse(dd_comprador.SelectedValue);
                DateTime data = DateTime.Parse(tb_data.Text);
                comp.adicionarCompra(nproduto, ncomprador, data);

                lb_erro.Text = "A compra foi registada com sucesso.";
                lb_erro.CssClass = "";

            }
            catch (Exception erro)
            {
                lb_erro.Text = "Ocorreu um erro:" + erro.Message;
                lb_erro.CssClass = "alert alert-danger";
            }
            AtualizarDDCompradores();
            AtualizaDDProdutos();
            AtualizarGrid();
        }

        protected void cb_produtos_comprados_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarGrid();
        }
    }
}