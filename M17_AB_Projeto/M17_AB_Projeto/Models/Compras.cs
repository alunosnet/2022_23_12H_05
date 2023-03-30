using M17_AB_Projeto.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace M17_AB_Projeto.Models
{
    public class Compras
    {
        BaseDados bd;

        public Compras()
        {
            this.bd = new BaseDados();
        }

        public void adicionarCompra(int nproduto, int ncomprador, DateTime datacompra)
        {
            string sql = "SELECT * FROM produtos WHERE nproduto=@nproduto";
            List<SqlParameter> parametrosBloquear = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nproduto",SqlDbType=SqlDbType.Int,Value=nproduto }
            };
            //iniciar transação
            SqlTransaction transacao = bd.iniciarTransacao(IsolationLevel.Serializable);
            DataTable dados = bd.devolveSQL(sql, parametrosBloquear, transacao);

            try
            {
                //verificar disponibilidade do produto
                if (int.Parse(dados.Rows[0]["stock"].ToString())<=0)
                    throw new Exception("Produto não está disponível");
                //alterar estado do produto
                sql = "UPDATE Produtos SET stock=stock -1 WHERE nproduto=@nproduto";
                List<SqlParameter> parametrosUpdate = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName="@nproduto",SqlDbType=SqlDbType.Int,Value=nproduto },
                     
                };
                bd.executaSQL(sql, parametrosUpdate, transacao);
                //registar Compras
                sql = @"INSERT INTO Compras(nproduto,idcompradores,data_compra) 
                            VALUES (@nproduto,@idcomprador,@data_compra)";
                List<SqlParameter> parametrosInsert = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName="@nproduto",SqlDbType=SqlDbType.Int,Value=nproduto },
                    new SqlParameter() {ParameterName="@idcomprador",SqlDbType=SqlDbType.Int,Value=ncomprador },
                    new SqlParameter() {ParameterName="@data_compra",SqlDbType=SqlDbType.Date,Value=datacompra},
                };
                bd.executaSQL(sql, parametrosInsert, transacao);
                //concluir transação
                transacao.Commit();
            }
            catch
            {
                transacao.Rollback();
            }
            dados.Dispose();
        }

        public DataTable listaTodosComprasComNomes(int ncomprador)
        {
            string sql = @"SELECT ncompras,produtos.nome as nomeProduto,compradores.nome as nomeComprador,data_compra
                        FROM Compras inner join produtos on compras.nproduto=produtos.nproduto
                        inner join compradores on compras.idcompradores=compradores.id Where idcompradores=@idcomprador";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@idcomprador",SqlDbType=SqlDbType.Int,Value=ncomprador }
            };
            return bd.devolveSQL(sql, parametros);
        }

        public DataTable listaTodosComprasComNomes()
        {
            string sql = @"SELECT ncompras,produtos.nome as nomeProduto,compradores.nome as nomeComprador,data_compra
                        FROM Compras inner join produtos on compras.nproduto=produtos.nproduto
                        inner join compradores on compras.idcompradores=compradores.id";
            return bd.devolveSQL(sql);
        }

        public DataTable listaTodosComprasConcluidasComNomes()
        {
            string sql = @"SELECT ncompras,produtos.nome as nomeProduto,compradores.nome as nomeComprador,data_compra,compras.stock
                        FROM Compras inner join produtos on compras.nproduto=produtos.nproduto
                        inner join compradores on compras.idcomprador=compradores.id where compras.stock!=0";
            return bd.devolveSQL(sql);
        }

        public DataTable devolveDadosCompras(int ncompras)
        {
            string sql = "SELECT * FROM compras WHERE ncompras=@ncompra";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@ncompra",SqlDbType=SqlDbType.Int,Value=ncompras }
            };
            return bd.devolveSQL(sql, parametros);
        }

        public void removerCompra(int ncompras)
        {
            string sql = "DELETE FROM Compras WHERE ncompras=@ncompras";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@ncompras",SqlDbType=SqlDbType.Int,Value=ncompras }
            };
            bd.executaSQL(sql, parametros);
        }
    }
}