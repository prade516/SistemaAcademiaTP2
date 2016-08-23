using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
   public class ModuloUsuario
    {
         private int _IdModuloUsuario;
       private int _IdModulo;
       private int _IdUsuario;
       private bool _Alta;
       private bool _Baja;
       private bool _Modificacion;
       private bool _Consulta;


       public int IdModuloUsuario
       {
           get { return _IdModuloUsuario; }
           set { _IdModuloUsuario = value; }
       }
       
       public int IdModulo
       {
           get { return _IdModulo; }
           set { _IdModulo = value; }
       }

       public int IdUsuario
       {
           get { return _IdUsuario; }
           set { _IdUsuario = value; }
       }

       public bool Alta
       {
           get { return _Alta; }
           set { _Alta = value; }
       }

       public bool Baja
       {
           get { return _Baja; }
           set { _Baja = value; }
       }

       public bool Modificacion
       {
           get { return _Modificacion; }
           set { _Modificacion = value; }
       }

       public bool Consulta
       {
           get { return _Consulta; }
           set { _Consulta = value; }
       }
       public ModuloUsuario() 
       {
       }
       public ModuloUsuario(int idmodulosusuarios,int idmodulo,int idusuario,bool alta,bool baja,bool modificacion,bool consulta)
       {
           this.IdModuloUsuario = idmodulosusuarios;
           this.IdModulo = idmodulo;
           this.IdUsuario = idusuario;
           this.Alta = alta;
           this.Baja = baja;
           this.Modificacion = modificacion;
           this.Consulta = consulta;
       }
    }
}
