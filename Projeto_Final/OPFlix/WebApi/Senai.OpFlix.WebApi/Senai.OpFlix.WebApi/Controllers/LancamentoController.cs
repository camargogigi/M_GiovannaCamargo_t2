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
    public class LancamentoController : ControllerBase
    {
        private ILancamentoRepository LancamentoRepository { get; set; }

        public LancamentoController()
            {
                LancamentoRepository = new LancamentoRepository();
            }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(LancamentoRepository.Listar());
        }//fim listar

        [Authorize(Roles = "Administrador")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Lancamentos lancamentos = LancamentoRepository.BuscarPorId(id);
            if (lancamentos == null)
            {
                return NotFound();
            }
            return Ok(lancamentos);
        }//fim buscar por id

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Cadastrar(Lancamentos lancamentos)
        {
            try
            {
                LancamentoRepository.Cadastrar(lancamentos);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "IIIIIII deu ruim" + ex.Message });
            }
        }//fim cadastrar

        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Lancamentos lancamentos)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                LancamentoRepository.Atualizar(id, lancamentos);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "IIIIIII deu ruim" + ex.Message });
            }
        }//fim atualizar

        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            LancamentoRepository.Deletar(id);
            return Ok();
        }//fim delete

        [HttpGet("categoria/{categoria}")]
        public IActionResult FiltrarPorCategoria(int categoria)
        {
            return Ok(LancamentoRepository.FiltrarPorCategoria(categoria));
        }//fim por plataforma

        [HttpGet("data/{datas}")]
        public IActionResult FiltrarPorData(int datas)
        {
            return Ok(LancamentoRepository.FiltrarPorData(datas));
        }//fim por plataforma
    }
}