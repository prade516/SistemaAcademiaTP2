using Business.Entities;
using Business.Logic;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web.Formulario
{
    public partial class frmaltacursado : System.Web.UI.Page
    {
        //Alumnos_InscripcionesD com = new Alumnos_InscripcionesD();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadGrid();

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
            string materia = (string)(Session["materia"]);
            int anio = (int)(Session["año"]);
            int tipo = (int)(Session["Tipo"]);
            if (tipo==1)
            {
                
            }
            this.gridview.DataSource = Logic.GetByInscripto(materia, tipo, anio);
            this.gridview.DataBind();
        }

        protected void gridview_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id_alu = Convert.ToInt32((Convert.ToString(this.gridview.SelectedRow.Cells[0].Text)).ToString());
            int id_cur = Convert.ToInt32((Convert.ToString(this.gridview.SelectedRow.Cells[1].Text)).ToString());
            int nota = 0;
            string inscripto = "Inscripto";

            AlumnoInscripciones alu = new AlumnoInscripciones();

            alu.IdAlumnos = id_alu;
            alu.IdCurso = id_cur;
            alu.Condicion = inscripto;
            alu.Nota = nota;
            alu.Estado = BusinessEntity.Estados.Nuevo;
            Logic.Insertar(alu);
            this.gridview.SelectedRow.Cells[3].Text="Inscripto";
           
        }
    }
}