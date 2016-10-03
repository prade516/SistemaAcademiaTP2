using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
public class PlanLogic
    {
        private Data.Database.Plan _Plans;

        public Data.Database.Plan Plans
        {
            get { return _Plans; }
            set { _Plans = value; }
        }
       public PlanLogic()
        {
            Plans = new Data.Database.Plan();
        }
       public List<Planes> GetAll()
           {
               return Plans.GetAll();
           }
    
       public List<Planes> GetByMostrar()
       {
           return Plans.GetByMostrar();
       }
       public List<Planes> GetPlan(string desc_plan)
           {
               return Plans.GetByPlan(desc_plan);
           }
     public void Delete(Business.Entities.Planes id)
         {
             Plans.Save(id);
         }
    public void Insertar(Business.Entities.Planes pla)
        {
            Plans.Save(pla);
        }
    public void Editar(Business.Entities.Planes pla)
    {
        Plans.Save(pla);
    }
  }
}
