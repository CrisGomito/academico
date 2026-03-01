namespace DataBase_First.Views.Perfil
{
    using Academico; // Para acceder a Program.rolId
    using DataBase_First.Views.Main;
    using FontAwesome.Sharp; // NUEVO: Para usar los iconos en código
    using global::Academico;
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

                // --- MAGIA: ÍCONO DINÁMICO SEGÚN EL ROL ---
                Color colorIcono = Color.FromArgb(52, 152, 219); // Azul institucional
                int tamañoIcono = 120; // Tamaño en píxeles

                if (Program.rolId == 3) // Estudiante
                {
                    picAvatar.Image = IconChar.UserGraduate.ToBitmap(colorIcono, tamañoIcono);
                }
                else if (Program.rolId == 2) // Docente
                {
                    picAvatar.Image = IconChar.ChalkboardTeacher.ToBitmap(colorIcono, tamañoIcono);
                }
                else // Admin y Coordinador
                {
                    picAvatar.Image = IconChar.UserTie.ToBitmap(colorIcono, tamañoIcono);
                }

                // Centramos la imagen en el PictureBox
                picAvatar.SizeMode = PictureBoxSizeMode.CenterImage;
            }
        }

        private void btnCambiarCorreo_Click(object sender, EventArgs e)
        {
            var principal = Application.OpenForms.OfType<DataBase_First.Views.Main.frm_Principal>().FirstOrDefault();
            if (principal != null)
            {
                principal.AbrirFormularioHijo(new frm_CambiarCorreo());
            }
        }

        private void btnCambiarClave_Click(object sender, EventArgs e)
        {
            var principal = Application.OpenForms.OfType<DataBase_First.Views.Main.frm_Principal>().FirstOrDefault();
            if (principal != null)
            {
                principal.AbrirFormularioHijo(new frm_CambiarClave());
            }
        }

        private void btnEditarInfo_Click(object sender, EventArgs e)
        {
            var principal = Application.OpenForms.OfType<DataBase_First.Views.Main.frm_Principal>().FirstOrDefault();
            if (principal != null)
            {
                principal.AbrirFormularioHijo(new frm_EditarInfoPerfil());
            }
        }

        private void btnCerrarPerfil_Click(object sender, EventArgs e)
        {
            this.Close(); // Esto solo cerrará el formulario hijo y dejará el panel limpio
        }
        private void BtnCerrarPerfil_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath botonCircular = new System.Drawing.Drawing2D.GraphicsPath();
            botonCircular.AddEllipse(0, 0, btnCerrarPerfil.Width, btnCerrarPerfil.Height);
            btnCerrarPerfil.Region = new System.Drawing.Region(botonCircular);
        }
    }
}