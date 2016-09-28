using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
   public class CursoLogic
    {
        private Data.Database.CursoD _Curso;

        public Data.Database.CursoD Curso
        {
            get { return _Curso; }
            set { _Curso = value; }
        }
        public CursoLogic()
        {
            Curso = new Data.Database.CursoD();
        }
        public List<Cursos> GetAll()
        {
            return Curso.GetAll();
        }
        public List<Cursos> GetByCurso(string desc_materia)
        {
            return Curso.GetByCurso(desc_materia);
        }
        public void Insertar(Cursos curso)
        {
            Curso.Save(curso);
        }
        public void Update(Cursos curso)
        {
            Curso.Save(curso);
        }
        public void Delete(Cursos curso)
        {
            Curso.Save(curso);
        }
    }
}
