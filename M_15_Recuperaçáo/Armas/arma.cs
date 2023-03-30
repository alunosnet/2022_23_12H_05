using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_15_Recuperaçáo.Armas
{
    public class arma
    {
        public int Narma { get; set; }
        public string Nome { get; set; }
        public DateTime Data_Aquisicao { get; set; }
        public decimal Preco { get; set; }

        public arma(int narma, string nome, DateTime data_aquisicao, decimal preco)
        {
            Narma = narma;
            Nome = nome;
            Data_Aquisicao = data_aquisicao;
            Preco = preco;
        }
        public arma()
        {
        }

        
        public void Guardar(BaseDados bd)
        {
            string sql = @"INSERT INTO armas(nome_arma,data_aquisicao,preco) VALUES 
                            (@nome_arma,@data_aquisicao,@preco)";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@nome_arma",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Nome
                },
                new SqlParameter()
                {
                    ParameterName="@data_aquisicao",
                    SqlDbType=System.Data.SqlDbType.Date,
                    Value=this.Data_Aquisicao.Date
                },
                new SqlParameter()
                {
                    ParameterName="@preco",
                    SqlDbType=System.Data.SqlDbType.Decimal,
                    Value=this.Preco
                },
                /*new SqlParameter()
                {
                    ParameterName="@narma",
                    SqlDbType=System.Data.SqlDbType.Decimal,
                    Value=this.Narma
                },*/
            };
            bd.ExecutaSQL(sql, parametros);
        }
        public static DataTable ListarTodos(BaseDados bd)
        {
            string sql = "SELECT * FROM armas";
            return bd.DevolveSQL(sql);
        }
        public DataTable Procurar(int narma, BaseDados bd)
        {
            string sql = "SELECT * FROM Armas WHERE narma=" + narma;
            DataTable temp = bd.DevolveSQL(sql);

            if (temp != null && temp.Rows.Count > 0)
            {
                this.Narma = int.Parse(temp.Rows[0]["narma"].ToString());
                this.Nome = temp.Rows[0]["nome_arma"].ToString();
                this.Data_Aquisicao = DateTime.Parse(temp.Rows[0]["data_aquisicao"].ToString());
                this.Preco = decimal.Parse(temp.Rows[0]["preco"].ToString());
            }

            return temp;
        }
        public static void ApagarArma(int narma, BaseDados bd)
        {
            string sql = "DELETE FROM armas WHERE narma=" + narma;
            bd.ExecutaSQL(sql);
        }
        public void Atualizar(BaseDados bd)
        {
           string sql = @"UPDATE Armas SET nome_arma=@nome,data_aquisicao=@data_aquisicao
                                WHERE narma=@narma";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@nome",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Nome
                },
                new SqlParameter()
                {
                    ParameterName="@data_aquisicao",
                    SqlDbType=System.Data.SqlDbType.Date,
                    Value=this.Data_Aquisicao.Date
                },
                new SqlParameter()
                {
                    ParameterName="@preco",
                    SqlDbType=System.Data.SqlDbType.Decimal,
                    Value=this.Preco
                },
                new SqlParameter()
                {
                    ParameterName="@narma",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.Narma
                }
            };
            bd.ExecutaSQL(sql, parametros);
        }
        public static DataTable PesquisaPorNome(BaseDados bd, string nome)
        {
            string sql = @"SELECT * FROM armas WHERE nome_arma LIKE @nome";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@nome",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value="%"+nome+"%"
                },
            };
            return bd.DevolveSQL(sql, parametros);
        }
        public static int NrRegistos(BaseDados bd)
        {
            string sql = "SELECT count(*) as NrRegistos from Armas";
            DataTable dados = bd.DevolveSQL(sql);
            int nr = int.Parse(dados.Rows[0][0].ToString());
            dados.Dispose();
            return nr;
        }
        public static DataTable ListarTodos(BaseDados bd, int primeiroregisto, int ultimoregisto)
        {
            string sql = $@"SELECT narma,nome,data_aquisicao FROM
                        (SELECT row_number() over (order by narma) as Num,* FROM Armas) as T
                        WHERE Num>={primeiroregisto} AND Num<={ultimoregisto}";
            return bd.DevolveSQL(sql);
        }
        public override string ToString()
        {
            return this.Nome;
        }
        public static DataTable ListarDisponiveis(BaseDados bd)
        {
            string sql = "SELECT * FROM Armas where estado = 1";
            return bd.DevolveSQL(sql);
        }

        internal void Procurar(BaseDados bd, int narma)
        {
            throw new NotImplementedException();
        }
    }
}
