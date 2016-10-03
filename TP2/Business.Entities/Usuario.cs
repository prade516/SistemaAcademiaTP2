using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
   public  class Usuario:BusinessEntity
    {
        private int _Id_Usuario;
        private int _id_persona;
        private string _Nombre_Usuario;
        private string _Clave;
        private string _Tipo;
        private bool _Habilitado;
        private string _Email;
        private bool _Cambia_Clave;
        private string txtbuscado;
        private string _Apellido;
        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public string Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }

        //Usuario ur = new Usuario();                                                
        public int Id_Usuario
        {
            get { return _Id_Usuario; }
            set { _Id_Usuario = value; }
        }
      public int Id_persona
        {
            get { return _id_persona; }
            set { _id_persona = value; }
        }
     public string Nombre_Usuario
        {
            get { return _Nombre_Usuario; }
            set { _Nombre_Usuario = value; }
        }
     public string Clave
        {
            get { return _Clave; }
            set { _Clave = value; }
        }
     public string Tipo
     {
         get { return _Tipo; }
         set { _Tipo = value; }
     }
      public bool Habilitado
        {
            get { return _Habilitado; }
            set { _Habilitado = value; }
        }

      public string Email
      {
          get { return _Email; }
          set { _Email = value; }
      }
       public bool Cambia_Clave
        {
            get { return _Cambia_Clave; }
            set { _Cambia_Clave = value; }
        }
      public string Txtbuscado
       {
           get { return txtbuscado; }
           set { txtbuscado = value; }
       }
       public Usuario()
       { 
       }
       public Usuario(int id_usuario, string nombre_usuario, string clave, bool habilitado,string tipo, bool cambia_clave, int id_persona, string txtbuscado,string email,string nombre,string apellido)
       {
           this.Id_Usuario = id_usuario;
           this.Nombre_Usuario = nombre_usuario;
           this.Clave = clave;
           this.Habilitado = habilitado;
           this.Email = email;
           this.Cambia_Clave = cambia_clave;
           this.Id_persona = id_persona;
           this.Txtbuscado = txtbuscado;
           this.Tipo = tipo;
           this.Nombre = nombre;
           this.Apellido = apellido;
       }
    }
}
