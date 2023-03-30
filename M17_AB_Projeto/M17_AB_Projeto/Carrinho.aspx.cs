using M17_AB_Projeto.Classes;
using M17_AB_Projeto.User.Compras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17_AB_Projeto
{
    public partial class Carrinho : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CompradorLogin.ValidarSessao(Session, Request, "1") == false)
                Response.Redirect("~/index.aspx");

            //id
            //adicionar ao carrinho

            AtualizarGrid();
        }

        private void AtualizarGrid()
        {

        }
    }
}