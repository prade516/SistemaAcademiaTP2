using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web.Formulario
{
    public partial class frmCursos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadGrid();
                llenarcomboMateria();
                llenarcomboComision();
            }     
        }

        private void Limpiar()
        {
            this.txtidCurso.Text = string.Empty;
            cblMateria.Items.Insert(0, new ListItem("Seleccione una materia", "0"));
            cblcomision.Items.Insert(0, new ListItem("Seleccione una Comision", "0"));
            this.Txtcupo.Text = string.Empty;
            this.txtanio_calendario.Text = string.Empty;
        }
        private void llenarcomboMateria()
        {
            Data.Database.MateriasD especia = new Data.Database.MateriasD();
            //_Especialidades fr = new _Especialidades();
            cblMateria.DataSource = especia.GetAll();
            cblMateria.DataValueField = "Id_Materia";
            cblMateria.DataTextField = "Desc_Materia";
            cblMateria.DataBind();
            cblMateria.Items.Insert(0, new ListItem("Seleccione una materia", "0"));
        }

        private void llenarcomboComision()
        {
            Data.Database.ComisionesD especia = new Data.Database.ComisionesD();
            //_Especialidades fr = new _Especialidades();
            cblcomision.DataSource = especia.GetAll();
            cblcomision.DataValueField = "IdComision";
            cblcomision.DataTextField = "DescComision";
            cblcomision.DataBind();
            cblcomision.Items.Insert(0, new ListItem("Seleccione una Comision", "0"));
        }
        private void DesHabilitar(bool valor)
        {
            this.txtidCurso.Enabled = valor;
            this.cblMateria.Enabled = valor;
            this.cblcomision.Enabled = valor;
            this.Txtcupo.Enabled = valor;
            this.txtanio_calendario.Enabled = valor;
            this.btnaceptar.Visible = valor;
            this.btnNuevo.Enabled = !valor;
            this.btncancelar.Visible = valor;
            this.btnEliminar.Visible = valor;
            this.btnEditar.Visible = valor;
        }

        CursoLogic _logic = new CursoLogic();

        public CursoLogic Logic
        {
            get { return _logic; }
            set { _logic = value; }
        }
        private void LoadGrid()
        {

            this.gridview.DataSource = Logic.GetAll();
            this.gridview.DataBind();
        }

        private void Habilitar(bool valor)
        {
            this.cblMateria.Enabled = valor;
            this.cblcomision.Enabled = valor;
            this.Txtcupo.Enabled = valor;
            this.txtanio_calendario.Enabled = valor;
            this.btnEditar.Visible = false;
            this.btnaceptar.Visible = valor;
            this.btnNuevo.Enabled = !valor;
            this.btncancelar.Visible = valor;
        }

        protected void btncancelar_Click(object sender, EventArgs e)
        {
            this.DesHabilitar(false);
            //this.Buton(false);
            this.btnNuevo.Visible = true;
            this.Limpiar();
        }
        protected void CargarCurso()
        {
            try
            {
                Cursos curso = new Cursos();
                bool registar = true;
                foreach (GridViewRow row in gridview.Rows)
                {
                    if (row.Cells[1].Text == (this.cblcomision.SelectedItem.Text).ToUpper())
                    {
                        registar = false;
                        msgError.Text = "ya existe esa materia";
                    }
                }
                if (registar)
                {
                    if (cblcomision.SelectedItem.Text == "Seleccione una materia" && cblMateria.SelectedItem.Text == "Seleccione una Comision")
                    {
                        msgError.Text = "Debe seleccionar materia y comision";
                    }
                    else
                    {
                        curso.IdMateria = (Convert.ToInt32(this.cblMateria.SelectedValue));
                        curso.IdComision = (Convert.ToInt32(this.cblcomision.SelectedValue));
                        curso.AnioCalendario = (Convert.ToInt32(this.txtanio_calendario.Text));
                        curso.Cupo = (Convert.ToInt32(this.Txtcupo.Text));
                        curso.Estado = BusinessEntity.Estados.Nuevo;
                        Logic.Insertar(curso);
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

        protected void ModificarCurso()
        {
            try
            {
                Cursos curso = new Cursos();
                curso.IdCurso = Convert.ToInt32(this.txtidCurso.Text);
                curso.IdMateria = (Convert.ToInt32(this.cblMateria.SelectedValue));
                curso.IdComision = (Convert.ToInt32(this.cblcomision.SelectedValue));
                curso.AnioCalendario = (Convert.ToInt32(this.txtanio_calendario.Text));
                curso.Cupo = (Convert.ToInt32(this.Txtcupo.Text));
                curso.Estado = BusinessEntity.Estados.Modificar;
                Logic.Update(curso);
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
                Cursos curso = new Cursos();
                curso.IdCurso = Convert.ToInt32(this.txtidCurso.Text);
                curso.Estado = BusinessEntity.Estados.Eliminar;
                Logic.Delete(curso);
            }
            catch (Exception ex)
            {
                msgError.Text = ex.Message;
            }

        }
        private void Buton(bool valor)
        {
            this.btnEditar.Visible = Visible;
            this.btncancelar.Visible = valor;
            this.btnNuevo.Visible = valor;
            this.btnaceptar.Visible = valor;
            this.btnEliminar.Visible = valor;
        } 
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            this.Habilitar(true);
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            this.Habilitar(true);
            this.btnEliminar.Visible = false;
        }
        
        [WebMethod]
        public void Buscar()
        {
                       
    }
        protected void txtIdMateria_TextChanged(object sender, EventArgs e)
        {
           
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            this.Eliminar();
        }

        protected void btnaceptar_Click(object sender, EventArgs e)
        {
            if (this.txtidCurso.Text== string.Empty)
            {
                CargarCurso();
            }
            else
            {
                ModificarCurso();
            }
            
        }

        protected void gridview_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridview.PageIndex = e.NewPageIndex;
            LoadGrid();
        }

        protected void gridview_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtidCurso.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[0].Text)).ToString();
            this.cblMateria.SelectedItem.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[2].Text)).ToString();
            this.cblcomision.SelectedItem.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[4].Text)).ToString();
            this.txtanio_calendario.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[5].Text)).ToString();
            this.Txtcupo.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[6].Text)).ToString();
            this.Buton(true);
            this.btnNuevo.Visible = false;
            this.btnaceptar.Visible = false;
        }
    }
}