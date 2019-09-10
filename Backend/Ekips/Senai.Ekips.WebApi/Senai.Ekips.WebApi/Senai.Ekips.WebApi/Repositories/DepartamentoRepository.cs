using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class DepartamentoRepository
    {
        //listar
        public List <Departamentos> Listar()
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Departamentos.ToList();
            }
        }//fim listar

        //buscar por id
        public Departamentos BuscarPorId (int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Departamentos.FirstOrDefault(x => x.IdDepartamento == id);
            }
        }//fim buscar por id 

        //cadastrar
        public void Cadastrar(Departamentos departamentos)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                //insert into
                ctx.Departamentos.Add(departamentos);
                ctx.SaveChanges();
            }
        }//fim cadastrar
    }
}
