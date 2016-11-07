using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web.Administrador
{
    public partial class frmmaterias : System.Web.UI.Page
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

        protected void gridview_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = (Convert.ToString(this.gridview.SelectedRow.Cells[0].Text)).ToString();
            string nombre = (Convert.ToString(this.gridview.SelectedRow.Cells[1].Text)).ToString();
            string apellido = (Convert.ToString(this.gridview.SelectedRow.Cells[2].Text)).ToString();
            bool habilitado=true;
            Session.Add("CodigoPerso", id);
            Session.Add("Nombre", nombre);
            Session.Add("Apellido", apellido);
            Session.Add("Habilitado", habilitado);

            Response.Redirect("Usuarios.aspx");
            
        }

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            
        }
    }
}