using Senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Repositories
{
    public class GeneroRepository
    {
        private string StringConexao = "Data Source=localhost; initial catalog=M_Filmes;User Id=sa;Pwd=132;";

        //listar
        public List<GeneroDomain> Listar()
        {
            List<GeneroDomain> generos = new List<GeneroDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT IdGenero, Nome FROM Generos";

                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain
                        {
                            IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                            Nome = sdr["Nome"].ToString()
                        };
                        generos.Add(genero);
                    }
                }
                return generos;
            }

        }//fim listar

        //buscar por id
        public GeneroDomain BuscarPorId(int id)
        {
            string Query = "SELECT IdGenero, Nome FROM Generos WHERE IdGenero =@IdGenero";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            GeneroDomain genero = new GeneroDomain
                            {
                                IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                Nome = sdr["Nome"].ToString()
                            };
                            return genero;
                        }
                    }
                    return null;
                }

            }
        }//fim buscar por id

        //cadastrar
        public void Cadastrar(GeneroDomain generos)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "INSERT INTO Generos (Nome) VALUES (@Nome)";

                SqlCommand cmd = new SqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@Nome", generos.Nome);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //update
        public void Alterar(GeneroDomain generoDomain)
        {
            string Query = "UPDATE Generos SET Nome = @Nome WHERE IdGenero = @IdGenero";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", generoDomain.Nome);
                cmd.Parameters.AddWithValue("@IdGenero", generoDomain.IdGenero);


                con.Open();
                cmd.ExecuteNonQuery();
            }
        }//fim update

        //delete
        public void Deletar(int id)
        {
            string Query = "DELETE FROM Generos WHERE IdGenero = @IdGenero";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@IdGenero", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }//fim delete

    }//fim classe
}//fim namespace
