using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_15_Recuperaçáo.Cacadores
{
    public class cacador 
    {
        public int Ncacador { get; set; }
        public string Nome { get; set; }
        public DateTime Data_nasc { get; set; }
        public cacador(int ncacador, string nome, DateTime data_nasc,  string fotografia) 
        {
            Ncacador = ncacador;
            Nome = nome;
            Data_nasc = data_nasc;
        }

        public cacador()
        {
        }

        public void Guardar(BaseDados bd)
        {
            string sql = @"INSERT INTO Cacadores(nome,data_nasc) VALUES 
                            (@nome,@data_nasc)";
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
                    ParameterName="@data_nasc",
                    SqlDbType=System.Data.SqlDbType.Date,
                    Value=this.Data_nasc.Date
                },
              
            };
            bd.ExecutaSQL(sql, parametros);
        }
        public static DataTable ListarTodos(BaseDados bd)
        {
            string sql = "SELECT * FROM Cacadores";
            return bd.DevolveSQL(sql);
        }
        public DataTable Procurar(int ncacador, BaseDados bd)
        {
            string sql = "SELECT * FROM Cacadores WHERE ncacador=" + ncacador;
            DataTable dados = bd.DevolveSQL(sql);

            if (dados != null && dados.Rows.Count > 0)
            {
                this.Ncacador = int.Parse(dados.Rows[0]["ncacador"].ToString());
                this.Nome = dados.Rows[0]["nome"].ToString();
                this.Data_nasc = DateTime.Parse(dados.Rows[0]["data_nasc"].ToString());
                /*this.Fotografia = dados.Rows[0]["foto"].ToString();*/
            }

            return dados;
        }
        public static void ApagarCacador(int ncacador, BaseDados bd)
        {
            string sql = "DELETE FROM Cacadores WHERE ncacador=" + ncacador;
            bd.ExecutaSQL(sql);
        }
        public void Atualizar(BaseDados bd)
        {
            string sql = @"UPDATE Cacadores SET nome=@nome,data_nasc=@data_nasc
                                WHERE ncacador=@ncacador";
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
                    ParameterName="@data_nasc",
                    SqlDbType=System.Data.SqlDbType.Date,
                    Value=this.Data_nasc.Date
                },
                
                new SqlParameter()
                {
                    ParameterName="@ncacador",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.Ncacador
                }
            };
            bd.ExecutaSQL(sql, parametros);
        }
        public static DataTable PesquisaPorNome(BaseDados bd, string nome)
        {
            string sql = @"SELECT * FROM Cacadores WHERE nome LIKE @nome";
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
            string sql = "SELECT count(*) as NrRegistos from Cacadores";
            DataTable dados = bd.DevolveSQL(sql);
            int nr = int.Parse(dados.Rows[0][0].ToString());
            dados.Dispose();
            return nr;
        }
        public static DataTable ListarTodos(BaseDados bd, int primeiroregisto, int ultimoregisto)
        {
            string sql = $@"SELECT ncacador,nome,data_nasc FROM
                        (SELECT row_number() over (order by ncacador) as Num,* FROM Cacadores) as T
                        WHERE Num>={primeiroregisto} AND Num<={ultimoregisto}";
            return bd.DevolveSQL(sql);
        }
        public override string ToString()
        {
            return this.Nome;
        }
        public static DataTable ListarDisponiveis(BaseDados bd)
        {
            string sql = "SELECT * FROM Cacadores where estado = 1";
            return bd.DevolveSQL(sql);
        }
    }
}
