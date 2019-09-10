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
    public class DepartamentoController : ControllerBase
    {
        DepartamentoRepository departamentoRepository = new DepartamentoRepository();

        //listar
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(departamentoRepository.Listar());
        }//fim listar

        //buscar por id
        [HttpGet("{id}")]
        public IActionResult BuscarPorId (int id)
        {
            Departamentos departamentos = departamentoRepository.BuscarPorId(id);
            if (departamentos == null)
            {
                return NotFound();
            }
            return Ok(departamentos);
        }//fim buscar por id

        //cadastrar
        [HttpPost]
        public IActionResult Cadastrar (Departamentos departamentos)
        {
            try
            {
                departamentoRepository.Cadastrar(departamentos);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "IIIIIII deu ruim" + ex.Message });
            }
        }//fim cadastrar
    }
}
