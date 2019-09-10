using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        FuncionarioRepository FuncionarioRepository = new FuncionarioRepository();

        //listar
        [HttpGet]
        public IEnumerable<FuncionarioDomain> Listar()
        {
            //retornar funcionarios
            return FuncionarioRepository.Listar();
        }//fim listar

        //buscar por id 
        [HttpGet("{id}")]
        public IActionResult BuscarPorId (int id)
        {
            FuncionarioDomain Funcionario = FuncionarioRepository.BuscarPorId(id);
            if (Funcionario == null)
            {
                return NotFound();
            }
            return Ok(Funcionario);
        }//fim buscar por id

        //cadastrar
        [HttpPost]
        public IActionResult Cadastrar(FuncionarioDomain funcionarioDomain)
        {
            FuncionarioRepository.Cadastrar(funcionarioDomain);
            return Ok();
        }//cadastrar

        //update
        [HttpPut("{id}")]
        public IActionResult Alterar (int id,FuncionarioDomain funcionarioDomain)
        {
            funcionarioDomain.IdFuncionario = id;
            FuncionarioRepository.Alterar(funcionarioDomain);
            return Ok();
        }

        //delete
        [HttpDelete("{id}")]
        public IActionResult Deletar (int id)
        {
            FuncionarioRepository.Deletar(id);
            return Ok();
        }//fim delete

    }//fim classe
}//fim name space
