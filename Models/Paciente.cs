using System;
using System.Collections.Generic;

#nullable disable

namespace Test
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consulta>();
            Triagems = new HashSet<Triagem>();
        }

        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }

        public virtual ICollection<Consulta> Consulta { get; set; }
        public virtual ICollection<Triagem> Triagems { get; set; }
    }
}
