using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    class Materias
    {
         private int _Id_Materia;
        private string _Desc_Materia;
        private int _Hs_Semanales;
        private int _Hs_Totales;
        private int _Id_Plan;

        
        public int Id_Materia
        {
            get { return _Id_Materia; }
            set { _Id_Materia = value; }
        }
        public string Desc_Materia
        {
            get { return _Desc_Materia; }
            set { _Desc_Materia = value; }
        }
        public int Hs_Semanales
        {
            get { return _Hs_Semanales; }
            set { _Hs_Semanales = value; }
        }
        public int Hs_Totales
        {
            get { return _Hs_Totales; }
            set { _Hs_Totales = value; }
        }
        public int Id_Plan
        {
            get { return _Id_Plan; }
            set { _Id_Plan = value; }
        }
       public Materias()
        {
        }
       public Materias(int id_materia,string desc_materia,int hs_semanales,int hs_totales,int id_plan)
       {
           this.Id_Materia = id_materia;
           this.Desc_Materia = desc_materia;
           this.Hs_Semanales = hs_semanales;
           this.Hs_Totales = hs_totales;
           this.Id_Plan = id_plan;
       }
    }
}
