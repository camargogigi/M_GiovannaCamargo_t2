using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class TiposUsuarios
    {
        public TiposUsuarios()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdTipoUser { get; set; }
        public string Tipo { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
