using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Sstop.WebApi.Domains;
using Senai.Sstop.WebApi.Repositories;

namespace Senai.Sstop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EstilosController : ControllerBase
    {
        List<EstiloDomain> estilos = new List<EstiloDomain>() {
            new EstiloDomain{ IdEstilo= 1, Nome= "R&B" }
        };


        EstilosRepository EstiloRepository = new EstilosRepository();

        //Listar    
        [HttpGet]
        public IEnumerable<EstiloDomain> Listar()
        {
            //return estilos;
            return EstiloRepository.Listar();
        }

        //buscar por id 
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int Id) {
            EstiloDomain Estilo = EstiloRepository.BuscarPorId(Id);
            if (Estilo == null) {
                return NotFound();
            }
            return Ok(Estilo);
        }

        //cadastrar
        [HttpPost]
        public IActionResult Cadastrar(EstiloDomain estiloDomain)
        {
            //do banco de dados
            EstiloRepository.Cadastrar(estiloDomain);
            return Ok();
        }

        //atualizar
        [HttpPut]
        public IActionResult Atualizar(EstiloDomain estiloDomain)
        {
            EstiloRepository.Alterar(estiloDomain);
            return Ok();
        }

        //deletar
        [HttpDelete ("{id}")]
        public IActionResult Deletar (int id)
        {
            EstiloRepository.Deletar(id);
            return Ok();
        }
    }


        //[HttpGet]
        //public string Get() {
        //    return "Requisição Recebida";
        //}
    }
