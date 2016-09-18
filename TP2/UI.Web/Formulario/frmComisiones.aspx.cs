using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using System.Data;

namespace UI.Web.Formulario
{
    public partial class frmComisiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               this.LoadGrid();
               this.llenarcomboPlan();               
            }         
        }
        private void llenarcomboPlan()
        {
            Data.Database.Plan especia = new Data.Database.Plan();
            cbldPlan.DataSource = especia.GetAll();
            cbldPlan.DataValueField = "Codigo";
            cbldPlan.DataTextField = "Plan";
            cbldPlan.DataBind();
            cbldPlan.Items.Insert(0, new ListItem("Seleccione un Plan", "0"));
        }
        ComisionLogic _logic = new ComisionLogic();

        public ComisionLogic Logic
        {
            get { return _logic; }
            set { _logic = value; }
        }
        private void LoadGrid()
        {
            this.gridview.DataSource = Logic.GetAll();
            this.gridview.DataBind();
        }
        public void Buscar()
        {
            ComisionLogic comlo = new ComisionLogic();
            this.gridview.DataSource = comlo.GetByComision(this.txtbuscar.Text);
            this.gridview.DataBind();
        }
        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }
        private void Limpiar()
        {
            this.txtidComision.Text = string.Empty;
            this.txtDesc_comision.Text = string.Empty;
            this.txtanio_especialidad.Text = string.Empty;
            cbldPlan.SelectedItem.Text = "Seleccione un Plan";
        }
        private void Habilitar(bool valor)
        {
            this.txtidComision.Enabled = valor;
            this.txtDesc_comision.Enabled = valor;
            this.txtanio_especialidad.Enabled = valor;
            //cbldPlan.SelectedItem.Text = "Seleccione un Plan";
            cbldPlan.Enabled = valor;
            this.btnEditar.Visible = false;
            this.btnaceptar.Visible = valor;
            this.btnNuevo.Enabled =! valor;
            this.btncancelar.Visible = valor;
        }
        private void DesHabilitar(bool valor)
        {
            this.txtidComision.Enabled = valor;
            this.txtDesc_comision.Enabled = valor;
            this.txtanio_especialidad.Enabled = valor;
            cbldPlan.SelectedItem.Text = "Seleccione un Plan";
            cbldPlan.Enabled = valor;
            this.btnaceptar.Visible = valor;
            this.btnNuevo.Enabled = !valor;
            this.btncancelar.Visible = valor;
            this.btnEliminar.Visible = valor;
            this.btnEditar.Visible = valor;
        }
        private void Buton(bool valor)
        {
            this.btnEditar.Visible = valor;
            this.btncancelar.Visible = valor;
            this.btnNuevo.Visible = valor;
            this.btnaceptar.Visible = valor;
            this.btnEliminar.Visible = valor;        

        } 
        protected void CargarComision()
        {
            Comisiones comision = new Comisiones();
            bool registar = true;
            foreach (GridViewRow row in gridview.Rows)
            {
                if (row.Cells[1].Text == this.txtDesc_comision.Text)
                {
                    registar = false;
                    msgError.Text = "ya existe esa comision";
                }                      
            }
            if (registar)
            {
                if (cbldPlan.SelectedItem.Text== "Seleccione un Plan")
                {
                    msgError.Text = "Debe seleccionar un plan";
                }
                else
                {
                    comision.DescComision = this.txtDesc_comision.Text;
                    comision.AnioEspecialidad = Convert.ToInt32(this.txtanio_especialidad.Text);
                    comision.IdPlan = Convert.ToInt32(this.cbldPlan.SelectedValue);
                    comision.Estado = BusinessEntity.Estados.Nuevo;
                    Logic.Save(comision);
                    this.Limpiar();
                }           
                
            }
            
        }
        protected void Modificar()
        {
            Comisiones comision = new Comisiones();
            comision.IdComision = (Convert.ToInt32(this.txtidComision.Text));
            comision.DescComision = this.txtDesc_comision.Text;
            comision.AnioEspecialidad = Convert.ToInt32(this.txtanio_especialidad.Text);
            comision.IdPlan = Convert.ToInt32(this.cbldPlan.SelectedValue); 
            comision.Estado = BusinessEntity.Estados.Modificar;
            Logic.Update(comision);
            this.Limpiar();
        }
        protected void Eliminar()
        {
            Comisiones comision = new Comisiones();
            comision.IdComision =Convert.ToInt32(this.txtidComision.Text);
            comision.Estado = BusinessEntity.Estados.Eliminar;
            Logic.Delete(comision);
        }

        protected void btnaceptar_Click(object sender, EventArgs e)
        {
            if (this.txtidComision.Text==string.Empty)
            {
                this.CargarComision();     
            }
            else
            {
                this.Modificar();
            }     
           
        }
        protected void gridview_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridview.PageIndex = e.NewPageIndex;
            LoadGrid();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            this.Habilitar(true);
        }

        protected void btncancelar_Click(object sender, EventArgs e)
        {
            this.DesHabilitar(false);
            //this.Buton(false);
            this.btnNuevo.Visible = true;
            this.Limpiar();
        }

        protected void gridview_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtidComision.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[0].Text)).ToString();
            this.txtDesc_comision.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[1].Text)).ToString();
            this.txtanio_especialidad.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[2].Text)).ToString();
            this.cbldPlan.SelectedItem.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[3].Text)).ToString();
            this.txtPlan.Text=(Convert.ToString(this.gridview.SelectedRow.Cells[3].Text)).ToString();
            this.Buton(true);
            this.btnNuevo.Visible = false;
            this.btnaceptar.Visible = false;
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            this.Habilitar(true);
            this.btnEliminar.Visible=false;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            this.Eliminar();
        }
    }
}