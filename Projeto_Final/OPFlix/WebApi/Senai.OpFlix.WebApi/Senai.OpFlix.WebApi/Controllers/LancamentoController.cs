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

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                Lancamentos LancamentoBuscado = LancamentoRepository.BuscarPorId(id);

                if (LancamentoBuscado == null)
                {
                    return NotFound();
                }

                LancamentoRepository.Deletar(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }//fim deletar
    }
}