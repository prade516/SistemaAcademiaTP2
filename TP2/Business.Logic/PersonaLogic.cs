using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;
using System.Data;

namespace Business.Logic
{
    public class PersonaLogic
    {
         private Data.Database.Personas _PersonaData;

      public Data.Database.Personas PersonaData
        {
             get { return _PersonaData; }
             set { _PersonaData = value; }
        }      
       
       public PersonaLogic()
       {
           PersonaData = new Data.Database.Personas();
       }
       public List<_Personas> GetAllAdministrador()
       {
           return PersonaData.GetAllAdministrador();
       }
       public List<_Personas> GetAllProfesor()
       {
           return PersonaData.GetAllProfesor();
       }
       public List<_Personas> GetAllAlumno()
       {
           return PersonaData.GetAllAlumno();
       }
       public List<_Personas> GetByPersona(int legajo)
       {
           return PersonaData.GetByPersona(legajo);
       }
       public void Delete(_Personas id) 
       {
            PersonaData.Save(id);
       }
       public void Insertar(_Personas persona)
       {
           PersonaData.Save(persona);
       }
       public void Update(_Personas persona)
       {
           PersonaData.Save(persona);
       }      
    }
}

