using M17_AB_Projeto.Classes;
using M17_AB_Projeto.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace M17_AB_Projeto
{
    public partial class detalhesproduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request["id"].ToString());
                Produto p = new Produto();
                p.nproduto = id;
                DataTable dados = p.devolveDadosProdutos(p.nproduto);
                lb_avaliacao.Text = dados.Rows[0]["avaliacao"].ToString();
                lb_comentario.Text = dados.Rows[0]["comentario"].ToString();
            }
            catch
            {
                Response.Redirect("index.aspx");
            }
        }

        protected void btAvaliar_Click(object sender, EventArgs e)
        {
            int avaliacao = Convert.ToInt32(ddavaliacao.SelectedValue);
            BaseDados bd =new BaseDados();
            int id = int.Parse(Request["id"].ToString());
            int avalia=int.Parse(ddavaliacao.SelectedValue.ToString());
            bd.executaSQL($"update Produtos set Avaliacao=(avaliacao+{avalia})/2 where nproduto={id}");

        }

        protected void btComentar_Click(object sender, EventArgs e)
        {
            BaseDados bd = new BaseDados();
            int id = int.Parse(Request["id"].ToString());
            string comenta = tb_comentario.Text;
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@comenta",comenta));
            bd.executaSQL($"update Produtos set Comentario=@comenta where nproduto={id}",paramList);
        }

        protected void btVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/index.aspx");
        }
    }
}