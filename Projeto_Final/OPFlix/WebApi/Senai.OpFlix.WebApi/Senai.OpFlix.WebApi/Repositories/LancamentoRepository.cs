using Microsoft.EntityFrameworkCore;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class LancamentoRepository : ILancamentoRepository
    {
        public List<Lancamentos> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Lancamentos.Include(x => x.IdCategoriaNavigation).Include(x => x.IdPlataformaNavigation).Include(x => x.IdTipoNavigation).ToList();
            }
        }//fim listar

        public Lancamentos BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Lancamentos.FirstOrDefault(x => x.IdLancamento == id);
            }
        }//fim buscar por id 

        public void Cadastrar(Lancamentos lancamentos)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                //insert into
                ctx.Lancamentos.Add(lancamentos);
                ctx.SaveChanges();
            }
        }//fim cadastrar

        public void Atualizar(int id, Lancamentos lancamentos)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Lancamentos lancamento = ctx.Lancamentos.FirstOrDefault(x => x.IdLancamento == id);
                lancamento.Nome = lancamentos.Nome;
                lancamento.DataEstreia = lancamentos.DataEstreia;
                lancamento.IdTipo = lancamentos.IdTipo;
                lancamento.Descricao = lancamentos.Descricao;
                lancamento.Sinopse = lancamentos.Sinopse;
                lancamento.IdCategoria = lancamentos.IdCategoria;
                lancamento.IdPlataforma = lancamentos.IdPlataforma;
                lancamento.TempoDuracao = lancamentos.TempoDuracao;
                ctx.Lancamentos.Update(lancamento);
                ctx.SaveChanges();
            }
        }//fim atualizar

        public void Deletar(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Lancamentos LancamentoBuscado = ctx.Lancamentos.Find(id);
                ctx.Lancamentos.Remove(LancamentoBuscado);
                ctx.SaveChanges();
            }
        }//fim delete

        public List<Lancamentos> FiltrarPorCategoria(int categoria)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Lancamentos.Include(x => x.IdCategoriaNavigation).Include(x => x.IdPlataformaNavigation).Include(x => x.IdTipoNavigation).Where(x => x.IdCategoria == categoria).ToList();
            }
        }//fim filtrar por plataforma

        public List<Lancamentos> FiltrarPorData(int data)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Lancamentos.Include(x => x.IdCategoriaNavigation).Include(x => x.IdPlataformaNavigation).Include(x => x.IdTipoNavigation).Where(x => x.DataEstreia.Month == data).ToList();
            }
        }//fim filtrar por data
    }
}
