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
    public partial class FrmMaterias : Form
    {
        private bool Isnuevo = false;
        private bool IsEditar = false;
        public FrmMaterias()
        {
            InitializeComponent();
        }

        private void txthoraSemanales_TextChanged(object sender, EventArgs e)
        {
            this.txtcantidadHora.Text = Convert.ToString(Convert.ToInt32(this.txthoraSemanales.Text) * 4);
        }
        private void Ocultarcolumna()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
            this.dataListado.Columns[6].Visible = false;

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
        public void Listar()
        {
            MateriaLogic ul = new MateriaLogic();
            this.dataListado.DataSource = ul.GetAll();
            //this.Ocultarcolumna();
            lblTotal.Text = "Total de registro;" + Convert.ToString(dataListado.Rows.Count);
        }
        private void FrmMaterias_Load(object sender, EventArgs e)
        {
            Listar();
            Ocultarcolumna();
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
        private void Habilitar(bool valor)
        {
            this.txthoraSemanales.ReadOnly = !valor;
            this.txtDescripcion.Enabled = valor;
            //this.txtidplan.ReadOnly = !valor;
        }
        private void Limpiar()
        {
            this.txtidmateria.Text = string.Empty;
            this.txtNombrePlan.Text = string.Empty;
            this.txthoraSemanales.Text = string.Empty;
            this.txtcantidadHora.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
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
        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtidmateria.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
                //llenarcomboEspecialidad();
                //this.cbldEspecialidad.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Especialidad"].Value); ;

            }
            else
            {
                this.MensajeError("Debe de seleccionar primero el registro a Modificar");
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.Isnuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txthoraSemanales.Focus();
            //llenarcomboEspecialidad();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {

            this.txtidmateria.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["id_materia"].Value);
            this.txthoraSemanales.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["hs_semanales"].Value);
            this.txtcantidadHora.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["hs_totales"].Value);
            this.txtidPlan.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["id_plan"].Value); 
            this.tabControl1.SelectedIndex = 1;
        }
    }
}
