using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPSentity.Entity
{
    public class PersonaEntity: BaseEntity
    {
        [Required(ErrorMessage ="Escriba su número de Cédula")]
        public string NumeroDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public bool? Sexo { get; set; }
    }
}
