using Academico;
using DataBase_First.Views.Academico.AsignacionDocentes;
using DataBase_First.Views.Academico.Asignaturas;
using DataBase_First.Views.Academico.Matriculas;
using DataBase_First.Views.Academico.Periodos;
using DataBase_First.Views.Administracion.Auditoria;
using DataBase_First.Views.Administracion.Docentes;
using DataBase_First.Views.Administracion.Estudiantes;
using DataBase_First.Views.Calificaciones;
using DataBase_First.Views.Dashboard;
using DataBase_First.Views.Perfil;
using DataBase_First.Views.Simulacion;
using DataBase_First.Views.Users;
using System;
using System.Windows.Forms;
// using _02_CRUD.Vistas; // Descomenta esto cuando quieras instanciar tus otros formularios

namespace DataBase_First.Views.Main
{
    public partial class frm_Principal : Form
    {
        public frm_Principal()
        {
            InitializeComponent();
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

            timer1.Start();

            // Ocultar dinámicamente según el Rol de BD
            AplicarPermisosPorRol();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_Reloj.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AplicarPermisosPorRol()
        {
            // 1. Ocultamos los menús principales por defecto por seguridad
            administracionToolStripMenuItem.Visible = false;
            academicoToolStripMenuItem.Visible = false;
            calificacionesToolStripMenuItem.Visible = false;
            simulacionToolStripMenuItem.Visible = false;
            reportesToolStripMenuItem.Visible = false;

            // 2. Evaluamos según los roles definidos en la base de datos (Tabla `rol`)
            // 1: Administrador | 2: Docente | 3: Estudiante | 4: Coordinador
            switch (Program.rolId)
            {
                case 1: // ADMINISTRADOR
                    // Tiene acceso a casi todo, especialmente creación y auditorías
                    administracionToolStripMenuItem.Visible = true;
                    academicoToolStripMenuItem.Visible = true;
                    reportesToolStripMenuItem.Visible = true;
                    calificacionesToolStripMenuItem.Visible = true;
                    simulacionToolStripMenuItem.Visible = true;
                    break;

                case 4: // COORDINADOR
                    // Gestiona la parte académica y monitorea el rendimiento (Predicción)
                    academicoToolStripMenuItem.Visible = true;
                    simulacionToolStripMenuItem.Visible = true;
                    simuladorNotasToolStripMenuItem.Visible = false; // El simulador es del estudiante
                    dashboardPrediccionToolStripMenuItem.Visible = true;
                    reportesToolStripMenuItem.Visible = true;
                    break;

                case 2: // DOCENTE
                    // Sube notas y revisa a sus estudiantes
                    calificacionesToolStripMenuItem.Visible = true;
                    simulacionToolStripMenuItem.Visible = true;
                    simuladorNotasToolStripMenuItem.Visible = false; // El simulador es del estudiante
                    dashboardPrediccionToolStripMenuItem.Visible = true;
                    reportesToolStripMenuItem.Visible = true;
                    break;

                case 3: // ESTUDIANTE
                    // Interactúa con su nota actual y simula su estado académico
                    simulacionToolStripMenuItem.Visible = true;
                    simuladorNotasToolStripMenuItem.Visible = true;
                    dashboardPrediccionToolStripMenuItem.Visible = false; // Predicción grupal no
                    reportesToolStripMenuItem.Visible = true;
                    break;

                default:
                    MessageBox.Show("El rol asignado no cuenta con permisos estructurados en el sistema.", "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        // --- MÉTODO PARA ABRIR FORMULARIOS HIJOS (MDI) ---
        // Úsalo en los eventos Click de tus menús para que no se abran ventanas sueltas.
        private void AbrirFormularioHijo(Form formularioHijo)
        {
            // Cerramos cualquier otro formulario hijo abierto para no amontonar
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }

            formularioHijo.MdiParent = this;
            formularioHijo.Dock = DockStyle.Fill; // Para que ocupe todo el espacio disponible
            formularioHijo.Show();
        }

        // EJEMPLOS DE USO CUANDO VAYAS CREANDO TUS FORMULARIOS:
        private void usuariosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frm_Usuarios());
        }

        private void docentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frm_Docentes());
        }

        private void estudiantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frm_Estudiantes());
        }

        private void auditoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frm_Auditoria());
        }

        private void asignaturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frm_Asignaturas());
        }

        private void periodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frm_Periodos());
        }

        private void matriculasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frm_Matriculas());
        }

        private void asignacionDocentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frm_AsignacionDocentes());
        }

        private void ingresoNotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frm_IngresoNotas());
        }

        private void simuladorNotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frm_SimuladorNotas());
        }

        private void dashboardPrediccionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frm_DashboardPrediccion());
        }

        private void reporteAcademicoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void actualizarCorreoElectrónicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frm_CambiarCorreo());
        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frm_CambiarClave());
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}