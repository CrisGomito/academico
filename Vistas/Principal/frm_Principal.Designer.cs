namespace DataBase_First.Views.Main
{
    partial class frm_Principal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            administracionToolStripMenuItem = new ToolStripMenuItem();
            usuariosToolStripMenuItem = new ToolStripMenuItem();
            docentesToolStripMenuItem = new ToolStripMenuItem();
            estudiantesToolStripMenuItem = new ToolStripMenuItem();
            auditoriaToolStripMenuItem = new ToolStripMenuItem();
            academicoToolStripMenuItem = new ToolStripMenuItem();
            asignaturasToolStripMenuItem = new ToolStripMenuItem();
            periodosToolStripMenuItem = new ToolStripMenuItem();
            matriculasToolStripMenuItem = new ToolStripMenuItem();
            asignacionDocentesToolStripMenuItem = new ToolStripMenuItem();
            calificacionesToolStripMenuItem = new ToolStripMenuItem();
            ingresoNotasToolStripMenuItem = new ToolStripMenuItem();
            simulacionToolStripMenuItem = new ToolStripMenuItem();
            simuladorNotasToolStripMenuItem = new ToolStripMenuItem();
            dashboardPrediccionToolStripMenuItem = new ToolStripMenuItem();
            reportesToolStripMenuItem = new ToolStripMenuItem();
            reporteAcademicoToolStripMenuItem = new ToolStripMenuItem();
            pnlHeader = new Panel();
            lbl_Reloj = new Label();
            lbl_Rol = new Label();
            label4 = new Label();
            lbl_Nombre = new Label();
            label1 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI", 11F);
            menuStrip1.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, administracionToolStripMenuItem, academicoToolStripMenuItem, calificacionesToolStripMenuItem, simulacionToolStripMenuItem, reportesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1212, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { salirToolStripMenuItem });
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(71, 24);
            archivoToolStripMenuItem.Text = "&Archivo";
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(107, 24);
            salirToolStripMenuItem.Text = "&Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // administracionToolStripMenuItem
            // 
            administracionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { usuariosToolStripMenuItem, docentesToolStripMenuItem, estudiantesToolStripMenuItem, auditoriaToolStripMenuItem });
            administracionToolStripMenuItem.Name = "administracionToolStripMenuItem";
            administracionToolStripMenuItem.Size = new Size(121, 24);
            administracionToolStripMenuItem.Text = "Administración";
            // 
            // usuariosToolStripMenuItem
            // 
            usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            usuariosToolStripMenuItem.Size = new Size(221, 24);
            usuariosToolStripMenuItem.Text = "Usuarios";
            usuariosToolStripMenuItem.Click += usuariosToolStripMenuItem_Click_1;
            // 
            // docentesToolStripMenuItem
            // 
            docentesToolStripMenuItem.Name = "docentesToolStripMenuItem";
            docentesToolStripMenuItem.Size = new Size(221, 24);
            docentesToolStripMenuItem.Text = "Docentes";
            // 
            // estudiantesToolStripMenuItem
            // 
            estudiantesToolStripMenuItem.Name = "estudiantesToolStripMenuItem";
            estudiantesToolStripMenuItem.Size = new Size(221, 24);
            estudiantesToolStripMenuItem.Text = "Estudiantes";
            // 
            // auditoriaToolStripMenuItem
            // 
            auditoriaToolStripMenuItem.Name = "auditoriaToolStripMenuItem";
            auditoriaToolStripMenuItem.Size = new Size(221, 24);
            auditoriaToolStripMenuItem.Text = "Auditoría del Sistema";
            // 
            // academicoToolStripMenuItem
            // 
            academicoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { asignaturasToolStripMenuItem, periodosToolStripMenuItem, matriculasToolStripMenuItem, asignacionDocentesToolStripMenuItem });
            academicoToolStripMenuItem.Name = "academicoToolStripMenuItem";
            academicoToolStripMenuItem.Size = new Size(96, 24);
            academicoToolStripMenuItem.Text = "Académico";
            // 
            // asignaturasToolStripMenuItem
            // 
            asignaturasToolStripMenuItem.Name = "asignaturasToolStripMenuItem";
            asignaturasToolStripMenuItem.Size = new Size(238, 24);
            asignaturasToolStripMenuItem.Text = "Asignaturas";
            // 
            // periodosToolStripMenuItem
            // 
            periodosToolStripMenuItem.Name = "periodosToolStripMenuItem";
            periodosToolStripMenuItem.Size = new Size(238, 24);
            periodosToolStripMenuItem.Text = "Periodos Académicos";
            // 
            // matriculasToolStripMenuItem
            // 
            matriculasToolStripMenuItem.Name = "matriculasToolStripMenuItem";
            matriculasToolStripMenuItem.Size = new Size(238, 24);
            matriculasToolStripMenuItem.Text = "Matrículas";
            // 
            // asignacionDocentesToolStripMenuItem
            // 
            asignacionDocentesToolStripMenuItem.Name = "asignacionDocentesToolStripMenuItem";
            asignacionDocentesToolStripMenuItem.Size = new Size(238, 24);
            asignacionDocentesToolStripMenuItem.Text = "Asignación de Docentes";
            // 
            // calificacionesToolStripMenuItem
            // 
            calificacionesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ingresoNotasToolStripMenuItem });
            calificacionesToolStripMenuItem.Name = "calificacionesToolStripMenuItem";
            calificacionesToolStripMenuItem.Size = new Size(112, 24);
            calificacionesToolStripMenuItem.Text = "Calificaciones";
            // 
            // ingresoNotasToolStripMenuItem
            // 
            ingresoNotasToolStripMenuItem.Name = "ingresoNotasToolStripMenuItem";
            ingresoNotasToolStripMenuItem.Size = new Size(191, 24);
            ingresoNotasToolStripMenuItem.Text = "Ingreso de Notas";
            // 
            // simulacionToolStripMenuItem
            // 
            simulacionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { simuladorNotasToolStripMenuItem, dashboardPrediccionToolStripMenuItem });
            simulacionToolStripMenuItem.Name = "simulacionToolStripMenuItem";
            simulacionToolStripMenuItem.Size = new Size(178, 24);
            simulacionToolStripMenuItem.Text = "Simulación y Predicción";
            // 
            // simuladorNotasToolStripMenuItem
            // 
            simuladorNotasToolStripMenuItem.Name = "simuladorNotasToolStripMenuItem";
            simuladorNotasToolStripMenuItem.Size = new Size(261, 24);
            simuladorNotasToolStripMenuItem.Text = "Simulador de Promedios";
            // 
            // dashboardPrediccionToolStripMenuItem
            // 
            dashboardPrediccionToolStripMenuItem.Name = "dashboardPrediccionToolStripMenuItem";
            dashboardPrediccionToolStripMenuItem.Size = new Size(261, 24);
            dashboardPrediccionToolStripMenuItem.Text = "Dashboard de Rendimiento";
            // 
            // reportesToolStripMenuItem
            // 
            reportesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { reporteAcademicoToolStripMenuItem });
            reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            reportesToolStripMenuItem.Size = new Size(80, 24);
            reportesToolStripMenuItem.Text = "Reportes";
            // 
            // reporteAcademicoToolStripMenuItem
            // 
            reporteAcademicoToolStripMenuItem.Name = "reporteAcademicoToolStripMenuItem";
            reporteAcademicoToolStripMenuItem.Size = new Size(252, 24);
            reporteAcademicoToolStripMenuItem.Text = "Reportes Académicos PDF";
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.WhiteSmoke;
            pnlHeader.Controls.Add(lbl_Reloj);
            pnlHeader.Controls.Add(lbl_Rol);
            pnlHeader.Controls.Add(label4);
            pnlHeader.Controls.Add(lbl_Nombre);
            pnlHeader.Controls.Add(label1);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 28);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1212, 50);
            pnlHeader.TabIndex = 2;
            // 
            // lbl_Reloj
            // 
            lbl_Reloj.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl_Reloj.AutoSize = true;
            lbl_Reloj.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbl_Reloj.Location = new Point(1000, 13);
            lbl_Reloj.Name = "lbl_Reloj";
            lbl_Reloj.Size = new Size(49, 21);
            lbl_Reloj.TabIndex = 0;
            lbl_Reloj.Text = "Reloj";
            // 
            // lbl_Rol
            // 
            lbl_Rol.AutoSize = true;
            lbl_Rol.Font = new Font("Segoe UI", 12F);
            lbl_Rol.Location = new Point(390, 13);
            lbl_Rol.Name = "lbl_Rol";
            lbl_Rol.Size = new Size(87, 21);
            lbl_Rol.TabIndex = 1;
            lbl_Rol.Text = "RolUsuario";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(350, 13);
            label4.Name = "label4";
            label4.Size = new Size(39, 21);
            label4.TabIndex = 2;
            label4.Text = "Rol:";
            // 
            // lbl_Nombre
            // 
            lbl_Nombre.AutoSize = true;
            lbl_Nombre.Font = new Font("Segoe UI", 12F);
            lbl_Nombre.Location = new Point(117, 13);
            lbl_Nombre.Name = "lbl_Nombre";
            lbl_Nombre.Size = new Size(122, 21);
            lbl_Nombre.TabIndex = 3;
            lbl_Nombre.Text = "NombreUsuario";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(12, 13);
            label1.Name = "label1";
            label1.Size = new Size(101, 21);
            label1.TabIndex = 4;
            label1.Text = "Bienvenido:";
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // frm_Principal
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1212, 674);
            Controls.Add(pnlHeader);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 14F);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "frm_Principal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema Académico con Simulación - UNIANDES";
            Load += frm_Principal_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;

        // Menus
        private System.Windows.Forms.ToolStripMenuItem administracionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem docentesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estudiantesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem auditoriaToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem academicoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asignaturasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem periodosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matriculasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asignacionDocentesToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem calificacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingresoNotasToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem simulacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simuladorNotasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dashboardPrediccionToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteAcademicoToolStripMenuItem;

        // UI Top
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Nombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_Rol;
        private System.Windows.Forms.Label lbl_Reloj;
        private System.Windows.Forms.Timer timer1;
    }
}