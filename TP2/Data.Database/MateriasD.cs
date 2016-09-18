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
       public List<Business.Entities.Materias> GetByMateria(string Tbuscado)
       {
           List<Materias> lista = new List<Materias>();
           try
           {
               this.OpenConnection();
               SqlCommand cmdmateria = new SqlCommand("select ma.id_materia,ma.desc_materia,pl.desc_plan,ma.hs_semanales,ma.hs_totales from materias ma inner join planes pl on ma.id_plan=pl.id_plan where ma.desc_materia like @Tbuscado + '%'", SqlConn);
               cmdmateria.Parameters.Add("@Tbuscado", SqlDbType.VarChar, 50).Value = Tbuscado;
               SqlDataReader drmateria = cmdmateria.ExecuteReader();

               while (drmateria.Read())
               {
                   Materias com = new Materias();

                   com.Id_Materia = drmateria.IsDBNull(0) ? Convert.ToInt32(string.Empty) : (Convert.ToInt32(drmateria["id_materia"]));
                   com.Desc_Materia = drmateria.IsDBNull(1) ? string.Empty : drmateria["desc_materia"].ToString();
                   com.Plan = drmateria.IsDBNull(2) ? string.Empty : ((string)drmateria["desc_plan"]);
                   com.Hs_Semanales = drmateria.IsDBNull(3) ? Convert.ToInt32(string.Empty) : (int)drmateria["hs_semanales"];
                   com.Hs_Totales = drmateria.IsDBNull(3) ? Convert.ToInt32(string.Empty) : (int)drmateria["hs_totales"];
                   lista.Add(com);
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
           return lista;
       }
       protected void Insertar(Materias mat) 
       {          
           try
           {
               this.OpenConnection();
               SqlCommand cmdMateria = new SqlCommand("insert into materias(desc_materia,hs_semanales,hs_totales,id_plan)" +
               " values(@desc_materia,@hs_semanales,@hs_totales,@id_plan)", SqlConn);

               cmdMateria.Parameters.Add("desc_materia", SqlDbType.VarChar, 50).Value = mat.Desc_Materia;
               cmdMateria.Parameters.Add("hs_semanales", SqlDbType.Int).Value = mat.Hs_Semanales;
               cmdMateria.Parameters.Add("hs_totales", SqlDbType.Int).Value = mat.Hs_Totales;
               cmdMateria.Parameters.Add("id_plan", SqlDbType.Int).Value = mat.Id_Plan;

              cmdMateria.ExecuteNonQuery();

           }
           catch (Exception Ex)
           {
               Exception ExcepcionManejada = new Exception("Error al crear usuario", Ex);
               throw ExcepcionManejada;
               throw;
           }
           finally
           {
              
                   this.CloseConnection();
           }
       }

       protected void Delete(Materias mat)
       {           
           try
           {
               this.OpenConnection();
               SqlCommand cmdelete = new SqlCommand("delete materias where id_materia=@id_materia", SqlConn);
               cmdelete.Parameters.Add("@id_materia", SqlDbType.Int).Value = mat.Id_Materia;
              Convert.ToInt32(cmdelete.ExecuteNonQuery());
           }
           catch (Exception Ex)
           {
               Exception ExcepcionManejada = new Exception("Error al elimanar usuario", Ex);
               throw ExcepcionManejada;
           }
           finally
           {
               if (SqlConn.State == ConnectionState.Open)
                   this.CloseConnection();
           }          
       }
       protected void Update(Materias pla)
       {
          try
           {
               this.OpenConnection();
               SqlCommand cmdSave = new SqlCommand("update materias set desc_materia = @desc_materia,hs_semanales=@hs_semanales,hs_totales=@hs_totales,id_plan=@id_plan where id_materia=@id ", SqlConn);

               cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = pla.Id_Materia;
               cmdSave.Parameters.Add("@desc_materia", SqlDbType.VarChar,50).Value = pla.Desc_Materia;
               cmdSave.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = pla.Hs_Semanales;
               cmdSave.Parameters.Add("@hs_totales", SqlDbType.Int).Value = pla.Hs_Totales;
               cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = pla.Id_Plan;

               cmdSave.ExecuteNonQuery();
           }
           catch (Exception Ex)
           {
               Exception ExcepcionManejada = new Exception("Error al midificar datos de la materia", Ex);
               throw ExcepcionManejada;
               throw;
           }
           finally
           {
               if (SqlConn.State == ConnectionState.Open)
                   this.CloseConnection();
           }           
       }

       public void Save(Materias materia)
       {
           if (materia.Estado == BusinessEntity.Estados.Eliminar)
           {
               this.Delete(materia);
           }
           else if (materia.Estado == BusinessEntity.Estados.Nuevo)
           {
               this.Insertar(materia);
           }

           else if (materia.Estado == BusinessEntity.Estados.Modificar)
           {
               this.Update(materia);
           }
           materia.Estado = BusinessEntity.Estados.No_Modificar;
       }
    }
}
