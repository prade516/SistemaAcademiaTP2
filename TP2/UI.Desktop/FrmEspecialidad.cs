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
using Data.Database;
using Business.Logic;

namespace UI.Desktop
{
    public partial class FrmEspecialidad : Form
    {
        private bool Isnuevo = false;
        private bool IsEditar = false;
        public FrmEspecialidad()
        {
            InitializeComponent();
            this.ttmensaje.SetToolTip(this.txtDesc_especialidad, "Ingrese la descripcion");           
        }

        public void Buscar()
        {
            EspecialidadLogic ul = new EspecialidadLogic();
            if (txtBuscar.Text == string.Empty) 
            {
                MensajeError("Falta ingresar algunos datos, seran remarcados");
                errorIcono.SetError(txtBuscar, "Ingresa la materia a Buscar");
            }
            else
            {
                this.dataListado.DataSource = EspecialidadLogic.GetOne(this.txtBuscar.Text);
                 //this.dataListado.DataSource = ul.GetOne( this.txtBuscar.Text);
                //this.Ocultarcolumna();
                lblTotal.Text = "Total de registro;" + Convert.ToString(dataListado.Rows.Count);
            }
            
        }
        public void Listar()
        {
            EspecialidadLogic ul = new EspecialidadLogic();
            this.dataListado.DataSource = ul.GetAll();
            //this.Ocultarcolumna();
            lblTotal.Text = "Total de registro;" + Convert.ToString(dataListado.Rows.Count);
            dataListado.AutoSizeRowsMode.ToString();
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema Academico", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Mensaje error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema Academico", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void Limpiar()
        {
            this.txtid_especialidad.Text = string.Empty;
            this.txtDesc_especialidad.Text = string.Empty;
        }
        private void Habilitar(bool valor)
        {
            this.txtDesc_especialidad.ReadOnly = !valor;
        }
        private void Botones()
        {
            if (this.Isnuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }
        private void Ocultarcolumna()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[3].Visible = false;
            //this.dataListado.Columns[4].Visible = false;
            //this.dataListado.Columns[10].Visible = false;
            //this.dataListado.Columns[7].Visible = false;
        }
        private void FrmEspecialidad_Load(object sender, EventArgs e)
        {
            Listar();
            Ocultarcolumna();
            this.Habilitar(false);
            this.Botones();
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.Isnuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string resp="";

                if (txtDesc_especialidad.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, seran remarcados");
                    errorIcono.SetError(txtDesc_especialidad, "Ingrese un valor");
                }
                else
                {
                    if (this.Isnuevo) 
                    {
                       resp = EspecialidadLogic.Insertar(txtDesc_especialidad.Text.Trim().ToUpper());
                    }
                    else 
                    {
                        resp = EspecialidadLogic.Editar(Convert.ToInt32(txtid_especialidad.Text),this.txtDesc_especialidad.Text.Trim().ToUpper());
                    }
                   if(resp.Equals("OK"))
                   {
                       if (this.Isnuevo)
                       {
                           this.MensajeOk("Se Inserto de forma correcto el registro");
                       }
                       else
                       {
                           this.MensajeOk("Se Actualizo de forma correcto el registro");
                       }
                   }
                   else
                   {
                       this.MensajeError(resp);
                   }
                   this.Isnuevo = false;
                   this.IsEditar = false;
                   this.Botones();
                   this.Limpiar();
                   this.Listar();


                   //DataGridTextBoxColumn row = dataListado.Columns[2];
                   //r = 80;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtid_especialidad.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe de seleccionar primero el registro a Modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Isnuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        private void dataListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtid_especialidad.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idespecialidad"].Value);
            this.txtDesc_especialidad.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["descespecialidad"].Value);
            this.tabControl1.SelectedIndex = 1;
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string resp = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            resp = EspecialidadLogic.Delete(Convert.ToInt32(Codigo));
                            if (resp.Equals("OK"))
                            {
                                this.MensajeOk("Se elimino Correctamente el registro");
                                chkEliminar.Checked = false;
                            }
                            else
                            {
                                this.MensajeError(resp);
                                //jfsaklfsklfsklfkslakfskl
                            }
                        }
                    }
                    this.Listar();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar(); 
        }

    }
}
