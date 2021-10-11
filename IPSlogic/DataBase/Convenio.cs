using System;
using System.Collections.Generic;

#nullable disable

namespace IPSlogic.DataBase
{
    public partial class Convenio
    {
        public Convenio()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public string Id { get; set; }
        public string NombreConvenio { get; set; }
        public double PorcentajeDescuento { get; set; }
        public bool TipoAfiliacion { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
