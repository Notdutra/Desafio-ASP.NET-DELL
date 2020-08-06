using System;
using System.Collections.Generic;

#nullable disable

namespace Test
{
    public partial class Enfermeiro
    {
        public Enfermeiro()
        {
            Consulta = new HashSet<Consulta>();
            Triagems = new HashSet<Triagem>();
        }

        public string Coren { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Consulta> Consulta { get; set; }
        public virtual ICollection<Triagem> Triagems { get; set; }
    }
}
