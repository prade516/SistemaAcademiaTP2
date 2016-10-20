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
    public partial class frmprofesor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
                //this.llenarcomboPlan();
            }
        }
        PersonaLogic _logic = new PersonaLogic();

        public PersonaLogic Logic
        {
            get { return _logic; }
            set { _logic = value; }
        }
        private void LoadGrid()
        {
            this.gridview.DataSource = Logic.GetAllProfesor();
            //gridview.Columns[2].Visible = false;
            this.gridview.DataBind();
        }

        protected void Buscar()
        {
            try
            {

                this.gridview.DataSource = Logic.GetByPersona(Convert.ToInt32(this.txtbuscar.Text));
                this.gridview.DataBind();
            }
            catch (Exception ex)
            {
                msgError.Text = ex.Message;
            }

        }
        private void Habilitar(bool valor)
        {
            this.txtidPersona.Enabled = valor;
            this.txtnombre.Enabled = valor;
            this.txtapellido.Enabled = valor;
            this.TxtLegajo.Enabled = valor;
            this.txtdireccion.Enabled = valor;
            this.txtE_mail.Enabled = valor;
            this.txttelefono.Enabled = valor;
            this.cblPlan.Enabled = valor;
            this.CblSexo.Enabled = valor;
            this.cblTipo_persona.Enabled = valor;
            this.btnEditar.Visible = false;
            this.btnaceptar.Visible = valor;
            this.btnNuevo.Enabled = !valor;
            this.btncancelar.Visible = valor;
        }
        protected void Editar()
        {
            this.Habilitar(true);
            this.btnEliminar.Visible = false;
        }
        private void llenarcomboPlan()
        {
            Data.Database.Plan especia = new Data.Database.Plan();
            cblPlan.DataSource = especia.GetByMostrar();
            cblPlan.DataValueField = "Codigo";
            cblPlan.DataTextField = "Especialidad";
            cblPlan.DataBind();
            cblPlan.Items.Insert(0, new ListItem("Seleccione un Plan", "0"));
        }
        protected void Eliminar()
        {
            try
            {
                _Personas persona = new _Personas();
                persona.Codigo = Convert.ToInt32(this.txtidPersona.Text);
                persona.Estado = BusinessEntity.Estados.Eliminar;
                Logic.Delete(persona);
            }
            catch (Exception ex)
            {
                msgError.Text = ex.Message;
            }

        }
        private void Limpiar()
        {
            this.txtidPersona.Text = string.Empty;
            this.txtnombre.Text = string.Empty;
            this.txtapellido.Text = string.Empty;
            this.txtdireccion.Text = string.Empty;
            this.txtE_mail.Text = string.Empty;
            this.txttelefono.Text = string.Empty;
            this.fecha_nacimiento.Text = string.Empty;
            this.TxtLegajo.Text = string.Empty;
            this.cblTipo_persona.Items.Insert(0, new ListItem("Elegir Categoria", "0"));
            cblPlan.Items.Insert(0, new ListItem("Seleccione un Plan", "0"));
            this.CblSexo.Items.Insert(0, new ListItem("Elegir Sexo", "0"));
        }

        private void DesHabilitar(bool valor)
        {
            //this.txtidComision.Enabled = valor;
            this.txtnombre.Enabled = valor;
            this.txtapellido.Enabled = valor;
            this.txtdireccion.Enabled = valor;
            this.txtE_mail.Enabled = valor;
            this.txttelefono.Enabled = valor;
            this.fecha_nacimiento.Enabled = valor;
            this.TxtLegajo.Enabled = valor;
            this.cblTipo_persona.Items.Insert(0, new ListItem("Elegir Categoria", "0"));
            cblPlan.Items.Insert(0, new ListItem("Seleccione un Plan", "0"));
            this.CblSexo.Items.Insert(0, new ListItem("Elegir Sexo", "0"));
            this.btnaceptar.Visible = valor;
            this.btnNuevo.Enabled = !valor;
            this.btncancelar.Visible = valor;
            this.btnEliminar.Visible = valor;
            this.btnEditar.Visible = valor;

        }
        private void Buton(bool valor)
        {
            this.btnEditar.Visible = Visible;
            this.btncancelar.Visible = valor;
            this.btnNuevo.Visible = valor;
            this.btnaceptar.Visible = valor;
            this.btnEliminar.Visible = valor;
        }

        protected void CargarPersona()
        {
            try
            {
                _Personas pers = new _Personas();
                bool registar = true;
                foreach (GridViewRow row in gridview.Rows)
                {
                    if (row.Cells[1].Text == (this.TxtLegajo.Text).ToUpper())
                    {
                        registar = false;
                        msgError.Text = "ya existe ese legajo";
                    }
                }
                if (registar)
                {
                    if (cblPlan.SelectedItem.Text == "Seleccione un Plan" && CblSexo.SelectedItem.Text == "Elegir Sexo" && cblTipo_persona.SelectedItem.Text == "Elegir Categoria")
                    {
                        msgError.Text = "Falta Seleccionar las opciones";
                    }
                    else
                    {
                        pers.Nombre = this.txtnombre.Text;
                        pers.Apellido = this.txtapellido.Text;
                        pers.Direccion = this.txtdireccion.Text;
                        pers.Email = this.txtE_mail.Text;
                        pers.Telefono = this.txttelefono.Text;
                        pers.Fecha_Nac = Convert.ToDateTime(this.datetimepicker4.Value);
                        pers.Legajo = Convert.ToInt32(this.TxtLegajo.Text);
                        pers.Tipo_Persona = this.cblTipo_persona.SelectedValue;
                        pers.Id_Plan = (Convert.ToInt32(this.cblPlan.SelectedValue));
                        pers.Sexo = this.CblSexo.SelectedValue;
                        pers.Estado = BusinessEntity.Estados.Nuevo;
                        Logic.Insertar(pers);
                        this.Limpiar();
                    }
                }
            }
            catch (Exception ex)
            {
                msgError.Text = ex.Message;
            }

        }
        protected void ModificarPersona()
        {
            try
            {
                _Personas pers = new _Personas();
                pers.Codigo = Convert.ToInt32(this.txtidPersona.Text);
                pers.Nombre = this.txtnombre.Text;
                pers.Apellido = this.txtapellido.Text;
                pers.Direccion = this.txtdireccion.Text;
                pers.Email = this.txtE_mail.Text;
                pers.Telefono = this.txttelefono.Text;
                pers.Fecha_Nac = Convert.ToDateTime(this.fecha_nacimiento.Text);
                pers.Legajo = Convert.ToInt32(this.TxtLegajo.Text);
                pers.Tipo_Persona = this.cblTipo_persona.SelectedValue;
                pers.Id_Plan = (Convert.ToInt32(this.cblPlan.SelectedValue));
                pers.Sexo = this.CblSexo.SelectedValue;
                pers.Estado = BusinessEntity.Estados.Modificar;
                Logic.Update(pers);
                this.Limpiar();
            }
            catch (Exception ex)
            {

                msgError.Text = ex.Message;
            }

        }
        protected void btnNuevo_Click1(object sender, EventArgs e)
        {
            this.Habilitar(true);
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            this.Editar();
            this.btnaceptar.Text = "Modificar";
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            this.Eliminar();
        }

        protected void btnaceptar_Click(object sender, EventArgs e)
        {
            if (this.txtidPersona.Text == string.Empty)
            {
                this.CargarPersona();
                //LoadGrid();
            }
            else
            {
                this.ModificarPersona();
                //LoadGrid();
            }
        }

    }
}