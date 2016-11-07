using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class Alumnos_InscripcionesLogic
    {
         private Data.Database.Alumnos_InscripcionesD _Alumno;

         public Data.Database.Alumnos_InscripcionesD Alumno
        {
            get { return _Alumno; }
            set { _Alumno = value; }
        }
        public Alumnos_InscripcionesLogic()
        {
            Alumno = new Data.Database.Alumnos_InscripcionesD();
        }
       public List<AlumnoInscripciones> GetAll()
       {
           return Alumno.GetAll();
       }
       public List<AlumnoInscripciones> GetByInscripto(int tipo)
       {
           return Alumno.GetByInscripto(tipo);
       }
       public List<AlumnoInscripciones> GetByGetByDevolverEstadoMateria(int tipo)
       {
           return Alumno.GetByDevolverEstadoMateria(tipo);
       }
       public List<AlumnoInscripciones> GetByMateriasAprobada()
       {
           return Alumno.GetByMateriasAprobada();
       }

       public List<Cursos> GetoneCupo(string desc_Com)
       {
           return Alumno.GetoneCupo(desc_Com);
       }
       public void Insertar(Business.Entities.AlumnoInscripciones alum)
       {
           Alumno.Save(alum);
       }
       public void Editar(Business.Entities.AlumnoInscripciones alum)
       {
           Alumno.Save(alum);
       }
       public void Delete(Business.Entities.AlumnoInscripciones alum)
       {
           Alumno.Save(alum);
       }
    }
}
