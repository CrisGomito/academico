using Academico.Properties;

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
            pnlControlWindow = new Panel();
            btnMinimizar = new Button();
            btnMaximizar = new Button();
            btnCerrar = new Button();
            pnlMenuContainer = new Panel();
            pnlSubMenuReportes = new Panel();
            btnRptAcademico = new FontAwesome.Sharp.IconButton();
            btnMenuReportes = new FontAwesome.Sharp.IconButton();
            pnlSubMenuSimulacion = new Panel();
            btnDashRendimiento = new FontAwesome.Sharp.IconButton();
            btnSimPromedios = new FontAwesome.Sharp.IconButton();
            btnMenuSimulacion = new FontAwesome.Sharp.IconButton();
            pnlSubMenuCalificaciones = new Panel();
            btnIngresoNotas = new FontAwesome.Sharp.IconButton();
            btnMenuCalificaciones = new FontAwesome.Sharp.IconButton();
            pnlSubMenuAcademico = new Panel();
            btnAsigDocentes = new FontAwesome.Sharp.IconButton();
            btnMatriculas = new FontAwesome.Sharp.IconButton();
            btnPeriodos = new FontAwesome.Sharp.IconButton();
            btnAsignaturas = new FontAwesome.Sharp.IconButton();
            btnMenuAcademico = new FontAwesome.Sharp.IconButton();
            pnlSubMenuAdmin = new Panel();
            btnAuditoria = new FontAwesome.Sharp.IconButton();
            btnEstudiantes = new FontAwesome.Sharp.IconButton();
            btnDocentes = new FontAwesome.Sharp.IconButton();
            btnUsuarios = new FontAwesome.Sharp.IconButton();
            btnMenuAdmin = new FontAwesome.Sharp.IconButton();
            pnlSubMenuPerfil = new Panel();
            btnCerrarSesion = new FontAwesome.Sharp.IconButton();
            btnInfoGeneral = new FontAwesome.Sharp.IconButton();
            btnMenuPerfil = new FontAwesome.Sharp.IconButton();
            pnlLogo = new Panel();
            label2 = new Label();
            pnlHeaderInfo = new Panel();
            lbl_Reloj = new Label();
            lbl_Rol = new Label();
            label4 = new Label();
            lbl_Nombre = new Label();
            label1 = new Label();
            pnlContenedorHijo = new Panel();
            timer1 = new System.Windows.Forms.Timer(components);
            pnlControlWindow.SuspendLayout();
            pnlMenuContainer.SuspendLayout();
            pnlSubMenuReportes.SuspendLayout();
            pnlSubMenuSimulacion.SuspendLayout();
            pnlSubMenuCalificaciones.SuspendLayout();
            pnlSubMenuAcademico.SuspendLayout();
            pnlSubMenuAdmin.SuspendLayout();
            pnlSubMenuPerfil.SuspendLayout();
            pnlLogo.SuspendLayout();
            pnlHeaderInfo.SuspendLayout();
            SuspendLayout();
            // 
            // pnlControlWindow
            // 
            pnlControlWindow.BackColor = Color.FromArgb(40, 50, 65);
            pnlControlWindow.Controls.Add(btnMinimizar);
            pnlControlWindow.Controls.Add(btnMaximizar);
            pnlControlWindow.Controls.Add(btnCerrar);
            pnlControlWindow.Dock = DockStyle.Top;
            pnlControlWindow.Location = new Point(0, 0);
            pnlControlWindow.Name = "pnlControlWindow";
            pnlControlWindow.Size = new Size(1280, 30);
            pnlControlWindow.TabIndex = 0;
            pnlControlWindow.MouseDown += pnlControlWindow_MouseDown;
            // 
            // btnMinimizar
            // 
            btnMinimizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMinimizar.FlatAppearance.BorderSize = 0;
            btnMinimizar.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 70, 85);
            btnMinimizar.FlatStyle = FlatStyle.Flat;
            btnMinimizar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnMinimizar.ForeColor = Color.White;
            btnMinimizar.Location = new Point(1190, 0);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Size = new Size(30, 30);
            btnMinimizar.Text = "—";
            btnMinimizar.UseVisualStyleBackColor = true;
            btnMinimizar.Click += btnMinimizar_Click;
            // 
            // btnMaximizar
            // 
            btnMaximizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMaximizar.FlatAppearance.BorderSize = 0;
            btnMaximizar.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 70, 85);
            btnMaximizar.FlatStyle = FlatStyle.Flat;
            btnMaximizar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnMaximizar.ForeColor = Color.White;
            btnMaximizar.Location = new Point(1220, 0);
            btnMaximizar.Name = "btnMaximizar";
            btnMaximizar.Size = new Size(30, 30);
            btnMaximizar.Text = "⬜";
            btnMaximizar.UseVisualStyleBackColor = true;
            btnMaximizar.Click += btnMaximizar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCerrar.BackColor = Color.FromArgb(231, 76, 60);
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Location = new Point(1255, 7);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(16, 16);
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            btnCerrar.Paint += btnCerrar_Paint;
            // 
            // pnlMenuContainer
            // 
            pnlMenuContainer.BackColor = Color.FromArgb(52, 73, 94);
            pnlMenuContainer.Controls.Add(pnlSubMenuReportes);
            pnlMenuContainer.Controls.Add(btnMenuReportes);
            pnlMenuContainer.Controls.Add(pnlSubMenuSimulacion);
            pnlMenuContainer.Controls.Add(btnMenuSimulacion);
            pnlMenuContainer.Controls.Add(pnlSubMenuCalificaciones);
            pnlMenuContainer.Controls.Add(btnMenuCalificaciones);
            pnlMenuContainer.Controls.Add(pnlSubMenuAcademico);
            pnlMenuContainer.Controls.Add(btnMenuAcademico);
            pnlMenuContainer.Controls.Add(pnlSubMenuAdmin);
            pnlMenuContainer.Controls.Add(btnMenuAdmin);
            pnlMenuContainer.Controls.Add(pnlSubMenuPerfil);
            pnlMenuContainer.Controls.Add(btnMenuPerfil);
            pnlMenuContainer.Controls.Add(pnlLogo);
            pnlMenuContainer.Dock = DockStyle.Left;
            pnlMenuContainer.Location = new Point(0, 30);
            pnlMenuContainer.Name = "pnlMenuContainer";
            pnlMenuContainer.Size = new Size(260, 690);
            pnlMenuContainer.TabIndex = 1;
            // 
            // pnlSubMenuReportes
            // 
            pnlSubMenuReportes.BackColor = Color.FromArgb(65, 85, 105);
            pnlSubMenuReportes.Controls.Add(btnRptAcademico);
            pnlSubMenuReportes.Dock = DockStyle.Top;
            pnlSubMenuReportes.Location = new Point(0, 770);
            pnlSubMenuReportes.Name = "pnlSubMenuReportes";
            pnlSubMenuReportes.Size = new Size(260, 45);
            pnlSubMenuReportes.TabIndex = 12;
            pnlSubMenuReportes.Visible = false;
            // 
            // btnRptAcademico
            // 
            btnRptAcademico.Dock = DockStyle.Top;
            btnRptAcademico.FlatAppearance.BorderSize = 0;
            btnRptAcademico.FlatStyle = FlatStyle.Flat;
            btnRptAcademico.Font = new Font("Segoe UI", 10F);
            btnRptAcademico.ForeColor = Color.Silver;
            btnRptAcademico.IconChar = FontAwesome.Sharp.IconChar.FilePdf;
            btnRptAcademico.IconColor = Color.Silver;
            btnRptAcademico.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRptAcademico.IconSize = 25;
            btnRptAcademico.ImageAlign = ContentAlignment.MiddleLeft;
            btnRptAcademico.Location = new Point(0, 0);
            btnRptAcademico.Name = "btnRptAcademico";
            btnRptAcademico.Padding = new Padding(40, 0, 0, 0);
            btnRptAcademico.Size = new Size(260, 40);
            btnRptAcademico.Text = "Reportes PDFs";
            btnRptAcademico.TextAlign = ContentAlignment.MiddleLeft;
            btnRptAcademico.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRptAcademico.UseVisualStyleBackColor = true;
            btnRptAcademico.Click += btnRptAcademico_Click;
            // 
            // btnMenuReportes
            // 
            btnMenuReportes.Dock = DockStyle.Top;
            btnMenuReportes.FlatAppearance.BorderSize = 0;
            btnMenuReportes.FlatStyle = FlatStyle.Flat;
            btnMenuReportes.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnMenuReportes.ForeColor = Color.Gainsboro;
            btnMenuReportes.IconChar = FontAwesome.Sharp.IconChar.ChartBar;
            btnMenuReportes.IconColor = Color.Gainsboro;
            btnMenuReportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMenuReportes.IconSize = 32;
            btnMenuReportes.ImageAlign = ContentAlignment.MiddleLeft;
            btnMenuReportes.Location = new Point(0, 720);
            btnMenuReportes.Name = "btnMenuReportes";
            btnMenuReportes.Padding = new Padding(15, 0, 0, 0);
            btnMenuReportes.Size = new Size(260, 50);
            btnMenuReportes.Text = "Reportes";
            btnMenuReportes.TextAlign = ContentAlignment.MiddleLeft;
            btnMenuReportes.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMenuReportes.UseVisualStyleBackColor = true;
            btnMenuReportes.Click += btnMenuReportes_Click;
            // 
            // pnlSubMenuSimulacion
            // 
            pnlSubMenuSimulacion.BackColor = Color.FromArgb(65, 85, 105);
            pnlSubMenuSimulacion.Controls.Add(btnDashRendimiento);
            pnlSubMenuSimulacion.Controls.Add(btnSimPromedios);
            pnlSubMenuSimulacion.Dock = DockStyle.Top;
            pnlSubMenuSimulacion.Location = new Point(0, 635);
            pnlSubMenuSimulacion.Name = "pnlSubMenuSimulacion";
            pnlSubMenuSimulacion.Size = new Size(260, 85);
            pnlSubMenuSimulacion.TabIndex = 11;
            pnlSubMenuSimulacion.Visible = false;
            // 
            // btnDashRendimiento
            // 
            btnDashRendimiento.Dock = DockStyle.Top;
            btnDashRendimiento.FlatAppearance.BorderSize = 0;
            btnDashRendimiento.FlatStyle = FlatStyle.Flat;
            btnDashRendimiento.Font = new Font("Segoe UI", 10F);
            btnDashRendimiento.ForeColor = Color.Silver;
            btnDashRendimiento.IconChar = FontAwesome.Sharp.IconChar.TachometerAlt;
            btnDashRendimiento.IconColor = Color.Silver;
            btnDashRendimiento.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDashRendimiento.IconSize = 25;
            btnDashRendimiento.ImageAlign = ContentAlignment.MiddleLeft;
            btnDashRendimiento.Location = new Point(0, 40);
            btnDashRendimiento.Name = "btnDashRendimiento";
            btnDashRendimiento.Padding = new Padding(40, 0, 0, 0);
            btnDashRendimiento.Size = new Size(260, 40);
            btnDashRendimiento.Text = "Dashboard";
            btnDashRendimiento.TextAlign = ContentAlignment.MiddleLeft;
            btnDashRendimiento.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDashRendimiento.UseVisualStyleBackColor = true;
            btnDashRendimiento.Click += btnDashRendimiento_Click;
            // 
            // btnSimPromedios
            // 
            btnSimPromedios.Dock = DockStyle.Top;
            btnSimPromedios.FlatAppearance.BorderSize = 0;
            btnSimPromedios.FlatStyle = FlatStyle.Flat;
            btnSimPromedios.Font = new Font("Segoe UI", 10F);
            btnSimPromedios.ForeColor = Color.Silver;
            btnSimPromedios.IconChar = FontAwesome.Sharp.IconChar.Calculator;
            btnSimPromedios.IconColor = Color.Silver;
            btnSimPromedios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSimPromedios.IconSize = 25;
            btnSimPromedios.ImageAlign = ContentAlignment.MiddleLeft;
            btnSimPromedios.Location = new Point(0, 0);
            btnSimPromedios.Name = "btnSimPromedios";
            btnSimPromedios.Padding = new Padding(40, 0, 0, 0);
            btnSimPromedios.Size = new Size(260, 40);
            btnSimPromedios.Text = "Simulador";
            btnSimPromedios.TextAlign = ContentAlignment.MiddleLeft;
            btnSimPromedios.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSimPromedios.UseVisualStyleBackColor = true;
            btnSimPromedios.Click += btnSimPromedios_Click;
            // 
            // btnMenuSimulacion
            // 
            btnMenuSimulacion.Dock = DockStyle.Top;
            btnMenuSimulacion.FlatAppearance.BorderSize = 0;
            btnMenuSimulacion.FlatStyle = FlatStyle.Flat;
            btnMenuSimulacion.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnMenuSimulacion.ForeColor = Color.Gainsboro;
            btnMenuSimulacion.IconChar = FontAwesome.Sharp.IconChar.Brain;
            btnMenuSimulacion.IconColor = Color.Gainsboro;
            btnMenuSimulacion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMenuSimulacion.IconSize = 32;
            btnMenuSimulacion.ImageAlign = ContentAlignment.MiddleLeft;
            btnMenuSimulacion.Location = new Point(0, 585);
            btnMenuSimulacion.Name = "btnMenuSimulacion";
            btnMenuSimulacion.Padding = new Padding(15, 0, 0, 0);
            btnMenuSimulacion.Size = new Size(260, 50);
            btnMenuSimulacion.Text = "Simulación";
            btnMenuSimulacion.TextAlign = ContentAlignment.MiddleLeft;
            btnMenuSimulacion.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMenuSimulacion.UseVisualStyleBackColor = true;
            btnMenuSimulacion.Click += btnMenuSimulacion_Click;
            // 
            // pnlSubMenuCalificaciones
            // 
            pnlSubMenuCalificaciones.BackColor = Color.FromArgb(65, 85, 105);
            pnlSubMenuCalificaciones.Controls.Add(btnIngresoNotas);
            pnlSubMenuCalificaciones.Dock = DockStyle.Top;
            pnlSubMenuCalificaciones.Location = new Point(0, 540);
            pnlSubMenuCalificaciones.Name = "pnlSubMenuCalificaciones";
            pnlSubMenuCalificaciones.Size = new Size(260, 45);
            pnlSubMenuCalificaciones.TabIndex = 10;
            pnlSubMenuCalificaciones.Visible = false;
            // 
            // btnIngresoNotas
            // 
            btnIngresoNotas.Dock = DockStyle.Top;
            btnIngresoNotas.FlatAppearance.BorderSize = 0;
            btnIngresoNotas.FlatStyle = FlatStyle.Flat;
            btnIngresoNotas.Font = new Font("Segoe UI", 10F);
            btnIngresoNotas.ForeColor = Color.Silver;
            btnIngresoNotas.IconChar = FontAwesome.Sharp.IconChar.Edit;
            btnIngresoNotas.IconColor = Color.Silver;
            btnIngresoNotas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnIngresoNotas.IconSize = 25;
            btnIngresoNotas.ImageAlign = ContentAlignment.MiddleLeft;
            btnIngresoNotas.Location = new Point(0, 0);
            btnIngresoNotas.Name = "btnIngresoNotas";
            btnIngresoNotas.Padding = new Padding(40, 0, 0, 0);
            btnIngresoNotas.Size = new Size(260, 40);
            btnIngresoNotas.Text = "Ingreso de Notas";
            btnIngresoNotas.TextAlign = ContentAlignment.MiddleLeft;
            btnIngresoNotas.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnIngresoNotas.UseVisualStyleBackColor = true;
            btnIngresoNotas.Click += btnIngresoNotas_Click;
            // 
            // btnMenuCalificaciones
            // 
            btnMenuCalificaciones.Dock = DockStyle.Top;
            btnMenuCalificaciones.FlatAppearance.BorderSize = 0;
            btnMenuCalificaciones.FlatStyle = FlatStyle.Flat;
            btnMenuCalificaciones.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnMenuCalificaciones.ForeColor = Color.Gainsboro;
            btnMenuCalificaciones.IconChar = FontAwesome.Sharp.IconChar.GraduationCap;
            btnMenuCalificaciones.IconColor = Color.Gainsboro;
            btnMenuCalificaciones.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMenuCalificaciones.IconSize = 32;
            btnMenuCalificaciones.ImageAlign = ContentAlignment.MiddleLeft;
            btnMenuCalificaciones.Location = new Point(0, 490);
            btnMenuCalificaciones.Name = "btnMenuCalificaciones";
            btnMenuCalificaciones.Padding = new Padding(15, 0, 0, 0);
            btnMenuCalificaciones.Size = new Size(260, 50);
            btnMenuCalificaciones.Text = "Calificaciones";
            btnMenuCalificaciones.TextAlign = ContentAlignment.MiddleLeft;
            btnMenuCalificaciones.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMenuCalificaciones.UseVisualStyleBackColor = true;
            btnMenuCalificaciones.Click += btnMenuCalificaciones_Click;
            // 
            // pnlSubMenuAcademico
            // 
            pnlSubMenuAcademico.BackColor = Color.FromArgb(65, 85, 105);
            pnlSubMenuAcademico.Controls.Add(btnAsigDocentes);
            pnlSubMenuAcademico.Controls.Add(btnMatriculas);
            pnlSubMenuAcademico.Controls.Add(btnPeriodos);
            pnlSubMenuAcademico.Controls.Add(btnAsignaturas);
            pnlSubMenuAcademico.Dock = DockStyle.Top;
            pnlSubMenuAcademico.Location = new Point(0, 325);
            pnlSubMenuAcademico.Name = "pnlSubMenuAcademico";
            pnlSubMenuAcademico.Size = new Size(260, 165);
            pnlSubMenuAcademico.TabIndex = 9;
            pnlSubMenuAcademico.Visible = false;
            // 
            // btnAsigDocentes
            // 
            btnAsigDocentes.Dock = DockStyle.Top;
            btnAsigDocentes.FlatAppearance.BorderSize = 0;
            btnAsigDocentes.FlatStyle = FlatStyle.Flat;
            btnAsigDocentes.Font = new Font("Segoe UI", 10F);
            btnAsigDocentes.ForeColor = Color.Silver;
            btnAsigDocentes.IconChar = FontAwesome.Sharp.IconChar.ChalkboardTeacher;
            btnAsigDocentes.IconColor = Color.Silver;
            btnAsigDocentes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAsigDocentes.IconSize = 25;
            btnAsigDocentes.ImageAlign = ContentAlignment.MiddleLeft;
            btnAsigDocentes.Location = new Point(0, 120);
            btnAsigDocentes.Name = "btnAsigDocentes";
            btnAsigDocentes.Padding = new Padding(40, 0, 0, 0);
            btnAsigDocentes.Size = new Size(260, 40);
            btnAsigDocentes.Text = "Asignación";
            btnAsigDocentes.TextAlign = ContentAlignment.MiddleLeft;
            btnAsigDocentes.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAsigDocentes.UseVisualStyleBackColor = true;
            btnAsigDocentes.Click += btnAsigDocentes_Click;
            // 
            // btnMatriculas
            // 
            btnMatriculas.Dock = DockStyle.Top;
            btnMatriculas.FlatAppearance.BorderSize = 0;
            btnMatriculas.FlatStyle = FlatStyle.Flat;
            btnMatriculas.Font = new Font("Segoe UI", 10F);
            btnMatriculas.ForeColor = Color.Silver;
            btnMatriculas.IconChar = FontAwesome.Sharp.IconChar.IdCard;
            btnMatriculas.IconColor = Color.Silver;
            btnMatriculas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMatriculas.IconSize = 25;
            btnMatriculas.ImageAlign = ContentAlignment.MiddleLeft;
            btnMatriculas.Location = new Point(0, 80);
            btnMatriculas.Name = "btnMatriculas";
            btnMatriculas.Padding = new Padding(40, 0, 0, 0);
            btnMatriculas.Size = new Size(260, 40);
            btnMatriculas.Text = "Matrículas";
            btnMatriculas.TextAlign = ContentAlignment.MiddleLeft;
            btnMatriculas.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMatriculas.UseVisualStyleBackColor = true;
            btnMatriculas.Click += btnMatriculas_Click;
            // 
            // btnPeriodos
            // 
            btnPeriodos.Dock = DockStyle.Top;
            btnPeriodos.FlatAppearance.BorderSize = 0;
            btnPeriodos.FlatStyle = FlatStyle.Flat;
            btnPeriodos.Font = new Font("Segoe UI", 10F);
            btnPeriodos.ForeColor = Color.Silver;
            btnPeriodos.IconChar = FontAwesome.Sharp.IconChar.CalendarAlt;
            btnPeriodos.IconColor = Color.Silver;
            btnPeriodos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnPeriodos.IconSize = 25;
            btnPeriodos.ImageAlign = ContentAlignment.MiddleLeft;
            btnPeriodos.Location = new Point(0, 40);
            btnPeriodos.Name = "btnPeriodos";
            btnPeriodos.Padding = new Padding(40, 0, 0, 0);
            btnPeriodos.Size = new Size(260, 40);
            btnPeriodos.Text = "Periodos";
            btnPeriodos.TextAlign = ContentAlignment.MiddleLeft;
            btnPeriodos.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPeriodos.UseVisualStyleBackColor = true;
            btnPeriodos.Click += btnPeriodos_Click;
            // 
            // btnAsignaturas
            // 
            btnAsignaturas.Dock = DockStyle.Top;
            btnAsignaturas.FlatAppearance.BorderSize = 0;
            btnAsignaturas.FlatStyle = FlatStyle.Flat;
            btnAsignaturas.Font = new Font("Segoe UI", 10F);
            btnAsignaturas.ForeColor = Color.Silver;
            btnAsignaturas.IconChar = FontAwesome.Sharp.IconChar.Book;
            btnAsignaturas.IconColor = Color.Silver;
            btnAsignaturas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAsignaturas.IconSize = 25;
            btnAsignaturas.ImageAlign = ContentAlignment.MiddleLeft;
            btnAsignaturas.Location = new Point(0, 0);
            btnAsignaturas.Name = "btnAsignaturas";
            btnAsignaturas.Padding = new Padding(40, 0, 0, 0);
            btnAsignaturas.Size = new Size(260, 40);
            btnAsignaturas.Text = "Asignaturas";
            btnAsignaturas.TextAlign = ContentAlignment.MiddleLeft;
            btnAsignaturas.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAsignaturas.UseVisualStyleBackColor = true;
            btnAsignaturas.Click += btnAsignaturas_Click;
            // 
            // btnMenuAcademico
            // 
            btnMenuAcademico.Dock = DockStyle.Top;
            btnMenuAcademico.FlatAppearance.BorderSize = 0;
            btnMenuAcademico.FlatStyle = FlatStyle.Flat;
            btnMenuAcademico.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnMenuAcademico.ForeColor = Color.Gainsboro;
            btnMenuAcademico.IconChar = FontAwesome.Sharp.IconChar.University;
            btnMenuAcademico.IconColor = Color.Gainsboro;
            btnMenuAcademico.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMenuAcademico.IconSize = 32;
            btnMenuAcademico.ImageAlign = ContentAlignment.MiddleLeft;
            btnMenuAcademico.Location = new Point(0, 275);
            btnMenuAcademico.Name = "btnMenuAcademico";
            btnMenuAcademico.Padding = new Padding(15, 0, 0, 0);
            btnMenuAcademico.Size = new Size(260, 50);
            btnMenuAcademico.Text = "Académico";
            btnMenuAcademico.TextAlign = ContentAlignment.MiddleLeft;
            btnMenuAcademico.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMenuAcademico.UseVisualStyleBackColor = true;
            btnMenuAcademico.Click += btnMenuAcademico_Click;
            // 
            // pnlSubMenuAdmin
            // 
            pnlSubMenuAdmin.BackColor = Color.FromArgb(65, 85, 105);
            pnlSubMenuAdmin.Controls.Add(btnAuditoria);
            pnlSubMenuAdmin.Controls.Add(btnEstudiantes);
            pnlSubMenuAdmin.Controls.Add(btnDocentes);
            pnlSubMenuAdmin.Controls.Add(btnUsuarios);
            pnlSubMenuAdmin.Dock = DockStyle.Top;
            pnlSubMenuAdmin.Location = new Point(0, 110);
            pnlSubMenuAdmin.Name = "pnlSubMenuAdmin";
            pnlSubMenuAdmin.Size = new Size(260, 165);
            pnlSubMenuAdmin.TabIndex = 8;
            pnlSubMenuAdmin.Visible = false;
            // 
            // btnAuditoria
            // 
            btnAuditoria.Dock = DockStyle.Top;
            btnAuditoria.FlatAppearance.BorderSize = 0;
            btnAuditoria.FlatStyle = FlatStyle.Flat;
            btnAuditoria.Font = new Font("Segoe UI", 10F);
            btnAuditoria.ForeColor = Color.Silver;
            btnAuditoria.IconChar = FontAwesome.Sharp.IconChar.History;
            btnAuditoria.IconColor = Color.Silver;
            btnAuditoria.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAuditoria.IconSize = 25;
            btnAuditoria.ImageAlign = ContentAlignment.MiddleLeft;
            btnAuditoria.Location = new Point(0, 120);
            btnAuditoria.Name = "btnAuditoria";
            btnAuditoria.Padding = new Padding(40, 0, 0, 0);
            btnAuditoria.Size = new Size(260, 40);
            btnAuditoria.Text = "Auditoría";
            btnAuditoria.TextAlign = ContentAlignment.MiddleLeft;
            btnAuditoria.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAuditoria.UseVisualStyleBackColor = true;
            btnAuditoria.Click += btnAuditoria_Click;
            // 
            // btnEstudiantes
            // 
            btnEstudiantes.Dock = DockStyle.Top;
            btnEstudiantes.FlatAppearance.BorderSize = 0;
            btnEstudiantes.FlatStyle = FlatStyle.Flat;
            btnEstudiantes.Font = new Font("Segoe UI", 10F);
            btnEstudiantes.ForeColor = Color.Silver;
            btnEstudiantes.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            btnEstudiantes.IconColor = Color.Silver;
            btnEstudiantes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEstudiantes.IconSize = 25;
            btnEstudiantes.ImageAlign = ContentAlignment.MiddleLeft;
            btnEstudiantes.Location = new Point(0, 80);
            btnEstudiantes.Name = "btnEstudiantes";
            btnEstudiantes.Padding = new Padding(40, 0, 0, 0);
            btnEstudiantes.Size = new Size(260, 40);
            btnEstudiantes.Text = "Estudiantes";
            btnEstudiantes.TextAlign = ContentAlignment.MiddleLeft;
            btnEstudiantes.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEstudiantes.UseVisualStyleBackColor = true;
            btnEstudiantes.Click += btnEstudiantes_Click;
            // 
            // btnDocentes
            // 
            btnDocentes.Dock = DockStyle.Top;
            btnDocentes.FlatAppearance.BorderSize = 0;
            btnDocentes.FlatStyle = FlatStyle.Flat;
            btnDocentes.Font = new Font("Segoe UI", 10F);
            btnDocentes.ForeColor = Color.Silver;
            btnDocentes.IconChar = FontAwesome.Sharp.IconChar.UserTie;
            btnDocentes.IconColor = Color.Silver;
            btnDocentes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDocentes.IconSize = 25;
            btnDocentes.ImageAlign = ContentAlignment.MiddleLeft;
            btnDocentes.Location = new Point(0, 40);
            btnDocentes.Name = "btnDocentes";
            btnDocentes.Padding = new Padding(40, 0, 0, 0);
            btnDocentes.Size = new Size(260, 40);
            btnDocentes.Text = "Docentes";
            btnDocentes.TextAlign = ContentAlignment.MiddleLeft;
            btnDocentes.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDocentes.UseVisualStyleBackColor = true;
            btnDocentes.Click += btnDocentes_Click;
            // 
            // btnUsuarios
            // 
            btnUsuarios.Dock = DockStyle.Top;
            btnUsuarios.FlatAppearance.BorderSize = 0;
            btnUsuarios.FlatStyle = FlatStyle.Flat;
            btnUsuarios.Font = new Font("Segoe UI", 10F);
            btnUsuarios.ForeColor = Color.Silver;
            btnUsuarios.IconChar = FontAwesome.Sharp.IconChar.Users;
            btnUsuarios.IconColor = Color.Silver;
            btnUsuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnUsuarios.IconSize = 25;
            btnUsuarios.ImageAlign = ContentAlignment.MiddleLeft;
            btnUsuarios.Location = new Point(0, 0);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Padding = new Padding(40, 0, 0, 0);
            btnUsuarios.Size = new Size(260, 40);
            btnUsuarios.Text = "Usuarios";
            btnUsuarios.TextAlign = ContentAlignment.MiddleLeft;
            btnUsuarios.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUsuarios.UseVisualStyleBackColor = true;
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // btnMenuAdmin
            // 
            btnMenuAdmin.Dock = DockStyle.Top;
            btnMenuAdmin.FlatAppearance.BorderSize = 0;
            btnMenuAdmin.FlatStyle = FlatStyle.Flat;
            btnMenuAdmin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnMenuAdmin.ForeColor = Color.Gainsboro;
            btnMenuAdmin.IconChar = FontAwesome.Sharp.IconChar.Tools;
            btnMenuAdmin.IconColor = Color.Gainsboro;
            btnMenuAdmin.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMenuAdmin.IconSize = 32;
            btnMenuAdmin.ImageAlign = ContentAlignment.MiddleLeft;
            btnMenuAdmin.Location = new Point(0, 60);
            btnMenuAdmin.Name = "btnMenuAdmin";
            btnMenuAdmin.Padding = new Padding(15, 0, 0, 0);
            btnMenuAdmin.Size = new Size(260, 50);
            btnMenuAdmin.Text = "Administración";
            btnMenuAdmin.TextAlign = ContentAlignment.MiddleLeft;
            btnMenuAdmin.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMenuAdmin.UseVisualStyleBackColor = true;
            btnMenuAdmin.Click += btnMenuAdmin_Click;
            // 
            // pnlSubMenuPerfil
            // 
            pnlSubMenuPerfil.BackColor = Color.FromArgb(65, 85, 105);
            pnlSubMenuPerfil.Controls.Add(btnCerrarSesion);
            pnlSubMenuPerfil.Controls.Add(btnInfoGeneral);
            pnlSubMenuPerfil.Dock = DockStyle.Top;
            pnlSubMenuPerfil.Location = new Point(0, 60);
            pnlSubMenuPerfil.Name = "pnlSubMenuPerfil";
            pnlSubMenuPerfil.Size = new Size(260, 0); // Altura inicial 0 para animación
            pnlSubMenuPerfil.TabIndex = 7;
            pnlSubMenuPerfil.Visible = false;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Dock = DockStyle.Top;
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Segoe UI", 10F);
            btnCerrarSesion.ForeColor = Color.Silver;
            btnCerrarSesion.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            btnCerrarSesion.IconColor = Color.Silver;
            btnCerrarSesion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCerrarSesion.IconSize = 25;
            btnCerrarSesion.ImageAlign = ContentAlignment.MiddleLeft;
            btnCerrarSesion.Location = new Point(0, 40);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Padding = new Padding(40, 0, 0, 0);
            btnCerrarSesion.Size = new Size(260, 40);
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.TextAlign = ContentAlignment.MiddleLeft;
            btnCerrarSesion.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // btnInfoGeneral
            // 
            btnInfoGeneral.Dock = DockStyle.Top;
            btnInfoGeneral.FlatAppearance.BorderSize = 0;
            btnInfoGeneral.FlatStyle = FlatStyle.Flat;
            btnInfoGeneral.Font = new Font("Segoe UI", 10F);
            btnInfoGeneral.ForeColor = Color.Silver;
            btnInfoGeneral.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            btnInfoGeneral.IconColor = Color.Silver;
            btnInfoGeneral.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnInfoGeneral.IconSize = 25;
            btnInfoGeneral.ImageAlign = ContentAlignment.MiddleLeft;
            btnInfoGeneral.Location = new Point(0, 0);
            btnInfoGeneral.Name = "btnInfoGeneral";
            btnInfoGeneral.Padding = new Padding(40, 0, 0, 0);
            btnInfoGeneral.Size = new Size(260, 40);
            btnInfoGeneral.Text = "Información";
            btnInfoGeneral.TextAlign = ContentAlignment.MiddleLeft;
            btnInfoGeneral.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnInfoGeneral.UseVisualStyleBackColor = true;
            btnInfoGeneral.Click += btnInfoGeneral_Click;
            // 
            // btnMenuPerfil
            // 
            btnMenuPerfil.Dock = DockStyle.Top;
            btnMenuPerfil.FlatAppearance.BorderSize = 0;
            btnMenuPerfil.FlatStyle = FlatStyle.Flat;
            btnMenuPerfil.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnMenuPerfil.ForeColor = Color.Gainsboro;
            btnMenuPerfil.IconChar = FontAwesome.Sharp.IconChar.User;
            btnMenuPerfil.IconColor = Color.Gainsboro;
            btnMenuPerfil.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMenuPerfil.IconSize = 32;
            btnMenuPerfil.ImageAlign = ContentAlignment.MiddleLeft;
            btnMenuPerfil.Location = new Point(0, 60); // Ajustado para que no tape el logo
            btnMenuPerfil.Name = "btnMenuPerfil";
            btnMenuPerfil.Padding = new Padding(15, 0, 0, 0);
            btnMenuPerfil.Size = new Size(260, 50);
            btnMenuPerfil.Text = "Mi Perfil";
            btnMenuPerfil.TextAlign = ContentAlignment.MiddleLeft;
            btnMenuPerfil.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMenuPerfil.UseVisualStyleBackColor = true;
            btnMenuPerfil.Click += btnMenuPerfil_Click;
            // 
            // pnlLogo
            // 
            pnlLogo.BackColor = Color.FromArgb(44, 62, 80);
            pnlLogo.Controls.Add(label2);
            pnlLogo.Dock = DockStyle.Top;
            pnlLogo.Location = new Point(0, 0);
            pnlLogo.Name = "pnlLogo";
            pnlLogo.Size = new Size(260, 60);
            pnlLogo.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(45, 15);
            label2.Name = "label2";
            label2.Size = new Size(165, 28);
            label2.Text = "SISTEMA ACAD";
            // 
            // pnlHeaderInfo
            // 
            pnlHeaderInfo.BackColor = Color.White;
            pnlHeaderInfo.Controls.Add(lbl_Reloj);
            pnlHeaderInfo.Controls.Add(lbl_Rol);
            pnlHeaderInfo.Controls.Add(label4);
            pnlHeaderInfo.Controls.Add(lbl_Nombre);
            pnlHeaderInfo.Controls.Add(label1);
            pnlHeaderInfo.Dock = DockStyle.Top;
            pnlHeaderInfo.Location = new Point(260, 30);
            pnlHeaderInfo.Name = "pnlHeaderInfo";
            pnlHeaderInfo.Size = new Size(1020, 60);
            pnlHeaderInfo.TabIndex = 2;
            // 
            // lbl_Reloj
            // 
            lbl_Reloj.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl_Reloj.AutoSize = true;
            lbl_Reloj.Font = new Font("Segoe UI", 11F);
            lbl_Reloj.ForeColor = Color.FromArgb(64, 64, 64);
            lbl_Reloj.Location = new Point(780, 20);
            lbl_Reloj.Name = "lbl_Reloj";
            lbl_Reloj.Size = new Size(220, 20);
            lbl_Reloj.TabIndex = 0;
            lbl_Reloj.Text = "dd/MM/yyyy HH:mm:ss --- 0 min";
            lbl_Reloj.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbl_Rol
            // 
            lbl_Rol.AutoSize = true;
            lbl_Rol.Font = new Font("Segoe UI", 11F);
            lbl_Rol.ForeColor = Color.FromArgb(64, 64, 64);
            lbl_Rol.Location = new Point(410, 20);
            lbl_Rol.Name = "lbl_Rol";
            lbl_Rol.Size = new Size(82, 20);
            lbl_Rol.TabIndex = 1;
            lbl_Rol.Text = "RolUsuario";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(44, 62, 80);
            label4.Location = new Point(370, 20);
            label4.Name = "label4";
            label4.Size = new Size(36, 20);
            label4.TabIndex = 2;
            label4.Text = "Rol:";
            // 
            // lbl_Nombre
            // 
            lbl_Nombre.AutoSize = true;
            lbl_Nombre.Font = new Font("Segoe UI", 11F);
            lbl_Nombre.ForeColor = Color.FromArgb(64, 64, 64);
            lbl_Nombre.Location = new Point(120, 20);
            lbl_Nombre.Name = "lbl_Nombre";
            lbl_Nombre.Size = new Size(116, 20);
            lbl_Nombre.TabIndex = 3;
            lbl_Nombre.Text = "NombreUsuario";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(44, 62, 80);
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(91, 20);
            label1.TabIndex = 4;
            label1.Text = "Bienvenido:";
            // 
            // pnlContenedorHijo
            // 
            pnlContenedorHijo.BackColor = Color.FromArgb(240, 243, 246);
            // CONFIGURACIÓN DE LA IMAGEN DE FONDO OPACA
            pnlContenedorHijo.BackgroundImage = Resources.background_academico;
            pnlContenedorHijo.BackgroundImageLayout = ImageLayout.Center; // O Zoom, según la imagen
            pnlContenedorHijo.Dock = DockStyle.Fill;
            pnlContenedorHijo.Location = new Point(260, 90);
            pnlContenedorHijo.Name = "pnlContenedorHijo";
            pnlContenedorHijo.Size = new Size(1020, 630);
            pnlContenedorHijo.TabIndex = 3;
            // Control MDI oculto pero funcional
            this.IsMdiContainer = true;
            foreach (Control control in this.Controls)
            {
                if (control is MdiClient)
                {
                    control.Visible = false; // Ocultamos el gris nativo
                }
            }
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
            BackColor = Color.FromArgb(240, 243, 246);
            ClientSize = new Size(1280, 720);
            Controls.Add(pnlContenedorHijo);
            Controls.Add(pnlHeaderInfo);
            Controls.Add(pnlMenuContainer);
            Controls.Add(pnlControlWindow);
            Font = new Font("Segoe UI", 14F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frm_Principal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema Académico";
            Load += frm_Principal_Load;
            pnlControlWindow.ResumeLayout(false);
            pnlMenuContainer.ResumeLayout(false);
            pnlSubMenuReportes.ResumeLayout(false);
            pnlSubMenuSimulacion.ResumeLayout(false);
            pnlSubMenuCalificaciones.ResumeLayout(false);
            pnlSubMenuAcademico.ResumeLayout(false);
            pnlSubMenuAdmin.ResumeLayout(false);
            pnlSubMenuPerfil.ResumeLayout(false);
            pnlLogo.ResumeLayout(false);
            pnlLogo.PerformLayout();
            pnlHeaderInfo.ResumeLayout(false);
            pnlHeaderInfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        // Paneles Principales de Estructura
        private System.Windows.Forms.Panel pnlControlWindow;
        private System.Windows.Forms.Panel pnlMenuContainer;
        private System.Windows.Forms.Panel pnlHeaderInfo;
        private System.Windows.Forms.Panel pnlContenedorHijo;
        private System.Windows.Forms.Panel pnlLogo;

        // Botones Control de Ventana
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnMaximizar;
        private System.Windows.Forms.Button btnMinimizar;

        // Menús Principales (Botones FontAwesome)
        private FontAwesome.Sharp.IconButton btnMenuPerfil;
        private FontAwesome.Sharp.IconButton btnMenuAdmin;
        private FontAwesome.Sharp.IconButton btnMenuAcademico;
        private FontAwesome.Sharp.IconButton btnMenuCalificaciones;
        private FontAwesome.Sharp.IconButton btnMenuSimulacion;
        private FontAwesome.Sharp.IconButton btnMenuReportes;

        // Paneles de SubMenús (Dropdowns)
        private System.Windows.Forms.Panel pnlSubMenuPerfil;
        private System.Windows.Forms.Panel pnlSubMenuAdmin;
        private System.Windows.Forms.Panel pnlSubMenuAcademico;
        private System.Windows.Forms.Panel pnlSubMenuCalificaciones;
        private System.Windows.Forms.Panel pnlSubMenuSimulacion;
        private System.Windows.Forms.Panel pnlSubMenuReportes;

        // Botones de SubMenús
        private FontAwesome.Sharp.IconButton btnInfoGeneral;
        private FontAwesome.Sharp.IconButton btnCerrarSesion;
        private FontAwesome.Sharp.IconButton btnUsuarios;
        private FontAwesome.Sharp.IconButton btnDocentes;
        private FontAwesome.Sharp.IconButton btnEstudiantes;
        private FontAwesome.Sharp.IconButton btnAuditoria;
        private FontAwesome.Sharp.IconButton btnAsignaturas;
        private FontAwesome.Sharp.IconButton btnPeriodos;
        private FontAwesome.Sharp.IconButton btnMatriculas;
        private FontAwesome.Sharp.IconButton btnAsigDocentes;
        private FontAwesome.Sharp.IconButton btnIngresoNotas;
        private FontAwesome.Sharp.IconButton btnSimPromedios;
        private FontAwesome.Sharp.IconButton btnDashRendimiento;
        private FontAwesome.Sharp.IconButton btnRptAcademico;

        // UI Labels e Info
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Nombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_Rol;
        private System.Windows.Forms.Label lbl_Reloj;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
    }
}