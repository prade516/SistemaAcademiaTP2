using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web.Administrador
{
    public partial class frmInscripcion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
                this.llenarcomboPlan();
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
            this.gridview.DataSource = Logic.GetAllAdministrador();
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
                    if (cblPlan.SelectedItem.Text == "Seleccione un Plan" && CblSexo.SelectedItem.Text=="Elegir Sexo")
                    {
                        msgError.Text = "Falta Seleccionar las opciones";
                    }
                    else
                    {
                        pers.Nombre = this.txtnombre.Text;
                        pers.Apellido = this.txtapellido.Text;
                        pers.Direccion =this.txtdireccion.Text;
                        pers.Email = this.txtE_mail.Text;
                        pers.Telefono = this.txttelefono.Text;
                        pers.Fecha_Nac = Convert.ToDateTime( datetimepicker4.Value);
                        pers.Legajo = Convert.ToInt32(this.TxtLegajo.Text);
                        pers.Tipo_Persona = "Administrador";                       
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
        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            this.Habilitar(true);
        }

        protected void cblPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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

        protected void btncancelar_Click(object sender, EventArgs e)
        {
            this.DesHabilitar(false);
            this.btnNuevo.Visible = true;
            this.Limpiar();
        }

        protected void gridview_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_Personas pers = new _Personas();
            this.txtidPersona.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[0].Text)).ToString();
            this.txtnombre.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[1].Text)).ToString();
            this.txtapellido.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[2].Text)).ToString();
            this.txtdireccion.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[3].Text)).ToString();
            this.txtE_mail.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[4].Text)).ToString();
            this.txttelefono.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[5].Text)).ToString();
            this.fecha_nacimiento.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[6].Text)).ToString();
            this.TxtLegajo.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[7].Text)).ToString();
            this.cblPlan.SelectedItem.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[9].Text)).ToString();
            this.CblSexo.SelectedItem.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[10].Text)).ToString();


            this.Buton(true);
            this.btnNuevo.Visible = false;
            this.btnaceptar.Visible = false;
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