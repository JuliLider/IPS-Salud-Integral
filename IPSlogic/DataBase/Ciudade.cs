using System;
using System.Collections.Generic;

#nullable disable

namespace IPSlogic.DataBase
{
    public partial class Ciudade
    {
        public Ciudade()
        {
            Ips = new HashSet<Ip>();
        }

        public string Id { get; set; }
        public string NombreCiudad { get; set; }

        public virtual ICollection<Ip> Ips { get; set; }
    }
}
