using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    interface IPlataformaRepository
    {
        List<Plataformas> Listar();

        void Cadastrar(Plataformas plataformas);

        void Atualizar(int id, Plataformas plataformas);
    }
}
