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
            label2 = new Label();
            btnMinimizar = new Button();
            btnMaximizar = new Button();
            btnCerrar = new Button();
            pnlMenuTop = new Panel();
            btnMenuReportes = new FontAwesome.Sharp.IconButton();
            btnMenuSimulacion = new FontAwesome.Sharp.IconButton();
            btnMenuCalificaciones = new FontAwesome.Sharp.IconButton();
            btnMenuAcademico = new FontAwesome.Sharp.IconButton();
            btnMenuAdmin = new FontAwesome.Sharp.IconButton();
            btnMenuPerfil = new FontAwesome.Sharp.IconButton();
            pnlHeaderInfo = new Panel();
            lbl_Reloj = new Label();
            lbl_Rol = new Label();
            label4 = new Label();
            lbl_Nombre = new Label();
            label1 = new Label();
            pnlContenedorHijo = new Panel();
            pnlSubMenuPerfil = new Panel();
            btnCerrarSesion = new FontAwesome.Sharp.IconButton();
            btnInfoGeneral = new FontAwesome.Sharp.IconButton();
            pnlSubMenuAdmin = new Panel();
            btnAuditoria = new FontAwesome.Sharp.IconButton();
            btnAuditoriaDetallada = new FontAwesome.Sharp.IconButton();
            btnSimMontecarlo = new FontAwesome.Sharp.IconButton();
            btnEstudiantes = new FontAwesome.Sharp.IconButton();
            btnDocentes = new FontAwesome.Sharp.IconButton();
            btnUsuarios = new FontAwesome.Sharp.IconButton();
            pnlSubMenuAcademico = new Panel();
            btnAsigDocentes = new FontAwesome.Sharp.IconButton();
            btnMatriculas = new FontAwesome.Sharp.IconButton();
            btnPeriodos = new FontAwesome.Sharp.IconButton();
            btnAsignaturas = new FontAwesome.Sharp.IconButton();
            pnlSubMenuCalificaciones = new Panel();
            btnIngresoNotas = new FontAwesome.Sharp.IconButton();
            pnlSubMenuSimulacion = new Panel();
            btnDashRendimiento = new FontAwesome.Sharp.IconButton();
            btnSimPromedios = new FontAwesome.Sharp.IconButton();
            pnlSubMenuReportes = new Panel();
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
            // 
            // pnlControlWindow
            // 
            pnlControlWindow.BackColor = Color.FromArgb(40, 50, 65);
            pnlControlWindow.Controls.Add(label2);
            pnlControlWindow.Controls.Add(btnMinimizar);
            pnlControlWindow.Controls.Add(btnMaximizar);
            pnlControlWindow.Controls.Add(btnCerrar);
            pnlControlWindow.Dock = DockStyle.Top;
            pnlControlWindow.Location = new Point(0, 0);
            pnlControlWindow.Name = "pnlControlWindow";
            pnlControlWindow.Size = new Size(1280, 40);
            pnlControlWindow.TabIndex = 9;
            pnlControlWindow.MouseDown += pnlControlWindow_MouseDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(15, 7);
            label2.Name = "label2";
            label2.Size = new Size(704, 25);
            label2.TabIndex = 0;
            label2.Text = "                                                                                                   SISTEMA ACADÉMICO";
            label2.MouseDown += pnlControlWindow_MouseDown;
            // 
            // btnMinimizar
            // 
            btnMinimizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMinimizar.FlatAppearance.BorderSize = 0;
            btnMinimizar.FlatStyle = FlatStyle.Flat;
            btnMinimizar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnMinimizar.ForeColor = Color.White;
            btnMinimizar.Location = new Point(1190, 5);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Size = new Size(30, 30);
            btnMinimizar.TabIndex = 1;
            btnMinimizar.Text = "—";
            btnMinimizar.UseVisualStyleBackColor = true;
            btnMinimizar.Click += btnMinimizar_Click;
            // 
            // btnMaximizar
            // 
            btnMaximizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMaximizar.FlatAppearance.BorderSize = 0;
            btnMaximizar.FlatStyle = FlatStyle.Flat;
            btnMaximizar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnMaximizar.ForeColor = Color.White;
            btnMaximizar.Location = new Point(1220, 5);
            btnMaximizar.Name = "btnMaximizar";
            btnMaximizar.Size = new Size(30, 30);
            btnMaximizar.TabIndex = 2;
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
            btnCerrar.Location = new Point(1255, 12);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(16, 16);
            btnCerrar.TabIndex = 3;
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            btnCerrar.Paint += btnCerrar_Paint;
            // 
            // pnlMenuTop
            // 
            pnlMenuTop.BackColor = Color.FromArgb(52, 73, 94);
            pnlMenuTop.Controls.Add(btnMenuReportes);
            pnlMenuTop.Controls.Add(btnMenuSimulacion);
            pnlMenuTop.Controls.Add(btnMenuCalificaciones);
            pnlMenuTop.Controls.Add(btnMenuAcademico);
            pnlMenuTop.Controls.Add(btnMenuAdmin);
            pnlMenuTop.Controls.Add(btnMenuPerfil);
            pnlMenuTop.Dock = DockStyle.Top;
            pnlMenuTop.Location = new Point(0, 40);
            pnlMenuTop.Name = "pnlMenuTop";
            pnlMenuTop.Size = new Size(1280, 50);
            pnlMenuTop.TabIndex = 8;
            // 
            // btnMenuReportes
            // 
            btnMenuReportes.Dock = DockStyle.Left;
            btnMenuReportes.FlatAppearance.BorderSize = 0;
            btnMenuReportes.FlatStyle = FlatStyle.Flat;
            btnMenuReportes.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnMenuReportes.ForeColor = Color.Gainsboro;
            btnMenuReportes.IconChar = FontAwesome.Sharp.IconChar.BarChart;
            btnMenuReportes.IconColor = Color.Gainsboro;
            btnMenuReportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMenuReportes.IconSize = 28;
            btnMenuReportes.Location = new Point(800, 0);
            btnMenuReportes.Name = "btnMenuReportes";
            btnMenuReportes.Size = new Size(140, 50);
            btnMenuReportes.TabIndex = 0;
            btnMenuReportes.Text = " Reportes";
            btnMenuReportes.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMenuReportes.Click += btnMenuReportes_Click;
            // 
            // btnMenuSimulacion
            // 
            btnMenuSimulacion.Dock = DockStyle.Left;
            btnMenuSimulacion.FlatAppearance.BorderSize = 0;
            btnMenuSimulacion.FlatStyle = FlatStyle.Flat;
            btnMenuSimulacion.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnMenuSimulacion.ForeColor = Color.Gainsboro;
            btnMenuSimulacion.IconChar = FontAwesome.Sharp.IconChar.Brain;
            btnMenuSimulacion.IconColor = Color.Gainsboro;
            btnMenuSimulacion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMenuSimulacion.IconSize = 28;
            btnMenuSimulacion.Location = new Point(650, 0);
            btnMenuSimulacion.Name = "btnMenuSimulacion";
            btnMenuSimulacion.Size = new Size(150, 50);
            btnMenuSimulacion.TabIndex = 1;
            btnMenuSimulacion.Text = " Simulación";
            btnMenuSimulacion.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMenuSimulacion.Click += btnMenuSimulacion_Click;
            // 
            // btnMenuCalificaciones
            // 
            btnMenuCalificaciones.Dock = DockStyle.Left;
            btnMenuCalificaciones.FlatAppearance.BorderSize = 0;
            btnMenuCalificaciones.FlatStyle = FlatStyle.Flat;
            btnMenuCalificaciones.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnMenuCalificaciones.ForeColor = Color.Gainsboro;
            btnMenuCalificaciones.IconChar = FontAwesome.Sharp.IconChar.MortarBoard;
            btnMenuCalificaciones.IconColor = Color.Gainsboro;
            btnMenuCalificaciones.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMenuCalificaciones.IconSize = 28;
            btnMenuCalificaciones.Location = new Point(480, 0);
            btnMenuCalificaciones.Name = "btnMenuCalificaciones";
            btnMenuCalificaciones.Size = new Size(170, 50);
            btnMenuCalificaciones.TabIndex = 2;
            btnMenuCalificaciones.Text = " Calificaciones";
            btnMenuCalificaciones.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMenuCalificaciones.Click += btnMenuCalificaciones_Click;
            // 
            // btnMenuAcademico
            // 
            btnMenuAcademico.Dock = DockStyle.Left;
            btnMenuAcademico.FlatAppearance.BorderSize = 0;
            btnMenuAcademico.FlatStyle = FlatStyle.Flat;
            btnMenuAcademico.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnMenuAcademico.ForeColor = Color.Gainsboro;
            btnMenuAcademico.IconChar = FontAwesome.Sharp.IconChar.Institution;
            btnMenuAcademico.IconColor = Color.Gainsboro;
            btnMenuAcademico.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMenuAcademico.IconSize = 28;
            btnMenuAcademico.Location = new Point(330, 0);
            btnMenuAcademico.Name = "btnMenuAcademico";
            btnMenuAcademico.Size = new Size(150, 50);
            btnMenuAcademico.TabIndex = 3;
            btnMenuAcademico.Text = " Académico";
            btnMenuAcademico.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMenuAcademico.Click += btnMenuAcademico_Click;
            // 
            // btnMenuAdmin
            // 
            btnMenuAdmin.Dock = DockStyle.Left;
            btnMenuAdmin.FlatAppearance.BorderSize = 0;
            btnMenuAdmin.FlatStyle = FlatStyle.Flat;
            btnMenuAdmin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnMenuAdmin.ForeColor = Color.Gainsboro;
            btnMenuAdmin.IconChar = FontAwesome.Sharp.IconChar.Tools;
            btnMenuAdmin.IconColor = Color.Gainsboro;
            btnMenuAdmin.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMenuAdmin.IconSize = 28;
            btnMenuAdmin.Location = new Point(150, 0);
            btnMenuAdmin.Name = "btnMenuAdmin";
            btnMenuAdmin.Size = new Size(180, 50);
            btnMenuAdmin.TabIndex = 4;
            btnMenuAdmin.Text = " Administración";
            btnMenuAdmin.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMenuAdmin.Click += btnMenuAdmin_Click;
            // 
            // btnMenuPerfil
            // 
            btnMenuPerfil.Dock = DockStyle.Left;
            btnMenuPerfil.FlatAppearance.BorderSize = 0;
            btnMenuPerfil.FlatStyle = FlatStyle.Flat;
            btnMenuPerfil.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnMenuPerfil.ForeColor = Color.Gainsboro;
            btnMenuPerfil.IconChar = FontAwesome.Sharp.IconChar.User;
            btnMenuPerfil.IconColor = Color.Gainsboro;
            btnMenuPerfil.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMenuPerfil.IconSize = 28;
            btnMenuPerfil.Location = new Point(0, 0);
            btnMenuPerfil.Name = "btnMenuPerfil";
            btnMenuPerfil.Size = new Size(150, 50);
            btnMenuPerfil.TabIndex = 5;
            btnMenuPerfil.Text = " Mi Perfil";
            btnMenuPerfil.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMenuPerfil.Click += btnMenuPerfil_Click;
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
            pnlHeaderInfo.Location = new Point(0, 90);
            pnlHeaderInfo.Name = "pnlHeaderInfo";
            pnlHeaderInfo.Size = new Size(1280, 40);
            pnlHeaderInfo.TabIndex = 7;
            // 
            // lbl_Reloj
            // 
            lbl_Reloj.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl_Reloj.AutoSize = true;
            lbl_Reloj.Font = new Font("Segoe UI", 11F);
            lbl_Reloj.ForeColor = Color.FromArgb(64, 64, 64);
            lbl_Reloj.Location = new Point(1056, 10);
            lbl_Reloj.Name = "lbl_Reloj";
            lbl_Reloj.Size = new Size(194, 20);
            lbl_Reloj.TabIndex = 0;
            lbl_Reloj.Text = "00/00/0000 00:00:00 - 0 min";
            // 
            // lbl_Rol
            // 
            lbl_Rol.AutoSize = true;
            lbl_Rol.Font = new Font("Segoe UI", 11F);
            lbl_Rol.Location = new Point(410, 10);
            lbl_Rol.Name = "lbl_Rol";
            lbl_Rol.Size = new Size(81, 20);
            lbl_Rol.TabIndex = 1;
            lbl_Rol.Text = "RolUsuario";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(44, 62, 80);
            label4.Location = new Point(370, 10);
            label4.Name = "label4";
            label4.Size = new Size(36, 20);
            label4.TabIndex = 2;
            label4.Text = "Rol:";
            // 
            // lbl_Nombre
            // 
            lbl_Nombre.AutoSize = true;
            lbl_Nombre.Font = new Font("Segoe UI", 11F);
            lbl_Nombre.Location = new Point(105, 10);
            lbl_Nombre.Name = "lbl_Nombre";
            lbl_Nombre.Size = new Size(114, 20);
            lbl_Nombre.TabIndex = 3;
            lbl_Nombre.Text = "NombreUsuario";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(44, 62, 80);
            label1.Location = new Point(20, 10);
            label1.Name = "label1";
            label1.Size = new Size(87, 20);
            label1.TabIndex = 4;
            label1.Text = "Bienvenido";
            // 
            // pnlContenedorHijo
            // 
            pnlContenedorHijo.BackColor = Color.FromArgb(240, 243, 246);
            pnlContenedorHijo.BackgroundImageLayout = ImageLayout.Zoom;
            pnlContenedorHijo.Dock = DockStyle.Fill;
            pnlContenedorHijo.Location = new Point(0, 130);
            pnlContenedorHijo.Name = "pnlContenedorHijo";
            pnlContenedorHijo.Size = new Size(1280, 590);
            pnlContenedorHijo.TabIndex = 6;
            // 
            // pnlSubMenuPerfil
            // 
            pnlSubMenuPerfil.BackColor = Color.FromArgb(65, 85, 105);
            pnlSubMenuPerfil.Controls.Add(btnCerrarSesion);
            pnlSubMenuPerfil.Controls.Add(btnInfoGeneral);
            pnlSubMenuPerfil.Location = new Point(0, 0);
            pnlSubMenuPerfil.Name = "pnlSubMenuPerfil";
            pnlSubMenuPerfil.Size = new Size(200, 80);
            pnlSubMenuPerfil.TabIndex = 5;
            pnlSubMenuPerfil.Visible = false;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Dock = DockStyle.Top;
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Segoe UI", 10F);
            btnCerrarSesion.ForeColor = Color.Silver;
            btnCerrarSesion.IconChar = FontAwesome.Sharp.IconChar.None;
            btnCerrarSesion.IconColor = Color.Black;
            btnCerrarSesion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCerrarSesion.Location = new Point(0, 40);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(200, 40);
            btnCerrarSesion.TabIndex = 0;
            btnCerrarSesion.Text = " Cerrar Sesión";
            btnCerrarSesion.TextAlign = ContentAlignment.MiddleLeft;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // btnInfoGeneral
            // 
            btnInfoGeneral.Dock = DockStyle.Top;
            btnInfoGeneral.FlatAppearance.BorderSize = 0;
            btnInfoGeneral.FlatStyle = FlatStyle.Flat;
            btnInfoGeneral.Font = new Font("Segoe UI", 10F);
            btnInfoGeneral.ForeColor = Color.Silver;
            btnInfoGeneral.IconChar = FontAwesome.Sharp.IconChar.None;
            btnInfoGeneral.IconColor = Color.Black;
            btnInfoGeneral.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnInfoGeneral.Location = new Point(0, 0);
            btnInfoGeneral.Name = "btnInfoGeneral";
            btnInfoGeneral.Size = new Size(200, 40);
            btnInfoGeneral.TabIndex = 1;
            btnInfoGeneral.Text = " Información General";
            btnInfoGeneral.TextAlign = ContentAlignment.MiddleLeft;
            btnInfoGeneral.Click += btnInfoGeneral_Click;
            // 
            // pnlSubMenuAdmin
            // 
            pnlSubMenuAdmin.BackColor = Color.FromArgb(65, 85, 105);
            pnlSubMenuAdmin.Controls.Add(btnAuditoriaDetallada); // AGREGADO AQUÍ
            pnlSubMenuAdmin.Controls.Add(btnAuditoria);
            pnlSubMenuAdmin.Controls.Add(btnEstudiantes);
            pnlSubMenuAdmin.Controls.Add(btnDocentes);
            pnlSubMenuAdmin.Controls.Add(btnUsuarios);
            pnlSubMenuAdmin.Location = new Point(0, 0);
            pnlSubMenuAdmin.Name = "pnlSubMenuAdmin";
            pnlSubMenuAdmin.Size = new Size(200, 200);
            pnlSubMenuAdmin.TabIndex = 4;
            pnlSubMenuAdmin.Visible = false;
            // 
            // btnAuditoria
            // 
            btnAuditoria.Dock = DockStyle.Top;
            btnAuditoria.FlatAppearance.BorderSize = 0;
            btnAuditoria.FlatStyle = FlatStyle.Flat;
            btnAuditoria.ForeColor = Color.Silver;
            btnAuditoria.IconChar = FontAwesome.Sharp.IconChar.None;
            btnAuditoria.IconColor = Color.Black;
            btnAuditoria.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAuditoria.Location = new Point(0, 120);
            btnAuditoria.Name = "btnAuditoria";
            btnAuditoria.Size = new Size(200, 40);
            btnAuditoria.TabIndex = 0;
            btnAuditoria.Text = " Auditoría";
            btnAuditoria.TextAlign = ContentAlignment.MiddleLeft;
            btnAuditoria.Click += btnAuditoria_Click;
            // 
            // btnAuditoriaDetallada
            // 
            btnAuditoriaDetallada.Dock = DockStyle.Top;
            btnAuditoriaDetallada.FlatAppearance.BorderSize = 0;
            btnAuditoriaDetallada.FlatStyle = FlatStyle.Flat;
            btnAuditoriaDetallada.ForeColor = Color.Silver;
            btnAuditoriaDetallada.IconChar = FontAwesome.Sharp.IconChar.None;
            btnAuditoriaDetallada.IconColor = Color.Black;
            btnAuditoriaDetallada.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAuditoriaDetallada.Location = new Point(0, 160);
            btnAuditoriaDetallada.Name = "btnAuditoriaDetallada";
            btnAuditoriaDetallada.Size = new Size(200, 40);
            btnAuditoriaDetallada.TabIndex = 4;
            btnAuditoriaDetallada.Text = " Auditoría Detallada";
            btnAuditoriaDetallada.TextAlign = ContentAlignment.MiddleLeft;
            btnAuditoriaDetallada.Click += btnAuditoriaDetallada_Click;
            // 
            // btnEstudiantes
            // 
            btnEstudiantes.Dock = DockStyle.Top;
            btnEstudiantes.FlatAppearance.BorderSize = 0;
            btnEstudiantes.FlatStyle = FlatStyle.Flat;
            btnEstudiantes.ForeColor = Color.Silver;
            btnEstudiantes.IconChar = FontAwesome.Sharp.IconChar.None;
            btnEstudiantes.IconColor = Color.Black;
            btnEstudiantes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEstudiantes.Location = new Point(0, 80);
            btnEstudiantes.Name = "btnEstudiantes";
            btnEstudiantes.Size = new Size(200, 40);
            btnEstudiantes.TabIndex = 1;
            btnEstudiantes.Text = " Estudiantes";
            btnEstudiantes.TextAlign = ContentAlignment.MiddleLeft;
            btnEstudiantes.Click += btnEstudiantes_Click;
            // 
            // btnDocentes
            // 
            btnDocentes.Dock = DockStyle.Top;
            btnDocentes.FlatAppearance.BorderSize = 0;
            btnDocentes.FlatStyle = FlatStyle.Flat;
            btnDocentes.ForeColor = Color.Silver;
            btnDocentes.IconChar = FontAwesome.Sharp.IconChar.None;
            btnDocentes.IconColor = Color.Black;
            btnDocentes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDocentes.Location = new Point(0, 40);
            btnDocentes.Name = "btnDocentes";
            btnDocentes.Size = new Size(200, 40);
            btnDocentes.TabIndex = 2;
            btnDocentes.Text = " Docentes";
            btnDocentes.TextAlign = ContentAlignment.MiddleLeft;
            btnDocentes.Click += btnDocentes_Click;
            // 
            // btnUsuarios
            // 
            btnUsuarios.Dock = DockStyle.Top;
            btnUsuarios.FlatAppearance.BorderSize = 0;
            btnUsuarios.FlatStyle = FlatStyle.Flat;
            btnUsuarios.ForeColor = Color.Silver;
            btnUsuarios.IconChar = FontAwesome.Sharp.IconChar.None;
            btnUsuarios.IconColor = Color.Black;
            btnUsuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnUsuarios.Location = new Point(0, 0);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(200, 40);
            btnUsuarios.TabIndex = 3;
            btnUsuarios.Text = " Usuarios";
            btnUsuarios.TextAlign = ContentAlignment.MiddleLeft;
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // pnlSubMenuAcademico
            // 
            pnlSubMenuAcademico.BackColor = Color.FromArgb(65, 85, 105);
            pnlSubMenuAcademico.Controls.Add(btnAsigDocentes);
            pnlSubMenuAcademico.Controls.Add(btnMatriculas);
            pnlSubMenuAcademico.Controls.Add(btnPeriodos);
            pnlSubMenuAcademico.Controls.Add(btnAsignaturas);
            pnlSubMenuAcademico.Location = new Point(0, 0);
            pnlSubMenuAcademico.Name = "pnlSubMenuAcademico";
            pnlSubMenuAcademico.Size = new Size(200, 160);
            pnlSubMenuAcademico.TabIndex = 3;
            pnlSubMenuAcademico.Visible = false;
            // 
            // btnAsigDocentes
            // 
            btnAsigDocentes.Dock = DockStyle.Top;
            btnAsigDocentes.FlatAppearance.BorderSize = 0;
            btnAsigDocentes.FlatStyle = FlatStyle.Flat;
            btnAsigDocentes.ForeColor = Color.Silver;
            btnAsigDocentes.IconChar = FontAwesome.Sharp.IconChar.None;
            btnAsigDocentes.IconColor = Color.Black;
            btnAsigDocentes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAsigDocentes.Location = new Point(0, 120);
            btnAsigDocentes.Name = "btnAsigDocentes";
            btnAsigDocentes.Size = new Size(200, 40);
            btnAsigDocentes.TabIndex = 0;
            btnAsigDocentes.Text = " Asignar Docentes";
            btnAsigDocentes.TextAlign = ContentAlignment.MiddleLeft;
            btnAsigDocentes.Click += btnAsigDocentes_Click;
            // 
            // btnMatriculas
            // 
            btnMatriculas.Dock = DockStyle.Top;
            btnMatriculas.FlatAppearance.BorderSize = 0;
            btnMatriculas.FlatStyle = FlatStyle.Flat;
            btnMatriculas.ForeColor = Color.Silver;
            btnMatriculas.IconChar = FontAwesome.Sharp.IconChar.None;
            btnMatriculas.IconColor = Color.Black;
            btnMatriculas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMatriculas.Location = new Point(0, 80);
            btnMatriculas.Name = "btnMatriculas";
            btnMatriculas.Size = new Size(200, 40);
            btnMatriculas.TabIndex = 1;
            btnMatriculas.Text = " Matrículas";
            btnMatriculas.TextAlign = ContentAlignment.MiddleLeft;
            btnMatriculas.Click += btnMatriculas_Click;
            // 
            // btnPeriodos
            // 
            btnPeriodos.Dock = DockStyle.Top;
            btnPeriodos.FlatAppearance.BorderSize = 0;
            btnPeriodos.FlatStyle = FlatStyle.Flat;
            btnPeriodos.ForeColor = Color.Silver;
            btnPeriodos.IconChar = FontAwesome.Sharp.IconChar.None;
            btnPeriodos.IconColor = Color.Black;
            btnPeriodos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnPeriodos.Location = new Point(0, 40);
            btnPeriodos.Name = "btnPeriodos";
            btnPeriodos.Size = new Size(200, 40);
            btnPeriodos.TabIndex = 2;
            btnPeriodos.Text = " Periodos Académicos";
            btnPeriodos.TextAlign = ContentAlignment.MiddleLeft;
            btnPeriodos.Click += btnPeriodos_Click;
            // 
            // btnAsignaturas
            // 
            btnAsignaturas.Dock = DockStyle.Top;
            btnAsignaturas.FlatAppearance.BorderSize = 0;
            btnAsignaturas.FlatStyle = FlatStyle.Flat;
            btnAsignaturas.ForeColor = Color.Silver;
            btnAsignaturas.IconChar = FontAwesome.Sharp.IconChar.None;
            btnAsignaturas.IconColor = Color.Black;
            btnAsignaturas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAsignaturas.Location = new Point(0, 0);
            btnAsignaturas.Name = "btnAsignaturas";
            btnAsignaturas.Size = new Size(200, 40);
            btnAsignaturas.TabIndex = 3;
            btnAsignaturas.Text = " Asignaturas";
            btnAsignaturas.TextAlign = ContentAlignment.MiddleLeft;
            btnAsignaturas.Click += btnAsignaturas_Click;
            // 
            // pnlSubMenuCalificaciones
            // 
            pnlSubMenuCalificaciones.BackColor = Color.FromArgb(65, 85, 105);
            pnlSubMenuCalificaciones.Controls.Add(btnIngresoNotas);
            pnlSubMenuCalificaciones.Location = new Point(0, 0);
            pnlSubMenuCalificaciones.Name = "pnlSubMenuCalificaciones";
            pnlSubMenuCalificaciones.Size = new Size(200, 40);
            pnlSubMenuCalificaciones.TabIndex = 2;
            pnlSubMenuCalificaciones.Visible = false;
            // 
            // btnIngresoNotas
            // 
            btnIngresoNotas.Dock = DockStyle.Top;
            btnIngresoNotas.FlatAppearance.BorderSize = 0;
            btnIngresoNotas.FlatStyle = FlatStyle.Flat;
            btnIngresoNotas.ForeColor = Color.Silver;
            btnIngresoNotas.IconChar = FontAwesome.Sharp.IconChar.None;
            btnIngresoNotas.IconColor = Color.Black;
            btnIngresoNotas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnIngresoNotas.Location = new Point(0, 0);
            btnIngresoNotas.Name = "btnIngresoNotas";
            btnIngresoNotas.Size = new Size(200, 40);
            btnIngresoNotas.TabIndex = 0;
            btnIngresoNotas.Text = " Ingreso de Notas";
            btnIngresoNotas.TextAlign = ContentAlignment.MiddleLeft;
            btnIngresoNotas.Click += btnIngresoNotas_Click;
            // 
            // pnlSubMenuSimulacion
            // 
            pnlSubMenuSimulacion.BackColor = Color.FromArgb(65, 85, 105);
            pnlSubMenuSimulacion.Controls.Add(this.btnDashRendimiento);
            pnlSubMenuSimulacion.Controls.Add(this.btnSimMontecarlo); // <- NUEVO BOTÓN
            pnlSubMenuSimulacion.Controls.Add(this.btnSimPromedios);
            pnlSubMenuSimulacion.Location = new Point(0, 0);
            pnlSubMenuSimulacion.Name = "pnlSubMenuSimulacion";
            pnlSubMenuSimulacion.Size = new Size(220, 120); // <- TAMAÑO AMPLIADO
            pnlSubMenuSimulacion.TabIndex = 1;
            pnlSubMenuSimulacion.Visible = false;
            // 
            // btnDashRendimiento
            // 
            btnDashRendimiento.Dock = DockStyle.Top;
            btnDashRendimiento.FlatAppearance.BorderSize = 0;
            btnDashRendimiento.FlatStyle = FlatStyle.Flat;
            btnDashRendimiento.ForeColor = Color.Silver;
            btnDashRendimiento.IconChar = FontAwesome.Sharp.IconChar.None;
            btnDashRendimiento.IconColor = Color.Black;
            btnDashRendimiento.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDashRendimiento.Location = new Point(0, 80);
            btnDashRendimiento.Name = "btnDashRendimiento";
            btnDashRendimiento.Size = new Size(220, 40);
            btnDashRendimiento.TabIndex = 0;
            btnDashRendimiento.Text = " Dashboard Predicción";
            btnDashRendimiento.TextAlign = ContentAlignment.MiddleLeft;
            btnDashRendimiento.Click += btnDashRendimiento_Click;
            //
            // btnSimMontecarlo
            //
            btnSimMontecarlo.Dock = DockStyle.Top;
            btnSimMontecarlo.FlatAppearance.BorderSize = 0;
            btnSimMontecarlo.FlatStyle = FlatStyle.Flat;
            btnSimMontecarlo.ForeColor = Color.Silver;
            btnSimMontecarlo.IconChar = FontAwesome.Sharp.IconChar.None;
            btnSimMontecarlo.IconColor = Color.Black;
            btnSimMontecarlo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSimMontecarlo.Location = new Point(0, 40);
            btnSimMontecarlo.Name = "btnSimMontecarlo";
            btnSimMontecarlo.Size = new Size(220, 40);
            btnSimMontecarlo.TabIndex = 2;
            btnSimMontecarlo.Text = " Simulación Montecarlo";
            btnSimMontecarlo.TextAlign = ContentAlignment.MiddleLeft;
            btnSimMontecarlo.Click += new System.EventHandler(this.btnSimMontecarlo_Click);
            // 
            // btnSimPromedios
            // 
            btnSimPromedios.Dock = DockStyle.Top;
            btnSimPromedios.FlatAppearance.BorderSize = 0;
            btnSimPromedios.FlatStyle = FlatStyle.Flat;
            btnSimPromedios.ForeColor = Color.Silver;
            btnSimPromedios.IconChar = FontAwesome.Sharp.IconChar.None;
            btnSimPromedios.IconColor = Color.Black;
            btnSimPromedios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSimPromedios.Location = new Point(0, 0);
            btnSimPromedios.Name = "btnSimPromedios";
            btnSimPromedios.Size = new Size(220, 40);
            btnSimPromedios.TabIndex = 1;
            btnSimPromedios.Text = " Simulador de Notas";
            btnSimPromedios.TextAlign = ContentAlignment.MiddleLeft;
            btnSimPromedios.Click += btnSimPromedios_Click;
            // 
            // pnlSubMenuReportes
            // 
            pnlSubMenuReportes.BackColor = Color.FromArgb(65, 85, 105);
            pnlSubMenuReportes.Controls.Add(btnRptAcademico);
            pnlSubMenuReportes.Location = new Point(0, 0);
            pnlSubMenuReportes.Name = "pnlSubMenuReportes";
            pnlSubMenuReportes.Size = new Size(200, 40);
            pnlSubMenuReportes.TabIndex = 0;
            pnlSubMenuReportes.Visible = false;
            // 
            // btnRptAcademico
            // 
            btnRptAcademico.Dock = DockStyle.Top;
            btnRptAcademico.FlatAppearance.BorderSize = 0;
            btnRptAcademico.FlatStyle = FlatStyle.Flat;
            btnRptAcademico.ForeColor = Color.Silver;
            btnRptAcademico.IconChar = FontAwesome.Sharp.IconChar.None;
            btnRptAcademico.IconColor = Color.Black;
            btnRptAcademico.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRptAcademico.Location = new Point(0, 0);
            btnRptAcademico.Name = "btnRptAcademico";
            btnRptAcademico.Size = new Size(200, 40);
            btnRptAcademico.TabIndex = 0;
            btnRptAcademico.Text = " Exportar PDFs";
            btnRptAcademico.TextAlign = ContentAlignment.MiddleLeft;
            btnRptAcademico.Click += btnRptAcademico_Click;
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
            Font = new Font("Segoe UI", 14F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frm_Principal";
            StartPosition = FormStartPosition.CenterScreen;
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
        private FontAwesome.Sharp.IconButton btnAuditoriaDetallada;
        private FontAwesome.Sharp.IconButton btnAsignaturas;
        private FontAwesome.Sharp.IconButton btnPeriodos;
        private FontAwesome.Sharp.IconButton btnMatriculas;
        private FontAwesome.Sharp.IconButton btnAsigDocentes;
        private FontAwesome.Sharp.IconButton btnIngresoNotas;
        private FontAwesome.Sharp.IconButton btnSimPromedios;
        private FontAwesome.Sharp.IconButton btnSimMontecarlo;
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