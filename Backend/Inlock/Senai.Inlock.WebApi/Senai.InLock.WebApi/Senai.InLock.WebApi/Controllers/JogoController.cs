using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        JogoRepository jogoRepository = new JogoRepository();

        //listar
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(jogoRepository.Listar());
        }//fim listar

        //buscar por id
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Jogos jogo = jogoRepository.BuscarPorId(id);
            if (jogo == null)
            {
                return NotFound();
            }
            return Ok(jogo);
        }//fim buscar por 

        //cadastrar
        [HttpPost]
        public IActionResult Cadastrar(Jogos jogo)
        {
            try
            {
                jogoRepository.Cadastrar(jogo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Eita" + ex.Message });
            }
        }//fim cadastrar

        //delete
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            jogoRepository.Deletar(id);
            return Ok();
        }//fim delete

        //atualizar
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Jogos jogos)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                jogoRepository.Atualizar(id, jogos);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "IIIIIII deu ruim" + ex.Message });
            }
        }//fim atualizar


    }
}
