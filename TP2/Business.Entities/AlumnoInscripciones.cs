﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class AlumnoInscripciones:BusinessEntity
    {
         private int _IdInscripcion;
        private int _IdAlumnos;
        private int _IdCurso;
        private string _Condicion;
        private int _Nota;
        private string _plan;
        private string _Desc_Materia;
        private int _Anio_especialidad;
        private int _Cupo;
        private string _Nombre;
        private string _Apellido;
        private string _Desc_Comision;
        private string _Tipo;

        public string Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        public string Desc_Comision
        {
            get { return _Desc_Comision; }
            set { _Desc_Comision = value; }
        }

        public string Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public int Cupo
        {
            get { return _Cupo; }
            set { _Cupo = value; }
        }

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
        public int Anio_especialidad
        {
            get { return _Anio_especialidad; }
            set { _Anio_especialidad = value; }
        }

        public string Desc_Materia
        {
            get { return _Desc_Materia; }
            set { _Desc_Materia = value; }
        }

        public string Plan
        {
            get { return _plan; }
            set { _plan = value; }
        }
        public AlumnoInscripciones()
        { 
        }
        public AlumnoInscripciones(int id_inscripcion, int id_alumnos, int id_curso, string condicion, int nota, string plan, string materia, int anio,int cupo,string nombre,string apellido,string comision,string tipo)
        {
            this.IdInscripcion = id_inscripcion;
            this.IdAlumnos = id_alumnos;
            this.IdCurso = id_curso;
            this.Condicion = condicion;
            this.Nota = nota;
            this.Plan = plan;
            this.Anio_especialidad = anio;
            this.Desc_Materia = materia;
            this.Cupo = cupo;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Desc_Comision = comision;
            this.Tipo = tipo;
        }
    }
}
