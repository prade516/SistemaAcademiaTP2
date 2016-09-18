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
       
       public List<_Especialidades> GetByEspecialidad(string desc_especialidad)
       {
           return EspecialidadDatos.GetByEspecialidad(desc_especialidad);
       }
       public void Delete(Business.Entities._Especialidades especialidad)
       {
           EspecialidadDatos.Save(especialidad);
       }
       public void Insertar(Business.Entities._Especialidades especialidad)
       {
           EspecialidadDatos.Save(especialidad);
       }
       public void Editar(Business.Entities._Especialidades especialidad)
       {
           EspecialidadDatos.Save(especialidad);
       }
    }
}
