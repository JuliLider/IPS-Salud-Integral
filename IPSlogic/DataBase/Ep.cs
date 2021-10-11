using System;
using System.Collections.Generic;

#nullable disable

namespace IPSlogic.DataBase
{
    public partial class Ep
    {
        public Ep()
        {
            Ips = new HashSet<Ip>();
        }

        public string Id { get; set; }
        public string HorarioAfiliados { get; set; }
        public string HorarioParticulares { get; set; }
        public string Ciudad { get; set; }

        public virtual ICollection<Ip> Ips { get; set; }
    }
}
