using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class AlumnoInscripciones
    {
         private int _IdInscripcion;
        private int _IdAlumnos;
        private int _IdCurso;
        private string _Condicion;
        private int _Nota;      
        
        public int IdInscripcion
        {
            get { return _IdInscripcion; }
            set { _IdInscripcion = value; }
        }
        public int IdAlumnos
        {
            get { return _IdAlumnos; }
            set { _IdAlumnos = value; }
        }
        public int IdCurso
        {
            get { return _IdCurso; }
            set { _IdCurso = value; }
        }
        public string Condicion
        {
            get { return _Condicion; }
            set { _Condicion = value; }
        }
        public int Nota
        {
            get { return _Nota; }
            set { _Nota = value; }
        }
        public AlumnoInscripciones()
        { 
        }
        public AlumnoInscripciones(int id_inscripcion,int id_alumnos,int id_curso,string condicion,int nota)
        {
            this.IdInscripcion = id_inscripcion;
            this.IdAlumnos = id_alumnos;
            this.IdCurso = id_curso;
            this.Condicion = condicion;
            this.Nota = nota;
        }
    }
}
