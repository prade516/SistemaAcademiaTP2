using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data;
using System.Data.SqlClient;
using System.Data;


namespace Data.Database
{
    public class ComisionesD : Adapter
    {
        public List<Comisiones> GetAll()
        {
            List<Comisiones> comi = new List<Comisiones>();
            try
            {
                OpenConnection();
                SqlCommand cmdcomisiones = new SqlCommand("select cm.id_comision,cm.desc_comision,cm.anio_especialidad,pl.desc_plan from comisiones cm inner join planes pl on cm.id_plan=pl.id_plan ", SqlConn);
                SqlDataReader drcomisiones = cmdcomisiones.ExecuteReader();
                while (drcomisiones.Read())
                {
                    Comisiones com = new Comisiones();
                    //_Especialidades esp = new _Especialidades();
                    com.IdComision = drcomisiones.IsDBNull(0) ? Convert.ToInt32(string.Empty) : (Convert.ToInt32(drcomisiones["id_comision"]));
                    com.DescComision = drcomisiones.IsDBNull(1) ? string.Empty : drcomisiones["desc_comision"].ToString();
                    com.AnioEspecialidad = drcomisiones.IsDBNull(2) ? Convert.ToInt32(string.Empty) : ((int)drcomisiones["anio_especialidad"]);
                    com.Plan = drcomisiones.IsDBNull(3) ? string.Empty : (string)drcomisiones["desc_plan"];
                    
                    comi.Add(com);
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
            return comi;
        }
        public List<Business.Entities.Comisiones> GetByComision(string Tbuscado)
        {
            List<Comisiones> lista = new List<Comisiones>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdcomision = new SqlCommand("select cm.id_comision,cm.desc_comision,cm.anio_especialidad,pl.desc_plan  from comisiones cm inner join planes pl on cm.id_plan=pl.id_plan where cm.desc_comision like @Tbuscado + '%'", SqlConn);
                cmdcomision.Parameters.Add("@Tbuscado", SqlDbType.VarChar, 50).Value = Tbuscado;
                SqlDataReader drcomision = cmdcomision.ExecuteReader();

                while (drcomision.Read())
                {
                    Comisiones com = new Comisiones();

                    com.IdComision = drcomision.IsDBNull(0) ? Convert.ToInt32(string.Empty):(Convert.ToInt32(drcomision["id_comision"]));                 
                    com.DescComision = drcomision.IsDBNull(1)? string.Empty : drcomision["desc_comision"].ToString();
                    com.AnioEspecialidad = drcomision.IsDBNull(2) ? Convert.ToInt32(string.Empty) : ((int)drcomision["anio_especialidad"]);
                    com.Plan = drcomision.IsDBNull(3) ? string.Empty : (string)drcomision["desc_plan"];
                    lista.Add(com);

                }
                drcomision.Close();
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
        protected void Delete(Comisiones comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete comisiones where id_comision=@id_comision", SqlConn);
                cmdDelete.Parameters.Add("@id_comision", SqlDbType.Int).Value = comision.IdComision;

                Convert.ToInt32(cmdDelete.ExecuteNonQuery());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al elimanar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Comisiones comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("update comisiones set desc_comision=@desc_comision" +
                "anio_especialidad=@anio_especialidad,id_plan=@id_plan where id_comision=@id_comision", SqlConn);

                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = comision.IdComision;
                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.DescComision;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.IdPlan;

                cmdSave.ExecuteNonQuery();
               
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al midificar datos del usuario", Ex);
                throw ExcepcionManejada;
                throw;
            }
            finally
            {
                this.CloseConnection();
            }
        }

          protected void Insert(Comisiones comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into comisiones(desc_comision,anio_especialidad,id_plan)" +
                                                     " values(@desc_comision,@anio_especialidad,@id_plan)", SqlConn);

                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.DescComision;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.IdPlan;
               
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear la comision", Ex);
                throw ExcepcionManejada;
                throw;
            }
            finally
            {
                this.CloseConnection();
            }
        }

          public void Save(Comisiones comision)
          {
              if (comision.Estado == BusinessEntity.Estados.Eliminar)
              {
                  this.Delete(comision);
              }
              else if (comision.Estado == BusinessEntity.Estados.Nuevo)
              {
                  this.Insert(comision);
              }

              else if (comision.Estado == BusinessEntity.Estados.Modificar)
              {
                  this.Update(comision);
              }
              comision.Estado = BusinessEntity.Estados.No_Modificar;
          }

    }
}