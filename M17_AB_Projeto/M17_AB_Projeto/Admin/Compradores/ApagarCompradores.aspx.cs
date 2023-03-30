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

namespace M17_AB_Projeto.Admin.Compradores
{
    public partial class ApagarCompradores : System.Web.UI.Page
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
                //querystring nComprador
                int id = int.Parse(Request["ncomprador"].ToString());

                Comprador comp = new Comprador();
                DataTable dados = comp.devolveDadosCompradores(id);
                if (dados == null || dados.Rows.Count == 0)
                {
                    //o ncomprador não existe na tabela dos compradores
                    throw new Exception("Comprador não existe.");
                }
                //mostrar os dados comprador
                lbNComprador.Text = dados.Rows[0]["id"].ToString();
                lbNome.Text = dados.Rows[0]["nome"].ToString();
                imgCapa.ImageUrl = @"~\Public\Imagens\" + id + ".jpg";
                imgCapa.Width = 300;
            }
            catch
            {
                Response.Redirect("~/Admin/Compradores/Compradores.aspx");
            }
        }

        protected void btVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Compradores/Compradores.aspx");
        }

        protected void btRemover_Click(object sender, EventArgs e)
        {
            try
            {
                int ncompradores = int.Parse(Request["ncomprador"].ToString());
                Comprador comp = new Comprador();
                comp.removerCompradores(ncompradores);

                //apagar a capa
                string ficheiro = Server.MapPath(@"~\Public\Imagens\") + ncompradores + ".jpg";
                if (File.Exists(ficheiro))
                    File.Delete(ficheiro);
                //Response.Redirect("~/Admin/Compradores/Compradores.aspx");
                lbErro.Text = "O comprador foi removido com sucesso";
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redirecionar", "returnMain('Compradores.aspx')", true);
            }
            catch
            {
                Response.Redirect("~/Admin/Compradores/Compradores.aspx");

            }
        }

    }
}