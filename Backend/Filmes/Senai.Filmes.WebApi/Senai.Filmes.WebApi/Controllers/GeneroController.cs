using Microsoft.AspNetCore.Mvc;
using Senai.Filmes.WebApi.Domains;
using Senai.Filmes.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        GeneroRepository GeneroRepository = new GeneroRepository();

        //listar
        [HttpGet]
        public IEnumerable<GeneroDomain> Listar()
        {
            //retornar funcionarios
            return GeneroRepository.Listar();
        }//fim listar

        //buscar por id 
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            GeneroDomain genero = GeneroRepository.BuscarPorId(id);
            if (genero == null)
            {
                return NotFound();
            }
            return Ok(genero);
        }//fim buscar por id

        //cadastrar
        [HttpPost]
        public IActionResult Cadastrar(GeneroDomain genero)
        {
            try
            {
                GeneroRepository.Cadastrar(genero);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro" + ex.Message });
            }
        }

        //update
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, GeneroDomain generoDomain)
        {
            generoDomain.IdGenero = id;
            GeneroRepository.Alterar(generoDomain);
            return Ok();
        }//fim update

        //delete
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            GeneroRepository.Deletar(id);
            return Ok();
        }//fim delete
    }
}
