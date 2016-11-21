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
using UI.Desktop;
using Util;

namespace UI.Desktop
{
    public partial class FrmLogin : Form
    {
        private string estado;
        public FrmLogin()
        {
            InitializeComponent();
        }
        public enum gestion
        {
            Administrador = 1,
            Profesor,
            Alumno
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario person = new Usuario();
                Validaciones valida = new Validaciones();
                UsuarioLogic Logic = new UsuarioLogic();
                List<Usuario> listadoPersonas = new List<Usuario>();
                listadoPersonas = Logic.GetAll();
                bool usuarioencontrado = false;

                for (int i = 0; i < listadoPersonas.Count; i++)
                {
                    if (!usuarioencontrado)
                    {
                        if (txtUsuario.Text.ToLower() == listadoPersonas[i].Nombre_Usuario.ToLower())
                        {
                            if (valida.EncryptKey(txtContraseña.Text) == listadoPersonas[i].Clave)
                            {
                                usuarioencontrado = true;
                                person = listadoPersonas[i];
                            }
                        }
                    }
                    else
                        break;
                }
                if (!usuarioencontrado)
                {
                    MessageBox.Show("No Tiene Acesso al Sistema", "Sistema Academico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Principal frm = new Principal();
                    frm.IdUsuario = Convert.ToString(person.Id_Usuario);
                    frm.Nombre = person.Nombre;
                    frm.Apellido = person.Apellido;
                    estado = person.Tipo;
                    if (estado == Convert.ToString(gestion.Administrador))
                    {
                        frm.Acceso = "1";
                    }
                    else if (estado == Convert.ToString(gestion.Profesor))
                    {
                        frm.Acceso = "2";
                    }
                    else
                    {
                        frm.Acceso = "3";
                    }

                    frm.Show();
                    this.Hide();

                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            } 
          }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.GroupBox1.TabIndex = 0;
        }
    }
}
