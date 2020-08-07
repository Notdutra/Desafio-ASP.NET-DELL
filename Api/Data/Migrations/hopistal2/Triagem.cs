using System;
using System.Collections.Generic;

namespace IdentityServer
{
    public partial class Triagem
    {
        public Triagem()
        {
            Consultas = new HashSet<Consultas>();
        }

        public int CodTriagem { get; set; }
        public string Cpf { get; set; }
        public string Coren { get; set; }
        public DateTime DataConsulta { get; set; }
        public string DescricaoPaciente { get; set; }
        public decimal? Prioridade { get; set; }

        public virtual Enfermeiros CorenNavigation { get; set; }
        public virtual ICollection<Consultas> Consultas { get; set; }
    }
}
