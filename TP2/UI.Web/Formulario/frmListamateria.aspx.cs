using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web.Formulario
{
    public partial class frmplanlista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Listar();
        }
        PlanLogic _logic = new PlanLogic();

        public PlanLogic Logic
        {
            get { return _logic; }
            set { _logic = value; }
        }
        public void Listar()
        {
            MateriaLogic ul = new MateriaLogic();
            this.gridview.DataSource = ul.GetAll();
            this.gridview.DataBind();
            //this.Ocultarcolumna();
            lblTotal.Text = "Total de registro: " + Convert.ToString(gridview.Rows.Count);
        }

        protected void gridview_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string idplan = (Convert.ToString(this.gridview.SelectedRow.Cells[0].Text)).ToString();
            string plan = (Convert.ToString(this.gridview.SelectedRow.Cells[1].Text)).ToString();
            Session.Add("codigo", idplan);
            Session.Add("plan", plan);
            //Session.Add("Last", lastName);
            //Session.Add("City", city);
            Server.Transfer("frmMaterias.aspx");

        }
    }
}