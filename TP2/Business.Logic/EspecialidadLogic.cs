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
   public class EspecialidadLogic
    {
        private Data.Database.Especialidad _especialidadDatos;

        public Data.Database.Especialidad EspecialidadDatos
        {
            get { return _especialidadDatos; }
            set { _especialidadDatos = value; }
        }
        public EspecialidadLogic()
       {
           EspecialidadDatos = new Data.Database.Especialidad();
       }
       public List<_Especialidades> GetAll()
       {
           return EspecialidadDatos.GetAll();
       }
       
       public static DataTable GetOne(string id)
       {
           Business.Entities._Especialidades espe = new Business.Entities._Especialidades();
           Data.Database.Especialidad especia = new Data.Database.Especialidad();
           espe.Txtbuscado = id;
           return especia.GetOne(espe);
       }
       public static string Delete(int id)
       {
           Business.Entities._Especialidades espe = new Business.Entities._Especialidades();
           Data.Database.Especialidad especia = new Data.Database.Especialidad();
           espe.Idespecialidad = id;
           return especia.Delete(espe);
       }
       public static string Insertar(string descrip)
       {
           Business.Entities._Especialidades espe =new Business.Entities._Especialidades();
            Data.Database.Especialidad especia = new  Data.Database.Especialidad();
           //Especialidad espe= new Especialidad();
           espe.DescEspecialidad = descrip;
           return especia.Insert(espe);
           //EspecialidadDatos.Insert(espe);
       }
       public static string editar(int idespecialidad, string descripcion)
       {
           Business.Entities._Especialidades espe = new Business.Entities._Especialidades();
           Data.Database.Especialidad especia = new Data.Database.Especialidad();
           espe.Idespecialidad = idespecialidad;
           espe.DescEspecialidad = descripcion;
           return especia.Update(espe);
       }
    }
}
