using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
   public class MateriasD:Adapter
    {
       public List<Materias> GetAll()
       {
           List<Materias> pl = new List<Materias>();
           try
           {
               this.OpenConnection();
               SqlCommand cmdplan = new SqlCommand("select id_materia,desc_materia,hs_semanales,hs_totales,id_plan from materias", SqlConn);
               SqlDataReader drplan = cmdplan.ExecuteReader();
               while (drplan.Read())
               {
                   Materias pla = new Materias();
                   //_Especialidades esp = new _Especialidades();
                   pla.Id_Materia = (int)drplan["id_materia"];
                   pla.Desc_Materia = (string)drplan["desc_materia"];
                   pla.Hs_Semanales = (int)drplan["hs_semanales"];
                   pla.Hs_Totales = (int)drplan["hs_totales"];
                   pla.Id_Plan = (int)drplan["id_plan"];
                   pl.Add(pla);
               }
           }

           catch (Exception ex)
           {
               Exception ExcepcionManejada = new Exception("No se Econtrar la lista", ex);
           }
           finally
           {
               this.CloseConnection();
           }
           return pl;
       }
    }
}
