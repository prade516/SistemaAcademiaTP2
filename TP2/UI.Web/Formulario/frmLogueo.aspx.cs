using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace UI.Web
{
    public partial class frmLogeo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
                Response.Redirect("Formulario/Home.aspx");
                //Principal frm = new Principal();
                //frm.IdUsuario = Datos.Rows[0][0].ToString();
                //frm.Nombre = Datos.Rows[0][1].ToString();
                //frm.Apellido = Datos.Rows[0][2].ToString();
                //frm.Acceso = Datos.Rows[0][4].ToString();

                //frm.Show();
                //this.Hide();
            }  
        }
        }
    }
