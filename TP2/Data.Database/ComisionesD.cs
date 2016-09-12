using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class ComisionesD : Adapter
    {
        public List<Comisiones> GetAll()
        {
            List<Comisiones> com = new List<Comisiones>();
            try
            {
                OpenConnection();
                SqlCommand cmdcomisiones = new SqlCommand("select cm.id_comision,cm.desc_comision,cm.anio_especialidad,pl.desc_plan from comisiones cm inner join planes pl on cm.id_plan=pl.id_plan ", SqlConn);
                SqlDataReader drcomisiones = cmdcomisiones.ExecuteReader();
                while (drcomisiones.Read())
                {
                    Comisiones comi = new Comisiones();
                    //_Especialidades esp = new _Especialidades();
                    comi.IdComision = (int)drcomisiones["id_comision"];
                    comi.DescComision = (string)drcomisiones["desc-comision"];
                    comi.AnioEspecialidad = (int)drcomisiones["anio_especialidad"];
                    comi.Plan = (string)drcomisiones["desc_plan"];
                    
                    com.Add(comi);
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
            return com;
        }
    }
}