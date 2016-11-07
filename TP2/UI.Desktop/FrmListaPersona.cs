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
    public partial class FrmListaPersona : Form
    {
        public string par1, par2,par3;
        public FrmListaPersona()
        {
            InitializeComponent();
        }
        private void Ocultarcolumna()
        {
            //this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[10].Visible = false;
            this.dataListado.Columns[11].Visible = false;
            this.dataListado.Columns[9].Visible = false;
            this.dataListado.Columns[3].Visible = false;
            this.dataListado.Columns[6].Visible = false;
            this.dataListado.Columns[4].Visible = false;

        }
        public void Listar()
        {
            PersonaLogic ul = new PersonaLogic();
            this.dataListado.DataSource = ul.GetAllAdministrador();
            //this.Ocultarcolumna();
            lblTotal.Text = "Total de registro;" + Convert.ToString(dataListado.Rows.Count);
        }
        private void FrmListaUsuario_Load(object sender, EventArgs e)
        {
            Listar();
            Ocultarcolumna();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            par3 = Convert.ToString(this.dataListado.CurrentRow.Cells["Apellido"].Value);
            this.Hide();
        }
    }
}
