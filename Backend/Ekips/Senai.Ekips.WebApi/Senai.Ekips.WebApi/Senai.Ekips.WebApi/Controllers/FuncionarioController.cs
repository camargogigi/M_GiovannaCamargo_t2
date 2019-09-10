using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        FuncionarioRepository funcionarioRepository = new FuncionarioRepository();

        //listar
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(funcionarioRepository.Listar());
        }//fim listar

        //cadastrar
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Funcionarios funcionarios)
        {
            try
            {
                funcionarioRepository.Cadastrar(funcionarios);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "IIIIIII deu ruim" + ex.Message });
            }
        }//fim cadastrar

        //atualizar
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Funcionarios funcionarios)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                funcionarioRepository.Atualizar(id, funcionarios);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "IIIIIII deu ruim" + ex.Message });
            }
        }//fim atualizar

        //delete
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            funcionarioRepository.Deletar(id);
            return Ok();
        }//fim delete
    }
}
