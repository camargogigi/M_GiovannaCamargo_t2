using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.Repositories;

namespace Senai.OpFlix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PlataformaController : ControllerBase
    {
        private IPlataformaRepository plataformaRepository { get; set; }

        public PlataformaController()
        {
            plataformaRepository = new PlataformaRepository();
        }

        //listar
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(plataformaRepository.Listar());
        }//fim listar


        //cadastrar
        [HttpPost]
        public IActionResult Cadastrar(Plataformas plataforma)
        {
            try
            {
                plataformaRepository.Cadastrar(plataforma);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "IIIIIII deu ruim" + ex.Message });
            }
        }//fim cadastrar

        //atualizar
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Plataformas plataforma)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                plataformaRepository.Atualizar(id, plataforma);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "IIIIIII deu ruim" + ex.Message });
            }
        }//fim atualizar
    }
}