using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Comisiones:BusinessEntity
    {
         private int _IdComision;
        private string _DescComision;
        private int _AnioEspecialidad;
        private int _IdPlan;
        private string _Plan;
        private string _BuscarComision;

        public string BuscarComision
        {
            get { return _BuscarComision; }
            set { _BuscarComision = value; }
        }

        public string Plan
        {
            get { return _Plan; }
            set { _Plan = value; }
        }

        public int IdComision
        {
            get { return _IdComision; }
            set { _IdComision = value; }
        }
        public string DescComision
        {
            get { return _DescComision; }
            set { _DescComision = value; }
        }
        public int AnioEspecialidad
        {
            get { return _AnioEspecialidad; }
            set { _AnioEspecialidad = value; }
        }
         public int IdPlan
        {
            get { return _IdPlan; }
            set { _IdPlan = value; }
        }
         public Comisiones()
         { 
         
         }
         public Comisiones(int id_comision,string desc_comision,int anio_especialidad,int id_plan,string plan,string buscarComision)
         {
             this.IdComision = id_comision;
             this.DescComision = desc_comision;
             this.AnioEspecialidad = anio_especialidad;
             this.IdPlan = id_plan;
             this.Plan = plan;
             this.BuscarComision = buscarComision;
         }
    }
}
