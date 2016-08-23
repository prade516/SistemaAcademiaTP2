using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class DocentesCursos
    {
         private int _IdDictado;
        private int _IdCurso;
        private int _IdDocente;
        private int _cargo;
                
        public int IdDictado
        {
            get { return _IdDictado; }
            set { _IdDictado = value; }
        }
        public int IdCurso
        {
            get { return _IdCurso; }
            set { _IdCurso = value; }
        }
       public int IdDocente
        {
            get { return _IdDocente; }
            set { _IdDocente = value; }
        }
        public int Cargo
        {
            get { return _cargo; }
            set { _cargo = value; }
        }
       public DocentesCursos()
        {

        }
       public DocentesCursos(int id_dictado,int id_curso,int id_docente,int cargo)
       {
           this.IdDictado = id_dictado;
           this.IdCurso = IdCurso;
           this.IdDocente = id_docente;
           this.Cargo = cargo;
           
       }
    }
}
