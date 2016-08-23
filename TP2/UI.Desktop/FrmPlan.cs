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
    public partial class FrmPlan : Form
    {
        private bool Isnuevo = false;
        private bool IsEditar = false;
        public FrmPlan()
        {
            InitializeComponent();
            this.ttmensaje.SetToolTip(this.txtplan, "Ingrese la Direcion");           
       
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
        public void Listar()
        {
            PlanLogic ul = new PlanLogic();
            this.dataListado.DataSource = ul.GetAll();
            //this.Ocultarcolumna();
            lblTotal.Text = "Total de registro;" + Convert.ToString(dataListado.Rows.Count);
        }
        private void Ocultarcolumna()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[2].Visible = false;
            this.dataListado.Columns[5].Visible = false;
           
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
        private void Habilitar(bool valor)
        {
            this.txtplan.ReadOnly = !valor;
            this.cbldEspecialidad.Enabled = valor;
            //this.txtidplan.ReadOnly = !valor;
            
        }
        private void Limpiar()
        {
            this.txtidplan.Text = string.Empty;
            this.txtplan.Text = string.Empty;
            this.cbldEspecialidad.Text = string.Empty;
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
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.Isnuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
        }
        private void FrmPlan_Load(object sender, EventArgs e)
        {
            Listar();
            Ocultarcolumna();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
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
                            resp = PlanLogic.Delete(Convert.ToInt32(Codigo));
                            if (resp.Equals("OK"))
                            {
                                this.MensajeOk("Se elimino Correctamente el registro");
                                chkEliminar.Checked = false;
                            }
                            else
                            {
                                this.MensajeError(resp);
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtidplan.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
                llenarcomboEspecialidad();
                this.cbldEspecialidad.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Especialidad"].Value); ;

            }
            else
            {
                this.MensajeError("Debe de seleccionar primero el registro a Modificar");
            }
        }

        private void dataListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtidplan.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
            this.txtplan.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Plan"].Value);
            this.cbldEspecialidad.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Especialidad"].Value); ;
            this.tabControl1.SelectedIndex = 1;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Isnuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }
        private void llenarcomboEspecialidad()
        {
            Data.Database.Especialidad especia = new Data.Database.Especialidad();
            cbldEspecialidad.DataSource = especia.GetAll();
            cbldEspecialidad.ValueMember = "Idespecialidad";
            cbldEspecialidad.DisplayMember = "DescEspecialidad";
        }
        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            this.Isnuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtplan.Focus();
            llenarcomboEspecialidad();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string resp = "";

                if (txtplan.Text == string.Empty && cbldEspecialidad.Text==string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, seran remarcados");
                    errorIcono.SetError(txtplan, "Ingrese un valor");
                    errorIcono.SetError(cbldEspecialidad, "Ingrese un valor");
                }
                else
                {
                    if (this.Isnuevo)
                    {
                        resp = PlanLogic.Insertar(txtplan.Text.Trim().ToUpper(),Convert.ToInt32(cbldEspecialidad.SelectedValue));
                    }
                    else
                    {
                        resp = PlanLogic.Editar(Convert.ToInt32(txtidplan.Text), this.txtplan.Text.Trim().ToUpper(),Convert.ToInt32(cbldEspecialidad.SelectedValue));
                    }
                    if (resp.Equals("OK"))
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
    }
}
