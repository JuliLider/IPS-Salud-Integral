using System;
using System.Collections.Generic;

#nullable disable

namespace IPSlogic.DataBase
{
    public partial class Usuario
    {
        public Usuario()
        {
            Cita = new HashSet<Citum>();
        }

        public string Contraseña { get; set; }
        public string NumeroDocumentoPersona { get; set; }
        public string IdConvenio { get; set; }

        public virtual Convenio IdConvenioNavigation { get; set; }
        public virtual Persona NumeroDocumentoPersonaNavigation { get; set; }
        public virtual ICollection<Citum> Cita { get; set; }
    }
}
