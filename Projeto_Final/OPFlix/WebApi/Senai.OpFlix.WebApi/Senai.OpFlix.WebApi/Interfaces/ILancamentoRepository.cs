using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    interface ILancamentoRepository
    {
        List<Lancamentos> Listar();

        Lancamentos BuscarPorId(int id);

        void Cadastrar(Lancamentos lancamentos);

        void Atualizar(int id, Lancamentos lancamentos);

        void Deletar(int id);
    }
}
