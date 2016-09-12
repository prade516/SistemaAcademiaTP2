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
               SqlCommand cmdplan = new SqlCommand("select ma.id_materia,ma.desc_materia,pl.desc_plan,ma.hs_semanales,ma.hs_totales,pl.id_plan from materias ma inner join planes pl on ma.id_plan=pl.id_plan", SqlConn);
               SqlDataReader drmateria = cmdplan.ExecuteReader();
               while (drmateria.Read())
               {
                   Materias pla = new Materias();
                   //_Especialidades esp = new _Especialidades();
                   pla.Id_Materia = (int)drmateria["id_materia"];
                   pla.Desc_Materia = (string)drmateria["desc_materia"];
                   pla.Plan = (string)drmateria["desc_plan"];
                   pla.Hs_Semanales = (int)drmateria["hs_semanales"];
                   pla.Hs_Totales = (int)drmateria["hs_totales"];
                   pla.Id_Plan = (int)drmateria["id_plan"];                   
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
       public DataTable GetOne(Materias Tbuscado)
       {
           DataTable dtresul = new DataTable("materia");
           try
           {
               this.OpenConnection();
               SqlCommand cmdmateria = new SqlCommand("select ma.id_materia,ma.desc_materia,pl.desc_plan,ma.hs_semanales,ma.hs_totales from materias ma inner join planes pl on ma.id_plan=pl.id_plan where ma.desc_materia like @textobuscar + '%'", SqlConn);
               SqlParameter parame = new SqlParameter();
               parame.ParameterName = "textobuscar";
               parame.SqlDbType = SqlDbType.VarChar;
               parame.Size = 50;
               parame.Value = Tbuscado.BuscarMaterias;
               cmdmateria.Parameters.Add(parame);

               SqlDataAdapter drmateria = new SqlDataAdapter(cmdmateria);

               drmateria.Fill(dtresul);

           }
           catch (Exception ex)
           {
               Exception ExcepcionManejada = new Exception("No se Econtrar la lista", ex);
           }
           return dtresul;
       }
       public string Insertar(Materias mat) 
       {
           string resp = "";
           try
           {
               this.OpenConnection();
               SqlCommand cmdMateria = new SqlCommand("insert into materias(desc_materia,hs_semanales,hs_totales,id_plan)"+
               " values(@desc_materia,@hs_semanales,@hs_totales,@id_plan)", SqlConn);

               cmdMateria.Parameters.Add("desc_materia", SqlDbType.VarChar, 50).Value = mat.Desc_Materia;
               cmdMateria.Parameters.Add("hs_semanales", SqlDbType.Int).Value = mat.Hs_Semanales;
               cmdMateria.Parameters.Add("hs_totales", SqlDbType.Int).Value = mat.Hs_Totales;
               cmdMateria.Parameters.Add("id_plan", SqlDbType.Int).Value = mat.Id_Plan;

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

       public string Delete(Materias mat)
       {
           string resp = "";
           try
           {
               this.OpenConnection();
               SqlCommand cmdelete = new SqlCommand("delete materias where id_materia=@id_materia", SqlConn);
               cmdelete.Parameters.Add("@id_materia", SqlDbType.Int).Value = mat.Id_Materia;
               resp = cmdelete.ExecuteNonQuery() == 1 ? "OK" : "No se Elimino el registro";
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

               cmdSave.Parameters.Add("@id_materia", SqlDbType.Int).Value = pla.Id_Materia;
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
