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
    public partial class frmexamen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
                //llenarcomboPlan();
            }
        }
        Alumnos_InscripcionesLogic _logic = new Alumnos_InscripcionesLogic();

        public Alumnos_InscripcionesLogic Logic
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

        protected void gridview_SelectedIndexChanged(object sender, EventArgs e)
        {

            int año = Convert.ToInt32((Convert.ToString(this.gridview.SelectedRow.Cells[0].Text)).ToString());
            int ID = Convert.ToInt32((Convert.ToString(this.gridview.SelectedRow.Cells[1].Text)).ToString());
            string materia = (Convert.ToString(this.gridview.SelectedRow.Cells[2].Text)).ToString();

            Session.Add("año", año);
            Session.Add("ID", ID);
            Session.Add("materia", materia);
            //Buscar();
            Response.Redirect("frmaltacursado.aspx");
            //int id_cur = Convert.ToInt32((Convert.ToString(this.gridview.SelectedRow.Cells[0].Text)).ToString());
            //int nota = 0;
            //string inscripto = "Inscribir a cursar";
            //int idCodPer = (int)(Session["CodPersona"]);

            //AlumnoInscripciones alu = new AlumnoInscripciones();

            //alu.IdAlumnos = idCodPer;
            //alu.IdCurso = id_cur;
            //alu.Condicion = inscripto;
            //alu.Nota = nota;
            //alu.Estado = BusinessEntity.Estados.Modificar;
            //Logic.Editar(alu);
            ////this.gridview.SelectedRow.Cells[3].Text="Inscripto";
            //Response.Redirect("frmcursar.aspx");
        }
    }
}