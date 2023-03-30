using M17_AB_Projeto.Admin.Compras;
using M17_AB_Projeto.Classes;
using M17_AB_Projeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17_AB_Projeto.User.Compras
{
    public partial class historico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CompradorLogin.ValidarSessao(Session, Request, "1") == false)
                Response.Redirect("~/index.aspx");
            AtualizarGrid();
        }

        private void AtualizarGrid()
        {
            gvhistorico.Columns.Clear();
            gvhistorico.DataSource = null;
            gvhistorico.DataBind();

            int idcompradores = int.Parse(Session["id"].ToString());
            Models.Compras comp = new Models.Compras();
            gvhistorico.DataSource = comp.listaTodosComprasComNomes(idcompradores);
            gvhistorico.DataBind();
        }
    }
}