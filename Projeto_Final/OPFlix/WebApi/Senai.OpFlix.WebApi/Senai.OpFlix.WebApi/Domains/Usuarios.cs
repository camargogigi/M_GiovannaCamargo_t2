using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Usuarios
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public int? IdTipoUser { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }

        public TiposUsuarios IdTipoUserNavigation { get; set; }
    }
}
