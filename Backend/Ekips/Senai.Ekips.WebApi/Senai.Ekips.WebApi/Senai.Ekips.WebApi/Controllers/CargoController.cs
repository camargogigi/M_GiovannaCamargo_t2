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
    public class CargoController : ControllerBase
    {
        CargoRepository cargoRepository = new CargoRepository();

        //listar
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(cargoRepository.Listar());
        }//fim listar

        //buscar por id
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Cargos cargos = cargoRepository.BuscarPorId(id);
            if (cargos == null)
            {
                return NotFound();
            }
            return Ok(cargos);
        }//fim buscar por id

        //cadastrar
        [HttpPost]
        public IActionResult Cadastrar(Cargos cargo)
        {
            try
            {
                cargoRepository.Cadastrar(cargo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "IIIIIII deu ruim" + ex.Message });
            }
        }//fim cadastrar
        
        //atualizar
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Cargos cargos)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                cargoRepository.Atualizar(id, cargos);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "IIIIIII deu ruim" + ex.Message });
            }
        }//fim atualizar
    }
}
