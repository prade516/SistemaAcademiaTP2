namespace UI.Desktop
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.SyscadMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SalirMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PersonaMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.altaPersonaMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.altaUsuarioMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.InscripcionMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.examenMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cursarMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.condicionDeAlumnosInscriptoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ConsultaMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.notasMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cursarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.examenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historiaAcademicoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.verMateriasAprobadasMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cursosMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.inscriptoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.HerramientaMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.realizarBackUpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.restaurarBackUpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.carreraMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.especialidadesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.planesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.materiasMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.comisionesMenuI = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.UsuarioStripButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.Conectado = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SyscadMenu,
            this.PersonaMenu,
            this.InscripcionMenu,
            this.ConsultaMenu,
            this.HerramientaMenu,
            this.carreraMenu,
            this.helpMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.HerramientaMenu;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(632, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // SyscadMenu
            // 
            this.SyscadMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SalirMenu});
            this.SyscadMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.SyscadMenu.Name = "SyscadMenu";
            this.SyscadMenu.Size = new System.Drawing.Size(123, 20);
            this.SyscadMenu.Text = "&Sistema Academico";
            // 
            // SalirMenu
            // 
            this.SalirMenu.Name = "SalirMenu";
            this.SalirMenu.Size = new System.Drawing.Size(96, 22);
            this.SalirMenu.Text = "&Salir";
            this.SalirMenu.Click += new System.EventHandler(this.ExitToolsStripMenuItem_Click);
            // 
            // PersonaMenu
            // 
            this.PersonaMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaPersonaMenu,
            this.altaUsuarioMenu});
            this.PersonaMenu.Name = "PersonaMenu";
            this.PersonaMenu.Size = new System.Drawing.Size(66, 20);
            this.PersonaMenu.Text = "&Personas";
            // 
            // altaPersonaMenu
            // 
            this.altaPersonaMenu.Name = "altaPersonaMenu";
            this.altaPersonaMenu.Size = new System.Drawing.Size(116, 22);
            this.altaPersonaMenu.Text = "Persona";
            // 
            // altaUsuarioMenu
            // 
            this.altaUsuarioMenu.Name = "altaUsuarioMenu";
            this.altaUsuarioMenu.Size = new System.Drawing.Size(116, 22);
            this.altaUsuarioMenu.Text = "Usuario";
            this.altaUsuarioMenu.Click += new System.EventHandler(this.altaUsuarioToolStripMenuItem_Click);
            // 
            // InscripcionMenu
            // 
            this.InscripcionMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.examenMenu,
            this.cursarMenu,
            this.condicionDeAlumnosInscriptoMenu});
            this.InscripcionMenu.Name = "InscripcionMenu";
            this.InscripcionMenu.Size = new System.Drawing.Size(72, 20);
            this.InscripcionMenu.Text = "&Incripcion";
            this.InscripcionMenu.Click += new System.EventHandler(this.viewMenu_Click);
            // 
            // examenMenu
            // 
            this.examenMenu.Name = "examenMenu";
            this.examenMenu.Size = new System.Drawing.Size(245, 22);
            this.examenMenu.Text = "Examen";
            // 
            // cursarMenu
            // 
            this.cursarMenu.Name = "cursarMenu";
            this.cursarMenu.Size = new System.Drawing.Size(245, 22);
            this.cursarMenu.Text = "Cursar";
            // 
            // condicionDeAlumnosInscriptoMenu
            // 
            this.condicionDeAlumnosInscriptoMenu.Name = "condicionDeAlumnosInscriptoMenu";
            this.condicionDeAlumnosInscriptoMenu.Size = new System.Drawing.Size(245, 22);
            this.condicionDeAlumnosInscriptoMenu.Text = "Condicion de Alumnos Inscripto";
            // 
            // ConsultaMenu
            // 
            this.ConsultaMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notasMenu,
            this.historiaAcademicoMenu,
            this.verMateriasAprobadasMenu,
            this.cursosMenu,
            this.inscriptoMenu});
            this.ConsultaMenu.Name = "ConsultaMenu";
            this.ConsultaMenu.Size = new System.Drawing.Size(70, 20);
            this.ConsultaMenu.Text = "&Consultar";
            // 
            // notasMenu
            // 
            this.notasMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cursarToolStripMenuItem,
            this.examenToolStripMenuItem});
            this.notasMenu.Name = "notasMenu";
            this.notasMenu.Size = new System.Drawing.Size(198, 22);
            this.notasMenu.Text = "Correlativa para";
            // 
            // cursarToolStripMenuItem
            // 
            this.cursarToolStripMenuItem.Name = "cursarToolStripMenuItem";
            this.cursarToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.cursarToolStripMenuItem.Text = "Cursar";
            // 
            // examenToolStripMenuItem
            // 
            this.examenToolStripMenuItem.Name = "examenToolStripMenuItem";
            this.examenToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.examenToolStripMenuItem.Text = "Examen";
            // 
            // historiaAcademicoMenu
            // 
            this.historiaAcademicoMenu.Name = "historiaAcademicoMenu";
            this.historiaAcademicoMenu.Size = new System.Drawing.Size(198, 22);
            this.historiaAcademicoMenu.Text = "Historia Academico";
            // 
            // verMateriasAprobadasMenu
            // 
            this.verMateriasAprobadasMenu.Name = "verMateriasAprobadasMenu";
            this.verMateriasAprobadasMenu.Size = new System.Drawing.Size(198, 22);
            this.verMateriasAprobadasMenu.Text = "Ver Materias Aprobadas";
            // 
            // cursosMenu
            // 
            this.cursosMenu.Name = "cursosMenu";
            this.cursosMenu.Size = new System.Drawing.Size(198, 22);
            this.cursosMenu.Text = "Cursos";
            // 
            // inscriptoMenu
            // 
            this.inscriptoMenu.Name = "inscriptoMenu";
            this.inscriptoMenu.Size = new System.Drawing.Size(198, 22);
            this.inscriptoMenu.Text = "Inscripto";
            // 
            // HerramientaMenu
            // 
            this.HerramientaMenu.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.HerramientaMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.HerramientaMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.realizarBackUpMenu,
            this.restaurarBackUpMenu});
            this.HerramientaMenu.ForeColor = System.Drawing.Color.Black;
            this.HerramientaMenu.Name = "HerramientaMenu";
            this.HerramientaMenu.Size = new System.Drawing.Size(90, 20);
            this.HerramientaMenu.Text = "&Herramientas";
            // 
            // realizarBackUpMenu
            // 
            this.realizarBackUpMenu.Name = "realizarBackUpMenu";
            this.realizarBackUpMenu.Size = new System.Drawing.Size(169, 22);
            this.realizarBackUpMenu.Text = "Realizar Back Up";
            // 
            // restaurarBackUpMenu
            // 
            this.restaurarBackUpMenu.Name = "restaurarBackUpMenu";
            this.restaurarBackUpMenu.Size = new System.Drawing.Size(169, 22);
            this.restaurarBackUpMenu.Text = "Restaurar Back Up";
            // 
            // carreraMenu
            // 
            this.carreraMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.especialidadesMenu,
            this.planesMenu,
            this.materiasMenu,
            this.comisionesMenuI});
            this.carreraMenu.Name = "carreraMenu";
            this.carreraMenu.Size = new System.Drawing.Size(57, 20);
            this.carreraMenu.Text = "Carrera";
            // 
            // especialidadesMenu
            // 
            this.especialidadesMenu.Name = "especialidadesMenu";
            this.especialidadesMenu.Size = new System.Drawing.Size(152, 22);
            this.especialidadesMenu.Text = "Especialidades";
            this.especialidadesMenu.Click += new System.EventHandler(this.especialidadesMenu_Click);
            // 
            // planesMenu
            // 
            this.planesMenu.Name = "planesMenu";
            this.planesMenu.Size = new System.Drawing.Size(152, 22);
            this.planesMenu.Text = "Planes";
            this.planesMenu.Click += new System.EventHandler(this.planesMenu_Click);
            // 
            // materiasMenu
            // 
            this.materiasMenu.Name = "materiasMenu";
            this.materiasMenu.Size = new System.Drawing.Size(150, 22);
            this.materiasMenu.Text = "Materias";
            // 
            // comisionesMenuI
            // 
            this.comisionesMenuI.Name = "comisionesMenuI";
            this.comisionesMenuI.Size = new System.Drawing.Size(150, 22);
            this.comisionesMenuI.Text = "Comisiones";
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator8,
            this.aboutToolStripMenuItem});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(53, 20);
            this.helpMenu.Text = "Ay&uda";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.contentsToolStripMenuItem.Text = "&Contenido";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("indexToolStripMenuItem.Image")));
            this.indexToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.indexToolStripMenuItem.Text = "&Índice";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("searchToolStripMenuItem.Image")));
            this.searchToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.searchToolStripMenuItem.Text = "&Buscar";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(173, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.aboutToolStripMenuItem.Text = "&Acerca de... ...";
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UsuarioStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(632, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "ToolStrip";
            // 
            // UsuarioStripButton
            // 
            this.UsuarioStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.UsuarioStripButton.Image = ((System.Drawing.Image)(resources.GetObject("UsuarioStripButton.Image")));
            this.UsuarioStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.UsuarioStripButton.Name = "UsuarioStripButton";
            this.UsuarioStripButton.Size = new System.Drawing.Size(23, 22);
            this.UsuarioStripButton.Text = "Alta persona";
            this.UsuarioStripButton.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.Conectado});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(632, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel.Text = "Estado";
            // 
            // Conectado
            // 
            this.Conectado.Name = "Conectado";
            this.Conectado.Size = new System.Drawing.Size(0, 17);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UI.Desktop.Properties.Resources.images__2_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "Principal";
            this.Text = "Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Principal_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Principal_FormClosed);
            this.Load += new System.EventHandler(this.Principal_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SyscadMenu;
        private System.Windows.Forms.ToolStripMenuItem SalirMenu;
        private System.Windows.Forms.ToolStripMenuItem PersonaMenu;
        private System.Windows.Forms.ToolStripMenuItem InscripcionMenu;
        private System.Windows.Forms.ToolStripMenuItem ConsultaMenu;
        private System.Windows.Forms.ToolStripMenuItem HerramientaMenu;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton UsuarioStripButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem altaPersonaMenu;
        private System.Windows.Forms.ToolStripMenuItem altaUsuarioMenu;
        private System.Windows.Forms.ToolStripMenuItem examenMenu;
        private System.Windows.Forms.ToolStripMenuItem cursarMenu;
        private System.Windows.Forms.ToolStripMenuItem notasMenu;
        private System.Windows.Forms.ToolStripMenuItem historiaAcademicoMenu;
        private System.Windows.Forms.ToolStripMenuItem verMateriasAprobadasMenu;
        private System.Windows.Forms.ToolStripMenuItem realizarBackUpMenu;
        private System.Windows.Forms.ToolStripMenuItem restaurarBackUpMenu;
        private System.Windows.Forms.ToolStripMenuItem condicionDeAlumnosInscriptoMenu;
        private System.Windows.Forms.ToolStripMenuItem cursosMenu;
        private System.Windows.Forms.ToolStripMenuItem inscriptoMenu;
        private System.Windows.Forms.ToolStripMenuItem carreraMenu;
        private System.Windows.Forms.ToolStripMenuItem especialidadesMenu;
        private System.Windows.Forms.ToolStripMenuItem planesMenu;
        private System.Windows.Forms.ToolStripMenuItem materiasMenu;
        private System.Windows.Forms.ToolStripMenuItem comisionesMenuI;
        private System.Windows.Forms.ToolStripMenuItem cursarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem examenToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel Conectado;
    }
}



