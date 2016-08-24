using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Desktop;

namespace UI.Desktop
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            string usuario, password;
            usuario = Convert.ToString(this.txtUsuario.Text);
            password = Convert.ToString(this.txtContraseña.Text);
            DataTable Datos = Business.Logic.UsuarioLogic.Login(usuario, password);
            
                if (Datos.Rows.Count == 0)
                {
                    MessageBox.Show("No Tiene Acesso al Sistema", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Principal frm = new Principal();
                    frm.IdUsuario = Datos.Rows[0][0].ToString();
                    frm.Nombre = Datos.Rows[0][1].ToString();
                    frm.Apellido = Datos.Rows[0][2].ToString();
                    frm.Acceso = Datos.Rows[0][3].ToString();

                    frm.Show();
                    this.Hide();
                }                 
          }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.txtUsuario.Focus();
        }
    }
}
