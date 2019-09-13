using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class PlataformaRepository : IPlataformaRepository
    {
        public List<Plataformas> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Plataformas.ToList();
            }
        }//fim listar

        public void Cadastrar(Plataformas plataformas)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                //INSERT INTO
                ctx.Plataformas.Add(plataformas);
                ctx.SaveChanges();
            }
        }//fim cadastrar

        public void Atualizar(int id, Plataformas plataformas)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Plataformas plataforma = ctx.Plataformas.FirstOrDefault(x => x.IdPlataforma == id);
                plataforma.Nome = plataformas.Nome;
                ctx.Plataformas.Update(plataforma);
                ctx.SaveChanges();
            }//fim atualizar
        }//fim aualizar


    }
}
