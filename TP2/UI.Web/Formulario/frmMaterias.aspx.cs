using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web.Formulario
{
    public partial class frmMaterias : System.Web.UI.Page
    {  
     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                    LoadGrid();                 
                    llenarcomboPlan();   
           }   
        }
        private void llenarcomboPlan()
        {
            Data.Database.Plan especia = new Data.Database.Plan();
            //_Especialidades fr = new _Especialidades();
            cbldPlan.DataSource = especia.GetAll();
            cbldPlan.DataValueField = "Codigo";
            cbldPlan.DataTextField = "Plan";
            cbldPlan.DataBind();
            cbldPlan.Items.Insert(0, new ListItem("Seleccione un Plan", "0"));
        }
        MateriaLogic _logic = new MateriaLogic();

        public MateriaLogic Logic
        {
            get { return _logic; }
            set { _logic = value; }
        }
        private void LoadGrid()
        {
            this.gridview.DataSource = Logic.GetAll();
            gridview.Columns[2].Visible = false;
            this.gridview.DataBind();
        }

        //protected void txtbuscaridplan_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("frmplanlista.aspx");
        //    this.btnaceptar.Enabled = false;
        //    this.btnEditar.Enabled = false;
            
        //}      
        protected void btnaceptar_Click1(object sender, EventArgs e)
        {
            if (this.txtidmateria.Text==string.Empty)
            {
                this.CargarMateria();
                //LoadGrid();
            }
            else
            {
                this.ModificarMateria();
                //LoadGrid();
            }
                
        }

        protected void CargarMateria()
        {
            try
            {
                Materias materia = new Materias();
                bool registar = true;
                foreach (GridViewRow row in gridview.Rows)
                {
                    if (row.Cells[1].Text == (this.txtdesc_materia.Text).ToUpper())
                    {
                        registar = false;
                        msgError.Text = "ya existe esa materia";
                    }
                }
                if (registar)
                {
                    if (cbldPlan.SelectedItem.Text == "Seleccione un Plan")
                    {
                        msgError.Text = "Debe seleccionar un plan";
                    }
                    else
                    {
                        materia.Desc_Materia = (this.txtdesc_materia.Text);
                        materia.Hs_Semanales = (Convert.ToInt32(this.txthorasemales.Text));
                        materia.Hs_Totales = (Convert.ToInt32(this.txtHsTotales.Text));
                        materia.Id_Plan = (Convert.ToInt32(this.cbldPlan.SelectedValue));
                        materia.Estado = BusinessEntity.Estados.Nuevo;
                        Logic.Insertar(materia);
                        this.Limpiar();
                        //gridview.EditIndex = -1;
                        //this.LoadGrid();
                    }
                }           
            }
            catch (Exception ex)
            {
                msgError.Text = ex.Message;
            }
              
        }
        protected void ModificarMateria()
        {
            try
            {
                Materias materia = new Materias();
                materia.Id_Materia = Convert.ToInt32(this.txtidmateria.Text);
                materia.Desc_Materia = (this.txtdesc_materia.Text);
                materia.Hs_Semanales = (Convert.ToInt32(this.txthorasemales.Text));
                materia.Hs_Totales = Convert.ToInt32(this.txtHsTotales.Text);
                materia.Id_Plan = Convert.ToInt32(this.cbldPlan.SelectedValue);
                materia.Estado = BusinessEntity.Estados.Modificar;
                Logic.Editar(materia);
                this.Limpiar();        
            }
            catch (Exception ex)
            {

                msgError.Text = ex.Message;
            }
                         
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
            this.btncancelar.Visible = valor;
        }
        protected void gridview_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridview.PageIndex = e.NewPageIndex;
            LoadGrid();
        }
        private void EnableTextBox(bool enable)
        {
            this.txtdesc_materia.Enabled = enable;
            this.txthorasemales.Enabled = enable;
            this.txtHsTotales.Enabled = enable;
            
        }
        private void EnableButon(bool enable)
        {
            this.btnaceptar.Enabled = enable;
            this.btnEditar.Enabled = enable;
            this.btncancelar.Enabled = enable;
            //this.txtbuscaridplan.Enabled = enable;
         
        }
        private void Buton(bool valor)
        {
            this.btnEditar.Visible = Visible;
            this.btncancelar.Visible = valor;
            this.btnNuevo.Visible = valor;
            this.btnaceptar.Visible = valor;
            this.btnEliminar.Visible = valor;
        } 
        private void DesHabilitar(bool valor)
        {
            //this.txtidComision.Enabled = valor;
            this.txtdesc_materia.Enabled = valor;
            this.txthorasemales.Enabled = valor;
            this.txtHsTotales.Enabled = valor;
            //cbldPlan.Items.Insert(0, new ListItem("Seleccione un Plan", "0"));
            cbldPlan.Enabled = valor;
            this.btnaceptar.Visible = valor;
            this.btnNuevo.Enabled = !valor;
            this.btncancelar.Visible = valor;
            this.btnEliminar.Visible = valor;
            this.btnEditar.Visible = valor;
            
        }
        protected void Editar()
        {
            if (!this.txtidmateria.Text.Equals(""))
            {                
                this.Habilitar(true);
                this.btnEliminar.Visible = false;
            }
            else
            {
                this.msgError.Text=("Debe de seleccionar primero el registro a Modificar");
            }
        }
        private void Limpiar()
        {
            this.txtidmateria.Text = string.Empty;           
            this.txtHsTotales.Text = string.Empty;
            this.txthorasemales.Text = string.Empty;
            this.txtdesc_materia.Text = string.Empty;
            
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

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            this.Editar();
        }  
        [WebMethod]
        protected void Buscar()
        {
            try
            {
                MateriaLogic malogic = new MateriaLogic();
                this.gridview.DataSource = malogic.GetByMateria(this.txtbuscar.Text);
                this.gridview.DataBind();
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
                Materias materia = new Materias();
                materia.Id_Materia = Convert.ToInt32(this.txtidmateria.Text);
                materia.Estado = BusinessEntity.Estados.Eliminar;
                Logic.Delete(materia);
            }
            catch (Exception ex)
            {
                msgError.Text = ex.Message;
            }
           
        }
        protected void gridview_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtidmateria.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[0].Text)).ToString();
            this.txtdesc_materia.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[1].Text)).ToString();
            this.cbldPlan.SelectedItem.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[3].Text)).ToString();
            this.txthorasemales.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[4].Text)).ToString();
            this.txtHsTotales.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[5].Text)).ToString();
            this.Buton(true);
            this.btnNuevo.Visible = false;
            this.btnaceptar.Visible = false;
        }

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            this.Eliminar();
        }    

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            this.ModificarMateria();
            this.DesHabilitar(false);
        }

    }
}