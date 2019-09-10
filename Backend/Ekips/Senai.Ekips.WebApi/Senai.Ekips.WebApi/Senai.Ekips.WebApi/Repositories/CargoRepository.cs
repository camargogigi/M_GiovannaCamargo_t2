using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class CargoRepository
    {
        //listar
        public List<Cargos> Listar()
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Cargos.ToList();
            }

        }//fim listar

        //buscar por id 
        public Cargos BuscarPorId(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Cargos.FirstOrDefault(x => x.IdCargo == id);
            }
        }// fim buscar por id

        //cadastrar
        public void Cadastrar(Cargos cargos)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                //INSERT INTO
                ctx.Cargos.Add(cargos);
                ctx.SaveChanges();
            }
        }//fim cadastrar

        //atualizar
        public void Atualizar(int id, Cargos cargos)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                //ctx.Cargos.FirstOrDefault(x => x.IdCargo == id);
                Cargos cargo = ctx.Cargos.FirstOrDefault(x => x.IdCargo == id);
                cargo.Nome = cargos.Nome;
                ctx.Cargos.Update(cargo);
                ctx.SaveChanges();
            }
        }//fim atualizar
    }
}
