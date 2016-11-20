using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web.Formulario
{
    public partial class frmAgregarNotas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadGrid();
            }
        }
        Alumnos_InscripcionesLogic _logic = new Alumnos_InscripcionesLogic();

        public Alumnos_InscripcionesLogic Logic
        {
            get { return _logic; }
            set { _logic = value; }
        }
        private void LoadGrid()
        {
            //string materia = (string)(Session["materia"]);
            int id = (int)(Session["CodPersona"]);
            //int anio = (int)(Session["año"]);
            //int tipo = (int)(Session["Tipo"]);
            //MateriaLogic al = new MateriaLogic();

            //Alumnos_InscripcionesLogic cur = new Alumnos_InscripcionesLogic();
            //if (tipo == 1)
            //{
            //    Response.Redirect("frminscribirporAdministrador.aspx");

            //}
            //else if (tipo == 3)
            //{
            this.gridview.DataSource = Logic.GetByPasarNotaFinal(id);
            this.gridview.DataBind();
            //}
        }
    }
}