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
            menuStrip1 = new System.Windows.Forms.MenuStrip();

            // Menú Archivo
            archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            // Menú Administración (Solo Admin)
            administracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            docentesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            estudiantesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            auditoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            // Menú Académico (Admin y Coordinador)
            academicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            asignaturasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            periodosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            matriculasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            asignacionDocentesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            // Menú Calificaciones (Solo Docente)
            calificacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ingresoNotasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            // Menú Simulación y Predicción (Estudiante, Docente, Coordinador)
            simulacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            simuladorNotasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            dashboardPrediccionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            // Menú Reportes
            reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            reporteAcademicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            // Panel Superior para la información del usuario
            pnlHeader = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            lbl_Nombre = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            lbl_Rol = new System.Windows.Forms.Label();
            lbl_Reloj = new System.Windows.Forms.Label();

            timer1 = new System.Windows.Forms.Timer(components);

            menuStrip1.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();

            // 
            // menuStrip1
            // 
            menuStrip1.Font = new System.Drawing.Font("Segoe UI", 11F);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                archivoToolStripMenuItem,
                administracionToolStripMenuItem,
                academicoToolStripMenuItem,
                calificacionesToolStripMenuItem,
                simulacionToolStripMenuItem,
                reportesToolStripMenuItem
            });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(1212, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";

            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { salirToolStripMenuItem });
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            archivoToolStripMenuItem.Text = "&Archivo";

            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new System.Drawing.Size(109, 24);
            salirToolStripMenuItem.Text = "&Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;

            // 
            // administracionToolStripMenuItem
            // 
            administracionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { usuariosToolStripMenuItem, docentesToolStripMenuItem, estudiantesToolStripMenuItem, auditoriaToolStripMenuItem });
            administracionToolStripMenuItem.Name = "administracionToolStripMenuItem";
            administracionToolStripMenuItem.Size = new System.Drawing.Size(119, 24);
            administracionToolStripMenuItem.Text = "Administración";

            // items administracion
            usuariosToolStripMenuItem.Text = "Usuarios";
            docentesToolStripMenuItem.Text = "Docentes";
            estudiantesToolStripMenuItem.Text = "Estudiantes";
            auditoriaToolStripMenuItem.Text = "Auditoría del Sistema";

            // 
            // academicoToolStripMenuItem
            // 
            academicoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { asignaturasToolStripMenuItem, periodosToolStripMenuItem, matriculasToolStripMenuItem, asignacionDocentesToolStripMenuItem });
            academicoToolStripMenuItem.Name = "academicoToolStripMenuItem";
            academicoToolStripMenuItem.Size = new System.Drawing.Size(95, 24);
            academicoToolStripMenuItem.Text = "Académico";

            // items academico
            asignaturasToolStripMenuItem.Text = "Asignaturas";
            periodosToolStripMenuItem.Text = "Periodos Académicos";
            matriculasToolStripMenuItem.Text = "Matrículas";
            asignacionDocentesToolStripMenuItem.Text = "Asignación de Docentes";

            // 
            // calificacionesToolStripMenuItem
            // 
            calificacionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { ingresoNotasToolStripMenuItem });
            calificacionesToolStripMenuItem.Name = "calificacionesToolStripMenuItem";
            calificacionesToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            calificacionesToolStripMenuItem.Text = "Calificaciones";

            // items calificaciones
            ingresoNotasToolStripMenuItem.Text = "Ingreso de Notas";

            // 
            // simulacionToolStripMenuItem
            // 
            simulacionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { simuladorNotasToolStripMenuItem, dashboardPrediccionToolStripMenuItem });
            simulacionToolStripMenuItem.Name = "simulacionToolStripMenuItem";
            simulacionToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            simulacionToolStripMenuItem.Text = "Simulación y Predicción";

            // items simulacion
            simuladorNotasToolStripMenuItem.Text = "Simulador de Promedios";
            dashboardPrediccionToolStripMenuItem.Text = "Dashboard de Rendimiento";

            // 
            // reportesToolStripMenuItem
            // 
            reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { reporteAcademicoToolStripMenuItem });
            reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            reportesToolStripMenuItem.Size = new System.Drawing.Size(80, 24);
            reportesToolStripMenuItem.Text = "Reportes";

            // items reportes
            reporteAcademicoToolStripMenuItem.Text = "Reportes Académicos PDF";

            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            pnlHeader.Controls.Add(lbl_Reloj);
            pnlHeader.Controls.Add(lbl_Rol);
            pnlHeader.Controls.Add(label4);
            pnlHeader.Controls.Add(lbl_Nombre);
            pnlHeader.Controls.Add(label1);
            pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pnlHeader.Location = new System.Drawing.Point(0, 28);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new System.Drawing.Size(1212, 50);
            pnlHeader.TabIndex = 2;

            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(12, 13);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(99, 21);
            label1.Text = "Bienvenido:";

            // lbl_Nombre
            // 
            lbl_Nombre.AutoSize = true;
            lbl_Nombre.Font = new System.Drawing.Font("Segoe UI", 12F);
            lbl_Nombre.Location = new System.Drawing.Point(117, 13);
            lbl_Nombre.Name = "lbl_Nombre";
            lbl_Nombre.Text = "NombreUsuario";

            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            label4.Location = new System.Drawing.Point(350, 13);
            label4.Name = "label4";
            label4.Text = "Rol:";

            // lbl_Rol
            // 
            lbl_Rol.AutoSize = true;
            lbl_Rol.Font = new System.Drawing.Font("Segoe UI", 12F);
            lbl_Rol.Location = new System.Drawing.Point(390, 13);
            lbl_Rol.Text = "RolUsuario";

            // lbl_Reloj
            // 
            lbl_Reloj.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lbl_Reloj.AutoSize = true;
            lbl_Reloj.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lbl_Reloj.Location = new System.Drawing.Point(1000, 13);
            lbl_Reloj.Text = "Reloj";

            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;

            // 
            // frm_Principal
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1212, 674);
            Controls.Add(pnlHeader);
            Controls.Add(menuStrip1);
            Font = new System.Drawing.Font("Segoe UI", 14F);
            IsMdiContainer = true; // MUY IMPORTANTE PARA QUE FUNCIONE COMO PADRE
            MainMenuStrip = menuStrip1;
            Name = "frm_Principal";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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