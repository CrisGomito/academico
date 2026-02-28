using Academico;
using DataBase_First.Views.Perfil;
using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices; // Necesario para mover la ventana
using System.Windows.Forms;


namespace DataBase_First.Views.Main
{
    public partial class frm_Principal : Form
    {
        // Campos para la lógica de dropdowns
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        private DateTime fechaInicioSesion;

        public frm_Principal()
        {
            InitializeComponent();

            // Inicializar borde izquierdo para selección de menú
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 50);
            pnlMenuContainer.Controls.Add(leftBorderBtn);

            // Configuraciones de ventana sin borde (MDI invisible)
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void frm_Principal_Load(object sender, EventArgs e)
        {
            // Validación de seguridad
            if (!Program.logueado)
            {
                this.Close();
                return;
            }

            // Datos visuales del Header
            lbl_Nombre.Text = Program.nombreUsuario;
            lbl_Rol.Text = Program.rol;

            // Guardamos la hora de inicio de sesión real (supongamos que está en Program)
            // Si no está, usa DateTime.Now como fallback
            fechaInicioSesion = DateTime.Now;

            timer1.Start();

            // Ocultar dinámicamente según el Rol de BD
            AplicarPermisosPorRol();

            // Asegurarnos que la imagen de fondo esté visible al inicio
            GestionarFondoMdi();
        }

        // --- LÓGICA DE RELOJ Y TIEMPO DE SESIÓN ---
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime ahora = DateTime.Now;
            TimeSpan tiempoTranscurrido = ahora - fechaInicioSesion;

            string formatoTiempo;
            if (tiempoTranscurrido.TotalMinutes < 60)
            {
                formatoTiempo = $"{(int)tiempoTranscurrido.TotalMinutes} min";
            }
            else
            {
                formatoTiempo = $"{(int)tiempoTranscurrido.TotalHours} hora(s) y {tiempoTranscurrido.Minutes} min";
            }

            lbl_Reloj.Text = $"{ahora.ToString("dd/MM/yyyy HH:mm:ss")} --- {formatoTiempo}";
        }

        // --- LÓGICA PARA MOVER LA VENTANA (DLL Imports) ---
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pnlControlWindow_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // --- BOTONES DE CONTROL DE VENTANA ---
        private void btnCerrar_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath botonCircular = new System.Drawing.Drawing2D.GraphicsPath();
            botonCircular.AddEllipse(0, 0, btnCerrar.Width, btnCerrar.Height);
            btnCerrar.Region = new System.Drawing.Region(botonCircular);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            ConfirmarCerrarSesion();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // --- LÓGICA DE MENÚS Y SUBMENÚS (DROPDOWNS) ---
        private void OcultarSubMenus()
        {
            pnlSubMenuPerfil.Visible = false;
            pnlSubMenuAdmin.Visible = false;
            pnlSubMenuAcademico.Visible = false;
            pnlSubMenuCalificaciones.Visible = false;
            pnlSubMenuSimulacion.Visible = false;
            pnlSubMenuReportes.Visible = false;
        }

        private void MostrarSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                OcultarSubMenus();
                subMenu.Visible = true;
                // Pequeña "animación" de altura (opcional, ajusta según la cantidad de items)
                // subMenu.Height = subMenu.Controls.Count * 40; 
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        // Estilo de selección de botón principal
        private void ActivarBoton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DesactivarBoton();
                // Botón
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(65, 85, 105);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                // Borde izquierdo
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
            }
        }

        private void DesactivarBoton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(52, 73, 94);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        // --- EVENTOS CLICK DE MENÚS PRINCIPALES ---
        private void btnMenuPerfil_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender, Color.FromArgb(160, 210, 255)); // Azul suave
            MostrarSubMenu(pnlSubMenuPerfil);
        }

        private void btnMenuAdmin_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender, Color.FromArgb(160, 210, 255));
            MostrarSubMenu(pnlSubMenuAdmin);
        }

        private void btnMenuAcademico_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender, Color.FromArgb(160, 210, 255));
            MostrarSubMenu(pnlSubMenuAcademico);
        }

        private void btnMenuCalificaciones_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender, Color.FromArgb(160, 210, 255));
            MostrarSubMenu(pnlSubMenuCalificaciones);
        }

        private void btnMenuSimulacion_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender, Color.FromArgb(160, 210, 255));
            MostrarSubMenu(pnlSubMenuSimulacion);
        }

        private void btnMenuReportes_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender, Color.FromArgb(160, 210, 255));
            MostrarSubMenu(pnlSubMenuReportes);
        }

        // --- LÓGICA DE FORMULARIOS HIJOS Y FONDO ---
        private void GestionarFondoMdi()
        {
            // Si hay formularios hijos visibles, ocultamos la imagen de fondo del panel contenedor
            if (this.MdiChildren.Length > 0)
            {
                pnlContenedorHijo.BackgroundImage = null;
            }
            else
            {
                // Si no hay hijos, restauramos la imagen de recursos
                pnlContenedorHijo.BackgroundImage = Properties.Resources.background_academico;
            }
        }

        public void AbrirFormularioHijo(Form formularioHijo)
        {
            // Cerramos cualquier otro formulario hijo abierto
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            currentChildForm = formularioHijo;
            formularioHijo.MdiParent = this;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;

            // Suscribirse al evento de cierre para restaurar el fondo
            formularioHijo.FormClosed += (s, args) => { GestionarFondoMdi(); };

            formularioHijo.Show();

            // Ocultamos el submenú después de seleccionar e iniciar la gestión del fondo
            OcultarSubMenus();
            GestionarFondoMdi();
        }

        // --- EVENTOS CLICK DE SUBMENÚS (ACCIONES) ---
        private void btnInfoGeneral_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frm_InformacionGeneral());
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            ConfirmarCerrarSesion();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new Users.frm_Usuarios());
        }

        private void btnDocentes_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new Administracion.Docentes.frm_Docentes());
        }

        private void btnEstudiantes_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new Administracion.Estudiantes.frm_Estudiantes());
        }

        private void btnAuditoria_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new Administracion.Auditoria.frm_Auditoria());
        }

        private void btnAsignaturas_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new Academico.Asignaturas.frm_Asignaturas());
        }

        private void btnPeriodos_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new Academico.Periodos.frm_Periodos());
        }

        private void btnMatriculas_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new Academico.Matriculas.frm_Matriculas());
        }

        private void btnAsigDocentes_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new Academico.AsignacionDocentes.frm_AsignacionDocentes());
        }

        private void btnIngresoNotas_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new Calificaciones.frm_IngresoNotas());
        }

        private void btnSimPromedios_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new Simulacion.frm_SimuladorNotas());
        }

        private void btnDashRendimiento_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new Dashboard.frm_DashboardPrediccion());
        }

        private void btnRptAcademico_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new Reportes.frm_Reportes());
        }

        private void ConfirmarCerrarSesion()
        {
            var confirm = MessageBox.Show("¿Está seguro que desea cerrar sesión o salir del sistema?", "Confirmar Salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                // Limpiamos memoria
                Program.logueado = false;
                // ... (resto de limpiezas de Program)

                // Reiniciamos la aplicación completa.
                Application.Restart();
            }
        }

        private void AplicarPermisosPorRol()
        {
            // Ocultamos los botones de menú principales por defecto
            btnMenuAdmin.Visible = false;
            btnMenuAcademico.Visible = false;
            btnMenuCalificaciones.Visible = false;
            btnMenuSimulacion.Visible = false;
            btnMenuReportes.Visible = false;

            // Evaluamos según los roles (1: Admin, 2: Docente, 3: Estudiante, 4: Coordinador)
            switch (Program.rolId)
            {
                case 1: // ADMINISTRADOR
                    btnMenuAdmin.Visible = true;
                    btnMenuAcademico.Visible = true;
                    btnMenuCalificaciones.Visible = true;
                    btnMenuSimulacion.Visible = true;
                    btnMenuReportes.Visible = true;
                    break;

                case 4: // COORDINADOR
                    btnMenuAcademico.Visible = true;
                    btnMenuSimulacion.Visible = true;
                    // Ocultar submenús específicos por código si es necesario
                    btnSimPromedios.Visible = false;
                    btnMenuReportes.Visible = true;
                    break;

                case 2: // DOCENTE
                    btnMenuCalificaciones.Visible = true;
                    btnMenuSimulacion.Visible = true;
                    btnSimPromedios.Visible = false;
                    btnMenuReportes.Visible = true;
                    break;

                case 3: // ESTUDIANTE
                    btnMenuSimulacion.Visible = true;
                    btnDashRendimiento.Visible = false;
                    btnMenuReportes.Visible = true;
                    break;

                default:
                    MessageBox.Show("El rol asignado no cuenta con permisos estructurados.", "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }
    }
}