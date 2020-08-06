using System;
using System.Collections.Generic;

#nullable disable

namespace Test
{
    public partial class Especialidade
    {
        public Especialidade()
        {
            Medicos = new HashSet<Medico>();
        }

        public string Nome { get; set; }
        public int CodEspecialidade { get; set; }
        public decimal ValorConsulta { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
