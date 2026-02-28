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
            pnlControlWindow = new System.Windows.Forms.Panel();
            label2 = new System.Windows.Forms.Label();
            btnMinimizar = new System.Windows.Forms.Button();
            btnMaximizar = new System.Windows.Forms.Button();
            btnCerrar = new System.Windows.Forms.Button();

            pnlMenuTop = new System.Windows.Forms.Panel();
            btnMenuReportes = new FontAwesome.Sharp.IconButton();
            btnMenuSimulacion = new FontAwesome.Sharp.IconButton();
            btnMenuCalificaciones = new FontAwesome.Sharp.IconButton();
            btnMenuAcademico = new FontAwesome.Sharp.IconButton();
            btnMenuAdmin = new FontAwesome.Sharp.IconButton();
            btnMenuPerfil = new FontAwesome.Sharp.IconButton();

            pnlHeaderInfo = new System.Windows.Forms.Panel();
            lbl_Reloj = new System.Windows.Forms.Label();
            lbl_Rol = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            lbl_Nombre = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();

            pnlContenedorHijo = new System.Windows.Forms.Panel();

            // Submenús (Flotantes)
            pnlSubMenuPerfil = new System.Windows.Forms.Panel();
            btnCerrarSesion = new FontAwesome.Sharp.IconButton();
            btnInfoGeneral = new FontAwesome.Sharp.IconButton();

            pnlSubMenuAdmin = new System.Windows.Forms.Panel();
            btnAuditoria = new FontAwesome.Sharp.IconButton();
            btnEstudiantes = new FontAwesome.Sharp.IconButton();
            btnDocentes = new FontAwesome.Sharp.IconButton();
            btnUsuarios = new FontAwesome.Sharp.IconButton();

            pnlSubMenuAcademico = new System.Windows.Forms.Panel();
            btnAsigDocentes = new FontAwesome.Sharp.IconButton();
            btnMatriculas = new FontAwesome.Sharp.IconButton();
            btnPeriodos = new FontAwesome.Sharp.IconButton();
            btnAsignaturas = new FontAwesome.Sharp.IconButton();

            pnlSubMenuCalificaciones = new System.Windows.Forms.Panel();
            btnIngresoNotas = new FontAwesome.Sharp.IconButton();

            pnlSubMenuSimulacion = new System.Windows.Forms.Panel();
            btnDashRendimiento = new FontAwesome.Sharp.IconButton();
            btnSimPromedios = new FontAwesome.Sharp.IconButton();

            pnlSubMenuReportes = new System.Windows.Forms.Panel();
            btnRptAcademico = new FontAwesome.Sharp.IconButton();

            timer1 = new System.Windows.Forms.Timer(components);

            pnlControlWindow.SuspendLayout();
            pnlMenuTop.SuspendLayout();
            pnlHeaderInfo.SuspendLayout();
            pnlSubMenuPerfil.SuspendLayout();
            pnlSubMenuAdmin.SuspendLayout();
            pnlSubMenuAcademico.SuspendLayout();
            pnlSubMenuCalificaciones.SuspendLayout();
            pnlSubMenuSimulacion.SuspendLayout();
            pnlSubMenuReportes.SuspendLayout();
            SuspendLayout();

            // --- PANEL CONTROL SUPERIOR (Título y Botones Ventana) ---
            pnlControlWindow.BackColor = System.Drawing.Color.FromArgb(40, 50, 65);
            pnlControlWindow.Controls.Add(label2);
            pnlControlWindow.Controls.Add(btnMinimizar);
            pnlControlWindow.Controls.Add(btnMaximizar);
            pnlControlWindow.Controls.Add(btnCerrar);
            pnlControlWindow.Dock = System.Windows.Forms.DockStyle.Top;
            pnlControlWindow.Location = new System.Drawing.Point(0, 0);
            pnlControlWindow.Name = "pnlControlWindow";
            pnlControlWindow.Size = new System.Drawing.Size(1280, 40);
            pnlControlWindow.MouseDown += pnlControlWindow_MouseDown;

            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            label2.ForeColor = System.Drawing.Color.White;
            label2.Location = new System.Drawing.Point(15, 7); // Corrección del error del Point
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(206, 25);
            label2.Text = "SISTEMA ACADÉMICO";
            label2.MouseDown += pnlControlWindow_MouseDown;

            btnMinimizar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnMinimizar.FlatAppearance.BorderSize = 0;
            btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnMinimizar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnMinimizar.ForeColor = System.Drawing.Color.White;
            btnMinimizar.Location = new System.Drawing.Point(1190, 5);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Size = new System.Drawing.Size(30, 30);
            btnMinimizar.Text = "—";
            btnMinimizar.UseVisualStyleBackColor = true;
            btnMinimizar.Click += btnMinimizar_Click;

            btnMaximizar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnMaximizar.FlatAppearance.BorderSize = 0;
            btnMaximizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnMaximizar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnMaximizar.ForeColor = System.Drawing.Color.White;
            btnMaximizar.Location = new System.Drawing.Point(1220, 5);
            btnMaximizar.Name = "btnMaximizar";
            btnMaximizar.Size = new System.Drawing.Size(30, 30);
            btnMaximizar.Text = "⬜";
            btnMaximizar.UseVisualStyleBackColor = true;
            btnMaximizar.Click += btnMaximizar_Click;

            btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnCerrar.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCerrar.Location = new System.Drawing.Point(1255, 12);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new System.Drawing.Size(16, 16);
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            btnCerrar.Paint += btnCerrar_Paint;

            // --- PANEL MENÚ HORIZONTAL ---
            pnlMenuTop.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            pnlMenuTop.Controls.Add(btnMenuReportes);
            pnlMenuTop.Controls.Add(btnMenuSimulacion);
            pnlMenuTop.Controls.Add(btnMenuCalificaciones);
            pnlMenuTop.Controls.Add(btnMenuAcademico);
            pnlMenuTop.Controls.Add(btnMenuAdmin);
            pnlMenuTop.Controls.Add(btnMenuPerfil);
            pnlMenuTop.Dock = System.Windows.Forms.DockStyle.Top;
            pnlMenuTop.Location = new System.Drawing.Point(0, 40);
            pnlMenuTop.Name = "pnlMenuTop";
            pnlMenuTop.Size = new System.Drawing.Size(1280, 50);

            // Configuración general de botones horizontales
            btnMenuPerfil.Dock = System.Windows.Forms.DockStyle.Left;
            btnMenuPerfil.FlatAppearance.BorderSize = 0;
            btnMenuPerfil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnMenuPerfil.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnMenuPerfil.ForeColor = System.Drawing.Color.Gainsboro;
            btnMenuPerfil.IconChar = FontAwesome.Sharp.IconChar.User;
            btnMenuPerfil.IconColor = System.Drawing.Color.Gainsboro;
            btnMenuPerfil.IconSize = 28;
            btnMenuPerfil.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btnMenuPerfil.Size = new System.Drawing.Size(150, 50);
            btnMenuPerfil.Text = " Mi Perfil";
            btnMenuPerfil.Click += btnMenuPerfil_Click;

            btnMenuAdmin.Dock = System.Windows.Forms.DockStyle.Left;
            btnMenuAdmin.FlatAppearance.BorderSize = 0;
            btnMenuAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnMenuAdmin.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnMenuAdmin.ForeColor = System.Drawing.Color.Gainsboro;
            btnMenuAdmin.IconChar = FontAwesome.Sharp.IconChar.Tools;
            btnMenuAdmin.IconColor = System.Drawing.Color.Gainsboro;
            btnMenuAdmin.IconSize = 28;
            btnMenuAdmin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btnMenuAdmin.Size = new System.Drawing.Size(180, 50);
            btnMenuAdmin.Text = " Administración";
            btnMenuAdmin.Click += btnMenuAdmin_Click;

            btnMenuAcademico.Dock = System.Windows.Forms.DockStyle.Left;
            btnMenuAcademico.FlatAppearance.BorderSize = 0;
            btnMenuAcademico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnMenuAcademico.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnMenuAcademico.ForeColor = System.Drawing.Color.Gainsboro;
            btnMenuAcademico.IconChar = FontAwesome.Sharp.IconChar.University;
            btnMenuAcademico.IconColor = System.Drawing.Color.Gainsboro;
            btnMenuAcademico.IconSize = 28;
            btnMenuAcademico.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btnMenuAcademico.Size = new System.Drawing.Size(150, 50);
            btnMenuAcademico.Text = " Académico";
            btnMenuAcademico.Click += btnMenuAcademico_Click;

            btnMenuCalificaciones.Dock = System.Windows.Forms.DockStyle.Left;
            btnMenuCalificaciones.FlatAppearance.BorderSize = 0;
            btnMenuCalificaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnMenuCalificaciones.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnMenuCalificaciones.ForeColor = System.Drawing.Color.Gainsboro;
            btnMenuCalificaciones.IconChar = FontAwesome.Sharp.IconChar.GraduationCap;
            btnMenuCalificaciones.IconColor = System.Drawing.Color.Gainsboro;
            btnMenuCalificaciones.IconSize = 28;
            btnMenuCalificaciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btnMenuCalificaciones.Size = new System.Drawing.Size(170, 50);
            btnMenuCalificaciones.Text = " Calificaciones";
            btnMenuCalificaciones.Click += btnMenuCalificaciones_Click;

            btnMenuSimulacion.Dock = System.Windows.Forms.DockStyle.Left;
            btnMenuSimulacion.FlatAppearance.BorderSize = 0;
            btnMenuSimulacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnMenuSimulacion.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnMenuSimulacion.ForeColor = System.Drawing.Color.Gainsboro;
            btnMenuSimulacion.IconChar = FontAwesome.Sharp.IconChar.Brain;
            btnMenuSimulacion.IconColor = System.Drawing.Color.Gainsboro;
            btnMenuSimulacion.IconSize = 28;
            btnMenuSimulacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btnMenuSimulacion.Size = new System.Drawing.Size(150, 50);
            btnMenuSimulacion.Text = " Simulación";
            btnMenuSimulacion.Click += btnMenuSimulacion_Click;

            btnMenuReportes.Dock = System.Windows.Forms.DockStyle.Left;
            btnMenuReportes.FlatAppearance.BorderSize = 0;
            btnMenuReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnMenuReportes.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnMenuReportes.ForeColor = System.Drawing.Color.Gainsboro;
            btnMenuReportes.IconChar = FontAwesome.Sharp.IconChar.ChartBar;
            btnMenuReportes.IconColor = System.Drawing.Color.Gainsboro;
            btnMenuReportes.IconSize = 28;
            btnMenuReportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btnMenuReportes.Size = new System.Drawing.Size(140, 50);
            btnMenuReportes.Text = " Reportes";
            btnMenuReportes.Click += btnMenuReportes_Click;

            // --- PANEL HEADER INFO (Usuario y Reloj) ---
            pnlHeaderInfo.BackColor = System.Drawing.Color.White;
            pnlHeaderInfo.Controls.Add(lbl_Reloj);
            pnlHeaderInfo.Controls.Add(lbl_Rol);
            pnlHeaderInfo.Controls.Add(label4);
            pnlHeaderInfo.Controls.Add(lbl_Nombre);
            pnlHeaderInfo.Controls.Add(label1);
            pnlHeaderInfo.Dock = System.Windows.Forms.DockStyle.Top;
            pnlHeaderInfo.Location = new System.Drawing.Point(0, 90);
            pnlHeaderInfo.Name = "pnlHeaderInfo";
            pnlHeaderInfo.Size = new System.Drawing.Size(1280, 40);

            lbl_Reloj.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lbl_Reloj.AutoSize = true;
            lbl_Reloj.Font = new System.Drawing.Font("Segoe UI", 11F);
            lbl_Reloj.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lbl_Reloj.Location = new System.Drawing.Point(950, 10);
            lbl_Reloj.Name = "lbl_Reloj";
            lbl_Reloj.Size = new System.Drawing.Size(220, 20);
            lbl_Reloj.Text = "00/00/0000 00:00:00 --- 0 min";

            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            label1.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            label1.Location = new System.Drawing.Point(20, 10);
            label1.Name = "label1";
            label1.Text = "Bienvenido:";

            lbl_Nombre.AutoSize = true;
            lbl_Nombre.Font = new System.Drawing.Font("Segoe UI", 11F);
            lbl_Nombre.Location = new System.Drawing.Point(120, 10);
            lbl_Nombre.Name = "lbl_Nombre";
            lbl_Nombre.Text = "NombreUsuario";

            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            label4.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            label4.Location = new System.Drawing.Point(370, 10);
            label4.Text = "Rol:";

            lbl_Rol.AutoSize = true;
            lbl_Rol.Font = new System.Drawing.Font("Segoe UI", 11F);
            lbl_Rol.Location = new System.Drawing.Point(410, 10);
            lbl_Rol.Text = "RolUsuario";

            // --- CONTENEDOR PRINCIPAL (Donde van los formularios hijos) ---
            pnlContenedorHijo.BackColor = System.Drawing.Color.FromArgb(240, 243, 246);
            pnlContenedorHijo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            pnlContenedorHijo.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlContenedorHijo.Location = new System.Drawing.Point(0, 130);
            pnlContenedorHijo.Name = "pnlContenedorHijo";
            pnlContenedorHijo.Size = new System.Drawing.Size(1280, 590);

            // =========================================================================
            // CONFIGURACIÓN DE LOS PANELES SUBMENÚS (Desplegables)
            // =========================================================================

            // MI PERFIL
            pnlSubMenuPerfil.BackColor = System.Drawing.Color.FromArgb(65, 85, 105);
            pnlSubMenuPerfil.Controls.Add(btnCerrarSesion);
            pnlSubMenuPerfil.Controls.Add(btnInfoGeneral);
            pnlSubMenuPerfil.Size = new System.Drawing.Size(200, 80);
            pnlSubMenuPerfil.Visible = false;

            btnInfoGeneral.Dock = System.Windows.Forms.DockStyle.Top;
            btnInfoGeneral.FlatAppearance.BorderSize = 0;
            btnInfoGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnInfoGeneral.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnInfoGeneral.ForeColor = System.Drawing.Color.Silver;
            btnInfoGeneral.Size = new System.Drawing.Size(200, 40);
            btnInfoGeneral.Text = " Información General";
            btnInfoGeneral.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnInfoGeneral.Click += btnInfoGeneral_Click;

            btnCerrarSesion.Dock = System.Windows.Forms.DockStyle.Top;
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnCerrarSesion.ForeColor = System.Drawing.Color.Silver;
            btnCerrarSesion.Size = new System.Drawing.Size(200, 40);
            btnCerrarSesion.Text = " Cerrar Sesión";
            btnCerrarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnCerrarSesion.Click += btnCerrarSesion_Click;

            // ADMINISTRACIÓN
            pnlSubMenuAdmin.BackColor = System.Drawing.Color.FromArgb(65, 85, 105);
            pnlSubMenuAdmin.Controls.Add(btnAuditoria);
            pnlSubMenuAdmin.Controls.Add(btnEstudiantes);
            pnlSubMenuAdmin.Controls.Add(btnDocentes);
            pnlSubMenuAdmin.Controls.Add(btnUsuarios);
            pnlSubMenuAdmin.Size = new System.Drawing.Size(200, 160);
            pnlSubMenuAdmin.Visible = false;

            btnUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            btnUsuarios.FlatAppearance.BorderSize = 0;
            btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnUsuarios.ForeColor = System.Drawing.Color.Silver;
            btnUsuarios.Size = new System.Drawing.Size(200, 40);
            btnUsuarios.Text = " Usuarios";
            btnUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnUsuarios.Click += btnUsuarios_Click;

            btnDocentes.Dock = System.Windows.Forms.DockStyle.Top;
            btnDocentes.FlatAppearance.BorderSize = 0;
            btnDocentes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDocentes.ForeColor = System.Drawing.Color.Silver;
            btnDocentes.Size = new System.Drawing.Size(200, 40);
            btnDocentes.Text = " Docentes";
            btnDocentes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnDocentes.Click += btnDocentes_Click;

            btnEstudiantes.Dock = System.Windows.Forms.DockStyle.Top;
            btnEstudiantes.FlatAppearance.BorderSize = 0;
            btnEstudiantes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnEstudiantes.ForeColor = System.Drawing.Color.Silver;
            btnEstudiantes.Size = new System.Drawing.Size(200, 40);
            btnEstudiantes.Text = " Estudiantes";
            btnEstudiantes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnEstudiantes.Click += btnEstudiantes_Click;

            btnAuditoria.Dock = System.Windows.Forms.DockStyle.Top;
            btnAuditoria.FlatAppearance.BorderSize = 0;
            btnAuditoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAuditoria.ForeColor = System.Drawing.Color.Silver;
            btnAuditoria.Size = new System.Drawing.Size(200, 40);
            btnAuditoria.Text = " Auditoría";
            btnAuditoria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnAuditoria.Click += btnAuditoria_Click;

            // ACADÉMICO
            pnlSubMenuAcademico.BackColor = System.Drawing.Color.FromArgb(65, 85, 105);
            pnlSubMenuAcademico.Controls.Add(btnAsigDocentes);
            pnlSubMenuAcademico.Controls.Add(btnMatriculas);
            pnlSubMenuAcademico.Controls.Add(btnPeriodos);
            pnlSubMenuAcademico.Controls.Add(btnAsignaturas);
            pnlSubMenuAcademico.Size = new System.Drawing.Size(200, 160);
            pnlSubMenuAcademico.Visible = false;

            btnAsignaturas.Dock = System.Windows.Forms.DockStyle.Top;
            btnAsignaturas.FlatAppearance.BorderSize = 0;
            btnAsignaturas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAsignaturas.ForeColor = System.Drawing.Color.Silver;
            btnAsignaturas.Size = new System.Drawing.Size(200, 40);
            btnAsignaturas.Text = " Asignaturas";
            btnAsignaturas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnAsignaturas.Click += btnAsignaturas_Click;

            btnPeriodos.Dock = System.Windows.Forms.DockStyle.Top;
            btnPeriodos.FlatAppearance.BorderSize = 0;
            btnPeriodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnPeriodos.ForeColor = System.Drawing.Color.Silver;
            btnPeriodos.Size = new System.Drawing.Size(200, 40);
            btnPeriodos.Text = " Periodos Académicos";
            btnPeriodos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnPeriodos.Click += btnPeriodos_Click;

            btnMatriculas.Dock = System.Windows.Forms.DockStyle.Top;
            btnMatriculas.FlatAppearance.BorderSize = 0;
            btnMatriculas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnMatriculas.ForeColor = System.Drawing.Color.Silver;
            btnMatriculas.Size = new System.Drawing.Size(200, 40);
            btnMatriculas.Text = " Matrículas";
            btnMatriculas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnMatriculas.Click += btnMatriculas_Click;

            btnAsigDocentes.Dock = System.Windows.Forms.DockStyle.Top;
            btnAsigDocentes.FlatAppearance.BorderSize = 0;
            btnAsigDocentes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAsigDocentes.ForeColor = System.Drawing.Color.Silver;
            btnAsigDocentes.Size = new System.Drawing.Size(200, 40);
            btnAsigDocentes.Text = " Asignar Docentes";
            btnAsigDocentes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnAsigDocentes.Click += btnAsigDocentes_Click;

            // CALIFICACIONES
            pnlSubMenuCalificaciones.BackColor = System.Drawing.Color.FromArgb(65, 85, 105);
            pnlSubMenuCalificaciones.Controls.Add(btnIngresoNotas);
            pnlSubMenuCalificaciones.Size = new System.Drawing.Size(200, 40);
            pnlSubMenuCalificaciones.Visible = false;

            btnIngresoNotas.Dock = System.Windows.Forms.DockStyle.Top;
            btnIngresoNotas.FlatAppearance.BorderSize = 0;
            btnIngresoNotas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnIngresoNotas.ForeColor = System.Drawing.Color.Silver;
            btnIngresoNotas.Size = new System.Drawing.Size(200, 40);
            btnIngresoNotas.Text = " Ingreso de Notas";
            btnIngresoNotas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnIngresoNotas.Click += btnIngresoNotas_Click;

            // SIMULACIÓN
            pnlSubMenuSimulacion.BackColor = System.Drawing.Color.FromArgb(65, 85, 105);
            pnlSubMenuSimulacion.Controls.Add(btnDashRendimiento);
            pnlSubMenuSimulacion.Controls.Add(btnSimPromedios);
            pnlSubMenuSimulacion.Size = new System.Drawing.Size(220, 80);
            pnlSubMenuSimulacion.Visible = false;

            btnSimPromedios.Dock = System.Windows.Forms.DockStyle.Top;
            btnSimPromedios.FlatAppearance.BorderSize = 0;
            btnSimPromedios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSimPromedios.ForeColor = System.Drawing.Color.Silver;
            btnSimPromedios.Size = new System.Drawing.Size(220, 40);
            btnSimPromedios.Text = " Simulador de Notas";
            btnSimPromedios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnSimPromedios.Click += btnSimPromedios_Click;

            btnDashRendimiento.Dock = System.Windows.Forms.DockStyle.Top;
            btnDashRendimiento.FlatAppearance.BorderSize = 0;
            btnDashRendimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDashRendimiento.ForeColor = System.Drawing.Color.Silver;
            btnDashRendimiento.Size = new System.Drawing.Size(220, 40);
            btnDashRendimiento.Text = " Dashboard Predicción";
            btnDashRendimiento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnDashRendimiento.Click += btnDashRendimiento_Click;

            // REPORTES
            pnlSubMenuReportes.BackColor = System.Drawing.Color.FromArgb(65, 85, 105);
            pnlSubMenuReportes.Controls.Add(btnRptAcademico);
            pnlSubMenuReportes.Size = new System.Drawing.Size(200, 40);
            pnlSubMenuReportes.Visible = false;

            btnRptAcademico.Dock = System.Windows.Forms.DockStyle.Top;
            btnRptAcademico.FlatAppearance.BorderSize = 0;
            btnRptAcademico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRptAcademico.ForeColor = System.Drawing.Color.Silver;
            btnRptAcademico.Size = new System.Drawing.Size(200, 40);
            btnRptAcademico.Text = " Exportar PDFs";
            btnRptAcademico.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnRptAcademico.Click += btnRptAcademico_Click;

            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;

            // Agregar submenús a los controles principales
            Controls.Add(pnlSubMenuReportes);
            Controls.Add(pnlSubMenuSimulacion);
            Controls.Add(pnlSubMenuCalificaciones);
            Controls.Add(pnlSubMenuAcademico);
            Controls.Add(pnlSubMenuAdmin);
            Controls.Add(pnlSubMenuPerfil);

            Controls.Add(pnlContenedorHijo);
            Controls.Add(pnlHeaderInfo);
            Controls.Add(pnlMenuTop);
            Controls.Add(pnlControlWindow);

            AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(240, 243, 246);
            ClientSize = new System.Drawing.Size(1280, 720);
            Font = new System.Drawing.Font("Segoe UI", 14F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Sistema Académico";
            Load += frm_Principal_Load;

            pnlControlWindow.ResumeLayout(false);
            pnlControlWindow.PerformLayout();
            pnlMenuTop.ResumeLayout(false);
            pnlHeaderInfo.ResumeLayout(false);
            pnlHeaderInfo.PerformLayout();
            pnlSubMenuPerfil.ResumeLayout(false);
            pnlSubMenuAdmin.ResumeLayout(false);
            pnlSubMenuAcademico.ResumeLayout(false);
            pnlSubMenuCalificaciones.ResumeLayout(false);
            pnlSubMenuSimulacion.ResumeLayout(false);
            pnlSubMenuReportes.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlControlWindow;
        private System.Windows.Forms.Panel pnlMenuTop;
        private System.Windows.Forms.Panel pnlHeaderInfo;
        private System.Windows.Forms.Panel pnlContenedorHijo;
        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnMaximizar;
        private System.Windows.Forms.Button btnMinimizar;

        private FontAwesome.Sharp.IconButton btnMenuPerfil;
        private FontAwesome.Sharp.IconButton btnMenuAdmin;
        private FontAwesome.Sharp.IconButton btnMenuAcademico;
        private FontAwesome.Sharp.IconButton btnMenuCalificaciones;
        private FontAwesome.Sharp.IconButton btnMenuSimulacion;
        private FontAwesome.Sharp.IconButton btnMenuReportes;

        private System.Windows.Forms.Panel pnlSubMenuPerfil;
        private System.Windows.Forms.Panel pnlSubMenuAdmin;
        private System.Windows.Forms.Panel pnlSubMenuAcademico;
        private System.Windows.Forms.Panel pnlSubMenuCalificaciones;
        private System.Windows.Forms.Panel pnlSubMenuSimulacion;
        private System.Windows.Forms.Panel pnlSubMenuReportes;

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

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Nombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_Rol;
        private System.Windows.Forms.Label lbl_Reloj;
        private System.Windows.Forms.Timer timer1;
    }
}