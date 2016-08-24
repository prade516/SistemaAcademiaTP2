using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;
using System.Data;



namespace Business.Logic
{
   public class UsuarioLogic : BusinessLogic
    {

        private Data.Database.UsuarioAdapter _UsuarioData;
       
        public Data.Database.UsuarioAdapter UsuarioData
        {
            get { return _UsuarioData; }
            set { _UsuarioData = value; }
        }
       public UsuarioLogic()
       {
           UsuarioData = new Data.Database.UsuarioAdapter();
       }
       public List<Usuario> GetAll()
       {
           return UsuarioData.GetAll();
       }
       
       public Business.Entities.Usuario GetOne(int id)
       {
           return UsuarioData.GetOne(id);
       }
       public void Delete(int id) 
       {
           UsuarioData.Delete(id);
       }
       public void  Save(Business.Entities.Usuario usur)
       {
           UsuarioData.Save(usur);
       }

      public static DataTable Login(string usuario,string password)
      {
          Usuario usr = new Usuario();
          UsuarioAdapter usradap = new   UsuarioAdapter();
          usr.Nombre_Usuario = usuario;
          usr.Clave = password;
          return usradap.Login(usr);
      }
    }
}
