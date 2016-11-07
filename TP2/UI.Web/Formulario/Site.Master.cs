using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
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
        public string Tipo = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            GestionUsuario();
        }
        private void GestionUsuario()
        {
            Idtrabajador = (string)(Session["codigo"]);
            Nombre = (string)(Session["Nombre"]);
            Apellidos = (string)(Session["Apellido"]);
            Tipo = Convert.ToString(Session["Tipo"]);
            TreeNode nodouno = new TreeNode();
            //nodouno.P = System.Drawing.Color.Red; 
            
            if (Tipo == "1")
            {
                Menu1.Items[1].Enabled = true;
                Menu1.Items[2].Enabled = true;
                Menu1.Items[3].Enabled = true;
                Menu1.Items[4].Enabled = true;
                Menu1.Items[5].Enabled = true;
                Menu1.Items[6].Enabled = true;
                Menu1.Items[7].Enabled = true;
                Menu1.Items[8].Enabled = true;
                Menu1.Items[9].Enabled = true;
                Menu1.Items[10].Enabled = true;
            }
            else if (Tipo == "2")
            {
                Menu1.Items[1].Enabled = false;
                Menu1.Items[2].Enabled = false;
                Menu1.Items[3].Enabled = false;
                Menu1.Items[4].Enabled = false;
                Menu1.Items[5].Enabled = false;
                Menu1.Items[6].Enabled = false;
                Menu1.Items[7].Enabled = false;
                Menu1.Items[8].Enabled = true;
                Menu1.Items[9].Enabled = false;
                Menu1.Items[10].Enabled = false;
                Menu1.Items[1].Text = "<div style='Color: Green'>" + Menu1.Items[1].Text + "</div>";
                Menu1.Items[2].Text = "<div style='Color: Green'>" + Menu1.Items[2].Text + "</div>";
                Menu1.Items[3].Text = "<div style='Color: Green'>" + Menu1.Items[3].Text + "</div>";
                Menu1.Items[4].Text = "<div style='Color: Green'>" + Menu1.Items[4].Text + "</div>";
                Menu1.Items[5].Text = "<div style='Color: Green'>" + Menu1.Items[5].Text + "</div>";
                Menu1.Items[6].Text = "<div style='Color: Green'>" + Menu1.Items[6].Text + "</div>";
                Menu1.Items[7].Text = "<div style='Color: Green'>" + Menu1.Items[7].Text + "</div>";
                Menu1.Items[9].Text = "<div style='Color: Green'>" + Menu1.Items[9].Text + "</div>";
                Menu1.Items[10].Text = "<div style='Color: Green'>" + Menu1.Items[10].Text + "</div>";
            }
            else
            {
                Menu1.Items[1].Enabled = false;
                Menu1.Items[2].Enabled = false;
                Menu1.Items[3].Enabled = false;
                Menu1.Items[4].Enabled = false;
                Menu1.Items[8].Enabled = false;
                Menu1.Items[9].Enabled = false;
                Menu1.Items[10].Enabled = false;
                Menu1.Items[1].Text = "<div style='Color: Green'>" + Menu1.Items[1].Text + "</div>";
                Menu1.Items[2].Text = "<div style='Color: Green'>" + Menu1.Items[2].Text + "</div>";
                Menu1.Items[3].Text = "<div style='Color: Green'>" + Menu1.Items[3].Text + "</div>";
                Menu1.Items[4].Text = "<div style='Color: Green'>" + Menu1.Items[4].Text + "</div>";
                Menu1.Items[8].Text = "<div style='Color: Green'>" + Menu1.Items[8].Text + "</div>";
                Menu1.Items[9].Text = "<div style='Color: Green'>" + Menu1.Items[9].Text + "</div>";
                Menu1.Items[10].Text = "<div style='Color: Green'>" + Menu1.Items[10].Text + "</div>";
            }
        }

        //protected void Timer1_Tick(object sender, EventArgs e)
        //{
        //    Session.Clear();
        //    Session.Abandon();
        //    Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    Response.Cache.SetNoStore();

        //    try
        //    {
        //        Session.Abandon();
        //        FormsAuthentication.SignOut();
        //        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //        Response.Buffer = true;
        //        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        //        Response.Expires = -1000;
        //        Response.CacheControl = "no-cache";
        //        //Response.Redirect("login.aspx", true);
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write(ex.Message);
        //    }
        //    Response.Redirect("~/frmlogin.aspx");
        //}
    }
}