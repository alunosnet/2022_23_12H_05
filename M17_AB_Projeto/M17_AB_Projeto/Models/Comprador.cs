using M17_AB_Projeto.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace M17_AB_Projeto.Models
{
    public class Comprador
    {
        public int id;
        public string nome;
        public string email;
        public string morada;
        public string nif;
        public string password;
        public int perfil;

        BaseDados bd;

        public Comprador()
        {
            bd = new BaseDados();
        }

        public void Adicionar()
        {
            string sql = @"INSERT INTO Compradores(email,nome,morada,nif,password,estado,perfil)
                            VALUES (@email,@nome,@morada,@nif,HASHBYTES('SHA2_512',@password),@estado,@perfil)";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@email",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.email
                },
                new SqlParameter()
                {
                    ParameterName="@nome",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.nome
                },
                new SqlParameter()
                {
                    ParameterName="@morada",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.morada
                },
                new SqlParameter()
                {
                    ParameterName="@nif",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.nif
                },
                new SqlParameter()
                {
                    ParameterName="@password",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.password
                },
                new SqlParameter()
                {
                    ParameterName="@estado",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=1
                },
                new SqlParameter()
                {
                    ParameterName="@perfil",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.perfil
                },
            };
            bd.executaSQL(sql, parametros);
        }
        internal DataTable ListaTodosCompradores()
        {
            return bd.devolveSQL("SELECT * FROM Compradores");
        }
        public DataTable listaTodosCompradoresDisponiveis()
        {
            string sql = $@"SELECT id, email,nome, morada, nif,  estado, perfil 
            FROM Compradores where estado=1";
            return bd.devolveSQL(sql);
        }
        public void atualizarCompradores()
        {
            string sql = @"UPDATE Compradores SET nome=@nome,morada=@morada,nif=@nif 
                            WHERE id=@id";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nome",SqlDbType=SqlDbType.VarChar,Value=nome },
                new SqlParameter() {ParameterName="@morada",SqlDbType=SqlDbType.VarChar,Value=morada },
                new SqlParameter() {ParameterName="@nif",SqlDbType=SqlDbType.VarChar,Value=nif },
                new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value=id },
            };
            bd.executaSQL(sql, parametros);
        }
        public DataTable devolveDadosCompradores(int id)
        {
            string sql = "SELECT * FROM Compradores WHERE id=@id";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value=id }
            };
            DataTable dados = bd.devolveSQL(sql, parametros);
            if (dados.Rows.Count == 0)
            {
                return null;
            }
            return dados;
        }
        public int estadoCompradores(int id)
        {
            string sql = "SELECT estado FROM Compradores WHERE id=@id";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value=id }
            };
            DataTable dados = bd.devolveSQL(sql, parametros);
            return int.Parse(dados.Rows[0][0].ToString());
        }
        public void ativarDesativarCompradores(int id)
        {
            int estado = this.estadoCompradores(id);
            if (estado == 0) estado = 1;
            else estado = 0;
            string sql = "UPDATE compradores SET estado = @estado WHERE id=@id";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@estado",SqlDbType=SqlDbType.Bit,Value=estado },
                new SqlParameter() {ParameterName="@ncomprador",SqlDbType=SqlDbType.Int,Value = id }
            };
            bd.executaSQL(sql, parametros);
        }
        public void removerCompradores(int id)
        {
            string sql = "DELETE FROM Compradores WHERE id=@id";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value= id},
            };
            bd.executaSQL(sql, parametros);
        }
        public void recuperarPassword(string email, string guid)
        {
            string sql = "UPDATE Compradores set lnkRecuperar=@lnk WHERE email=@email";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@email",SqlDbType=SqlDbType.VarChar,Value=email },
                new SqlParameter() {ParameterName="@lnk",SqlDbType=SqlDbType.VarChar,Value=guid },
            };
            bd.executaSQL(sql, parametros);
        }
        public void atualizarPassword(string guid, string password)
        {
            string sql = "UPDATE Compradores set password=HASHBYTES('SHA2_512',contact(@password)),estado=1,lnkRecuperar=null WHERE lnkRecuperar=@lnk";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@password",SqlDbType=SqlDbType.VarChar,Value=password},
                new SqlParameter() {ParameterName="@lnk",SqlDbType=SqlDbType.VarChar,Value=guid },
            };
            bd.executaSQL(sql, parametros);
        }
        public DataTable devolveDadosCompradores(string email)
        {
            string sql = "SELECT * FROM Compradores WHERE email=@email";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@email",SqlDbType=SqlDbType.VarChar,Value=email }
            };
            DataTable dados = bd.devolveSQL(sql, parametros);
            return dados;
        }
    }
}