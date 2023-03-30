using M17_AB_Projeto.Classes;
using M17_AB_Projeto.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17_AB_Projeto.Admin.Compras
{
    public partial class ApagarCompras : System.Web.UI.Page
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
                //querystring ncompra
                int ncompra = int.Parse(Request["id"].ToString());

                Models.Compras cp = new Models.Compras();
                DataTable dados = cp.devolveDadosCompras(ncompra);
                if (dados == null || dados.Rows.Count == 0)
                {
                    //o ncompra não existe na tabela dos produtos
                    throw new Exception("A compra não existe.");
                }
                //mostrar os dados compra
                lbNcompra.Text = dados.Rows[0]["ncompras"].ToString();
                lbNome.Text = dados.Rows[0]["nproduto"].ToString();
            }
            catch
            {
                Response.Redirect("~/Admin/Compras/Compras.aspx");
            }
        }

        protected void btRemover_Click(object sender, EventArgs e)
        {
            try
            {
                int ncompra = int.Parse(Request["id"].ToString());
                Models.Compras cp = new Models.Compras();
                cp.removerCompra(ncompra);

                lbErro.Text = "A compra foi removida com sucesso";
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redirecionar", "returnMain('Compras.aspx')", true);
            }
            catch
            {
                Response.Redirect("~/Admin/Compras/Compras.aspx");

            }
        }

        protected void btVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Compras/Compras.aspx");
        }
    }
}