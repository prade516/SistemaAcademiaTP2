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

        protected void btnaceptar_Click(object sender, EventArgs e)
        {
            if (this.Isnuevo)
            {
                 EspecialidadLogic.Insertar(txtDesc_especialidad.Text.Trim().ToUpper());
            }
            else
            {
                 EspecialidadLogic.editar(Convert.ToInt32(txtidespecialidad.Text), this.txtDesc_especialidad.Text.Trim().ToUpper());
            }
        }
        private void Limpiar()
        {
            this.txtidespecialidad.Text = string.Empty;
            this.txtDesc_especialidad.Text = string.Empty;
        }
        private void Habilitar(bool valor)
        {
            this.txtDesc_especialidad.ReadOnly = !valor;
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
        protected void btncancelar_Click(object sender, EventArgs e)
        {
            this.Isnuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            this.Isnuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            this.IsEditar = true;
            this.Botones();
            this.Habilitar(true);
        }

        protected void gridview_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtidespecialidad.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[0].Text));
            this.txtDesc_especialidad.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[1].Text));
        }

        protected void gridview_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            //gridview.PageIndex = e.NewPageIndex;
            LoadGrid();
        }
    }
}