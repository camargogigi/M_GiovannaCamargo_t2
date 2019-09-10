using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class FuncionarioRepository
    {
        //listar
        public List<Funcionarios> Listar()
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Funcionarios.ToList();
            }
        }//fim listar

        //cadastrar
        public void Cadastrar(Funcionarios funcionarios)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                //insert into
                ctx.Funcionarios.Add(funcionarios);
                ctx.SaveChanges();
            }
        }//fim cadastrar

        //atualizar
        public void Atualizar(int id, Funcionarios funcionarios)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Funcionarios funcionario = ctx.Funcionarios.FirstOrDefault(x => x.IdFuncionario == id);
                funcionario.Nome = funcionarios.Nome;
                funcionario.Cpf = funcionarios.Cpf;
                funcionario.DataNascimento = funcionarios.DataNascimento;
                funcionario.Salario = funcionario.Salario;
                funcionario.IdDepartamento = funcionarios.IdDepartamento;
                funcionario.IdCargo = funcionarios.IdCargo;
                funcionario.IdUsuario = funcionarios.IdUsuario;
                ctx.Funcionarios.Update(funcionario);
                ctx.SaveChanges();
            }
        }//fim atualizar

        //Deletar
        public void Deletar(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Funcionarios FuncionarioBuscado = ctx.Funcionarios.Find(id);
                ctx.Funcionarios.Remove(FuncionarioBuscado);
                ctx.SaveChanges();
            }
        }//fim delete
    }
}
