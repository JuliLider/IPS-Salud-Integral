using System;
using System.Collections.Generic;

#nullable disable

namespace IPSlogic.DataBase
{
    public partial class Triage
    {
        public Triage()
        {
            Cita = new HashSet<Citum>();
        }

        public string Id { get; set; }
        public bool Fiebre { get; set; }
        public bool Gripe { get; set; }
        public bool ContactoPositivoCovid { get; set; }

        public virtual ICollection<Citum> Cita { get; set; }
    }
}
