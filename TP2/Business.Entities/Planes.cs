using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Planes:BusinessEntity
    {
        private int _Id_Plan;
       private int _Id_Especialidad;
       private string _Desc_Plan;
       private string _DescEspecialidad;
       private string txtbuscado;
       
       public int Codigo
       {
           get { return _Id_Plan; }
           set { _Id_Plan = value; }
       }
       public int Id_Especialidad
       {
           get { return _Id_Especialidad; }
           set { _Id_Especialidad = value; }
       }
       public string Plan
       {
           get { return _Desc_Plan; }
           set { _Desc_Plan = value; }
       }
       public Planes() 
       {
       }
       public string Especialidad
       {
           get { return _DescEspecialidad; }
           set { _DescEspecialidad = value; }
       }
       public string Txtbuscado
       {
           get { return txtbuscado; }
           set { txtbuscado = value; }
       }
       public Planes(int id_plan,int id_especialidad,string desc_plan,string desc_especialidad, string txtbuscado)
       {
           this.Codigo = id_plan;
           this.Id_Especialidad = id_especialidad;
           this.Plan = desc_plan;
           this.Especialidad = desc_especialidad;
           this.Txtbuscado = txtbuscado;
       }
    }
}
