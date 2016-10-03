using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using System.Data;
using System.Data.SqlClient;
using Business.Entities;

namespace Data.Database
{
public class Plan:Adapter
 {
 public List<Planes> GetAll()
  {
      List<Planes> pl = new List<Planes>();
    try 
	{
        this.OpenConnection();
        SqlCommand cmdplan = new SqlCommand("select id_plan,esp.id_especialidad,esp.desc_especialidad,desc_plan  from planes inner join especialidades esp on planes.id_especialidad= esp.id_especialidad", SqlConn);
        SqlDataReader drplan = cmdplan.ExecuteReader();
        while (drplan.Read())
        {
            Planes pla = new Planes();
            //_Especialidades esp = new _Especialidades();
            pla.Codigo = (int)drplan["id_plan"];
            pla.Id_Especialidad=(int)drplan["id_especialidad"];
            pla.Especialidad = (string)drplan["desc_especialidad"];
            pla.Plan = (string)drplan["desc_plan"];
            pl.Add(pla);
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
 public List<Planes> GetByMostrar()
 {
     List<Planes> pl = new List<Planes>();
     try
     {
         this.OpenConnection();
         SqlCommand cmdplan = new SqlCommand("select pla.id_plan,(pla.desc_plan +'---'+esp.desc_especialidad) as plans from  planes pla inner join especialidades esp  on esp.id_especialidad=pla.id_especialidad", SqlConn);
         SqlDataReader drplan = cmdplan.ExecuteReader();
         while (drplan.Read())
         {
             Planes pla = new Planes();
             //_Especialidades esp = new _Especialidades();
             pla.Codigo = (int)drplan["id_plan"];
             //pla.Id_Especialidad = (int)drplan["id_especialidad"];
             //pla.Plan = (string)drplan["desc_plan"];
             pla.Especialidad = (string)drplan["plans"];
            
             pl.Add(pla);
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
 public List<Business.Entities.Planes> GetByPlan(string Tbuscado)
 {
     List<Planes> lista = new List<Planes>();
     try
     {
         this.OpenConnection();
         SqlCommand cmdplan = new SqlCommand("select planes.id_plan,planes.desc_plan,especialidades.desc_especialidad  from planes inner join especialidades on planes.id_especialidad= especialidades.id_especialidad where desc_plan like @Tbuscado + '%'", SqlConn);
         cmdplan.Parameters.Add("@Tbuscado", SqlDbType.VarChar, 50).Value = Tbuscado;
        SqlDataReader drplan = cmdplan.ExecuteReader();
         while (drplan.Read())
         {
           Planes  plan = new Planes();

           plan.Codigo = drplan.IsDBNull(0) ? Convert.ToInt32(string.Empty) : (Convert.ToInt32(drplan["id_plan"]));
           plan.Plan = drplan.IsDBNull(1) ? string.Empty : drplan["desc_plan"].ToString();
           plan.Especialidad = drplan.IsDBNull(2) ? Convert.ToString(string.Empty) : ((string)drplan["desc_especialidad"]);
           lista.Add(plan);
         }
         drplan.Close();
        }
     catch (Exception ex)
     {
         Exception ExcepcionManejada = new Exception("No se Econtrar la lista", ex);          
     }
     return lista;
 }
protected void Delete(Planes Codigo)
    {
        
        try
        {
            this.OpenConnection();
            SqlCommand cmdelete = new SqlCommand("delete planes where id_plan=@id_plan",SqlConn);
            cmdelete.Parameters.Add("@id_plan", SqlDbType.Int).Value =Codigo.Codigo;

          cmdelete.ExecuteNonQuery();
        }
        catch (Exception Ex)
        {
            Exception ExcepcionManejada = new Exception("Error al elimanar el plan", Ex);
            throw ExcepcionManejada;
        }
        finally
        {
            if (SqlConn.State == ConnectionState.Open)
                this.CloseConnection();
        }
        
    }
protected void Update (Planes pla)
{    
    try
    {
        this.OpenConnection();
        SqlCommand cmdSave = new SqlCommand("update planes set desc_plan = @desc_plan,id_especialidad=@id_especialidad where id_plan=@id_plan",SqlConn);

        cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = pla.Codigo;
        cmdSave.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = pla.Plan;
        cmdSave.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = pla.Id_Especialidad;

        Convert.ToInt32(cmdSave.ExecuteNonQuery());
    }
    catch (Exception Ex)
    {
        Exception ExcepcionManejada = new Exception("Error al Actualizar el plan", Ex);
        throw ExcepcionManejada;
    }
    finally
    {
        if (SqlConn.State == ConnectionState.Open)
            this.CloseConnection();
    }
   
}
protected void Insert(Planes pla)
{
    try
    {
        this.OpenConnection();
        SqlCommand cmdSave = new SqlCommand("insert into planes (desc_plan,id_especialidad)values(@desc_plan,@id_especialidad)",SqlConn);

        cmdSave.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = pla.Plan;
        cmdSave.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = pla.Id_Especialidad;

     cmdSave.ExecuteNonQuery();
    
    }
    catch (Exception Ex)
    {
        Exception ExcepcionManejada = new Exception("Error al Insertar el plan", Ex);
        throw ExcepcionManejada;
    }
    finally
    {
        if (SqlConn.State == ConnectionState.Open)
            this.CloseConnection();
    }   
}
public void Save(Planes comision)
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
