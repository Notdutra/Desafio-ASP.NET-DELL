using System;
using System.Collections.Generic;

#nullable disable

namespace Test
{
    public partial class Consulta
    {
        public string Cpf { get; set; }
        public string Crm { get; set; }
        public string Coren { get; set; }
        public DateTime DataConsulta { get; set; }
        public int? CodTriagem { get; set; }
        public int CodConsultas { get; set; }

        public virtual Triagem CodTriagemNavigation { get; set; }
        public virtual Enfermeiro CorenNavigation { get; set; }
        public virtual Paciente CpfNavigation { get; set; }
        public virtual Medico CrmNavigation { get; set; }
    }
}
