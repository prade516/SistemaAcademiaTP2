using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using System.Data;
using System.Data.SqlClient;
using Business.Entities;

namespace Data.Database
{
   public class Especialidad:Adapter
    {
       public List<_Especialidades> GetAll()
       {
           List<_Especialidades> especiali = new List<_Especialidades>();
           try
           {
               this.OpenConnection();
               SqlCommand cmdEspecialidad = new SqlCommand("select * from especialidades", SqlConn);
               SqlDataReader drEspecialidad = cmdEspecialidad.ExecuteReader();
               while (drEspecialidad.Read())
               {
                   _Especialidades espe = new _Especialidades();
                   espe.Idespecialidad = (int)drEspecialidad["id_especialidad"];
                   espe.DescEspecialidad = (string)drEspecialidad["desc_Especialidad"];
                   especiali.Add(espe);
                   //drUsuarios.Close();
                   //this.CloseConnection();
               }
               drEspecialidad.Close();
           }
           catch (Exception ex)
           {
               Exception ExcepcionManejada = new Exception("No se Econtrar la lista", ex);
           }
           finally
           {
               this.CloseConnection();
           }
           return especiali;
       }

       public List<_Especialidades> GetByEspecialidad(string Txtbuscado)
       {
           List<_Especialidades> lista = new List<_Especialidades>();
           try
           {
               this.OpenConnection();
               SqlCommand cmdEspecialidad = new SqlCommand("select id_especialidad,desc_especialidad from especialidades where desc_especialidad like @textobuscar + '%'", SqlConn);
               cmdEspecialidad.Parameters.Add("@Tbuscado", SqlDbType.VarChar, 50).Value = Txtbuscado;
               SqlDataReader drEspecialidad = cmdEspecialidad.ExecuteReader();
               while (drEspecialidad.Read())
               {
                   _Especialidades especialidad = new _Especialidades();

                   especialidad.Idespecialidad = drEspecialidad.IsDBNull(0) ? Convert.ToInt32(string.Empty) : (Convert.ToInt32(drEspecialidad["id_especialidad"]));
                   especialidad.DescEspecialidad = drEspecialidad.IsDBNull(1) ? string.Empty : drEspecialidad["desc_especialidad"].ToString();
                 
                   lista.Add(especialidad);
               }
               drEspecialidad.Close();
           }
           catch (Exception ex)
           {
               Exception ExcepcionManejada = new Exception("No se Econtrar la lista", ex);
           }
           return lista;
       }

      protected void Delete(_Especialidades Espe)
       {
           try
           {
               this.OpenConnection();
               SqlCommand cmdDelete = new SqlCommand("delete especialidades where id_especialidad=@id_especialidad", SqlConn);
               cmdDelete.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = Espe.Idespecialidad;
               cmdDelete.ExecuteNonQuery();
           }
           catch (Exception Ex)
           {
               Exception ExcepcionManejada = new Exception("Error al elimanar la especialidad", Ex);
               throw ExcepcionManejada;
           }
           finally
           {
               if(SqlConn.State==ConnectionState.Open)
               this.CloseConnection();
           }
         
       }

     protected void Update(_Especialidades Espe)
       {
           try
           {
               this.OpenConnection();
               SqlCommand cmdSave = new SqlCommand("update especialidades set desc_especialidad=@desc_especialidad where id_especialidad=@id_especialidad", SqlConn);

               cmdSave.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = Espe.Idespecialidad;
               cmdSave.Parameters.Add("@desc_especialidad", SqlDbType.VarChar, 50).Value = Espe.DescEspecialidad;

               Convert.ToInt32(cmdSave.ExecuteNonQuery());
           }
           catch (Exception Ex)
           {
               Exception ExcepcionManejada = new Exception("Error al elimanar el plan", Ex);
               throw ExcepcionManejada;
           }
           finally
           {
               if(SqlConn.State==ConnectionState.Open)
                  this.CloseConnection();
           }
       }
      protected void Insert(_Especialidades espe)
       {          
           try
           {
               this.OpenConnection();
               SqlCommand cmdSave = new SqlCommand("insert into especialidades(desc_especialidad)values(@desc_especialidad)", SqlConn);

               cmdSave.Parameters.Add("@desc_especialidad", SqlDbType.VarChar, 50).Value = espe.DescEspecialidad;              
               //espe.Idespecialidad = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
              Convert.ToString(cmdSave.ExecuteNonQuery());
           }
           catch (Exception Ex)
           {
               Exception ExcepcionManejada = new Exception("Error al elimanar el plan", Ex);
               throw ExcepcionManejada;
           }
           finally
           {
               if (SqlConn.State == ConnectionState.Open)
                   this.CloseConnection();                             
           }          
       }

      public void Save(_Especialidades especialidad)
      {
          if (especialidad.Estado == BusinessEntity.Estados.Eliminar)
          {
              this.Delete(especialidad);
          }
          else if (especialidad.Estado == BusinessEntity.Estados.Nuevo)
          {
              this.Insert(especialidad);
          }

          else if (especialidad.Estado == BusinessEntity.Estados.Modificar)
          {
              this.Update(especialidad);
          }
          especialidad.Estado = BusinessEntity.Estados.No_Modificar;
      }
    }
}
