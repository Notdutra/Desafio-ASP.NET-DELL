using System;
using System.Collections.Generic;

#nullable disable

namespace Test
{
    public partial class Medico
    {
        public Medico()
        {
            Consulta = new HashSet<Consulta>();
        }

        public string Crm { get; set; }
        public string Nome { get; set; }
        public int CodEspecialidade { get; set; }

        public virtual Especialidade CodEspecialidadeNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
