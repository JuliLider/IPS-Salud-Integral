using System;
using System.Collections.Generic;

#nullable disable

namespace IPSlogic.DataBase
{
    public partial class Servicio
    {
        public Servicio()
        {
            Medicos = new HashSet<Medico>();
        }

        public string Id { get; set; }
        public bool MetodoPago { get; set; }
        public double TarifaParticular { get; set; }
        public double TarifaAfiliado { get; set; }
        public decimal Descuento { get; set; }
        public string Especialidad { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
