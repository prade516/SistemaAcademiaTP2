using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;

namespace Business.Logic
{
   public  class MateriaLogic
    {
        private Data.Database.MateriasD _PersonaData;

        public Data.Database.MateriasD PersonaData
        {
            get { return _PersonaData; }
            set { _PersonaData = value; }
        }   
       public MateriaLogic()
        {
            PersonaData = new Data.Database.MateriasD();
        }
       public List<Materias> GetAll()
       {
           return PersonaData.GetAll();
       }
    }
}
