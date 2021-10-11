using System;
using System.Collections.Generic;

#nullable disable

namespace IPSlogic.DataBase
{
    public partial class Persona
    {
        public Persona()
        {
            Medicos = new HashSet<Medico>();
            Usuarios = new HashSet<Usuario>();
        }

        public string NumeroDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public bool? Sexo { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
