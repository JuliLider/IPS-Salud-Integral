using System;
using System.Collections.Generic;

#nullable disable

namespace IPSlogic.DataBase
{
    public partial class Citum
    {
        public string Id { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public bool TipoCita { get; set; }
        public string ObservacionMedica { get; set; }
        public bool EstadoCita { get; set; }
        public string IdIps { get; set; }
        public string IdTriage { get; set; }
        public string LicenciaMedico { get; set; }
        public string ContraseñaUsuario { get; set; }

        public virtual Usuario ContraseñaUsuarioNavigation { get; set; }
        public virtual Ip IdIpsNavigation { get; set; }
        public virtual Triage IdTriageNavigation { get; set; }
        public virtual Medico LicenciaMedicoNavigation { get; set; }
    }
}
