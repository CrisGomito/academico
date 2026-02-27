namespace DataBase_First.Views.Perfil
{
    using DataBase_First.Views.Main;
    using global::Academico.Controladores;
    using System;
    using System.Windows.Forms;

    public partial class frm_InformacionGeneral : Form
    {
        private readonly PerfilController _perfil = new PerfilController();

        public frm_InformacionGeneral()
        {
            InitializeComponent();
        }

        private void frm_InformacionGeneral_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            var info = _perfil.ObtenerInformacionUsuarioActual();
            if (info != null)
            {
                lblNombreCompleto.Text = $"{info.Nombre} {info.Apellido}";
                lblRol.Text = info.Roles;
                // Mostramos el correo en texto plano ya que es la vista general privada del usuario
                lblCorreo.Text = info.CorreoPlano;
            }
        }

        private void btnCambiarCorreo_Click(object sender, EventArgs e)
        {
            // Reutilizamos el método público del formulario Padre para no tener ventanas flotantes
            if (this.MdiParent is frm_Principal principal)
            {
                principal.AbrirFormularioHijo(new frm_CambiarCorreo());
            }
        }

        private void btnCambiarClave_Click(object sender, EventArgs e)
        {
            if (this.MdiParent is frm_Principal principal)
            {
                principal.AbrirFormularioHijo(new frm_CambiarClave());
            }
        }

        private void btnEditarInfo_Click(object sender, EventArgs e)
        {
            if (this.MdiParent is frm_Principal principal)
            {
                principal.AbrirFormularioHijo(new frm_EditarInfoPerfil());
            }
        }

        private void btnCerrarPerfil_Click(object sender, EventArgs e)
        {
            this.Close(); // Esto solo cerrará el formulario hijo y dejará el panel limpio
        }
    }
}