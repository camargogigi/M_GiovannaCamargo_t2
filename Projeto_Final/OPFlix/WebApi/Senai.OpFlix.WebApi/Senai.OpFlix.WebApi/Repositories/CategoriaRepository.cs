using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {

        public List<Categorias> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Categorias.ToList();
            }
        }//fim listar

        public void Cadastrar(Categorias categorias)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                //INSERT INTO
                ctx.Categorias.Add(categorias);
                ctx.SaveChanges();
            }
        }//fim cadastrar

        public void Atualizar(int id, Categorias categorias)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Categorias categoria = ctx.Categorias.FirstOrDefault(x => x.IdCategoria == id);
                categoria.Nome = categorias.Nome;
                ctx.Categorias.Update(categoria);
                ctx.SaveChanges();
            }
        }//fim atualizar
    }
}
