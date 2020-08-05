using System;
using System.Collections.Generic;

namespace IdentityServer
{
    public partial class Especialidades
    {
        public Especialidades()
        {
            Medicos = new HashSet<Medicos>();
        }

        public string Nome { get; set; }
        public int CodEspecialidade { get; set; }
        public decimal ValorConsulta { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Medicos> Medicos { get; set; }
    }
}
