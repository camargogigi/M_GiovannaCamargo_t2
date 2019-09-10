using System;
using System.Collections.Generic;

namespace Senai.Ekips.WebApi.Domains
{
    public partial class StatusCargo
    {
        public StatusCargo()
        {
            Cargos = new HashSet<Cargos>();
        }

        public int IdStatus { get; set; }
        public string Nome { get; set; }

        public ICollection<Cargos> Cargos { get; set; }
    }
}
