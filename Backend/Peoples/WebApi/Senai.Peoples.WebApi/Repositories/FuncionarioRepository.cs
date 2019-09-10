using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionarioRepository
    {
        private string StringConexao = "Data Source=Localhost; initial catalog=M_Peoples;User Id=sa;Pwd=132;";

        //listar
        public List<FuncionarioDomain> Listar()
        {
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

            using(SqlConnection con = new SqlConnection(StringConexao))
	        {
                string Query = "SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios";

                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"]),
                            Nome = sdr ["Nome"].ToString(),
                            Sobrenome = sdr ["Sobrenome"].ToString()
                        };
                        funcionarios.Add(funcionario);
                    }
                }
                return funcionarios;
            }
            
        }//fim listar

        //buscar por id
        public FuncionarioDomain BuscarPorId (int id)
        {
            string Query = "SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios WHERE IdFuncionario =@IdFuncionario";

            using (SqlConnection con = new SqlConnection (StringConexao))
            {
                con.Open();
                SqlDataReader sdr;
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdFuncionario", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            FuncionarioDomain funcionario = new FuncionarioDomain
                            {
                                IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"]),
                                Nome = sdr["Nome"].ToString(),
                                Sobrenome = sdr["Sobrenome"].ToString()
                            };
                            return funcionario;
                        }
                    }
                    return null;
                }

            }
        }//fim buscar por id

        //cadastrar
        public void Cadastrar (FuncionarioDomain funcionario)
        {
            string Query = "INSERT INTO Funcionarios(Nome, Sobrenome) VALUES (@Nome, @Sobrenome)";
            using (SqlConnection con = new SqlConnection (StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);
                con.Open();
                cmd.ExecuteNonQuery();
                
            }
        } //fim cadastrar

        //update
        public void Alterar (FuncionarioDomain funcionarioDomain)
        {
            string Query = "UPDATE Funcionarios SET Nome = @Nome, Sobrenome = @Sobrenome WHERE IdFuncionario = @IdFuncionario";
            using (SqlConnection con = new SqlConnection (StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", funcionarioDomain.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", funcionarioDomain.Sobrenome);
                cmd.Parameters.AddWithValue("@IdFuncionario", funcionarioDomain.IdFuncionario);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }//fim update

        //delete
        public void Deletar (int id)
        {
            string Query = "DELETE FROM Funcionarios WHERE IdFuncionario = @IdFuncionario";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //comando
                SqlCommand cmd = new SqlCommand(Query, con);
                //definir parametros
                cmd.Parameters.AddWithValue("@IdFuncionario", id);
                //abrir conexao
                con.Open();
                //executar
                cmd.ExecuteNonQuery();
            }
        }//fim delete


    }//fim classe
}//fim namespace
