
namespace _02_CRUD.Vistas
{
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using Academico;
    using Academico.Controladores;
    using DataBase_First.Views.Main;
    public partial class frm_login : Form
    {
        private readonly UsuariosController _usuariosController = new UsuariosController();
        public frm_login()
        {
            InitializeComponent();
        }
        private void btn_Ingresar2_Click(object sender, EventArgs e)
        {
            /*
            var usuario = _usuariosController
                .AutenticarUsuario(txt_Correo.Text, txt_Contrasenia.Text);
            if (usuario != null)
            {
                /*
                Program.logueado = true;
                Program.usuarioActualId = usuario.UsuarioId;
                Program.rol = usuario.Rols.FirstOrDefault()?.NombreRol ?? "Sin Rol";
                Program.rolId = usuario.Rols.FirstOrDefault()?.RolId ?? 0;
                Program.nombreUsuario = usuario.NombreCompleto;
                Program.descripcionRol = usuario.Rols.FirstOrDefault()?.Descripcion ?? "Sin Descripción";

                MessageBox.Show("Inicio de sesión exitoso");
                this.Hide();
                frm_Principal mainForm = new frm_Principal();
                mainForm.ShowDialog();
                this.Close();
                
            }
            else
            {
                MessageBox.Show("Correo o contraseña incorrectos");
            }
                */
        }

        private void txt_Correo_Leave(object sender, EventArgs e)
        {
            bool ok = Regex.IsMatch(txt_Correo.Text,
                 @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                 RegexOptions.IgnoreCase);
            if (!ok)
            {
                txt_Correo.Text = "";
                txt_Correo.Focus();
                MessageBox.Show("El correo no tiene el formato correcto");
            }
        }
    }
}
