using System;
using System.Collections.Generic;

namespace IdentityServer
{
    public partial class Consultas
    {
        public string Cpf { get; set; }
        public string Crm { get; set; }
        public string Coren { get; set; }
        public DateTime DataConsulta { get; set; }
        public int? CodTriagem { get; set; }
        public int CodConsultas { get; set; }

        public virtual Triagem CodTriagemNavigation { get; set; }
        public virtual Enfermeiros CorenNavigation { get; set; }
        public virtual Medicos CrmNavigation { get; set; }
    }
}
