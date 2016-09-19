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
    public partial class frmEspecialidades : System.Web.UI.Page
    {
        private bool Isnuevo = false;
        private bool IsEditar = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();                
                //EnableButon(false);
                //EnableTextBox(false);
                //llenarcajas();
            }         
        }
        EspecialidadLogic _logic = new EspecialidadLogic();

        public EspecialidadLogic Logic
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
        protected void CargarEspecialidad()
        {
            _Especialidades especialidad = new _Especialidades();
            bool registar = true;
            foreach (GridViewRow row in gridview.Rows)
            {
                if (row.Cells[1].Text == this.txtDesc_especialidad.Text)
                {
                    registar = false;
                    msgError.Text = "ya existe esa Especialidad";
                }                     
            }
            if (registar)
            {
                especialidad.DescEspecialidad = this.txtDesc_especialidad.Text;

                especialidad.Estado = BusinessEntity.Estados.Nuevo;
                Logic.Insertar(especialidad);
                this.Limpiar();
            }

        }
        protected void Modificar()
        {
            try
            {
                _Especialidades especialidad = new _Especialidades();
                especialidad.Idespecialidad = Convert.ToInt32(this.txtidespecialidad.Text);
                especialidad.DescEspecialidad = this.txtDesc_especialidad.Text;

                especialidad.Estado = BusinessEntity.Estados.Modificar;
                Logic.Editar(especialidad);

                this.Limpiar();
            }
            catch (Exception ex)
            {
                msgError.Text = ex.Message;
            }
           
        }
        protected void Eliminar()
        {
            try
            {
                _Especialidades especialidad = new _Especialidades();
                especialidad.Idespecialidad = Convert.ToInt32(this.txtidespecialidad.Text);
                especialidad.Estado = BusinessEntity.Estados.Eliminar;
                Logic.Delete(especialidad);
            }
            catch (Exception ex)
            {
                msgError.Text = ex.Message;
            }
            
        }
        protected void btnaceptar_Click(object sender, EventArgs e)
        {
            if (this.txtidespecialidad.Text==string.Empty)
            {
                this.CargarEspecialidad();
            }
            else
            {
                this.Modificar();
            }
        }
        private void Limpiar()
        {
            this.txtidespecialidad.Text = string.Empty;
            this.txtDesc_especialidad.Text = string.Empty;
        }
        private void Habilitar(bool valor)
        {
            this.txtDesc_especialidad.Enabled = valor;
        }
        protected void Botones(bool valor)
        {
            this.btnEditar.Visible = !valor;
            this.btncancelar.Visible = valor;
            this.btnNuevo.Visible = !valor;
            this.btnaceptar.Visible = valor;
            this.btnEliminar.Visible = !valor;
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
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            this.Isnuevo = true;
            this.IsEditar = false;
            this.Botones(true);
            this.Limpiar();
            this.Habilitar(true);
            this.txtDesc_especialidad.Focus();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            this.IsEditar = true;
            this.Botones(true);
            this.Habilitar(true); 
        }      

        protected void gridview_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            //gridview.PageIndex = e.NewPageIndex;
            LoadGrid();
        }
        public void Buscar()
        {
            EspecialidadLogic comlo = new EspecialidadLogic();
            this.gridview.DataSource = comlo.GetByEspecialidad(this.txtbuscar.Text);
            this.gridview.DataBind();
        }
        protected void gridview_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtidespecialidad.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[0].Text));
            this.txtDesc_especialidad.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[1].Text));
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

        protected void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            this.Buscar();
        }
    }
}