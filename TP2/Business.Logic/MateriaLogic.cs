using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;
using System.Data;

namespace Business.Logic
{
   public  class MateriaLogic
    {
        private Data.Database.MateriasD _Materia;

        public Data.Database.MateriasD Materia
        {
            get { return _Materia; }
            set { _Materia = value; }
        }   
       public MateriaLogic()
        {
            Materia = new Data.Database.MateriasD();
        }
       public List<Materias> GetAll()
       {
           return Materia.GetAll();
       }
       public List<Business.Entities.Materias> GetByMateria(string desc_materia)
       {
           return Materia.GetByMateria(desc_materia);
       }

       public void Insertar(Business.Entities.Materias mat)
       {
           Materia.Save(mat);
       }
       public void Editar(Business.Entities.Materias mat)
       {
           Materia.Save(mat);
       }
       public void Delete(Business.Entities.Materias mat)
       {
           Materia.Save(mat);
       }
    }
}
