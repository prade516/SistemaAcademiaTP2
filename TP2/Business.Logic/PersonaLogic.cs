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
       public List<_Personas> GetAll()
       {
           return PersonaData.GetAll();
       }

       public static DataTable GetOne(string id)
       {
           Business.Entities._Personas espe = new Business.Entities._Personas();
           Data.Database.Personas especia = new Data.Database.Personas();
           espe.Txtbuscado = id;
           return especia.GetOne(espe);
       }
       public static string Delete(string id) 
       {
           Business.Entities._Personas espe = new Business.Entities._Personas();
           Data.Database.Personas especia = new Data.Database.Personas();
           espe.Txtbuscado = id;
           return especia.Delete(espe);
       }
       public static string Save(string nombre,string apellido,string direccion,string email,string telefono,DateTime fech_nac,int legajo,string tipo_persona,int id_plan,string sexo)
       {
           Business.Entities._Personas espe = new Business.Entities._Personas();
           Data.Database.Personas especia = new Data.Database.Personas();
           
           espe.Nombre = nombre;
           espe.Apellido = apellido;
           espe.Direccion = direccion;
           espe.Email = email;
           espe.Telefono = telefono;
           espe.Fecha_Nac = fech_nac;
           espe.Legajo = legajo;
           espe.Tipo_Persona = tipo_persona;
           espe.Id_Plan = id_plan;
           espe.Sexo = sexo;

           return especia.Insert(espe);
       }
       public static string Insertar(int id_persona, string nombre, string apellido, string direccion, string email, string telefono, DateTime fech_nac, int legajo, string tipo_persona, int id_plan, string sexo)
       {
           Business.Entities._Personas espe = new Business.Entities._Personas();
           Data.Database.Personas especia = new Data.Database.Personas();

           espe.Codigo = id_persona;
           espe.Nombre = nombre;
           espe.Apellido = apellido;
           espe.Direccion = direccion;
           espe.Email = email;
           espe.Telefono = telefono;
           espe.Fecha_Nac = fech_nac;
           espe.Legajo = legajo;
           espe.Tipo_Persona = tipo_persona;
           espe.Id_Plan = id_plan;
           espe.Sexo = sexo;

           return especia.Update(espe);
       }
       public static string Delete(int id)
       {
           Business.Entities._Personas pla = new Business.Entities._Personas();
           Data.Database.Personas pl = new Data.Database.Personas();

           pla.Codigo = id;
           return pl.Delete(pla);
       }
    }
    }

