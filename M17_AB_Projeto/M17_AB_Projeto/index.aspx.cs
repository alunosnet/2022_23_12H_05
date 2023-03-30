using M17_AB_Projeto.Classes;
using M17_AB_Projeto.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17_AB_Projeto
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["perfil"] != null)
                divLogin.Visible = false;

            //ordenar os produtos?
            int? ordenar = 0;
            try
            {
                ordenar = int.Parse(Request["ordena"].ToString());
            }
            catch
            {
                ordenar = null;
            }
            //atualizar grelha produtos
            atualizaListaProdutos(null, ordenar);
        }

        private void atualizaListaProdutos(string pesquisa = null, int? ordena = null)
        {
            Produto produto = new Produto();
            DataTable dados = null;
            if (pesquisa == null)
            {
                if(Request["tipo"]==null)
                { 
                 //se existir o cookie ultimo produto listar os produtos do mesmo comprador
                    HttpCookie httpCookie = Request.Cookies["ultimoproduto"];
                    if (httpCookie == null)
                        dados = produto.listaProdutosDisponiveis(ordena);
                }
                else
                {
                    pesquisa = Request["tipo"].ToString();
                    dados = produto.listaProdutosDisponiveisTipo(pesquisa,ordena);
                }
            }
            else
            {
                dados = produto.listaProdutosDisponiveis(pesquisa, ordena);
            }
            gerarIndex(dados);
        }

        private void gerarIndex(DataTable dados)
        {
            if (dados == null || dados.Rows.Count == 0)
            {
                divProdutos.InnerHtml = "";
                return;
            }
            string grelha = "<div class='container-fluid'>";
            grelha += "<div class='row'>";
            foreach (DataRow produtos in dados.Rows)
            {
                grelha += "<div class='col'>";
                grelha += "<img src='/Public/Imagens/" + produtos[0].ToString() +
                    ".jpg' class='img-fluid'/>";
                grelha += "<p/><span class='stat-title'>" + produtos[1].ToString()
                    + "</span>";
                grelha += "<span class='stat-title'>" +
                    String.Format(" | {0:C}", Decimal.Parse(produtos["preco"].ToString()))
                    + "</span>";
                grelha += "<br/><a href='detalhesproduto.aspx?id=" + produtos[0].ToString()
                    + "'>Detalhes</a>";
                if (Session["perfil"]!=null)
                    grelha += "<br/><a href='Carrinho.aspx?id=" + produtos[0].ToString()
                        + "'>Adicionar ao carrinho</a>";
                
                grelha += "</div>";

            }
            grelha += "</div></div>";
            divProdutos.InnerHtml = grelha;
        }

        protected void bt_login_Click(object sender, EventArgs e)
        {
            try
            {
                string email = tbEmail.Text;
                string password = tbPassword.Text;
                CompradorLogin comprador = new CompradorLogin();
                DataTable dados = comprador.VerificaLogin(email, password);
                if (dados == null)
                    throw new Exception("Login falhou");
                //iniciar sessão
                Session["nome"] = dados.Rows[0]["nome"].ToString();
                Session["id"] = dados.Rows[0]["id"].ToString();
                //autorização
                Session["perfil"] = dados.Rows[0]["perfil"].ToString();
                Session["ip"] = Request.UserHostAddress;
                Session["useragent"] = Request.UserAgent;
                //Redirecionar
                if (Session["perfil"].ToString() == "0")
                    Response.Redirect("~/index.aspx");
                if (Session["perfil"].ToString() == "1")
                    Response.Redirect("~/User/User.aspx");
            }
            catch
            {
                lb_erro.Text = "Login falhou.Tente novamente";
            }
        }

        protected void bt_recuperar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbEmail.Text.Trim().Length == 0)
                {
                    throw new Exception("Indique um email");
                }
                string email = tbEmail.Text.Trim();
                Comprador comprador = new Comprador();
                DataTable dados = comprador.devolveDadosCompradores(email);
                if (dados == null || dados.Rows.Count != 1)
                {
                    throw new Exception("Foi enviado um email para recuperação da palavra passe");
                }
                Guid guid = Guid.NewGuid();
                comprador.recuperarPassword(email, guid.ToString());

                string mensagem = "Clique no link para recuperar a sua password.<br/>";
                mensagem += "<a href='http://" + Request.Url.Authority + "/recuperarpassword.aspx?";
                mensagem += "id=" + Server.UrlEncode(guid.ToString()) + "'>Clique aqui<a/>";

                string meuemail = ConfigurationManager.AppSettings["MeuEmail"];
                string minhapassword = ConfigurationManager.AppSettings["MinhaPassword"];
                Helper.enviarMail(meuemail, minhapassword, email, "Recuperação de password", mensagem);

                lb_erro.Text = "Foi enviado um eamil para recuperação da palavra passe";
            }
            catch (Exception ex)
            {
                lb_erro.Text = ex.Message;
            }
        }

        protected void btPesquisar_Click(object sender, EventArgs e)
        {
            atualizaListaProdutos(tbPesquisa.Text);
        }
    }
}