using Senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Repositories
{
    public class FilmeRepository
    {
        private string StringConexao = "Data Source=localhost; initial catalog=M_Filmes;User Id=sa;Pwd=132;";

        //listar
        public List<FilmeDomain> Listar()
        {
            List<FilmeDomain> filmes = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT IdFilme, Titulo, IdGenero FROM Filmes";

                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(sdr["IdFilme"]),
                            Titulo = sdr["Titulo"].ToString(),
                            Genero = new GeneroDomain { 
                                IdGenero = Convert.ToInt32(sdr["IdGenero"])
                           }
                        };
                        filmes.Add(filme);
                    }
                }
                return filmes;
            }

        }//fim listar

        //buscar por id
        public FilmeDomain BuscarPorId(int id)
        {
            string Query = "SELECT IdFilme, Titulo, IdGenero FROM Filmes WHERE IdFilme =@IdFilme";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            FilmeDomain filme = new FilmeDomain
                            {
                                IdFilme = Convert.ToInt32(sdr["IdFilme"]),
                                Titulo = sdr["Titulo"].ToString(),
                                Genero = new GeneroDomain {
                                IdGenero = Convert.ToInt32(sdr["IdGenero"])
                                }
                            };
                            return filme;
                        }
                    }
                    return null;
                }

            }
        }//fim buscar por id

        //cadastrar
        public void Cadastrar (FilmeDomain filmes)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "INSERT INTO Filmes (Titulo, IdGenero) VALUES (@Titulo, @IdGenero)";
                
                SqlCommand cmd = new SqlCommand(Query, con);
                
                    cmd.Parameters.AddWithValue("@Titulo", filmes.Titulo);
                    cmd.Parameters.AddWithValue("@IdGenero", filmes.GeneroId);

                    con.Open();
                cmd.ExecuteNonQuery();
                
            }
        }//fim cadastrar

    }//fim classe
}//fim namespace
