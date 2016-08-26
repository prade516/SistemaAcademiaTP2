using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Data.Database;
using System.Text.RegularExpressions;
using Business.Entities;

namespace UI.Desktop
{
    public partial class FrmPersona : Form 
    {
        private bool Isnuevo = false;
        private bool IsEditar = false;
        private static FrmPersona _instancia;
        public static FrmPersona GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new FrmPersona();
            }
            return _instancia;
        }
        public FrmPersona()
        {
            InitializeComponent();
            this.ttmensaje.SetToolTip(this.txtNombre, "Ingrese El nombre");
            this.ttmensaje.SetToolTip(this.txtApellido, "Ingrese el Apellido");
            this.ttmensaje.SetToolTip(this.cbAcesso, "Elegir el sexo");
            this.ttmensaje.SetToolTip(this.txtLegajo, "Ingrese El Legajo");
            this.ttmensaje.SetToolTip(this.txtDireccion, "Ingrese la direccion");
            this.ttmensaje.SetToolTip(this.txtTelefono, "Ingresa el Telefono");
            this.ttmensaje.SetToolTip(this.txtE_mail, "Ingresa el Correo");
           
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
            this.txtNombre.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtE_mail.Text = string.Empty;
            this.txtLegajo.Text = string.Empty;
            this.txtPlan.Text = string.Empty;
            this.txtIdPersonas.Text = string.Empty;
            cbldEspecialidad.Text = string.Empty;
            this.cbAcesso.Text = "Dar Aceso";
            this.cbsexo.Text = "Elegir sexo";
        }
        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.txtApellido.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.cbAcesso.Enabled = valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtE_mail.ReadOnly = !valor;
            this.txtLegajo.ReadOnly = !valor;
            this.cbsexo.Enabled = valor;
            this.cbAcesso.Enabled = valor;
            this.dtFecha.Enabled = valor;
            this.cbldEspecialidad.Enabled = !valor;
            //this.txtPlan.ReadOnly = !valor;
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
                this.button3.Enabled = true ;
               
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
                this.button3.Enabled = false;
            }
        }
        public void Plan(string Codigo, string Plan)
        {
            this.txtIdPlan.Text = Codigo;
            this.txtPlan.Text = Plan;
        }
        private void Ocultarcolumna()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[12].Visible = false;
            this.dataListado.Columns[4].Visible = false;
            this.dataListado.Columns[10].Visible = false;
            this.dataListado.Columns[7].Visible = false;
        }

        public void Buscar()
        {
            PersonaLogic ul = new PersonaLogic();
            if (txtBuscar.Text == string.Empty)
            {
                MensajeError("Falta ingresar algunos datos, seran remarcados");
                errorIcono.SetError(txtBuscar, "Ingresa la materia a Buscar");
            }
            else
            {
                //int busca = Convert.ToInt16(this.txtBuscar.Text);
                this.dataListado.DataSource = PersonaLogic.GetOne(txtBuscar.Text);
                //this.dataListado.DataSource = ul.GetOne( this.txtBuscar.Text);
                //this.Ocultarcolumna();
                lblTotal.Text = "Total de registro;" + Convert.ToString(dataListado.Rows.Count);
            }

        }
        public void Listar()
        {
            PersonaLogic ul = new PersonaLogic();
            this.dataListado.DataSource = ul.GetAll();
            this.Ocultarcolumna();
            lblTotal.Text = "Total de registro;" + Convert.ToString(dataListado.Rows.Count);
            cbldEspecialidad.Visible = false;
            
        }

        private void FrmPersona_Load(object sender, EventArgs e)
        {
            Listar();
            //llenarcomboEspecialidad();
            this.Habilitar(false);
            this.Botones();
            cbldEspecialidad.Enabled = false;
            txtIdPlan.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
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
                            resp = PersonaLogic.Delete(Convert.ToInt32(Codigo));
                            if (resp.Equals("OK"))
                            {
                                this.MensajeError(resp);
                            }
                            else
                            {
                                this.MensajeOk("Se elimino Correctamente el registro");
                                chkEliminar.Checked = false;                                
                            }
                        }
                    }
                    this.Listar();
                    this.chkEliminar.Checked = false;

                }
                else
                {
                    this.MensajeError("La eliminacion esta cancelada");
                    this.chkEliminar.Checked = false;
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string resp = "";
                Regex rgx = new Regex("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");
                Regex rgx1 = new Regex("[0-9]");//solo numero
                Regex rgxletra = new Regex("[a-zA-Z ]");
                string combo = cbAcesso.SelectedItem.ToString();
                string sexo = cbsexo.SelectedItem.ToString();
                if (!rgxletra.IsMatch(txtNombre.Text) || !rgxletra.IsMatch(txtApellido.Text) || txtDireccion.Text == string.Empty ||
                    !rgx.IsMatch(txtE_mail.Text) || !rgx1.IsMatch(txtTelefono.Text) || dtFecha.Value > DateTime.Now ||
                    !rgx1.IsMatch(txtLegajo.Text) || combo == "Dar acceso" || txtIdPlan.Text == string.Empty || sexo == "Elegir sexo")
                {
                   //&& this.dtFecha.Text == Convert.ToString(DateTime.Now)
                        MensajeError("Falta ingresar algunos datos, seran remarcados");
                        errorIcono.SetError(txtNombre, "Ingresa el nomnre");
                        errorIcono.SetError(txtApellido, "Ingresa el apellido");
                        errorIcono.SetError(txtDireccion, "Ingresa la Direccion");
                        errorIcono.SetError(txtE_mail, "Ingresa un email valido");
                        errorIcono.SetError(txtTelefono, "Ingresa el telefono");
                        errorIcono.SetError(dtFecha, "Ingresa una fecha corecta");
                        errorIcono.SetError(txtPlan, "Busca el Plan");
                        //MessageBox.Show("Falta ingresar algunos datos, seran remarcados");
                                    
                }
                else 
                {
                    if (this.Isnuevo)
                    {
                        resp = PersonaLogic.Save(this.txtNombre.Text.Trim(), txtApellido.Text.Trim(), this.txtDireccion.Text.Trim(), this.txtE_mail.Text.Trim(),
                                                 this.txtTelefono.Text.Trim(),this.dtFecha.Value, Convert.ToInt32(this.txtLegajo.Text.Trim()),
                                                 this.cbAcesso.Text, Convert.ToInt32(this.txtIdPlan.Text.Trim()), cbsexo.Text);
                    }
                    else
                    {
                        resp = PersonaLogic.Insertar(Convert.ToInt32(this.txtIdPersonas.Text.Trim()), this.txtNombre.Text.Trim(), this.txtApellido.Text.Trim(),
                                                     this.txtDireccion.Text.Trim(), this.txtE_mail.Text.Trim(), this.txtTelefono.Text.Trim(),this.dtFecha.Value,
                                                     Convert.ToInt32(this.txtLegajo.Text.Trim()), this.cbAcesso.Text, Convert.ToInt32(this.txtIdPlan.Text.Trim()),
                                                     this.cbsexo.Text);
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

                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.Isnuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
            cbldEspecialidad.Visible = false;
            this.txtPlan.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmLista_Plan vista = new FrmLista_Plan();
            vista.ShowDialog();
            Plan(vista.par1, vista.par2);
            cbldEspecialidad.Visible = false;
            txtPlan.Visible = true;
        }

        private void FrmPersona_FormClosing(object sender, FormClosingEventArgs e)
        {
            //_instancia = null;
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Isnuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            cbldEspecialidad.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdPersonas.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
                //llenarcomboEspecialidad();
                
             }
            else
            {
                this.MensajeError("Debe de seleccionar primero el registro a Modificar");
            }
        }
        string opc;
        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            
            this.txtIdPersonas.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            this.cbsexo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["sexo"].Value);
            this.txtApellido.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Apellido"].Value);
            this.dtFecha.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["fecha_nac"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["direccion"].Value);
            this.txtLegajo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["legajo"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["telefono"].Value);
            this.cbAcesso.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["tipo_persona"].Value);
            this.txtE_mail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["email"].Value);
            this.txtIdPlan.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["id_plan"].Value);
            opc = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
            Data.Database.Plan especia = new Data.Database.Plan();
            Planes fr = new Planes();
            cbldEspecialidad.DataSource = PlanLogic.GetOne(opc);
            cbldEspecialidad.ValueMember = "id_plan";
            cbldEspecialidad.DisplayMember = "desc_plan";
            if (cbldEspecialidad.DisplayMember == opc)
            {
                txtPlan.Text = fr.Plan;
            }
            this.tabControl1.SelectedIndex = 1;
            cbldEspecialidad.Visible = true;
            cbldEspecialidad.Enabled = false;
            txtPlan.Visible = false;
            
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

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }
        
    }
}
