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
            if (this.Isnuevo)
            {
                int val = Convert.ToInt32(this.txthoraSemanales.Text);
                this.txtcantidadHora.Text = Convert.ToString(val * 4);
                
            }
            else
            {
                this.txtcantidadHora.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["hs_totales"].Value);
            }
           
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
            this.Habilitar(false);
            this.Botones();
            this.btnEliminar.Enabled = false;
            
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
                this.btnEliminar.Enabled = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
                this.btnEliminar.Enabled = false;
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
        public void Materias(string Codigo, string Plan)
        {
            this.txtidPlan.Text = Codigo;
            this.txtNombrePlan.Text = Plan;
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
            this.txtDescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["desc_materia"].Value);
            this.txtidPlan.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["id_plan"].Value); 
            this.tabControl1.SelectedIndex = 1;
        }

        private void btnBuscarcategoria_Click(object sender, EventArgs e)
        {
            FrmLista_Plan vista = new FrmLista_Plan();
            vista.ShowDialog();
            Materias(vista.par1, vista.par2);
            //cbldEspecialidad.Visible = false;
            //txtPlan.Visible = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
             try
            {
                string resp = "";

                if (txtDescripcion.Text == string.Empty && txthoraSemanales.Text==string.Empty && txtcantidadHora.Text==string.Empty&& txtidPlan.Text==string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, seran remarcados");
                    errorIcono.SetError(txtDescripcion, "Ingrese un valor");
                    errorIcono.SetError(txtNombrePlan, "Ingrese un valor");
                }
                else
                {
                    if (this.Isnuevo)
                    {
                        resp = MateriaLogic.Insertar(txtDescripcion.Text.Trim().ToUpper(),Convert.ToInt32(txthoraSemanales.Text.Trim().ToUpper()),Convert.ToInt16(txtcantidadHora.Text.Trim().ToUpper()),Convert.ToInt32(txtidPlan.Text.Trim().ToUpper()));
                    }
                    else
                    {
                        resp = MateriaLogic.Editar(Convert.ToInt32(txtidmateria.Text), txtDescripcion.Text.Trim().ToUpper(),Convert.ToInt32(txthoraSemanales.Text.Trim().ToUpper()),Convert.ToInt32(txtcantidadHora.Text.Trim().ToUpper()),Convert.ToInt32(txtidPlan.Text.Trim().ToUpper()));
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema Academia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string resp = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            resp = MateriaLogic.Delete(Convert.ToInt32(Codigo));
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
    }
}
