using Microsoft.AspNetCore.Mvc;
using Senai.Filmes.WebApi.Domains;
using Senai.Filmes.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        FilmeRepository FilmeRepository = new FilmeRepository();

        //listar
        [HttpGet]
        public IEnumerable<FilmeDomain> Listar()
        {
            //retornar funcionarios
            return FilmeRepository.Listar();
        }//fim listar

        //buscar por id 
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            FilmeDomain filme = FilmeRepository.BuscarPorId(id);
            if (filme == null)
            {
                return NotFound();
            }
            return Ok(filme);
        }//fim buscar por id

        //cadastrar
        [HttpPost]
        public IActionResult Cadastrar(FilmeDomain filmes)
        {
            try
            {
               FilmeRepository.Cadastrar(filmes);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro" + ex.Message });
            }
        }//fim cadastrar
    }
}
