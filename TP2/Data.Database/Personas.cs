﻿using System;
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
           Administrador=1,
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
                   per.Codigo = (int)drpersonas["id_persona"];
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
                       per.Tipo_Persona = Convert.ToString(gestion.Administrador);
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
       public DataTable GetOne(_Personas Txtbuscado)
       {
           DataTable dtresul = new DataTable("Persona");
           //_Personas per = new _Personas();
           //Adapter c = new Adapter();
           try
           {
               this.OpenConnection();
               int opc;
               SqlCommand cmdpersonas = new SqlCommand("select per.nombre,per.apellido,per.legajo,pl.desc_plan from personas per inner join planes pl on per.id_plan=pl.id_plan where per.legajo like @textobuscar + '%'", SqlConn);
               SqlParameter parame = new SqlParameter();
               parame.ParameterName = "textobuscar";
               parame.SqlDbType = SqlDbType.VarChar;
               parame.Size = 50;
               parame.Value = Txtbuscado.Txtbuscado;
               cmdpersonas.Parameters.Add(parame);

               SqlDataAdapter drplan = new SqlDataAdapter(cmdpersonas);
               drplan.Fill(dtresul);

               SqlDataReader drpersona = cmdpersonas.ExecuteReader();
           }
           catch (Exception ex)
           {
               Exception ExcepcionManejada = new Exception("No se Econtrar la lista", ex);
           }
           return dtresul;
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

                   if (opc==Convert.ToString(gestion.Administrador) )
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

               cmdSave.Parameters.Add("@id_persona", SqlDbType.Int).Value = persona.Codigo;
               cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
               cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
               cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar,50).Value = persona.Direccion;
               cmdSave.Parameters.Add("@email", SqlDbType.VarChar,50).Value = persona.Email;
               cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
               cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.Fecha_Nac;
               cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
               opc = persona.Tipo_Persona;
               if (opc == Convert.ToString(gestion.Administrador))
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
               SqlCommand cmdDelete = new SqlCommand("delete personas where id_persona=@id_persona", SqlConn);
               cmdDelete.Parameters.Add("@id_persona", SqlDbType.Int).Value = ID.Codigo;
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
