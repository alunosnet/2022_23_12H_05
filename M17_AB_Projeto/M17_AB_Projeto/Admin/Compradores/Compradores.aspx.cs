using M17_AB_Projeto.Classes;
using M17_AB_Projeto.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace M17_AB_Projeto.Admin.Compradores
{
    public partial class Compradores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if (CompradorLogin.ValidarSessao(Session, Request, "0") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            AtualizaGrid();
        }

        protected void bt_guardar_Click(object sender, EventArgs e)
        {
            //validar o form
            string nome = tb_nome.Text;
            string email = tb_email.Text;
            string morada = tb_morada.Text;
            string nif = tb_nif.Text;
            string password = tb_password.Text;
            int perfil = int.Parse(dd_perfil.SelectedValue);
            Random rnd = new Random();
            int sal = rnd.Next(1000);

            Comprador compradores = new Comprador();
            compradores.nome = nome;
            compradores.email = email;
            compradores.morada = morada;
            compradores.nif = nif;
            compradores.password = password;
            compradores.perfil = perfil;

            compradores.Adicionar();

            //limpar o form
            tb_email.Text = "";
            tb_morada.Text = "";
            tb_nif.Text = "";
            tb_nome.Text = "";

            //Atualizar grid()
            AtualizaGrid();
        }

        private void AtualizaGrid()
        {
            gvCompradores.Columns.Clear();
            Comprador comp = new Comprador();
            DataTable dados = comp.ListaTodosCompradores();
            
            DataColumn dcEditar = new DataColumn();
            dcEditar.ColumnName = "Editar";
            dcEditar.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcEditar); DataColumn dcApagar = new DataColumn();
            dcApagar.ColumnName = "Apagar";
            dcApagar.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcApagar);             //colunas da gridview
            gvCompradores.DataSource = dados;
            gvCompradores.AutoGenerateColumns = false;       
            //Editar
            HyperLinkField hlEditar = new HyperLinkField();
            hlEditar.HeaderText = "Editar";
            hlEditar.DataTextField = "Editar";
            hlEditar.Text = "Editar...";
            hlEditar.DataNavigateUrlFormatString = "EditarCompradores.aspx?ncomprador={0}";
            hlEditar.DataNavigateUrlFields = new string[] { "id" };
            gvCompradores.Columns.Add(hlEditar);

            //Apagar
            HyperLinkField hlApagar = new HyperLinkField();
            hlApagar.HeaderText = "Apagar";
            hlApagar.DataTextField = "Apagar";
            hlApagar.Text = "Apagar...";
            hlApagar.DataNavigateUrlFormatString = "ApagarCompradores.aspx?ncomprador={0}";
            hlApagar.DataNavigateUrlFields = new string[] { "id" };
            gvCompradores.Columns.Add(hlApagar);

            //ncomprador
            BoundField bfncomprador = new BoundField();
            bfncomprador.HeaderText = "ncomprador";
            bfncomprador.DataField = "id";
            gvCompradores.Columns.Add(bfncomprador);

            //nome
            BoundField bfnome = new BoundField();
            bfnome.HeaderText = "Nome";
            bfnome.DataField = "nome";
            gvCompradores.Columns.Add(bfnome);

            //Email
            BoundField bfemail = new BoundField();
            bfemail.HeaderText = "Email";
            bfemail.DataField = "email";
            gvCompradores.Columns.Add(bfemail);

            //Morada
            BoundField bfmorada = new BoundField();
            bfmorada.HeaderText = "Morada";
            bfmorada.DataField = "Morada";
            gvCompradores.Columns.Add(bfmorada);

            //nif
            BoundField bfnif = new BoundField();
            bfnif.HeaderText = "Nif";
            bfnif.DataField = "nif";
            gvCompradores.Columns.Add(bfnif);

            gvCompradores.DataBind();
        }
    }
}