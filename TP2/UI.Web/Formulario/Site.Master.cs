using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.Web;

namespace UI.Web
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        public string Idtrabajador = "";
        public string Apellidos = "";
        public string Nombre = "";
        public string Acceso = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            GestionUsuario();
        }
        private void GestionUsuario()
        {
            Idtrabajador = (string)(Session["codigo"]);
            Nombre = (string)(Session["Nombre"]);
            Apellidos = (string)(Session["Apellido"]);
            Acceso = (string)(Session["Acesso"]);

            if (Acceso == "1")
            {
                //LinkCarrera.Visible = true;
                //LinkConsulta.Visible = true;
                //LinkInicio.Visible = true;
                //LinkPersona.Visible = true;
            }
            else if (Acceso == "2")
            {
                //LinkCarrera.Visible = false;
                //LinkConsulta.Visible = true;
                //LinkInicio.Visible = true;
                //LinkPersona.Visible = false;
            }
            else
            {
                //LinkCarrera.Visible = false;
                //LinkConsulta.Visible = true;
                //LinkInicio.Visible = true;
                //LinkPersona.Visible = false; 
            }
        }

    }
}