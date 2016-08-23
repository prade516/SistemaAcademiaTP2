using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
   public class Cursos
    {
       private int _IdCurso;
        private int _IdMateria;
        private int _IdComision;
        private int _AnioCalendario;
        private int _Cupo;

        public int IdCurso
        {
            get { return _IdCurso; }
            set { _IdCurso = value; }
        }
        public int IdMateria
        {
            get { return _IdMateria; }
            set { _IdMateria = value; }
        }
        public int IdComision
        {
            get { return _IdComision; }
            set { _IdComision = value; }
        }
        public int AnioCalendario
        {
            get { return _AnioCalendario; }
            set { _AnioCalendario = value; }
        }
        public int Cupo
        {
            get { return _Cupo; }
            set { _Cupo = value; }
        }

        public Cursos()
        {
        }

        public Cursos(int id_curso,int id_materia,int id_comision,int anio_calendario,int cupo)
        {
            this.IdCurso = id_curso;
            this.IdMateria = id_materia;
            this.IdComision = id_comision;
            this.AnioCalendario = anio_calendario;
            this.Cupo = cupo;
        }
    }
}
