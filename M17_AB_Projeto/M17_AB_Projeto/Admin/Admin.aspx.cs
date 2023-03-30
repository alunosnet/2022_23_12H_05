using M17_AB_Projeto.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17_AB_Projeto.Admin
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if (CompradorLogin.ValidarSessao(Session, Request, "0") == false)
               Response.Redirect("~/index.aspx");

            AtualizaGrelhaConsulta();
        }

        protected void ddConsultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizaGrelhaConsulta();
        }

        private void AtualizaGrelhaConsulta()
        {
            gvConsultas.Columns.Clear();
            int iconsulta = int.Parse(ddConsultas.SelectedValue);
            DataTable dados;
            string sql = "";
            switch (iconsulta)
            {
                //Top de Produtos mais vendidos
                case 0:
                    sql = @"SELECT Nome,count(Compras.nproduto) as [Nº de compras] FROM Produtos 
                            INNER JOIN Compras ON Produtos.nproduto=Compras.nproduto 
                            GROUP BY Produtos.nproduto,Produtos.Nome
                            ORDER BY count(Compras.nproduto) DESC";
                    break;
                //Top de Compradores
                case 1:
                    sql = @"SELECT Nome,count(idcompradores) as [Nº de compras] FROM Compradores
                            INNER JOIN Compras ON Compradores.id=Compras.idcompradores
                            GROUP BY Compradores.id,Compradores.Nome
                            ORDER BY count(idcompradores) DESC";
                    break;
                //Top de produtos mais vendidos do último mês
                case 2:
                    sql = @"SELECT TOP 3 nome AS [Produtos], COUNT(compras.nproduto) AS [Nº de Compras] 
                            FROM Produtos, compras
                            WHERE Produtos.nproduto = compras.nproduto 
                                AND DATEDIFF(DAY, compras.data_compra, GETDATE()) < 30
                            GROUP BY Produtos.nproduto,Produtos.nome
                            ORDER BY COUNT(compras.nproduto) DESC";
                    break;
            }

            BaseDados bd = new BaseDados();
            dados = bd.devolveSQL(sql);
            gvConsultas.DataSource = dados;
            gvConsultas.DataBind();
        }

        protected void btVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/index.aspx");
        }
    }
}