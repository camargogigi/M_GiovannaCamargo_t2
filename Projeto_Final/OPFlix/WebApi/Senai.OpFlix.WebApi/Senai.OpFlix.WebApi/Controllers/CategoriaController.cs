using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    public class CategoriaController : ControllerBase
    {
        private ICategoriaRepository categoriaRepository { get; set; }

        public CategoriaController()
        {
            categoriaRepository = new CategoriaRepository();
        }

        //listar
        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(categoriaRepository.Listar());
        }//fim listar

        //cadastrar
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Cadastrar(Categorias categoria)
        {
            try
            {
                categoriaRepository.Cadastrar(categoria);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "IIIIIII deu ruim" + ex.Message });
            }
        }//fim cadastrar

        //atualizar
        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Categorias categoria)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                categoriaRepository.Atualizar(id, categoria);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "IIIIIII deu ruim" + ex.Message });
            }
        }//fim atualizar

    }
}