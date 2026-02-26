
using Academico;

namespace DataBase_First.Views.Main
{
    public partial class frm_Principal : Form
    {
        public frm_Principal()
        {
            InitializeComponent();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            frm_Usuarios frm_usuarios = new frm_Usuarios();
            frm_usuarios.Show();
            */
        }

        private void frm_Principal_Load(object sender, EventArgs e)
        {
            if (Program.logueado != true) this.Close();

            lbl_Nombre.Text = Program.nombreUsuario;
            lbl_Rol.Text = Program.rol;
            lbl_DescripcionRol.Text = Program.descripcionRol;

            timer1.Start();

            AplicarPermisosPorRol();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_Reloj.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void AplicarPermisosPorRol()
        {
            // ADMINISTRADOR (acceso total)
            if (Program.rolId == 1)
            {
                // No hacemos nada, todo queda habilitado
                return;
            }

            // Primero deshabilitamos todo
            usuariosToolStripMenuItem.Enabled = false;
            estudiantesToolStripMenuItem.Enabled = false;
            materiasToolStripMenuItem.Enabled = false;
            periodosAcadémicosToolStripMenuItem.Enabled = false;
            cursosToolStripMenuItem.Enabled = false;
            inscripcionesToolStripMenuItem.Enabled = false;
            calificacionesToolStripMenuItem.Enabled = false;
            automatizaciónToolStripMenuItem.Enabled = false;

            // ROLES ESPECÍFICOS
            switch (Program.rolId)
            {
                case 2: // DOCENTE
                    calificacionesToolStripMenuItem.Enabled = true;
                    materiasToolStripMenuItem.Enabled = true;
                    cursosToolStripMenuItem.Enabled = true;
                    break;

                case 3: // COORDINADOR
                    estudiantesToolStripMenuItem.Enabled = true;
                    materiasToolStripMenuItem.Enabled = true;
                    periodosAcadémicosToolStripMenuItem.Enabled = true;
                    cursosToolStripMenuItem.Enabled = true;
                    automatizaciónToolStripMenuItem.Enabled = true;
                    break;

                case 4: // SECRETARÍA / ASISTENTE
                    estudiantesToolStripMenuItem.Enabled = true;
                    inscripcionesToolStripMenuItem.Enabled = true;
                    periodosAcadémicosToolStripMenuItem.Enabled = true;
                    cursosToolStripMenuItem.Enabled = true;
                    break;

                default:
                    MessageBox.Show("Rol no reconocido. Contacte al administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
    }
}
