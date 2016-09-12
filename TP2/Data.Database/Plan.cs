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
 public  DataTable GetOne(Planes Tbuscado)
 {
     DataTable dtresul = new DataTable();
     try
     {
         this.OpenConnection();
         SqlCommand cmdplan = new SqlCommand("select planes.id_plan,planes.desc_plan,especialidades.desc_especialidad  from planes inner join especialidades on planes.id_especialidad= especialidades.id_especialidad where desc_plan like @textobuscar + '%'",SqlConn);
         SqlParameter parame = new SqlParameter();
         parame.ParameterName = "textobuscar";
         parame.SqlDbType = SqlDbType.VarChar;
         parame.Size = 50;
         parame.Value = Tbuscado.Txtbuscado;
         cmdplan.Parameters.Add(parame);

         SqlDataAdapter drplan = new SqlDataAdapter(cmdplan);
         drplan.Fill(dtresul);

     }
     catch (Exception ex)
     {
         Exception ExcepcionManejada = new Exception("No se Econtrar la lista", ex);          
     }
     return dtresul;
 }
public string Delete(Planes pla)
    {
        string resp = "";
        try
        {
            this.OpenConnection();
            SqlCommand cmdelete = new SqlCommand("delete planes where id_plan=@id_plan",SqlConn);
            cmdelete.Parameters.Add("@id_plan", SqlDbType.Int).Value = pla.Codigo;
            resp = cmdelete.ExecuteNonQuery() == 1 ? "OK" : "No se Elimino el registro";
        }
        catch (Exception Ex)
        {
            resp = Ex.Message;
        }
        finally
        {
            if (SqlConn.State == ConnectionState.Open)
                this.CloseConnection();
        }
        return resp;
    }
public string Update (Planes pla)
{
    string resp = "";
    try
    {
        this.OpenConnection();
        SqlCommand cmdSave = new SqlCommand("update planes set desc_plan = @desc_plan,id_especialidad=@id_especialidad where id_plan=@id_plan",SqlConn);

        cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = pla.Codigo;
        cmdSave.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = pla.Plan;
        cmdSave.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = pla.Id_Especialidad;

        resp = cmdSave.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualiza el registro";
    }
    catch (Exception Ex)
    {
        resp = Ex.Message;
    }
    finally
    {
        if (SqlConn.State == ConnectionState.Open)
            this.CloseConnection();
    }
    return resp;
}
public string Insert(Planes pla)
{
    string resp = "";
    try
    {
        this.OpenConnection();
        SqlCommand cmdSave = new SqlCommand("insert into planes (desc_plan,id_especialidad)values(@desc_plan,@id_especialidad)",SqlConn);

        cmdSave.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = pla.Plan;
        cmdSave.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = pla.Id_Especialidad;

        resp = cmdSave.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el registro";
    
    }
    catch (Exception Ex)
    {
        resp = Ex.Message;
    }
    finally
    {
        if (SqlConn.State == ConnectionState.Open)
            this.CloseConnection();
    }
    return resp;
}
}
}
