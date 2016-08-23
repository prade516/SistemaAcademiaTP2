using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial  class UsuarioDesktop : ApplicationForm
    {
        public UsuarioDesktop()
        {
            InitializeComponent();
        }
        public virtual void MapearDeDatos() 
        {
            this.txtID.Text = UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = UsuarioActual.Habilitado;
            //this.txtNombre.Text = UsuarioActual.Email.ToString();
            this.txtApellido.Text = UsuarioActual.Nombre_Usuario.ToString();
            this.txtClave.Text = UsuarioActual.Clave.ToString();

            switch (Modo)
            {
                case ModoForm.Alta:
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Modificacion:
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Consulta:
                    btnAceptar.Text = "Aceptar";
                    break;
                default:
                    break;
            }
        }
   
        public virtual void MapearADatos() {
          
            switch (Modo)
            {
                case ModoForm.Alta:
                    UsuarioActual = new Usuario();  
                     this.UsuarioActual.Habilitado= this.chkHabilitado.Checked;
                     //this.UsuarioActual.Email=this.txtEmail.Text;
                    this.UsuarioActual.Nombre_Usuario=this.txtUsuario.Text;
                    this.UsuarioActual.Clave=this.txtClave.Text;
                    break;
                case ModoForm.Baja:  
                    this.UsuarioActual.ID = Convert.ToInt16(this.txtID.Text);
                    break;
                case ModoForm.Modificacion:
                     this.UsuarioActual.Habilitado= this.chkHabilitado.Checked;
                     //this.UsuarioActual.Email=this.txtNombre.Text;
                     this.UsuarioActual.Nombre_Usuario=this.txtApellido.Text;
                     this.UsuarioActual.Clave=this.txtClave.Text;
                    break;
                case ModoForm.Consulta:
                    this.UsuarioActual.ID = Convert.ToInt16(this.txtID.Text);
                     this.UsuarioActual.Habilitado= this.chkHabilitado.Checked;
                     //this.UsuarioActual.Email=this.txtNombre.Text;
                     this.UsuarioActual.Nombre_Usuario=this.txtApellido.Text;
                     this.UsuarioActual.Clave=this.txtClave.Text;
                    break;
                default:
                    break;
            }
            
        }
        public virtual void GuardarCambios() {
            MapearADatos();
            UsuarioLogic usu = new UsuarioLogic();
            usu.Save(UsuarioActual);


        }
        public  virtual bool  Validar()
        {
            if (txtUsuario.Text != String.Empty  && txtClave.Text != String.Empty && txtConfirmarClave.Text != String.Empty)
            {
               
                if (txtClave.TextLength >= 8 && txtClave.Text == txtConfirmarClave.Text)
                {
                    MessageBox.Show("Conectado");
                    return true;
                }
                else
                {
                    Notificar("Mensaje de error", "La clave debe superar a 8 caracteres o la confirmacion es diferente de la clave", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                
            }
            Notificar("Mensaje de error", "Todos los campos son obligatorios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   
            return false;
            }

        public void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        public void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }

        private Usuario _UsuarioActual;

        public Usuario UsuarioActual
        {
            get { return _UsuarioActual; }
            set { _UsuarioActual = value; }
        }
        public UsuarioDesktop(ModoForm modo) :this()
        {
            Modo = modo;
        }
        public UsuarioDesktop(int ID, ModoForm modo) : this() 
        {
            UsuarioLogic usr = new UsuarioLogic();
            UsuarioActual=usr.GetOne(ID);
            Modo = modo;
            MapearDeDatos();

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                this.Close();
                
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
