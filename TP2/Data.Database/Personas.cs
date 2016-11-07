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
           Administrador=1,
           Profesor,
           Alumno
       }
       public List<_Personas> GetAllAdministrador()
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
                   opc = (int)drpersonas["tipo_persona"];
                   if (opc==1)
                   {
                       per.Codigo = (int)drpersonas["id_persona"];
                       per.Nombre = (string)drpersonas["nombre"];
                       per.Apellido = (string)drpersonas["apellido"];
                       per.Direccion = (string)drpersonas["direccion"];
                       per.Email = (string)drpersonas["email"];
                       per.Telefono = (string)drpersonas["telefono"];
                       per.Fecha_Nac = (DateTime)drpersonas["fecha_nac"];
                       per.Legajo = (int)drpersonas["legajo"];
                       per.Tipo_Persona = Convert.ToString(gestion.Administrador);
                       per.Id_Plan = (int)drpersonas["id_plan"];
                       per.Sexo = (string)drpersonas["sexo"];
                       personas.Add(per);
                   }
                  
                   
                   
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

       public List<_Personas> GetAllProfesor()
       {
           List<_Personas> personas = new List<_Personas>();

           try
           {

               //this.OpenConnection();
               this.OpenConnection();
               int opc;
               SqlCommand cmdPersonas = new SqlCommand("select * from personas", SqlConn);
               SqlDataReader drpersonas = cmdPersonas.ExecuteReader();

               while (drpersonas.Read())
               {
                  _Personas per = new _Personas();
                  opc = (int)drpersonas["tipo_persona"];
                if (opc == 2)
                  {
                      per.Codigo = (int)drpersonas["id_persona"];
                      per.Nombre = (string)drpersonas["nombre"];
                      per.Apellido = (string)drpersonas["apellido"];
                      per.Direccion = (string)drpersonas["direccion"];
                      per.Email = (string)drpersonas["email"];
                      per.Telefono = (string)drpersonas["telefono"];
                      per.Fecha_Nac = (DateTime)drpersonas["fecha_nac"];
                      per.Legajo = (int)drpersonas["legajo"];
                      per.Id_Plan = (int)drpersonas["id_plan"];
                      per.Sexo = (string)drpersonas["sexo"];
                      per.Tipo_Persona = Convert.ToString(gestion.Profesor);
                      personas.Add(per);
                      
                  }
                  
                 

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

       public List<_Personas> GetAllAlumno()
       {
           List<_Personas> personas = new List<_Personas>();           
           try
           {

               //this.OpenConnection();
               this.OpenConnection();
               int opc;
               SqlCommand cmdPersonas = new SqlCommand("select * from personas", SqlConn);
               SqlDataReader drpersonas = cmdPersonas.ExecuteReader();
               while (drpersonas.Read())
               {
                   _Personas per = new _Personas();
                   opc = (int)drpersonas["tipo_persona"];
                   if (opc == 3)
                   {
                       per.Codigo = (int)drpersonas["id_persona"];
                       per.Nombre = (string)drpersonas["nombre"];
                       per.Apellido = (string)drpersonas["apellido"];
                       per.Direccion = (string)drpersonas["direccion"];
                       per.Email = (string)drpersonas["email"];
                       per.Telefono = (string)drpersonas["telefono"];
                       per.Fecha_Nac = (DateTime)drpersonas["fecha_nac"];
                       per.Legajo = (int)drpersonas["legajo"];
                       per.Tipo_Persona = Convert.ToString(gestion.Alumno);
                       per.Id_Plan = (int)drpersonas["id_plan"];
                       per.Sexo = (string)drpersonas["sexo"];
                       personas.Add(per);
                   }



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

       public List<_Personas> GetByPersona(int Txtbuscado)
       {
           List<_Personas> Lista = new List<_Personas>();
           try
           {
               this.OpenConnection();
               SqlCommand cmdpersonas = new SqlCommand("select per.id_Persona,per.nombre,per.apellido,per.legajo,pl.desc_plan from personas per inner join planes pl on per.id_plan=pl.id_plan where per.legajo like @textobuscar + '%'", SqlConn);
               cmdpersonas.Parameters.Add("@textobuscar",SqlDbType.VarChar,50).Value=Txtbuscado;
              
               SqlDataReader drPersonas=cmdpersonas.ExecuteReader();
               while (drPersonas.Read())
               {
                   _Personas per = new _Personas();

                   per.Codigo = drPersonas.IsDBNull(0) ? Convert.ToInt32(string.Empty) : (Convert.ToInt32(drPersonas["id_persona"]));
                   per.Nombre = drPersonas.IsDBNull(1) ? string.Empty : drPersonas["nombre"].ToString();
                   per.Apellido = drPersonas.IsDBNull(2) ? string.Empty : ((string)drPersonas["apellido"]);
                   per.Legajo = drPersonas.IsDBNull(3) ? Convert.ToInt32(string.Empty) : (int)drPersonas["legajo"];
                   per.Plan = drPersonas.IsDBNull(2) ? string.Empty : ((string)drPersonas["desc_plan"]);
                   Lista.Add(per);
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
           return Lista;
       }
       protected void Insert(_Personas persona)
       {           
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
          
                cmdSave.ExecuteNonQuery();
    
           }
           catch (Exception Ex)
           {
               Exception ExcepcionManejada = new Exception("Error al crear la Persona", Ex);
               throw ExcepcionManejada;
               throw;
           }
           finally
           {
               if(SqlConn.State==ConnectionState.Open)
                     this.CloseConnection();
           }
           
       }

      protected void Update(_Personas persona)
       {           
           try
           {
               this.OpenConnection();
               string opc;
               SqlCommand cmdSave = new SqlCommand("update personas set nombre=@nombre,apellido=@apellido,direccion=@direccion,email=@email,telefono=@telefono,fecha_nac=@fecha_nac,legajo=@legajo,tipo_persona=@tipo_persona,id_plan=@id_plan,sexo=@sexo where id_persona=@id_persona", SqlConn);

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
               cmdSave.Parameters.Add("@sexo", SqlDbType.VarChar,1).Value = persona.Sexo;
              
               Convert.ToInt32(cmdSave.ExecuteNonQuery());
   
           }
           catch (Exception Ex)
           {
               Exception ExcepcionManejada = new Exception("Error al midificar la persona", Ex);
               throw ExcepcionManejada;
               throw;
           }
           finally
           {
               if (SqlConn.State == ConnectionState.Open)
                   this.CloseConnection();
           }          
       }

       protected void Delete(_Personas ID)
       {
           try
           {
               this.OpenConnection();
               SqlCommand cmdDelete = new SqlCommand("delete personas where id_persona=@id_persona", SqlConn);
               cmdDelete.Parameters.Add("@id_persona", SqlDbType.Int).Value = ID.Codigo;
               cmdDelete.ExecuteNonQuery();

               Convert.ToInt32(cmdDelete.ExecuteNonQuery());

           }
           catch (Exception Ex)
           {
               Exception ExcepcionManejada = new Exception("Error al elimanar la Persona", Ex);
               throw ExcepcionManejada;
           }
           finally
           {
               if (SqlConn.State == ConnectionState.Open)
                   this.CloseConnection();
           }
       }

       public void Save(_Personas persona)
       {
           if (persona.Estado == BusinessEntity.Estados.Eliminar)
           {
               this.Delete(persona);
           }
           else if (persona.Estado == BusinessEntity.Estados.Nuevo)
           {
               this.Insert(persona);
           }

           else if (persona.Estado == BusinessEntity.Estados.Modificar)
           {
               this.Update(persona);
           }
           persona.Estado = BusinessEntity.Estados.No_Modificar;
       }

    }
}
