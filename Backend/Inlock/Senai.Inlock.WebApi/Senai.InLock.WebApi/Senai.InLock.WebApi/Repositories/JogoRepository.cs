using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class JogoRepository
    {
        //listar
        public List<Jogos> Listar()
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Jogos.ToList();
            }
        }//fim listar

        //buscar por id 
        public Jogos BuscarPorId(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Jogos.FirstOrDefault(x => x.JogoId == id);
            }
        }// fim buscar por id

        //cadastrar
        public void Cadastrar(Jogos jogo)
        {
            using (InLockContext ctx = new InLockContext())
            {
                //INSERT INTO
                ctx.Jogos.Add(jogo);
                ctx.SaveChanges();
            }
        }//fim cadastrar

        //Deletar
        public void Deletar(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Jogos JogoBuscado = ctx.Jogos.Find(id);
                ctx.Jogos.Remove(JogoBuscado);
                ctx.SaveChanges();
            }
        }//fim delete

        //atualizar
        public void Atualizar(int id, Jogos jogos)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Jogos jogo = ctx.Jogos.FirstOrDefault(x => x.JogoId == id);
                jogo.NomeJogo = jogos.NomeJogo;
                jogo.Descricao = jogos.Descricao;
                jogo.DataLancamento = jogos.DataLancamento;
                jogo.Valor = jogos.Valor;
                jogo.EstudioId = jogos.EstudioId;
                ctx.Jogos.Update(jogos);
                ctx.SaveChanges();
            }
        }//fim atualizar
    }
}
