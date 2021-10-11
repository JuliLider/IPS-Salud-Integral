using System;
using System.Collections.Generic;

#nullable disable

namespace IPSlogic.DataBase
{
    public partial class Ip
    {
        public Ip()
        {
            Cita = new HashSet<Citum>();
        }

        public string Id { get; set; }
        public string Sede { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string IdEps { get; set; }
        public string IdServicios { get; set; }
        public string IdPago { get; set; }
        public string IdCiudad { get; set; }

        public virtual Ciudade IdCiudadNavigation { get; set; }
        public virtual Ep IdEpsNavigation { get; set; }
        public virtual ICollection<Citum> Cita { get; set; }
    }
}
