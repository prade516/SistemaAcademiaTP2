using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web.Formulario
{
    public partial class frmVer_Materia_Aprobada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
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
            this.gridview.DataSource = Logic.GetByMateriasAprobada();
            //gridview.Columns[2].Visible = false;
            this.gridview.DataBind();
        }
        protected void gridview_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}