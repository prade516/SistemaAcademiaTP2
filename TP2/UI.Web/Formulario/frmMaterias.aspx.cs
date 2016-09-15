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
    public partial class frmMaterias : System.Web.UI.Page
    {
      private static string  idm;
      private static string materia;
      private static string cthosema;
      private static string tthor;
      private bool Isnuevo = false;
      //private bool IsEditar = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                    LoadGrid();
                    //this.txtidplan.Text = (string)(Session["codigo"]);
                    //this.txtplan.Text = (string)(Session["plan"]);
                    EnableButon(false);
                    EnableTextBox(false);
                    llenarcajas();
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

        protected void txtbuscaridplan_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmplanlista.aspx");
            this.btnaceptar.Enabled = false;
            this.btnEditar.Enabled = false;
            
        }      
        protected void btnaceptar_Click1(object sender, EventArgs e)
        {
            if (Isnuevo)
            {
                MateriaLogic.Insertar(this.txtdesc_materia.Text, Convert.ToInt32(this.txthorasemales.Text), Convert.ToInt32(this.txtHsTotales.Text), Convert.ToInt32(this.txtidplan.Text));
                LoadGrid();
                this.btnaceptar.Enabled = false;
                //this.btnEditar.Enabled = false;
                Limpiar();
            }
            else
            {
                MateriaLogic.Editar(Convert.ToInt32(this.txtidmateria.Text),this.txtdesc_materia.Text, Convert.ToInt32(this.txthorasemales.Text), Convert.ToInt32(this.txtHsTotales.Text), Convert.ToInt32(this.txtidplan.Text));
                LoadGrid();
                this.btnaceptar.Enabled = false;
                this.btnNuevo.Enabled = true;
                Limpiar();
            }
          
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
        private void Limpiar()
        {
            this.txtidmateria.Text = string.Empty;
            //this.txtplan.Text = string.Empty;
            this.txtHsTotales.Text = string.Empty;
            this.txthorasemales.Text = string.Empty;
            this.txtdesc_materia.Text = string.Empty;
            this.txtidplan.Text = string.Empty;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            EnableTextBox(true);
            EnableButon(true);
            this.btnNuevo.Enabled = false;
            this.btnEditar.Enabled = false;
        }

        protected void btncancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            EnableTextBox(false);
            EnableButon(false);
            this.btnNuevo.Enabled = true;
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {            
            EnableTextBox(true);
            EnableButon(true);
            this.btnNuevo.Enabled = false;
            this.txtidmateria.Text = idm;
            this.btnaceptar.Enabled = true;
            this.btnEditar.Enabled = false;
            //this.txtbuscaridplan.Enabled = true; 
        }
        private void guardarValor()
        {
            idm = (Convert.ToString(this.gridview.SelectedRow.Cells[0].Text));
            materia = (Convert.ToString(this.gridview.SelectedRow.Cells[1].Text));
            cthosema = (Convert.ToString(this.gridview.SelectedRow.Cells[3].Text));
            tthor = (Convert.ToString(this.gridview.SelectedRow.Cells[4].Text));
        }
        private void llenarcajas()
        {
            this.txtidmateria.Text = idm;
            this.txtdesc_materia.Text = materia;
            this.txthorasemales.Text = Convert.ToString(cthosema);
            this.txtHsTotales.Text = Convert.ToString(tthor);
            this.btnEditar.Enabled = true;
                   
        }
        public void Buscar()
        {
            this.gridview.DataSource = MateriaLogic.GetOne(this.txtbuscar.Text);
            this.gridview.DataBind();
        }
        protected void gridview_SelectedIndexChanged1(object sender, EventArgs e)
        {
            //this.txtplan.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[2].Text));
            guardarValor();
            llenarcajas();
            this.txtidplan.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[5].Text));
            this.btnEditar.Enabled = true;
        }

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

    }
}