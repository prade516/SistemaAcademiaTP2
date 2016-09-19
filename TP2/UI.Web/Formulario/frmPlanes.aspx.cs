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
            this.gridview.DataBind();
        }
        private void llenarcomboEspecialidad()
        {
            Data.Database.Especialidad especia = new Data.Database.Especialidad();
            cbldEspecialidad.DataSource = especia.GetAll();
            cbldEspecialidad.DataValueField = "Idespecialidad";
            cbldEspecialidad.DataTextField = "DescEspecialidad";
            cbldEspecialidad.DataBind();
            cbldEspecialidad.Items.Insert(0, new ListItem("Seleccione una Especialidad", "0"));
        }
        private void Habilitar(bool valor)
        {
            this.txtDesc_plan.Enabled = valor;
            this.cbldEspecialidad.Enabled = valor;
            cbldEspecialidad.Enabled = valor;
        }

        protected void Botones(bool valor)
        {
            this.btnEditar.Visible =! valor;
            this.btncancelar.Visible = valor;
            this.btnNuevo.Visible =! valor;
            this.btnaceptar.Visible = valor;
            this.btnEliminar.Visible =! valor; 
        }
       
        protected void CargarPlan()
        {
            Planes plan = new Planes();
            bool registar = true;
            foreach (GridViewRow row in gridview.Rows)
            {
                if (row.Cells[2].Text == this.cbldEspecialidad.SelectedItem.Text)
                {
                    registar = false;
                    msgError.Text = "ya existe esa Especialidad";
                }
            }
            if (registar)
            {
                if (cbldEspecialidad.SelectedItem.Text == "Seleccione una Especialidad")
                {
                    msgError.Text = "Debe seleccionar una Especialidad";
                }
                else
                {
                    plan.Plan = this.txtDesc_plan.Text;
                    plan.Id_Especialidad = (Convert.ToInt32(cbldEspecialidad.SelectedValue));
                   
                    plan.Estado = BusinessEntity.Estados.Nuevo;
                    Logic.Insertar(plan);
                    this.Limpiar();
                }
            }

        }
        protected void Modificar()
        {
            Planes plan = new Planes();
            plan.Codigo = Convert.ToInt32(this.txtidplan.Text);
            plan.Plan = this.txtDesc_plan.Text;
            plan.Id_Especialidad = (Convert.ToInt32(cbldEspecialidad.SelectedValue));
                       
            plan.Estado = BusinessEntity.Estados.Modificar;
            Logic.Editar(plan);

            this.Limpiar();
        }
        protected void Eliminar()
        {
            Planes plan = new Planes();
            plan.Codigo = Convert.ToInt32(this.txtidplan.Text);
            plan.Estado = BusinessEntity.Estados.Eliminar;
            Logic.Delete(plan);
        }
        public void Buscar()
        {
            PlanLogic comlo = new PlanLogic();
            this.gridview.DataSource = comlo.GetPlan(this.txtbuscar.Text);
            this.gridview.DataBind();
        }
        private void Limpiar()
        {            
            this.txtDesc_plan.Text = string.Empty;
            this.txtDesc_plan.Text = string.Empty;
            this.txtidplan.Text = string.Empty;
        }
        protected void btncancelar_Click(object sender, EventArgs e)
        {
            this.Isnuevo = false;
            this.IsEditar = false;
            this.Botones(false);
            this.Limpiar();
            this.Habilitar(false);
            this.btnEditar.Visible = false;
            this.btnEliminar.Visible = false;
            cbldEspecialidad.SelectedItem.Text = "Seleccione una Especialidad";
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            this.IsEditar = true;
            this.Botones(true);
            this.Habilitar(true);     
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            this.Isnuevo = true;
            this.IsEditar = false;
            this.Botones(true);
            this.Limpiar();
            this.Habilitar(true);
            this.txtDesc_plan.Focus();
        }

        protected void btnaceptar_Click(object sender, EventArgs e)
        {
            if (this.txtidplan.Text==string.Empty)
            {
                this.CargarPlan();
            }
            else
            {
                this.Modificar();
            }
        }

        protected void gridview_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtidplan.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[0].Text));
            this.txtDesc_plan.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[1].Text));
            this.cbldEspecialidad.SelectedItem.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[2].Text)).ToString();
            this.Botones(false);
            this.btnNuevo.Visible = false;
            this.btnaceptar.Visible = false;
            this.btncancelar.Visible = true;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            this.Eliminar();
        }

        protected void gridview_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridview.PageIndex = e.NewPageIndex;
            LoadGrid();
        }

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }
    }
}