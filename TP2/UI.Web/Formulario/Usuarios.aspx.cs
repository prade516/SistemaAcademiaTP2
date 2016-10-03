using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;
using System.Windows;
namespace UI.Web
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
                this.formPanal.Visible = Convert.ToBoolean(Session["Habilitado"]);
                this.txtnombre.Text = Convert.ToString(Session["Nombre"]);
                this.txtapellido.Text = Convert.ToString(Session["Apellido"]);
                this.txtidpersona.Text = Convert.ToString(Session["CodigoPerso"]);
                this.EnableForm(Convert.ToBoolean(Session["Habilitado"]));
                this.Habilitado.Checked =!  Convert.ToBoolean(Session["Habilitado"]);
                this.aceptarLinkButton.Visible = Convert.ToBoolean(Session["Habilitado"]);
                this.cancelarLinkButton.Visible = Convert.ToBoolean(Session["Habilitado"]);
                this.nuevoLinkButton.Visible =! Convert.ToBoolean(Session["Habilitado"]);
            }
          
        }

        UsuarioLogic _logic = new UsuarioLogic();

        public UsuarioLogic Logic
        {
            get { return _logic; }
            set { _logic = value; }
        }
        private void LoadGrid()
        {
            //UsuarioLogic log = new UsuarioLogic();
            this.gridview.DataSource = Logic.GetAll();
            this.gridview.DataBind();
            //gridview.EditIndex = -1;
        }
        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }
        public FormModes FormMode
        {
            get { return ((FormModes)this.ViewState["FormMode"]); }
            set { this.ViewState["FormMode"] = value; }
        }
        private Usuario Entity
        {
            get;
            set;
            //get { return Entity; }
            //set { Entity = value; }
        }

        private int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"]!=null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }
        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }
        }

        protected void gridview_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.SelectedID = (int)this.gridview.SelectedValue;
            this.SelectedID = Convert.ToInt32(this.gridview.SelectedRow.Cells[0].Text);
            this.txtidUsuario.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[0].Text)).ToString();
            this.txtidpersona.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[1].Text)).ToString();
            this.txtnombre.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[2].Text)).ToString();
            this.txtapellido.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[3].Text)).ToString();
            this.txtusuario.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[4].Text)).ToString();
            this.txtclave.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[5].Text)).ToString();
            this.Habilitado.Checked =(Convert.ToBoolean(this.gridview.SelectedRow.Cells[6].Text));
            
            this.txtRepetirClave.Text = (Convert.ToString(this.gridview.SelectedRow.Cells[5].Text)).ToString();

            this.formPanal.Visible = true;
            this.editarLinkButton.Visible = true;
            this.eliminarLinkButton.Visible = true;
            this.nuevoLinkButton.Visible = false;
            this.aceptarLinkButton.Visible = false;
            this.cancelarLinkButton.Visible = true;
        }

        protected void CargarUsuario()
        {
            try
            {
                Usuario usua = new Usuario();
                bool registar = true;
                foreach (GridViewRow row in gridview.Rows)
                {
                    if (row.Cells[1].Text == (this.txtusuario.Text).ToUpper())
                    {
                        registar = false;
                        msgError.Text = "ya existe ese usuario";
                    }
                }
                if (registar)
                {                  
                        usua.Nombre_Usuario = this.txtusuario.Text;
                        usua.Clave = this.txtclave.Text;
                        usua.Habilitado = this.Habilitado.Checked;
                        usua.Cambia_Clave = this.CkbCambiaClave.Checked;
                        usua.Id_persona = Convert.ToInt32(this.txtidpersona.Text);
                      
                        usua.Estado = BusinessEntity.Estados.Nuevo;
                        Logic.Save(usua);
                        this.Limpiar();
                    //gridview.e
                        //this.LoadGrid();
                }
            }
            catch (Exception ex)
            {
                msgError.Text = ex.Message;
            }
           
        }
        protected void ModificarUsuario()
        {
            try
            {
                Usuario usua = new Usuario();
                usua.Id_Usuario = Convert.ToInt32(this.txtidUsuario.Text);
                usua.Nombre_Usuario = this.txtusuario.Text;
                usua.Clave = this.txtclave.Text;
                usua.Habilitado = this.Habilitado.Checked;
                usua.Cambia_Clave = this.CkbCambiaClave.Checked;
                usua.Id_persona = Convert.ToInt32(this.txtidpersona.Text);
                usua.Estado = BusinessEntity.Estados.Modificar;
                Logic.Update(usua);
                this.Limpiar();
            }
            catch (Exception ex)
            {

                msgError.Text = ex.Message;
            }
            //this.LoadGrid();
        }

        private void LoadForm(string id)
        {
            UsuarioLogic log = new UsuarioLogic();
            this.gridview.DataSource = Logic.GetOne(id);
            gridview.DataBind();
            this.gridview.Columns[9].Visible = false;
            //this.txtusuario.Text = this.Entity.Nombre_Usuario;
            //txtclave.UseSystemPasswordChar = true;
            //this.txtclave.Text = this.Entity.Clave;
            //this.Habilitado.Checked = this.Entity.Habilitado;
            
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanal.Visible = true;
                this.FormMode = FormModes.Modificacion;
                //this.LoadForm(this.SelectedID);
                this.EnableForm(true);
                this.editarLinkButton.Visible = false;
                this.aceptarLinkButton.Visible = true;
                this.aceptarLinkButton.Text = "Modificar";
                this.eliminarLinkButton.Visible = false;
                this.cancelarLinkButton.Visible = true;
                //this.txtapellido.Text = this.gr;
            }
        }
        private void LoadEntity(Usuario usuario)
        {
            usuario.Nombre_Usuario = this.txtusuario.Text;
            usuario.Clave = this.txtclave.Text;
            usuario.Habilitado = this.Habilitado.Checked;
            usuario.Cambia_Clave = this.CkbCambiaClave.Checked;
        }
        private void SaveEntity(Usuario usuario)
        {
            try
            {
                UsuarioLogic log = new UsuarioLogic();
                log.Save(usuario);
            }
            catch (Exception ex)
            {
                msgError.Text = ex.Message;
            }
           
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            //switch (this.FormMode)
            //{
            //   case FormModes.Baja:
            //        this.DeleteEntity(this.SelectedID);
            //        this.LoadGrid();
            //        break;
            //    case FormModes.Modificacion:
            //        this.Entity = new Usuario();
            //        this.Entity.Id_Usuario = this.SelectedID;
            //        this.Entity.Estado = BusinessEntity.Estados.Modificar;
            //        this.LoadEntity(this.Entity);
            //        this.SaveEntity(this.Entity);
            //        this.LoadGrid();
            //        break;
            //    case FormModes.Alta:
            //        this.Entity= new Usuario();
            //        this.LoadEntity(this.Entity);
            //        this.SaveEntity(this.Entity);
            //        this.LoadGrid();
            //        break;
            //    default:
            //        break;
            //}            
            if (this.txtidUsuario.Text=="")
            {
                this.CargarUsuario();
                this.LoadGrid();
            }
            else
            {
                this.ModificarUsuario();
                this.LoadGrid();
            }
            this.formPanal.Visible = false;
            this.aceptarLinkButton.Visible = false;
        }
        private void Limpiar()
        {
            this.txtidpersona.Text = string.Empty;
            this.txtnombre.Text = string.Empty;
            this.txtapellido.Text = string.Empty;
            this.txtidUsuario.Text = string.Empty;
            this.txtusuario.Text = string.Empty;
            this.txtclave.Text = string.Empty;
            this.txtRepetirClave.Text = string.Empty;
            this.Habilitado.Checked =false;
            this.CkbCambiaClave.Checked = false;
        }
        private void EnableForm(bool enable)
        {
            this.txtidUsuario.Enabled = enable;
            this.txtnombre.Enabled = enable;
            this.txtapellido.Enabled = enable;
            this.txtusuario.Enabled = enable;
            this.txtclave.Enabled = enable;
            this.txtRepetirClave.Visible = enable;
            this.Habilitado.Checked = enable;
            //this.repetirClveLabel.Visible = enable;
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.DeleteEntity(Convert.ToInt32(this.txtidUsuario.Text));
                this.Limpiar();
                this.LoadGrid();
            }
            catch (Exception ex)
            {
                msgError.Text = ex.Message;
            }
            this.formPanal.Visible = false;
            this.eliminarLinkButton.Visible = false;
            this.nuevoLinkButton.Visible = true;
            //this.LoadGrid();
        }
        private void DeleteEntity(int id)
        {
            Usuario log = new Usuario();
            log.Id_Usuario = id;
            log.Estado = BusinessEntity.Estados.Eliminar;
            Logic.Save(log);
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanal.Visible = true;
            this.FormMode = FormModes.Alta;
            this.EnableForm(true);
            this.Habilitado.Checked = false;
            this.aceptarLinkButton.Visible = true;
            this.cancelarLinkButton.Visible = true;           
            this.nuevoLinkButton.Visible = false;
            this.Limpiar();
            
        }

        //private void ClearForm()
        //{
        //    this.txtnombre.Text = string.Empty;
        //    this.txtapellido.Text = string.Empty;
        //    this.txtusuario.Text = string.Empty;
        //}

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanal.Visible = false;
            this.Limpiar();
            this.EnableForm(false);
            this.Habilitado.Checked = false;
            this.aceptarLinkButton.Visible = false;
            this.nuevoLinkButton.Visible = true;
            this.cancelarLinkButton.Visible = false;
            this.eliminarLinkButton.Visible = false;
            this.editarLinkButton.Visible = false;
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmListaPersona.aspx");
           
            //Session.Add("Habilitado", this.formPanal.Visible = true);
            //this.formPanal.Visible = true;
        }

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            this.LoadForm(this.txtbuscar.Text);
        }

    }
}