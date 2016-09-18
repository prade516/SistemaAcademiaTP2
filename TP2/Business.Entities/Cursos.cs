using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
   public class Cursos:BusinessEntity
    {
       private int _IdCurso;
        private int _IdMateria;
        private int _IdComision;
        private int _AnioCalendario;
        private int _Cupo;
        private string _desc_materia;
        private string _desc_comision;
        private string _Tbuscado;

        public string Desc_comision
        {
            get { return _desc_comision; }
            set { _desc_comision = value; }
        }
        public string TextoBuscado
        {
            get { return _Tbuscado; }
            set { _Tbuscado = value; }
        }
        public string Desc_materia
        {
            get { return _desc_materia; }
            set { _desc_materia = value; }
        }

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

        public Cursos(int id_curso,int id_materia,int id_comision,int anio_calendario,int cupo,string materia,string comision,string texto)
        {
            this.IdCurso = id_curso;
            this.IdMateria = id_materia;
            this.IdComision = id_comision;
            this.AnioCalendario = anio_calendario;
            this.Cupo = cupo;
            this.Desc_comision = comision;
            this.Desc_materia = materia;
            this.TextoBuscado = texto;
        }
    }
}
