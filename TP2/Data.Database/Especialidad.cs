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

       public DataTable GetOne(_Especialidades Txtbuscado)
       {
           DataTable dtresul = new DataTable("Especialidad");
           try
           {
               this.OpenConnection();
               SqlCommand cmdEspecialidad = new SqlCommand("select * from especialidades where desc_especialidad like @textobuscar + '%'", SqlConn);
               SqlParameter parame = new SqlParameter();
               parame.ParameterName = "textobuscar";
               parame.SqlDbType = SqlDbType.VarChar;
               parame.Size = 50;
               parame.Value = Txtbuscado.Txtbuscado;
               cmdEspecialidad.Parameters.Add(parame);
               
               SqlDataAdapter drEspecialidad = new SqlDataAdapter(cmdEspecialidad);

               drEspecialidad.Fill(dtresul);
           }
           catch (Exception ex)
           {
               Exception ExcepcionManejada = new Exception("No se Econtrar la lista", ex);
           }
           //finally
           //{
           //    this.CloseConnection();
           //}
           return dtresul;
       }

       public string Delete(_Especialidades Espe)
       {
           string resp = "";
           try
           {
               this.OpenConnection();
               SqlCommand cmdDelete = new SqlCommand("delete especialidades where id_especialidad=@id_especialidad", SqlConn);
               cmdDelete.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = Espe.Idespecialidad;
               resp = cmdDelete.ExecuteNonQuery() == 1 ? "OK" : "No se Elimino el registro";
           }
           catch (Exception Ex)
           {
               resp = Ex.Message;
           }
           finally
           {
               if(SqlConn.State==ConnectionState.Open)
               this.CloseConnection();
           }
           return resp;
       }

       public  string Update(_Especialidades Espe)
       {
           string resp = "";
           try
           {
               this.OpenConnection();
               SqlCommand cmdSave = new SqlCommand("update especialidades set desc_especialidad=@desc_especialidad where id_especialidad=@id_especialidad", SqlConn);

               cmdSave.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = Espe.Idespecialidad;
               cmdSave.Parameters.Add("@desc_especialidad", SqlDbType.VarChar, 50).Value = Espe.DescEspecialidad;

               resp = cmdSave.ExecuteNonQuery() == 1 ? "OK" : "No se Actualizo el registro";
           }
           catch (Exception Ex)
           {
               resp = Ex.Message;
           }
           finally
           {
               if(SqlConn.State==ConnectionState.Open)
                  this.CloseConnection();
           }
           return resp;
       }
       public string Insert(_Especialidades espe)
       {
           string resp = "";
           try
           {
               this.OpenConnection();
               SqlCommand cmdSave = new SqlCommand("insert into especialidades(desc_especialidad)values(@desc_especialidad)", SqlConn);

               cmdSave.Parameters.Add("@desc_especialidad", SqlDbType.VarChar, 50).Value = espe.DescEspecialidad;              
               //espe.Idespecialidad = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
               resp = Convert.ToString(cmdSave.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el registro");
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
