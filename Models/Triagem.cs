using System;
using System.Collections.Generic;

#nullable disable

namespace Test
{
    public partial class Triagem
    {
        public Triagem()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int CodTriagem { get; set; }
        public string Cpf { get; set; }
        public string Coren { get; set; }
        public DateTime DataConsulta { get; set; }
        public string DescricaoPaciente { get; set; }
        public decimal? Prioridade { get; set; }

        public virtual Enfermeiro CorenNavigation { get; set; }
        public virtual Paciente CpfNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
