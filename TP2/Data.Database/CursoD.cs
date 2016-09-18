using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
   public class CursoD:Adapter
    {
       protected List<Cursos> GetAll()
       {
           List<Cursos> lista = new List<Cursos>();
           try
           {
               OpenConnection();
               SqlCommand cmdCurso = new SqlCommand("select cur.id_curso,mat.desc_materia,com.desc_comision,cur.cupo from cursos cur inner join materias mat on cur.id_materia=mat.id_materia inner join comisiones com on cur.id_comision=com.id_comision",SqlConn);
               SqlDataReader drCurso = cmdCurso.ExecuteReader();
               while (drCurso.Read())
               {
                   Cursos curso = new Cursos();

                   curso.IdComision = drCurso.IsDBNull(0) ? Convert.ToInt32(string.Empty) : (Convert.ToInt32(drCurso["id_curso"]));
                   curso.Desc_materia = drCurso.IsDBNull(1) ? string.Empty : drCurso["desc_materia"].ToString();
                   curso.Desc_comision = drCurso.IsDBNull(2) ? string.Empty : ((string)drCurso["desc_comision"]);
                   curso.Cupo = drCurso.IsDBNull(3) ? Convert.ToInt32(string.Empty) : (int)drCurso["cupo"];

                   lista.Add(curso);
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

       protected List<Cursos> GetByCurso(string Tbuscado)
       {
           List<Cursos> lista = new List<Cursos>();
           try
           {
               OpenConnection();
               SqlCommand cmdCurso = new SqlCommand("select cur.id_curso,mat.desc_materia,com.desc_comision,cur.cupo from cursos cur inner join materias mat on cur.id_materia=mat.id_materia inner join comisiones com on cur.id_comision=com.id_comision where mat.desc_materia like @Tbuscado + '%'", SqlConn);
               cmdCurso.Parameters.Add("@Tbuscado", SqlDbType.VarChar, 50).Value = Tbuscado;
               SqlDataReader drCurso = cmdCurso.ExecuteReader();
               while (drCurso.Read())
               {
                   Cursos curso = new Cursos();

                   curso.IdComision = drCurso.IsDBNull(0) ? Convert.ToInt32(string.Empty) : (Convert.ToInt32(drCurso["id_curso"]));
                   curso.Desc_materia = drCurso.IsDBNull(1) ? string.Empty : drCurso["desc_materia"].ToString();
                   curso.Desc_comision = drCurso.IsDBNull(2) ? string.Empty : ((string)drCurso["desc_comision"]);
                   curso.Cupo = drCurso.IsDBNull(3) ? Convert.ToInt32(string.Empty) : (int)drCurso["cupo"];

                   lista.Add(curso);
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

       protected void Insertar(Cursos curso)
       {
           try
           {
               this.OpenConnection();
               SqlCommand cmdMateria = new SqlCommand("insert into cursos(id_materia,id_comision,anio_calendario,cupo)" +
               " values(@id_materia,@id_comision,@anio_calendario,@cupo)", SqlConn);

               cmdMateria.Parameters.Add("id_materia", SqlDbType.Int).Value = curso.IdMateria;
               cmdMateria.Parameters.Add("id_comision", SqlDbType.Int).Value = curso.IdComision;
               cmdMateria.Parameters.Add("anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
               cmdMateria.Parameters.Add("cupo", SqlDbType.Int).Value = curso.Cupo;

               cmdMateria.ExecuteNonQuery();

           }
           catch (Exception Ex)
           {
               Exception ExcepcionManejada = new Exception("Error al crear el curso", Ex);
               throw ExcepcionManejada;
               throw;
           }
           finally
           {

               this.CloseConnection();
           }
       }

       protected void Delete(Cursos curso)
       {
           try
           {
               this.OpenConnection();
               SqlCommand cmdelete = new SqlCommand("delete cursos where id_curso=@id_curso", SqlConn);
               cmdelete.Parameters.Add("@id_curso", SqlDbType.Int).Value = curso.IdCurso;
               Convert.ToInt32(cmdelete.ExecuteNonQuery());
           }
           catch (Exception Ex)
           {
               Exception ExcepcionManejada = new Exception("Error al elimanar el curso", Ex);
               throw ExcepcionManejada;
           }
           finally
           {
               if (SqlConn.State == ConnectionState.Open)
                   this.CloseConnection();
           }
       }
       protected void Update(Cursos curso)
       {
           try
           {
               this.OpenConnection();
               SqlCommand cmdSave = new SqlCommand("update cursos set id_materia = @id_materia,id_comision=@id_comision,anio_calendario=@anio_calendario,cupo=@cupo where id_curso=@id ", SqlConn);

               cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = curso.IdCurso;
               cmdSave.Parameters.Add("@id_materia", SqlDbType.VarChar, 50).Value = curso.IdMateria;
               cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.IdComision;
               cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
               cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;

               cmdSave.ExecuteNonQuery();
           }
           catch (Exception Ex)
           {
               Exception ExcepcionManejada = new Exception("Error al midificar datos el curso", Ex);
               throw ExcepcionManejada;
               throw;
           }
           finally
           {
               if (SqlConn.State == ConnectionState.Open)
                   this.CloseConnection();
           }
       }

       public void Save(Cursos curso)
       {
           if (curso.Estado == BusinessEntity.Estados.Eliminar)
           {
               this.Delete(curso);
           }
           else if (curso.Estado == BusinessEntity.Estados.Nuevo)
           {
               this.Insertar(curso);
           }

           else if (curso.Estado == BusinessEntity.Estados.Modificar)
           {
               this.Update(curso);
           }
           curso.Estado = BusinessEntity.Estados.No_Modificar;
       }
    }
}
