using Academico;
using DataBase_First.Views.Perfil;
using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DataBase_First.Views.Main
{
    public partial class frm_Principal : Form
    {
        private Form currentChildForm;
        private IconButton currentBtn;
        private Panel activeSubMenu;
        private DateTime fechaInicioSesion;

        public frm_Principal()
        {
            InitializeComponent();
        }

        private void frm_Principal_Load(object sender, EventArgs e)
        {
            if (!Program.logueado)
            {
                this.Close();
                return;
            }

            lbl_Nombre.Text = Program.nombreUsuario;
            lbl_Rol.Text = Program.rol;
            fechaInicioSesion = DateTime.Now;
            timer1.Start();

            AplicarPermisosPorRol();

            // Asignación segura del background desde C# para evitar crasheos del diseñador
            try
            {
                pnlContenedorHijo.BackgroundImage = global::Academico.Properties.Resources.background_academico;
            }
            catch { /* Ignorar si no existe la imagen temporalmente */ }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime ahora = DateTime.Now;
            TimeSpan tiempo = ahora - fechaInicioSesion;

            string formatoTiempo = tiempo.TotalMinutes < 60
                ? $"{(int)tiempo.TotalMinutes} min"
                : $"{(int)tiempo.TotalHours} h {tiempo.Minutes} min";

            lbl_Reloj.Text = $"{ahora.ToString("dd/MM/yyyy HH:mm:ss")} --- {formatoTiempo}";
        }

        // --- ARRASTRAR VENTANA ---
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pnlControlWindow_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // --- BOTONES VENTANA ---
        private void btnCerrar_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath circulo = new System.Drawing.Drawing2D.GraphicsPath();
            circulo.AddEllipse(0, 0, btnCerrar.Width, btnCerrar.Height);
            btnCerrar.Region = new Region(circulo);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("¿Está seguro que desea salir del sistema?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes) Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            WindowState = WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // --- LÓGICA DE MENÚS Y DROPDOWNS (ESTILO NAVEGADOR WEB) ---
        private void OcultarSubMenus()
        {
            if (activeSubMenu != null)
            {
                activeSubMenu.Visible = false;
                activeSubMenu = null;
            }
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(52, 73, 94);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn = null;
            }
        }

        private void MostrarSubMenu(Panel subMenu, IconButton btn)
        {
            if (activeSubMenu == subMenu)
            {
                OcultarSubMenus();
                return;
            }

            OcultarSubMenus();

            // Activar botón superior
            currentBtn = btn;
            currentBtn.BackColor = Color.FromArgb(65, 85, 105);
            currentBtn.ForeColor = Color.White;
            currentBtn.IconColor = Color.White;

            // Posicionar el submenú debajo del botón dinámicamente
            subMenu.Location = new Point(btn.Location.X, pnlMenuTop.Location.Y + pnlMenuTop.Height);
            subMenu.BringToFront();
            subMenu.Visible = true;
            activeSubMenu = subMenu;
        }

        private void btnMenuPerfil_Click(object sender, EventArgs e) => MostrarSubMenu(pnlSubMenuPerfil, (IconButton)sender);
        private void btnMenuAdmin_Click(object sender, EventArgs e) => MostrarSubMenu(pnlSubMenuAdmin, (IconButton)sender);
        private void btnMenuAcademico_Click(object sender, EventArgs e) => MostrarSubMenu(pnlSubMenuAcademico, (IconButton)sender);
        private void btnMenuCalificaciones_Click(object sender, EventArgs e) => MostrarSubMenu(pnlSubMenuCalificaciones, (IconButton)sender);
        private void btnMenuSimulacion_Click(object sender, EventArgs e) => MostrarSubMenu(pnlSubMenuSimulacion, (IconButton)sender);
        private void btnMenuReportes_Click(object sender, EventArgs e) => MostrarSubMenu(pnlSubMenuReportes, (IconButton)sender);

        // --- LA MAGIA: PANEL HOSTING EN VEZ DE MDI ---
        public void AbrirFormularioHijo(Form formularioHijo)
        {
            OcultarSubMenus();

            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            currentChildForm = formularioHijo;
            // Configuración clave: Ya no es un MDI hijo, es un control incrustado en el panel.
            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;

            pnlContenedorHijo.Controls.Add(formularioHijo);
            pnlContenedorHijo.Tag = formularioHijo;

            // Ocultar imagen de fondo
            pnlContenedorHijo.BackgroundImage = null;

            // Restaurar imagen de fondo al cerrar
            formularioHijo.FormClosed += (s, args) =>
            {
                if (pnlContenedorHijo.Controls.Count == 0)
                {
                    try { pnlContenedorHijo.BackgroundImage = global::Academico.Properties.Resources.background_academico; } catch { }
                }
            };

            formularioHijo.BringToFront();
            formularioHijo.Show();
        }

        // --- EVENTOS CLICK DE SUBMENÚS (Formularios) ---
        private void btnInfoGeneral_Click(object sender, EventArgs e) => AbrirFormularioHijo(new frm_InformacionGeneral());
        private void btnUsuarios_Click(object sender, EventArgs e) => AbrirFormularioHijo(new Users.frm_Usuarios());
        private void btnDocentes_Click(object sender, EventArgs e) => AbrirFormularioHijo(new Administracion.Docentes.frm_Docentes());
        private void btnEstudiantes_Click(object sender, EventArgs e) => AbrirFormularioHijo(new Administracion.Estudiantes.frm_Estudiantes());
        private void btnAuditoria_Click(object sender, EventArgs e) => AbrirFormularioHijo(new Administracion.Auditoria.frm_Auditoria());
        private void btnAsignaturas_Click(object sender, EventArgs e) => AbrirFormularioHijo(new Academico.Asignaturas.frm_Asignaturas());
        private void btnPeriodos_Click(object sender, EventArgs e) => AbrirFormularioHijo(new Academico.Periodos.frm_Periodos());
        private void btnMatriculas_Click(object sender, EventArgs e) => AbrirFormularioHijo(new Academico.Matriculas.frm_Matriculas());
        private void btnAsigDocentes_Click(object sender, EventArgs e) => AbrirFormularioHijo(new Academico.AsignacionDocentes.frm_AsignacionDocentes());
        private void btnIngresoNotas_Click(object sender, EventArgs e) => AbrirFormularioHijo(new Calificaciones.frm_IngresoNotas());
        private void btnSimPromedios_Click(object sender, EventArgs e) => AbrirFormularioHijo(new Simulacion.frm_SimuladorNotas());
        private void btnDashRendimiento_Click(object sender, EventArgs e) => AbrirFormularioHijo(new Dashboard.frm_DashboardPrediccion());
        private void btnRptAcademico_Click(object sender, EventArgs e) => AbrirFormularioHijo(new Reportes.frm_Reportes());

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("¿Está seguro que desea cerrar sesión?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)

            {

                // Limpiamos memoria

                Program.logueado = false;

                Program.usuarioActualId = 0;

                Program.nombreUsuario = "";

                Program.rol = "";

                Program.rolId = 0;



                // Reiniciamos la aplicación completa. Esto destruye el MDI y levanta el Login limpio.

                Application.Restart();

            }
        }


        private void AplicarPermisosPorRol()
        {
            btnMenuAdmin.Visible = false;
            btnMenuAcademico.Visible = false;
            btnMenuCalificaciones.Visible = false;
            btnMenuSimulacion.Visible = false;
            btnMenuReportes.Visible = false;

            switch (Program.rolId)
            {
                case 1: // ADMIN
                    btnMenuAdmin.Visible = true;
                    btnMenuAcademico.Visible = true;
                    btnMenuCalificaciones.Visible = true;
                    btnMenuSimulacion.Visible = true;
                    btnMenuReportes.Visible = true;
                    break;
                case 4: // COORDINADOR
                    btnMenuAcademico.Visible = true;
                    btnMenuSimulacion.Visible = true;
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
            }
        }
    }
}