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
       public static DataTable GetOne(string desc_materia)
       {
           Business.Entities.Materias pla = new Business.Entities.Materias();
           Data.Database.MateriasD pl = new Data.Database.MateriasD();
           pla.BuscarMaterias = desc_materia;
           return pl.GetOne(pla);
       }
       public static string Insertar(string desc_materia, int hs_semanal, int hs_total,int idplan)
       {
           Business.Entities.Materias pla = new Business.Entities.Materias();
           Data.Database.MateriasD pl = new Data.Database.MateriasD();

           pla.Desc_Materia = desc_materia;
           pla.Hs_Semanales = hs_semanal;
           pla.Hs_Totales = hs_total;
           pla.Id_Plan = idplan;

           return pl.Insertar(pla);
       }
       public static string Editar(int idmateria,string desc_materia, int hs_semanal, int hs_total, int idplan)
       {
           Business.Entities.Materias pla = new Business.Entities.Materias();
           Data.Database.MateriasD pl = new Data.Database.MateriasD();

           pla.Id_Materia = idmateria;
           pla.Desc_Materia = desc_materia;
           pla.Hs_Semanales = hs_semanal;
           pla.Hs_Totales = hs_total;
           pla.Id_Plan = idplan;

           return pl.Update(pla);
       }
       public static string Delete(int id)
       {
           Business.Entities.Materias pla = new Business.Entities.Materias();
           Data.Database.MateriasD pl = new Data.Database.MateriasD();

           pla.Id_Materia = id;
           return pl.Delete(pla);
       }
    }
}
