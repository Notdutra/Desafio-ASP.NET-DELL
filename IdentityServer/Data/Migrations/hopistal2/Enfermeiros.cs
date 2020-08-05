using System;
using System.Collections.Generic;

namespace IdentityServer
{
    public partial class Enfermeiros
    {
        public Enfermeiros()
        {
            Consultas = new HashSet<Consultas>();
            Triagem = new HashSet<Triagem>();
        }

        public string Coren { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Consultas> Consultas { get; set; }
        public virtual ICollection<Triagem> Triagem { get; set; }
    }
}
