using M17_AB_Projeto.Classes;
using M17_AB_Projeto.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace M17_AB_Projeto.Admin
{
    /// <summary>
    /// Summary description for Servicos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Servicos : System.Web.Services.WebService
    {

        [WebMethod]
        public string ListaProdutos()
        {
            Produto produto = new Produto();
            DataTable dados = produto.ListaTodosProdutos();
            List<Produto> Produto = new List<Produto>();
            for (int i = 0; i < dados.Rows.Count; i++)
            {
                Produto novo = new Produto();
                novo.nproduto = int.Parse(dados.Rows[i]["nproduto"].ToString());
                novo.nome = dados.Rows[i]["nome"].ToString();
                novo.preco = decimal.Parse(dados.Rows[i]["preco"].ToString());
                Produto.Add(novo);
            }
            return new JavaScriptSerializer().Serialize(Produto);
        }
        public class Dados
        {
            public string perfil;
            public int contagem;
        }
        [WebMethod(EnableSession = true)]

        public List<Dados> DadosUtilizadores()
        {
            if (Session["perfil"] == null || Session["perfil"].ToString() != "0")
                return null;
            List<Dados> devolver = new List<Dados>();
            BaseDados bd = new BaseDados();
            DataTable dados = bd.devolveSQL(@"SELECT count(*), case 
                                                   when perfil=0 then 'Admin'
                                                   when perfil=1 then 'Comprador'
                                                end as [perfil]
                                                FROM compradores GROUP BY perfil");
            for (int i = 0; i < dados.Rows.Count; i++)
            {
                Dados novo = new Dados();
                novo.perfil = dados.Rows[i][1].ToString();
                novo.contagem = int.Parse(dados.Rows[i][0].ToString());
                devolver.Add(novo);
            }
            return devolver;
        }
    }

}
