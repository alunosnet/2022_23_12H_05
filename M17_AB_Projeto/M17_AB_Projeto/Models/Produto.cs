using M17_AB_Projeto.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace M17_AB_Projeto.Models
{
    public class Produto
    {
        public int nproduto;
        public string nome;
        public decimal preco;
        public string referencia;
        public string tipo;
        public int stock;

        BaseDados bd;

        public Produto()
        {
            bd = new BaseDados();
        }

        public int Adicionar()
        {
            string sql = @"INSERT INTO Produtos(nome,referencia,preco,tipo,stock)
                    VALUES (@nome,@referencia,@preco,@tipo,@stock);
                    SELECT CAST(SCOPE_IDENTITY() AS INT)";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@nome",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.nome
                },
                new SqlParameter()
                {
                    ParameterName="@referencia",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.referencia
                },
                new SqlParameter()
                {
                    ParameterName="@preco",
                    SqlDbType=System.Data.SqlDbType.Decimal,
                    Value=this.preco
                },
                new SqlParameter()
                {
                    ParameterName="@tipo",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.tipo
                },
                new SqlParameter()
                {
                    ParameterName="@stock",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.stock
                },
            };
            return bd.executaEDevolveSQL(sql, parametros);
        }

        internal DataTable ListaTodosProdutos()
        {
            string sql = @"SELECT nproduto,nome,
                    preco, tipo, referencia, stock,
                    case
                        when stock=0 then 'Vendido'
                        when stock=1 then 'Disponível'
                        when stock=2 then 'Fora de stock'
                    end as estado
                    FROM Produtos";
            return bd.devolveSQL(sql);
        }

        public DataTable devolveDadosProdutos(int nproduto)
        {
            string sql = "SELECT * FROM Produtos WHERE nproduto=@nproduto";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nproduto",SqlDbType=SqlDbType.Int,Value=nproduto }
            };
            return bd.devolveSQL(sql, parametros);
        }

        public void removerProduto(int nproduto)
        {
            string sql = "DELETE FROM Produtos WHERE nproduto=@nproduto";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nproduto",SqlDbType=SqlDbType.Int,Value=nproduto }
            };
            bd.executaSQL(sql, parametros);
        }

        public void atualizaProduto()
        {
            string sql = "UPDATE Produtos SET nome=@nome,referencia=@referencia,preco=@preco,stock=@stock,";
            sql += "tipo=@tipo ";
            sql += " WHERE nproduto=@nproduto;";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nome",SqlDbType=SqlDbType.VarChar,Value = nome},
                new SqlParameter() {ParameterName="@referencia",SqlDbType=SqlDbType.VarChar,Value = referencia},
                new SqlParameter() {ParameterName="@preco",SqlDbType=SqlDbType.Decimal,Value = preco},
                new SqlParameter() {ParameterName="@tipo",SqlDbType=SqlDbType.VarChar,Value = tipo},
                new SqlParameter() {ParameterName="@stock",SqlDbType=System.Data.SqlDbType.Int, Value = stock},
                new SqlParameter() {ParameterName="@nproduto",SqlDbType=SqlDbType.Int,Value = nproduto}
            };
            bd.executaSQL(sql, parametros);
        }

        public DataTable listaProdutosDisponiveis(int? ordena = null)
        {
            string sql = "SELECT * FROM Produtos WHERE stock=1";
            if (ordena != null && ordena == 1)
            {
                sql += " order by preco";
            }
            if (ordena != null && ordena == 2)
            {
                sql += " order by tipo";
            }
            return bd.devolveSQL(sql);
        }

        internal DataTable listaProdutosDisponiveis(string pesquisa, int? ordena = null)
        {
            string sql = "SELECT * FROM Produtos WHERE stock=1 and nome like @nome";
            if (ordena != null && ordena == 1)
            {
                sql += " order by preco";
            }
            if (ordena != null && ordena == 2)
            {
                sql += " order by tipo";
            }

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {
                    ParameterName ="@nome",
                    SqlDbType =SqlDbType.VarChar,
                    Value = "%"+pesquisa+"%"},
            };
            return bd.devolveSQL(sql, parametros);
        }
        internal DataTable listaProdutosDisponiveisTipo(string pesquisa, int? ordena = null)
        {
            string sql = "SELECT * FROM Produtos WHERE stock=1 and tipo like @nome";
            if (ordena != null && ordena == 1)
            {
                sql += " order by preco";
            }
            if (ordena != null && ordena == 2)
            {
                sql += " order by tipo";
            }

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {
                    ParameterName ="@nome",
                    SqlDbType =SqlDbType.VarChar,
                    Value = "%"+pesquisa+"%"},
            };
            return bd.devolveSQL(sql, parametros);
        }
    }
}