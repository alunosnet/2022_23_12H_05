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

namespace M17_AB_Projeto.Admin.Compradores
{
    public partial class EditarCompradores : System.Web.UI.Page
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
                //querystring ncomprador
                int ncomprador = int.Parse(Request["ncomprador"].ToString());

                Comprador lv = new Comprador();
                DataTable dados = lv.devolveDadosCompradores(ncomprador);
                if (dados == null || dados.Rows.Count == 0)
                {
                    //o ncomprador não existe na tabela dos compradores
                    throw new Exception("O comprador não existe.");
                }

                //mostrar os dados comprador
                tbNome.Text = dados.Rows[0]["nome"].ToString();
                tbEmail.Text = dados.Rows[0]["email"].ToString();
                tbMorada.Text = dados.Rows[0]["morada"].ToString();
                tbNif.Text = dados.Rows[0]["nif"].ToString();
                tbPassword.Text = dados.Rows[0]["password"].ToString();
                Random rnd = new Random();
                //imgCapa.ImageUrl = @"~\Public\Imagens\" + nproduto + ".jpg?" + rnd.Next(9999);
                //imgCapa.Width = 300;
            }
            catch
            {
                Response.Redirect("~/Admin/Compradores/Compradores.aspx");
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

                string email = tbEmail.Text;
                if (email.Contains("@") == false || email.Contains(".") == false)
                {
                    throw new Exception("O email tem de conter @ e .");
                }

                string morada = tbMorada.Text;
                if (morada.Trim().Length < 5)
                {
                    throw new Exception("A morada tem de ter mais que 5 palavras");
                }

                string nif = tbNif.Text;
                if (nif.Trim().Length != 9)
                {
                    throw new Exception("O nif deve conter 9 números");
                }

                string password = tbPassword.Text;
                if (!Regex.IsMatch(password, @"[0-9]+"))
                {
                    throw new Exception("A senha deve conter pelo menos um número.");
                }

                Comprador compradores = new Comprador();
                compradores.nome = nome;
                compradores.email = email;
                compradores.morada = morada;
                compradores.nif = nif;
                compradores.password = password;
                compradores.id = int.Parse(Request["ncomprador"].ToString());
                compradores.atualizarCompradores();
                
            }
            catch (Exception ex)
            {
                lbErro.Text = "Ocorreu o seguinte erro: " + ex.Message;
                return;
            }

            
        }
    }
}