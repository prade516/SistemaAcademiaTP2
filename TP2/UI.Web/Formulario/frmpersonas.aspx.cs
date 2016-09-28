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
                //llenarcomboPlan();
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
            this.gridview.DataSource = Logic.GetAll();
            //gridview.Columns[2].Visible = false;
            this.gridview.DataBind();
        }
    }
}