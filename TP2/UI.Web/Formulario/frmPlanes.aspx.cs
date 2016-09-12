using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web.Formulario
{
    public partial class frmPlanes : System.Web.UI.Page
    {
        private bool Isnuevo = false;
        private bool IsEditar = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
                llenarcomboEspecialidad();                
            }         
        }
        PlanLogic _logic = new PlanLogic();

        public PlanLogic Logic
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
        private void llenarcomboEspecialidad()
        {
            Data.Database.Especialidad especia = new Data.Database.Especialidad();
            //_Especialidades fr = new _Especialidades();
            cbldEspecialidad.DataSource = especia.GetAll();
            cbldEspecialidad.DataValueField = "Idespecialidad";
            cbldEspecialidad.DataTextField = "DescEspecialidad";
            cbldEspecialidad.DataBind();
        }
        private void Habilitar(bool valor)
        {
            this.txtdesc_especialidad.Enabled = valor;
            this.txtDesc_plan.Enabled = valor;
            this.cbldEspecialidad.Enabled = valor;
        }
        private void Botones()
        {
            if (this.Isnuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnaceptar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btncancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnaceptar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btncancelar.Enabled = false;
            }
        }
        private void Limpiar()
        {
            this.txtdesc_especialidad.Text = string.Empty;
            this.txtDesc_plan.Text = string.Empty;
            this.txtDesc_plan.Text = string.Empty;
        }
        protected void btncancelar_Click(object sender, EventArgs e)
        {
            this.Isnuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            this.IsEditar = true;
            this.Botones();
            this.Habilitar(true);
            llenarcomboEspecialidad();
            this.cbldEspecialidad.Text = Convert.ToString(this.gridview.SelectedRow.Cells[2].Text);
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            this.Isnuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtdesc_especialidad.Focus();
            llenarcomboEspecialidad();
        }

        protected void btnaceptar_Click(object sender, EventArgs e)
        {
            if (this.Isnuevo)
            {
                PlanLogic.Insertar(txtDesc_plan.Text.Trim().ToUpper(), Convert.ToInt32(cbldEspecialidad.SelectedValue));
            }
            else
            {
               PlanLogic.Editar(Convert.ToInt32(txtidplan.Text), this.txtDesc_plan.Text.Trim().ToUpper(), Convert.ToInt32(cbldEspecialidad.SelectedValue));
            }
        }

        protected void gridview_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtidplan.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[0].Text));
            this.txtDesc_plan.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[1].Text));
            this.txtdesc_especialidad.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[2].Text));
        }
    }
}