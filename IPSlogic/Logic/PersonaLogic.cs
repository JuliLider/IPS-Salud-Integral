using IPSentity.Entity;
using IPSlogic.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPSlogic.Logic
{
    public class PersonaLogic
    {
        IpsDBContext ipsDBContext = new IpsDBContext(); 
        public List<PersonaEntity> GetAllPersona()
        {
            List<PersonaEntity> listPersonaEntities = new List<PersonaEntity>();
            var listpersonaDataBase = ipsDBContext.Personas.ToList();

            foreach(var personaDataBase in listpersonaDataBase)
            {
                listPersonaEntities.Add(ConvertPersonaDataBasetoPersonaEntity(personaDataBase));
            }
            return listPersonaEntities;
        }

        public PersonaEntity AddPersona(PersonaEntity personaEntity)
        {
            try
            {
                if (GetAllPersona().Where(x => x.NumeroDocumento == personaEntity.NumeroDocumento).Any())
                {
                    PersonaEntity persona = new PersonaEntity();
                    persona.Message = " Ya existe un Usuario con esa Cédula ";
                    persona.Type = "danger";
                    return persona;
                }

                ipsDBContext.Personas.Add(ConvertPersonaEntitytoPersonaDataBase(personaEntity));
                ipsDBContext.SaveChanges();
                personaEntity.Message = "Registro Guardado con Éxito";
                personaEntity.Type = "success";
                return personaEntity;
            }
            catch (Exception ex)
            {
                PersonaEntity persona = new PersonaEntity();
                persona.Message = ex.Message;
                return persona;
            }
        }

        private Persona ConvertPersonaEntitytoPersonaDataBase(PersonaEntity personaEntity)
        {
            Persona persona = new Persona();
            persona.NumeroDocumento = personaEntity.NumeroDocumento;
            persona.TipoDocumento = personaEntity.TipoDocumento;
            persona.Nombres = personaEntity.Nombres;
            persona.Apellidos = personaEntity.Apellidos;
            persona.FechaNacimiento = personaEntity.FechaNacimiento;
            persona.Telefono = personaEntity.Telefono;
            persona.Email = personaEntity.Email;
            persona.Direccion = personaEntity.Direccion;
            persona.Sexo = personaEntity.Sexo;

            return persona;
        }

        private PersonaEntity ConvertPersonaDataBasetoPersonaEntity(Persona persona)
        {
            PersonaEntity personaEntity = new PersonaEntity();
            personaEntity.NumeroDocumento = persona.NumeroDocumento;
            personaEntity.TipoDocumento = persona.TipoDocumento;
            personaEntity.Nombres = persona.Nombres;
            personaEntity.Apellidos = persona.Apellidos;
            personaEntity.FechaNacimiento = persona.FechaNacimiento;
            personaEntity.Telefono = persona.Telefono;
            personaEntity.Email = persona.Email;
            personaEntity.Direccion = persona.Direccion;
            personaEntity.Sexo = persona.Sexo;

            return personaEntity;
            }
    }
}
