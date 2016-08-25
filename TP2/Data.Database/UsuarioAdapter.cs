using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using Data.Database;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class UsuarioAdapter:Adapter
    {
        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
        //private static List<Usuario> _Usuarios;

        //private static List<Usuario> Usuarios
        //{
        //    get
        //    {
        //        if (_Usuarios == null)
        //        {
        //            _Usuarios = new List<Business.Entities.Usuario>();
        //            Business.Entities.Usuario usr;
        //            usr = new Business.Entities.Usuario();
        //            usr.Id_Usuario = 1;
        //            usr.Estado = Business.Entities.BusinessEntity.Estados.No_Modificar;
        //            //usr.Nombre = "Casimiro";
        //            //usr.Apellido = "Cegado";
        //            usr.Nombre_Usuario = "casicegado";
        //            usr.Clave = "miro";
        //            //usr.Email = "casimirocegado@gmail.com";
        //            usr.Habilitado = true;
        //            _Usuarios.Add(usr);

        //            usr = new Business.Entities.Usuario();
        //            usr.Id_Usuario = 2;
        //            usr.Estado = Business.Entities.BusinessEntity.Estados.No_Modificar;
        //            //usr.Nombre = "Armando Esteban";
        //            //usr.Apellido = "Quito";
        //            usr.Nombre_Usuario = "aequito";
        //            usr.Clave = "carpintero";
        //            //usr.Email = "armandoquito@gmail.com";
        //            usr.Habilitado = true;
        //            _Usuarios.Add(usr);

        //            usr = new Business.Entities.Usuario();
        //            usr.Id_Usuario = 3;
        //            usr.Estado = Business.Entities.BusinessEntity.Estados.No_Modificar;
        //            //usr.Nombre = "Alan";
        //            //usr.Apellido = "Brado";
        //            usr.Nombre_Usuario = "alanbrado";
        //            usr.Clave = "abrete sesamo";
        //            //usr.Email = "alanbrado@gmail.com";
        //            usr.Habilitado = true;
        //            _Usuarios.Add(usr);

        //        }
        //        return _Usuarios;
        //    }
        //}
        #endregion
        
        public  List<Usuario> GetAll()
        {
           List<Usuario> usuarios = new List<Usuario>();
           int op;
           try
           {
               this.OpenConnection();
               SqlCommand cmdUsuarios = new SqlCommand("select u.id_usuario,p.id_persona,u.nombre_usuario,u.clave,u.habilitado,u.cambia_clave,p.tipo_persona from usuarios u inner join personas p on p.id_persona=u.id_persona", SqlConn);
               SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
               while (drUsuarios.Read())
               {
                   Usuario usr = new Usuario();
                   usr.Id_Usuario = (int)drUsuarios["id_usuario"];
                   usr.Id_persona = (int)drUsuarios["id_persona"];
                   usr.Nombre_Usuario = (string)drUsuarios["nombre_usuario"];
                   usr.Clave = (string)drUsuarios["clave"];
                   op = (int)drUsuarios["tipo_persona"];
                   if (op==1)
                   {
                       usr.Tipo=Convert.ToString(Data.Database.Personas.gestion.Adminstrador);
                   }
                   else if (op==2)
                   {
                       usr.Tipo=Convert.ToString(Data.Database.Personas.gestion.Profesor);
                   }
                   else
                   {
                       usr.Tipo = Convert.ToString(Data.Database.Personas.gestion.Alumno);
                   }

                   usr.Habilitado = (bool)drUsuarios["habilitado"];
                   usr.Cambia_Clave = (bool)drUsuarios["cambia_clave"];
                   
                   //usr.Email = (string)drUsuarios["email"];
                   usuarios.Add(usr);
                   //drUsuarios.Close();
                   //this.CloseConnection();
               }
               drUsuarios.Close();
           }
           catch (Exception ex)
           {
               Exception ExcepcionManejada = new Exception("No se Econtrar la lista", ex);
           }
            finally     
           {
               this.CloseConnection();
           }
            return usuarios;          
                
        }

        public Business.Entities.Usuario GetOne(int ID)
        {
            Usuario usr = new Usuario();                   
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios where id_usuario=@ID", SqlConn);
                cmdUsuarios.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                while (drUsuarios.Read())
                {
                    usr.Id_Usuario = (int)drUsuarios["id_usuario"];
                    usr.Nombre_Usuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    //usr.Email = (string)drUsuarios["email"];
                    //usuarios.Add(usr);
                    //drUsuarios.Close();
                    //this.CloseConnection();
                }
                drUsuarios.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("No se Econtrar l lista", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return usr;
            
                
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete usuarios where id_usuario=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al elimanar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Update(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("update usuarios set nombre_usuario=@nombre_usuario"+
                "clave=@clave,habilitado=@habilitado where id_usuario=@id",SqlConn);

                cmdSave.Parameters.Add("@id",SqlDbType.Int).Value=usuario.Id_Usuario;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar,50).Value = usuario.Nombre_Usuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar,50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al midificar datos del usuario", Ex);
                throw ExcepcionManejada;
                throw;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into usuarios(nombre_usuario,clave,habilitado,cambia_clave,id_persona)"+
                                                     "value(@nombre_usuario,@clave,@habilitado,@Cambia_clave,@id_persona", SqlConn);

                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.Nombre_Usuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@cambi_clave", SqlDbType.Bit).Value = usuario.Cambia_Clave;
                cmdSave.Parameters.Add("@id_persona", SqlDbType.Bit).Value = usuario.Id_persona;
               
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

        public void Save(Usuario usuario)
        {
            if (usuario.Estado == BusinessEntity.Estados.Eliminar)
            {
                this.Delete(usuario.Id_Usuario);
            }
            else if (usuario.Estado == BusinessEntity.Estados.Nuevo)
            {
                this.Insert(usuario);
            }
            
            else if (usuario.Estado == BusinessEntity.Estados.Modificar)
            {
                this.Update(usuario);
            }
            usuario.Estado = BusinessEntity.Estados.No_Modificar;            
        }
        public DataTable Login(Business.Entities.Usuario lg)
        {
            DataTable dtresul = new DataTable("usuario");
            try
            {
                this.OpenConnection();
                SqlCommand cmlogin = new SqlCommand("select usr.id_usuario,per.nombre,per.apellido,usr.habilitado,per.tipo_persona from usuarios usr inner join personas per on per.id_persona=usr.id_persona where usr.nombre_usuario like @nombre_usuario and usr.clave like @clave",SqlConn);
                
                SqlParameter parame = new SqlParameter();
                parame.ParameterName = "nombre_usuario";
                parame.SqlDbType = SqlDbType.VarChar;
                parame.Size = 50;
                parame.Value = lg.Nombre_Usuario;
                cmlogin.Parameters.Add(parame);

                SqlParameter parausuio = new SqlParameter();
                parausuio.ParameterName = "clave";
                parausuio.SqlDbType = SqlDbType.VarChar;
                parausuio.Size = 50;
                parausuio.Value = lg.Nombre_Usuario;
                cmlogin.Parameters.Add(parausuio);

                SqlDataAdapter drplan = new SqlDataAdapter(cmlogin);
                drplan.Fill(dtresul);
            }
            catch (Exception)
            {

                dtresul=null;
            }
            return dtresul;
        }
    }
}
