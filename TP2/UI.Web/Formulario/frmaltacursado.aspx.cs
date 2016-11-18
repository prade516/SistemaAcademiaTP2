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
            int id = (int)(Session["ID"]);
            int anio = (int)(Session["año"]);
            int tipo = (int)(Session["Tipo"]);
            AlumnoInscripciones al = new AlumnoInscripciones();
           
            Alumnos_InscripcionesLogic cur = new Alumnos_InscripcionesLogic();
            if (tipo==1)
            {
                Response.Redirect("frminscribirporAdministrador.aspx");
                
            }
            else if (tipo==3)
            {
                this.gridview.DataSource = Logic.GetByInscripto(id);
                this.gridview.DataBind();
            }
          

        }       
        protected void gridview_SelectedIndexChanged(object sender, EventArgs e)
        {         
            int id_cur = Convert.ToInt32((Convert.ToString(this.gridview.SelectedRow.Cells[0].Text)).ToString());
            int nota = 0;
            string materia = (string)(Session["materia"]);
            string inscripto = "Cursando";
            int idCodPer = (int)(Session["CodPersona"]);

            List<AlumnoInscripciones> listadoPersonas = new List<AlumnoInscripciones>();
            AlumnoInscripciones alu = new AlumnoInscripciones();
            Alumnos_InscripcionesLogic compa = new Alumnos_InscripcionesLogic();

            listadoPersonas = compa.GetAllInscriptonCursado();
            bool bandera = true;
            for (int i = 0; i < listadoPersonas.Count; i++)
            {
                if (materia == listadoPersonas[i].Desc_Materia)
                {
                    bandera = false;
                }
            }
            if (bandera)
            {
                alu.IdAlumnos = idCodPer;
                alu.IdCurso = id_cur;
                alu.Condicion = inscripto;
                alu.Nota = nota;
                alu.Estado = BusinessEntity.Estados.Nuevo;
                Logic.Insertar(alu);
                Response.Redirect("frmcursar.aspx");
            }
            else
            {
                Response.Redirect("Error.aspx");

            }
        }
    }
}