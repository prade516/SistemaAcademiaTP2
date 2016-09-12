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
            UsuarioLogic log = new UsuarioLogic();
            this.gridview.DataSource = log.GetAll();
            this.gridview.DataBind();
        }
        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }
        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
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
            //this.txtidplan.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
        }

        private void LoadForm(int id)
        {
            UsuarioLogic log = new UsuarioLogic();
            this.Entity = log.GetOne(id);
            this.txtusuario.Text = this.Entity.Nombre_Usuario;
            //txtclave.UseSystemPasswordChar = true;
            this.txtclave.Text = this.Entity.Clave;
            this.Habilitado.Checked = this.Entity.Habilitado;
            
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanal.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
                this.EnableForm(true);
                //this.txtapellido.Text = this.gr;
            }
        }
        private void LoadEntity(Usuario usuario)
        {
            usuario.Nombre_Usuario = this.txtusuario.Text;
            usuario.Clave = this.txtclave.Text;
            usuario.Habilitado = this.Habilitado.Checked;
        }
        private void SaveEntity(Usuario usuario)
        {
            UsuarioLogic log = new UsuarioLogic();
            log.Save(usuario);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
               case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.Entity = new Usuario();
                    this.Entity.Id_Usuario = this.SelectedID;
                    this.Entity.Estado = BusinessEntity.Estados.Modificar;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity= new Usuario();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                default:
                    break;
            }            

            this.formPanal.Visible = false;
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
            this.repetirClveLabel.Visible = enable;
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanal.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }
        private void DeleteEntity(int id)
        {
            UsuarioLogic log = new UsuarioLogic();
            log.Delete(id);
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanal.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
            this.Habilitado.Checked = false;  
        }

        private void ClearForm()
        {
            this.txtnombre.Text = string.Empty;
            this.txtapellido.Text = string.Empty;
            this.txtusuario.Text = string.Empty;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanal.Visible = false;
            this.ClearForm();
            this.EnableForm(false);
            this.Habilitado.Checked = false;    
        }

    }
}