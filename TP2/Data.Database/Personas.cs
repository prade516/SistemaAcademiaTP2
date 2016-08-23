using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;
using System.Data;
using System.Data.SqlClient;
//using Data.Database;

namespace Data.Database
{
   public class Personas:Adapter
    {
       Adapter c = new Adapter();
       public enum gestion 
       {
           Adminstrador=1,
           Profesor,
           Alumno
       }
       public List<_Personas> GetAll()
       {
           List<_Personas> personas = new List<_Personas>();
          
           try
           {
               
               //this.OpenConnection();
               this.OpenConnection();
               int opc;
               SqlCommand cmdPersonas = new SqlCommand("select * from personas",SqlConn);
               SqlDataReader drpersonas = cmdPersonas.ExecuteReader();
               while (drpersonas.Read())
               {
                   _Personas per = new _Personas();
                   per.Id_Persona = (int)drpersonas["id_persona"];
                   per.Nombre = (string)drpersonas["nombre"];
                   per.Apellido = (string)drpersonas["apellido"];
                   per.Direccion = (string)drpersonas["direccion"];
                   per.Email = (string)drpersonas["email"];
                   per.Telefono = (string)drpersonas["telefono"];
                   per.Fecha_Nac = (DateTime)drpersonas["fecha_nac"];
                   per.Legajo = (int)drpersonas["legajo"];
                   opc = (int)drpersonas["tipo_persona"];
                   if (opc == 1) 
                   {
                       per.Tipo_Persona = Convert.ToString(gestion.Adminstrador);
                   }
                   else if (opc==2)
                   {
                       per.Tipo_Persona = Convert.ToString(gestion.Profesor);
                   }
                   else 
                   {
                       per.Tipo_Persona = Convert.ToString(gestion.Alumno);
                   }
                   per.Id_Plan = (int)drpersonas["id_plan"];
                   per.Sexo = (string)drpersonas["sexo"];
                   personas.Add(per);
                   
               }
               drpersonas.Close();
           }
           catch (Exception ex)
           {
               Exception ExcepcionManejada = new Exception("No se Econtrar la lista", ex);
           }
           finally
           {
               this.CloseConnection();
           }
           return personas;

       }
       public Business.Entities._Personas GetOne(string Txtbuscado)
       {
           //DataTable dtresul = new DataTable("Persona");
           _Personas per = new _Personas();
           //Adapter c = new Adapter();
           try
           {
               this.OpenConnection();
               int opc;
               SqlCommand cmdpersonas = new SqlCommand("select * from personas where legajo= @Txtbuscado", SqlConn);
               cmdpersonas.Parameters.Add("@Txtbuscado", SqlDbType.Int).Value = Txtbuscado;
               //SqlParameter parpersona = new SqlParameter();
               //parpersona.ParameterName="textobuscar";
               //parpersona.SqlDbType=SqlDbType.VarChar;
               //parpersona.Size=50;
               //parpersona.Value=Txtbuscado.Txtbuscado;
               //cmdpersonas.Parameters.Add(parpersona);

               //SqlDataAdapter drpersonas = new SqlDataAdapter(cmdpersonas);
               //drpersonas.Fill(dtresul);

               SqlDataReader drpersona = cmdpersonas.ExecuteReader();
               while (drpersona.Read())
               {
                   //Personas per = new _Personas();
                   per.Id_Persona = (int)drpersona["id_persona"];
                   per.Nombre = (string)drpersona["nombre"];
                   per.Apellido = (string)drpersona["apellido"];
                   per.Direccion = (string)drpersona["direccion"];
                   per.Email = (string)drpersona["email"];  
                   per.Telefono = (string)drpersona["telefono"];
                   per.Fecha_Nac = (DateTime)drpersona["fecha_nac"];                        
                   per.Legajo = (int)drpersona["legajo"];
                   opc = (int)drpersona["tipo_persona"];
                   if (opc == 1)
                   {
                       per.Tipo_Persona = Convert.ToString(gestion.Adminstrador);
                   }
                   else if (opc == 2)
                   {
                       per.Tipo_Persona = Convert.ToString(gestion.Profesor);
                   }
                   else
                   {
                       per.Tipo_Persona = Convert.ToString(gestion.Alumno);
                   }
                   per.Id_Plan = (int)drpersona["id_plan"];
                   per.Sexo = (string)drpersona["sexo"];
               }
               //SqlDataAdapter dr = new SqlDataAdapter(cmdpersonas);
               //dr.Fill(dtresul);
               drpersona.Close();
               
           }
           catch (Exception ex)
           {
               Exception ExcepcionManejada = new Exception("No se Econtrar a la persona Buscada", ex);
           }
           //finally
           //{
           //    this.CloseConnection();
           //}
            return per;;
       }
       public string Insert(_Personas persona)
       {
           string resp="";
           try
           {
               this.OpenConnection();
                string opc;
               SqlCommand cmdSave = new SqlCommand("insert into personas(nombre,apellido,direccion,email,telefono,fecha_nac,legajo,tipo_persona,id_plan,sexo)" +
               "values(@nombre,@apellido,@direccion,@email,@telefono,@fecha_nac,@legajo,@tipo_persona,@id_plan,@sexo)", SqlConn);

               cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
               cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
               cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar,50).Value = persona.Direccion;
               cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
               cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar,50).Value = persona.Telefono;
               cmdSave.Parameters.Add("@fecha_nac", SqlDbType.VarChar, 50).Value = persona.Fecha_Nac;
               cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
               opc = persona.Tipo_Persona;

                   if (opc==Convert.ToString(gestion.Adminstrador) )
                   {
                        cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value =1;
                   }
                   else if (opc ==Convert.ToString(gestion.Profesor))
                   {
                        cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value =2;
                   }
                   else 
                   {
                      cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value =3;
                   }
               cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.Id_Plan;
               cmdSave.Parameters.Add("@sexo",SqlDbType.VarChar,1).Value =persona.Sexo;
               //persona.Id_Persona = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
          
                resp = Convert.ToString(cmdSave.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el registro");
    
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

      public string Update(_Personas persona)
       {
           string resp = "";
           try
           {
               this.OpenConnection();
               string opc;
               SqlCommand cmdSave = new SqlCommand("update personas set nombre=@nombre,apellido=@apellido,direccion=@direccion" +
               "email=@email,telefono=@telefono,fecha_nac=@fecha_nac,legago=@legajo,tipo_persona=@tipo_persona where id_persona=@id", SqlConn);

               cmdSave.Parameters.Add("@id_persona", SqlDbType.Int).Value = persona.Id_Persona;
               cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
               cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
               cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar,50).Value = persona.Direccion;
               cmdSave.Parameters.Add("@email", SqlDbType.VarChar,50).Value = persona.Email;
               cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
               cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.Fecha_Nac;
               cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
               opc = persona.Tipo_Persona;
               if (opc == Convert.ToString(gestion.Adminstrador))
               {
                   cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = 1;
               }
               else if (opc == Convert.ToString(gestion.Profesor))
               {
                   cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = 2;
               }
               else
               {
                   cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = 3;
               }
               cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.Id_Plan;
               cmdSave.Parameters.Add("sexo", SqlDbType.VarChar,1).Value = persona.Sexo;
              
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

       public string Delete(_Personas ID)
       {
           string resp = "";
           try
           {
               this.OpenConnection();
               SqlCommand cmdDelete = new SqlCommand("delete personas where id_persona=@id", SqlConn);
               cmdDelete.Parameters.Add("@id_persona", SqlDbType.Int).Value = ID.Id_Persona;
               cmdDelete.ExecuteNonQuery();

               resp = cmdDelete.ExecuteNonQuery() == 1 ? "OK" : "No se Elimino el registro";

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
