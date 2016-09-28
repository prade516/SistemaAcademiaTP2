using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace UI.Web.Formulario
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.txtusuario.Focus();
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            string usuario, password;
            usuario = Convert.ToString(this.txtusuario.Text);
            password = Convert.ToString(this.Txtcontrasena.Text);
            DataTable Datos = Business.Logic.UsuarioLogic.Login(usuario, password);

            if (Datos.Rows.Count == 0)
            {
                msglabel.Visible = true;
            }
            else
            {
                string idusuario = Datos.Rows[0][0].ToString();
                string nombre = Datos.Rows[0][1].ToString();
                string apellido = Datos.Rows[0][2].ToString();
                string acesso = Datos.Rows[0][4].ToString();
                int tipo = Convert.ToInt32(Datos.Rows[0][4].ToString());

                Session.Add("codigo", idusuario);
                Session.Add("Nombre", nombre);
                Session.Add("Apellido", apellido);
                Session.Add("Acesso", acesso);
                Session.Add("Tipo", tipo);

                Response.Redirect("Home.aspx");
                
            }
        }
    }
}