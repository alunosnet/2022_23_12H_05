using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_15_Recuperaçáo.Pontuacao
{
    public class pontuacao
    {
        public int npontuacao { get; set; }
        public int ncacador { get; set; }
        public int narma { get; set; }
        public DateTime data_pontuacao { get; set; }

        public pontuacao(int npontuacao, int ncacador, int narma, DateTime data_pontuacao)
        {
            this.npontuacao = npontuacao;
            this.ncacador = ncacador;
            this.narma = narma;
            this.data_pontuacao = data_pontuacao;
        }

        public pontuacao()
        {
        }

        public void Guardar(BaseDados bd)
        {
            string sql = @"INSERT INTO Pontuacao(ncacador,narma,data_pontuacao) VALUES 
                            (@ncacador,@narma,@data_pontuacao)";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@ncacador",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.ncacador
                },
                new SqlParameter()
                {
                    ParameterName="@data_pontuacao",
                    SqlDbType=System.Data.SqlDbType.Date,
                    Value=this.data_pontuacao.Date
                },
                new SqlParameter()
                {
                    ParameterName="@narma",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.narma
                },
                new SqlParameter()
                {
                    ParameterName="@npontuacao",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.npontuacao
                },
            };
            bd.ExecutaSQL(sql, parametros);
        }
        public static DataTable ListarTodos(BaseDados bd)
        {
            string sql = "SELECT P.npontuacao, C.nome, P.ncacador, P.narma, P.data_pontuacao FROM Pontuacao P inner join Cacadores C ON P.ncacador = C.ncacador ";
            return bd.DevolveSQL(sql);
        }
        public void Atualizar(BaseDados bd)
        {
            string sql = @"UPDATE Pontuacao SET ncacador=@ncacador,narma=@narma,data_pontuacao=@data_pontuacao
                                WHERE npontuacao=@npontuacao";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@ncacador",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.ncacador
                },
                new SqlParameter()
                {
                    ParameterName="@data_pontuacao",
                    SqlDbType=System.Data.SqlDbType.Date,
                    Value=this.data_pontuacao.Date
                },

                new SqlParameter()
                {
                    ParameterName="@narma",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.narma
                },
                new SqlParameter()
                {
                    ParameterName="@npontuacao",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.npontuacao
                }
            };
            bd.ExecutaSQL(sql, parametros);
        }
        public static DataTable ListarTodos(BaseDados bd, int primeiroregisto, int ultimoregisto)
        {
            string sql = $@"SELECT ncacador,narma,data_pontuacao,npontuacao FROM
                        (SELECT row_number() over (order by ncacador) as Num,* FROM Pontuacao) as T
                        WHERE Num>={primeiroregisto} AND Num<={ultimoregisto}";
            return bd.DevolveSQL(sql);
        }

        public int devolveIDCacador (BaseDados bd, string cacador)
        {
            string sql = "SELECT ncacador FROM cacadores WHERE nome='" + cacador + "'";
            DataTable data = bd.DevolveSQL(sql);

            return int.Parse(data.Rows[0][0].ToString());
        }

        public int devolveIDArma(BaseDados bd, string arma)
        {
            string sql = "SELECT narma FROM Armas WHERE nome_arma = '" + arma + "'";

            DataTable data = bd.DevolveSQL(sql);

            return int.Parse(data.Rows[0][0].ToString());
        }

        public DataTable Procurar(int npontuacao, BaseDados bd)
        {
            string sql = "SELECT * FROM pontuacao WHERE npontuacao=" + npontuacao;
            DataTable temp = bd.DevolveSQL(sql);

            if (temp != null && temp.Rows.Count > 0)
            {
                this.npontuacao = int.Parse(temp.Rows[0]["npontuacao"].ToString());
                this.ncacador = int.Parse(temp.Rows[0]["ncacador"].ToString());
                this.narma = int.Parse(temp.Rows[0]["narma"].ToString());
                this.data_pontuacao = DateTime.Parse(temp.Rows[0]["data_pontuacao"].ToString());
            }

            return temp;

        }

        public static void ApagarPontuacao(int npontuacao_escolhido, BaseDados bd)
        {
            string sql = "DELETE FROM pontuacao WHERE npontuacao=" + npontuacao_escolhido ;
            bd.ExecutaSQL(sql);
        }

        public static void ApagarArma(int narma_escolhido, BaseDados bd)
        {
            
            string sql = "DELETE FROM pontuacao WHERE narma=" + narma_escolhido;
            bd.ExecutaSQL(sql);
            
        }
    }
}
