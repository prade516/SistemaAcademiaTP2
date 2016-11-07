using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    public class Alumnos_InscripcionesD:Adapter
    {

        public List<AlumnoInscripciones> GetAll()
        {
            List<AlumnoInscripciones> pl = new List<AlumnoInscripciones>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdplan = new SqlCommand("select  DISTINCT com.anio_especialidad,mat.id_materia,mat.desc_materia,pl.desc_plan from cursos cur inner join materias mat on cur.id_materia= mat.id_materia inner join comisiones com on cur.id_comision=com.id_comision inner join planes pl on com.id_plan=pl.id_plan ", SqlConn);
                SqlDataReader drmateria = cmdplan.ExecuteReader();
                while (drmateria.Read())
                {
                    AlumnoInscripciones alumno = new AlumnoInscripciones();
                   
                    //_Especialidades esp = new _Especialidades();
                    alumno.Anio_especialidad = (int)drmateria["anio_especialidad"];
                    alumno.ID = (int)drmateria["id_materia"];
                    alumno.Desc_Materia = (string)drmateria["desc_materia"];
                    alumno.Plan = (string)drmateria["desc_plan"];
                    //alumno.IdAlumnos = (int)drmateria["id_inscripcion"];                   
                                        
                    pl.Add(alumno);
                    
                }
            }

            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("No se Econtrar la lista", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return pl;
        }

        public List<AlumnoInscripciones> GetByInscripto(int id_mat)
        {
            List<AlumnoInscripciones> lista = new List<AlumnoInscripciones>();           
            try
            {
                OpenConnection();
                SqlCommand cmdCurso = new SqlCommand("select cur.id_curso,com.desc_comision,count(mat.id_materia) as cantidad,mat.desc_materia from cursos cur inner join materias mat on cur.id_materia=mat.id_materia inner join comisiones com on cur.id_comision=com.id_comision where mat.id_materia=@tipo_persona group by cur.id_curso,com.desc_comision,mat.id_materia,mat.desc_materia", SqlConn);
                cmdCurso.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = id_mat;
                SqlDataReader drCurso = cmdCurso.ExecuteReader();
                while (drCurso.Read())
                {
                    AlumnoInscripciones alumno = new AlumnoInscripciones();
                    int contrala = drCurso.IsDBNull(2) ? Convert.ToInt32(string.Empty) : (Convert.ToInt32(drCurso["cantidad"]));
                    if (contrala < 31)
                    {
                        alumno.IdCurso = drCurso.IsDBNull(0) ? Convert.ToInt32(string.Empty) : (Convert.ToInt32(drCurso["id_curso"]));                        
                        alumno.Desc_Comision = drCurso.IsDBNull(1) ? string.Empty : ((string)drCurso["desc_comision"]);
                        alumno.Desc_Materia = drCurso.IsDBNull(1) ? string.Empty : ((string)drCurso["desc_materia"]);
                        lista.Add(alumno);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("No se Econtrar la lista", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return lista;
        }


        public List<AlumnoInscripciones> GetByDevolverEstadoMateria(int id_mat)
        {
            List<AlumnoInscripciones> lista = new List<AlumnoInscripciones>();
            try
            {
                OpenConnection();
                SqlCommand cmdCurso = new SqlCommand(" select aluins.id_alumno,mat.desc_materia,aluins.condicion from alumnos_inscripciones aluins inner join cursos curs on curs.id_curso=aluins.id_curso inner join materias mat on mat.id_materia=curs.id_materia where aluins.id_alumno=@id_alumno", SqlConn);
                cmdCurso.Parameters.Add("@id_alumno", SqlDbType.Int).Value = id_mat;
                SqlDataReader drCurso = cmdCurso.ExecuteReader();
                while (drCurso.Read())
                {
                    AlumnoInscripciones alumno = new AlumnoInscripciones();
                  
                        alumno.IdAlumnos = drCurso.IsDBNull(0) ? Convert.ToInt32(string.Empty) : (Convert.ToInt32(drCurso["id_alumno"]));
                        alumno.Desc_Materia = drCurso.IsDBNull(1) ? string.Empty : ((string)drCurso["desc_materia"]);
                        alumno.Condicion = drCurso.IsDBNull(1) ? string.Empty : ((string)drCurso["condicion"]);
                      
                        lista.Add(alumno);
                   

                }
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("No se Econtrar la lista", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return lista;
        }


        public List<AlumnoInscripciones> GetByMateriasAprobada()
        {
            List<AlumnoInscripciones> lista = new List<AlumnoInscripciones>();
            try
            {
                OpenConnection();
                SqlCommand cmdCurso = new SqlCommand(" select aluins.id_inscripcion,mat.desc_materia,aluins.nota from alumnos_inscripciones aluins" +
                                                     " inner join personas per on aluins.id_alumno=per.id_persona inner join cursos cur on cur.id_curso=aluins.id_curso"+
                                                     " inner join materias mat on cur.id_materia=mat.id_materia where aluins.nota>=4", SqlConn);
                SqlDataReader drCurso = cmdCurso.ExecuteReader();
                while (drCurso.Read())
                {
                    AlumnoInscripciones alumno = new AlumnoInscripciones();                    
                    
                        alumno.IdInscripcion = drCurso.IsDBNull(0) ? Convert.ToInt32(string.Empty) : (Convert.ToInt32(drCurso["id_inscripcion"]));
                        alumno.Desc_Materia = drCurso.IsDBNull(1) ? string.Empty : ((string)(drCurso["desc_materia"]));
                        //alumno.Apellido = drCurso.IsDBNull(2) ? string.Empty : ((string)drCurso["Apellido"]);
                        alumno.Nota = drCurso.IsDBNull(2) ? Convert.ToInt32(string.Empty) : (Convert.ToInt32(drCurso["nota"]));
                        lista.Add(alumno);                 

                }
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("No se Econtrar la lista", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return lista;
        }

        public List<Cursos> GetoneCupo(string desc_mat)
        {
            List<Cursos> lista = new List<Cursos>();
            
            try
            {
                OpenConnection();
                SqlCommand cmdCurso = new SqlCommand(" select count(mat.id_materia)as Cantidad from alumnos_inscripciones alins inner join cursos cur on alins.id_curso= cur.id_curso inner join materias mat on cur.id_materia=mat.id_materia where mat.desc_materia=@desc_materia", SqlConn);
                cmdCurso.Parameters.Add("@desc_materia", SqlDbType.VarChar,50).Value = desc_mat;
                SqlDataReader drCurso = cmdCurso.ExecuteReader();
                while (drCurso.Read())
                {
                    Cursos alumno = new Cursos();
                    alumno.IdMateria = drCurso.IsDBNull(0) ? Convert.ToInt32(string.Empty) : (Convert.ToInt32(drCurso["Cantidad"]));
                    lista.Add(alumno);                  
                }
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("No se Econtrar la lista", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return lista;
        }

        protected void Insertar(AlumnoInscripciones alum)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInscripcion = new SqlCommand("insert into alumnos_inscripciones(id_alumno,id_curso,condicion,nota) values(@id_alumno,@id_curso,@condicion,@nota)", SqlConn);

                cmdInscripcion.Parameters.Add("id_alumno", SqlDbType.Int).Value = alum.IdAlumnos;
                cmdInscripcion.Parameters.Add("id_curso", SqlDbType.Int).Value = alum.IdCurso;
                cmdInscripcion.Parameters.Add("condicion", SqlDbType.VarChar,50).Value = alum.Condicion;
                cmdInscripcion.Parameters.Add("nota", SqlDbType.Int).Value = alum.Nota;

                cmdInscripcion.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear la Incripcion", Ex);
                throw ExcepcionManejada;
                throw;
            }
            finally
            {

                this.CloseConnection();
            }
        }

        protected void Delete(AlumnoInscripciones alum)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdelete = new SqlCommand("delete alumnos_inscripciones where id_alumno=@id_alumno", SqlConn);
                cmdelete.Parameters.Add("@id_alumno", SqlDbType.Int).Value = alum.IdAlumnos;
                Convert.ToInt32(cmdelete.ExecuteNonQuery());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al elimanar la Inscripcion", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                if (SqlConn.State == ConnectionState.Open)
                    this.CloseConnection();
            }
        }
        protected void Update(AlumnoInscripciones alum)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("update materias set id_alumno = @id_alumno,id_curso=@id_curso,condicion=@condicion,nota=@nota where id_inscripcion=@id ", SqlConn);
               
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = alum.IdInscripcion;
                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = alum.IdAlumnos;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = alum.IdCurso;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar,50).Value = alum.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = alum.Nota;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al midificar ", Ex);
                throw ExcepcionManejada;
                throw;
            }
            finally
            {
                if (SqlConn.State == ConnectionState.Open)
                    this.CloseConnection();
            }
        }
        public void Save(AlumnoInscripciones alum)
        {
            if (alum.Estado == BusinessEntity.Estados.Eliminar)
            {
                this.Delete(alum);
            }
            else if (alum.Estado == BusinessEntity.Estados.Nuevo)
            {
                this.Insertar(alum);
            }

            else if (alum.Estado == BusinessEntity.Estados.Modificar)
            {
                this.Update(alum);
            }
            alum.Estado = BusinessEntity.Estados.No_Modificar;
        }
    }
}
