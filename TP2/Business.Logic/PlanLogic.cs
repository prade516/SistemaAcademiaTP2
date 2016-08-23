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
 public static DataTable GetOne(string desc_plan)
       {
           Business.Entities.Planes pla = new Business.Entities.Planes();
           Data.Database.Plan pl = new Data.Database.Plan();
           pla.Txtbuscado = desc_plan;
           return pl.GetOne(pla);
       }
public static string Delete(int id)
 {
     Business.Entities.Planes pla = new Business.Entities.Planes();
     Data.Database.Plan pl = new Data.Database.Plan();
    
     pla.Codigo = id;
     return pl.Delete(pla);
 }
public static string Insertar(string desc_plan,int id_especialidad)
{
    Business.Entities.Planes pla = new Business.Entities.Planes();
    Data.Database.Plan pl = new Data.Database.Plan();

    pla.Plan = desc_plan;
    pla.Id_Especialidad = id_especialidad;
    return pl.Insert(pla);
}
public static string Editar(int id_plan,string desc_plan, int id_especialidad)
{
    Business.Entities.Planes pla = new Business.Entities.Planes();
    Data.Database.Plan pl = new Data.Database.Plan();

    pla.Codigo = id_plan;
    pla.Plan = desc_plan;
    pla.Id_Especialidad = id_especialidad;
    return pl.Update(pla);
}
}
}
