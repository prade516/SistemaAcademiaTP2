using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web.Formulario
{
    public partial class frmcursar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
                //llenarcomboPlan();
            }
           
        }

        protected void gridview_SelectedIndexChanged(object sender, EventArgs e)
        {
            int año = Convert.ToInt32((Convert.ToString(this.gridview.SelectedRow.Cells[0].Text)).ToString());
            string materia =(Convert.ToString(this.gridview.SelectedRow.Cells[1].Text)).ToString();

            Session.Add("año", año);
            Session.Add("materia", materia);
            //Buscar();
            Response.Redirect("frmaltacursado.aspx");
        }
      
        Alumnos_InscripcionesLogic _logic = new Alumnos_InscripcionesLogic();

        public Alumnos_InscripcionesLogic Logic
        {
            get { return _logic; }
            set { _logic = value; }
        }
        private void LoadGrid()
        {
            this.gridview.DataSource = Logic.GetAll();
            //gridview.Columns[2].Visible = false;
            this.gridview.DataBind();
        }

        private void Habilitar(bool valor)
        {
            this.txtdesc_materia.Enabled = valor;
            this.txthorasemales.Enabled = valor;
            this.txtHsTotales.Enabled = valor;
            //cbldPlan.SelectedItem.Text = "Seleccione un Plan";
            cbldPlan.Enabled = valor;
            this.btnEditar.Visible = false;
            this.btnaceptar.Visible = valor;
            this.btnNuevo.Enabled = !valor;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            this.Habilitar(true);
        }

        protected void btnaceptar_Click(object sender, EventArgs e)
        {

        }
    }
}