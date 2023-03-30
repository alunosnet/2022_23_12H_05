using M17_AB_Projeto.Classes;
using M17_AB_Projeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17_AB_Projeto
{
    public partial class registo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bt_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                // validar os dados do form
                string nome = tb_nome.Text;
                string email = tb_email.Text;
                string morada = tb_morada.Text;
                string nif = tb_nif.Text;
                string palavra_pass = tb_password.Text;
                int perfil = 1;

                //validar o recaptcha
                var respostaRecaptcha = Request.Form["g-Recaptcha-Response"];
                var valido = ReCaptcha.Validate(respostaRecaptcha);
                if (valido == false)
                {
                    throw new Exception("Tem de provar que não é um robot");
                }

                //inserir o comprador na bd
                Comprador comprador = new Comprador();
                comprador.nif = nif;
                comprador.email = email;
                comprador.nome = nome;
                comprador.morada = morada;
                comprador.password = palavra_pass;
                comprador.perfil = perfil;
                Random rnd = new Random();
                comprador.Adicionar();
                lb_erro.Text = "Registo com sucesso";

                //redirecionar para index
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redirecionar", "returnMain('/index.aspx')", true);

            }
            catch (Exception erro)
            {
                lb_erro.Text = erro.Message;
            }
        }
    }
    
}