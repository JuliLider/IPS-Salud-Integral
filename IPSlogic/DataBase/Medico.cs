using System;
using System.Collections.Generic;

#nullable disable

namespace IPSlogic.DataBase
{
    public partial class Medico
    {
        public Medico()
        {
            Cita = new HashSet<Citum>();
        }

        public string Licencia { get; set; }
        public string Turno { get; set; }
        public string NumeroDocumentoPersona { get; set; }
        public string IdServicio { get; set; }

        public virtual Servicio IdServicioNavigation { get; set; }
        public virtual Persona NumeroDocumentoPersonaNavigation { get; set; }
        public virtual ICollection<Citum> Cita { get; set; }
    }
}
