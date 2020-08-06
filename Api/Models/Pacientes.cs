using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class Pacientes
    {
        public Pacientes()
        {
            Consultas = new HashSet<Consultas>();
            Triagem = new HashSet<Triagem>();
        }

        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }

        public virtual Clients CpfNavigation { get; set; }
        public virtual ICollection<Consultas> Consultas { get; set; }
        public virtual ICollection<Triagem> Triagem { get; set; }
    }
}
