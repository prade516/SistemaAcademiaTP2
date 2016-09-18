using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web.Formulario
{
    public partial class frmcarrera : System.Web.UI.MasterPage
    {
        public string Idtrabajador = "";
        public string Apellidos = "";
        public string Nombre = "";
        public string Acceso = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            GestionUsuario();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //Response.Redirect("frmPlanes.aspx");
        }
        private void GestionUsuario()
        {
            Idtrabajador = (string)(Session["codigo"]);
            Nombre = (string)(Session["Nombre"]);
            Apellidos = (string)(Session["Apellido"]);
            Acceso = (string)(Session["Acesso"]);

            if (Acceso == "1")
            {
                //LinkButton1.Enabled = false;
                
                //this.MenuIngreso.Enabled = true;
                //this.MenuVenta.Enabled = true;
                //this.MenuMantenimiento.Enabled = true;
                //this.MenuConsulta.Enabled = true;
                //this.MenuVer.Enabled = true;
                //this.MenuHerramienta.Enabled = true;
                //this.MenuSalida.Enabled = true;
                //this.MEnuReporte.Enabled = true;
                //this.menuventana.Enabled = true;
                //this.menuAyuda.Enabled = true;
                //this.tsCompras.Enabled = true;
                //this.TsVentas.Enabled = true;
            }
            else if (Acceso == "2")
            {
                
                //this.MenuAlmacen.Enabled = false;
                //this.MenuIngreso.Enabled = false;
                //this.MenuVenta.Enabled = true;
                //this.MenuMantenimiento.Enabled = false;
                //this.MenuConsulta.Enabled = true;
                //this.MenuVer.Enabled = true;
                //this.MenuHerramienta.Enabled = false;
                //this.MenuSalida.Enabled = false;
                //this.MEnuReporte.Enabled = true;
                //this.menuventana.Enabled = true;
                //this.menuAyuda.Enabled = true;
                //this.tsCompras.Enabled = false;
                //this.TsVentas.Enabled = true;
            }
            else
            {
                //this.MenuAlmacen.Enabled = false;
                //this.MenuIngreso.Enabled = false;
                //this.MenuVenta.Enabled = false;
                //this.MenuMantenimiento.Enabled = false;
                //this.MenuConsulta.Enabled = false;
                //this.MenuVer.Enabled = false;
                //this.MenuHerramienta.Enabled = false;
                //this.MenuSalida.Enabled = false;
                //this.MEnuReporte.Enabled = false;
                //this.menuventana.Enabled = false;
                //this.menuAyuda.Enabled = false;
                //this.tsCompras.Enabled = false;
                //this.TsVentas.Enabled = false;
            }
        }
    }
}