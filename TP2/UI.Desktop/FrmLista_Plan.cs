using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class FrmLista_Plan : Form
    {
        public FrmLista_Plan()
        {
            InitializeComponent();
        }
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema Academico", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void Lista_Persona_Load(object sender, EventArgs e)
        {
            Listar();
        }
       public void Listar()
        {
            PlanLogic ul = new PlanLogic();
            this.dataListado.DataSource = ul.GetAll();
            this.Ocultarcolumna();
            lblTotal.Text = "Total de registro;" + Convert.ToString(dataListado.Rows.Count);
        }
       public void Buscar()
       {
           PlanLogic ul = new PlanLogic();
           if (txtBuscar.Text == string.Empty)
           {
               MensajeError("Falta ingresar algunos datos, seran remarcados");
               errorIcono.SetError(txtBuscar, "Ingresa la materia a Buscar");
           }
           else
           {
               this.dataListado.DataSource = PlanLogic.GetOne(this.txtBuscar.Text);
               //this.dataListado.DataSource = ul.GetOne( this.txtBuscar.Text);
               //this.Ocultarcolumna();
               lblTotal.Text = "Total de registro;" + Convert.ToString(dataListado.Rows.Count);
           }
       }
       private void Ocultarcolumna()
       {
           this.dataListado.Columns[1].Visible = false;
           this.dataListado.Columns[4].Visible = false;
           //this.dataListado.Columns[4].Visible = false;
           //this.dataListado.Columns[10].Visible = false;
           //this.dataListado.Columns[7].Visible = false;
       }

       private void btnBuscar_Click(object sender, EventArgs e)
       {
           Buscar();
       }    

      private void dataListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
       {

       }

      private void dataListado_DoubleClick(object sender, EventArgs e)
      {
          FrmPersona frpersona = FrmPersona.GetInstancia();
          string par1, par2;
          par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
          par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["Plan"].Value);
                   
          frpersona.Plan(par1, par2);

          this.Hide();
      }
    }
}
