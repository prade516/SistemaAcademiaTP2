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
    public partial class FrmListaUsuario : Form
    {
        public FrmListaUsuario()
        {
            InitializeComponent();
        }
        private void Ocultarcolumna()
        {
            //this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[7].Visible = false;
            this.dataListado.Columns[8].Visible = false;
            this.dataListado.Columns[9].Visible = false;

        }
        public void Listar()
        {
            UsuarioLogic ul = new UsuarioLogic();
            this.dataListado.DataSource = ul.GetAll();
            //this.Ocultarcolumna();
            lblTotal.Text = "Total de registro;" + Convert.ToString(dataListado.Rows.Count);
        }
        private void FrmListaUsuario_Load(object sender, EventArgs e)
        {
            Listar();
            Ocultarcolumna();
        }
    }
}
