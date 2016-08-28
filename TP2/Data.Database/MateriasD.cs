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
       public string Insertar(Materias mat) 
       {
           string resp = "";
           try
           {
               this.OpenConnection();
               SqlCommand cmdMateria = new SqlCommand("insert into materias(desc_materia,hs_semanales,hs_totales,id_plan)"+
               " values(?,?,?,?)",SqlConn);

               cmdMateria.Parameters.Add("desc_materia", SqlDbType.VarChar, 50).Value = mat.Desc_Materia;
               cmdMateria.Parameters.Add("hs_semanales", SqlDbType.Int).Value = mat.Hs_Semanales;
               cmdMateria.Parameters.Add("hs_totales", SqlDbType.Int).Value = mat.Hs_Totales;
               cmdMateria.Parameters.Add("id_plan", SqlDbType.Int).Value = mat.Desc_Materia;

               resp = cmdMateria.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el registro";

           }
           catch (Exception Ex)
           {
               resp = Ex.Message;
           }
           finally
           {
               if (SqlConn.State == ConnectionState.Open)
                   this.CloseConnection();
           }
           return resp;
       }

       public string Update(Materias pla)
       {
           string resp = "";
           try
           {
               this.OpenConnection();
               SqlCommand cmdSave = new SqlCommand("update materias set desc_materia = @desc_materia,hs_semanales=@hs_semanales,hs_totales=@hs_semanales,id_plan=@id_plan where id_materia=@id_materia", SqlConn);

               cmdSave.Parameters.Add("@desc_materia", SqlDbType.VarChar,50).Value = pla.Desc_Materia;
               cmdSave.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = pla.Hs_Semanales;
               cmdSave.Parameters.Add("@hs_totales", SqlDbType.Int).Value = pla.Hs_Totales;
               cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = pla.Id_Plan;

               resp = cmdSave.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualiza el registro";
           }
           catch (Exception Ex)
           {
               resp = Ex.Message;
           }
           finally
           {
               if (SqlConn.State == ConnectionState.Open)
                   this.CloseConnection();
           }
           return resp;
       }
    }
}
