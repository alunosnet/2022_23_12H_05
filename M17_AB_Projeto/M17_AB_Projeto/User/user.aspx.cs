using M17_AB_Projeto.Admin.Compradores;
using M17_AB_Projeto.Classes;
using M17_AB_Projeto.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17_AB_Projeto.User
{
    public partial class user : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if (CompradorLogin.ValidarSessao(Session, Request, "1") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            if (!IsPostBack)
            {
                divEditar.Visible = false;
                MostrarPerfil();
                
            }
        }

        void MostrarPerfil()
        {
            int id = int.Parse(Session["id"].ToString());
            Comprador compradores = new Comprador();
            DataTable dados = compradores.devolveDadosCompradores(id);
            if (divPerfil.Visible == true)
            {
                lbNome.Text = dados.Rows[0]["nome"].ToString();
                lbEmail.Text = dados.Rows[0]["email"].ToString();
                lbMorada.Text = dados.Rows[0]["morada"].ToString();
                lbnif.Text = dados.Rows[0]["nif"].ToString();
            }
            else
            {
                tbNome.Text = dados.Rows[0]["nome"].ToString();
                tbEmail.Text = dados.Rows[0]["email"].ToString();
                tbMorada.Text = dados.Rows[0]["morada"].ToString();
                tbNif.Text = dados.Rows[0]["nif"].ToString();
            }
        }

        protected void btEditar_Click(object sender, EventArgs e)
        {
            divPerfil.Visible = false;
            divEditar.Visible = true;
            MostrarPerfil();
           
        }

        protected void btAtualizar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Session["id"].ToString());
            string nome = tbNome.Text;
            string email = tbEmail.Text;
            string morada = tbMorada.Text;
            string nif = tbNif.Text;

            //TODO: validar os dados
            Models.Comprador compradores = new Models.Comprador();
            compradores.nome = nome;
            compradores.morada = morada;
            compradores.nif = nif;
            compradores.id = id;
            compradores.atualizarCompradores();
            btCancelar_Click(sender, e);
        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            divPerfil.Visible = true;
            divEditar.Visible = false;
            MostrarPerfil();
        }
    }
}