namespace _02_CRUD.Vistas
{
    using System;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using Academico;
    using Academico.Controladores; // Asegúrate de tener creado AuthController aquí
    using DataBase_First.Views.Main; // Mantengo tu using original para frm_Principal

    public partial class frm_login : Form
    {
        private readonly AuthController _authController = new AuthController();
        private int idUsuarioTemporal = 0; // Guarda el ID entre el paso 1 y el paso 2

        public frm_login()
        {
            InitializeComponent();
        }

        // --- PASO 1: Validar Credenciales ---
        private void btn_Ingresar2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Correo.Text) || string.IsNullOrWhiteSpace(txt_Contrasenia.Text))
            {
                MessageBox.Show("Por favor, ingrese el correo y la contraseña.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Deshabilitar botón para evitar múltiples envíos
            btn_Ingresar2.Enabled = false;

            var resultado = _authController.LoginPaso1(txt_Correo.Text.Trim(), txt_Contrasenia.Text);

            if (resultado.exito)
            {
                this.idUsuarioTemporal = resultado.idUsuario;
                MessageBox.Show(resultado.mensaje, "Código Enviado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ocultar panel de Login y mostrar panel de 2FA
                pnlLogin.Visible = false;
                pnl2FA.Visible = true;
                txt_Codigo2FA.Focus();
            }
            else
            {
                MessageBox.Show(resultado.mensaje, "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btn_Ingresar2.Enabled = true;
            }
        }

        // --- PASO 2: Verificar Código 2FA ---
        private void btn_Verificar2FA_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Codigo2FA.Text))
            {
                MessageBox.Show("Ingrese el código enviado a su correo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = _authController.LoginPaso2(this.idUsuarioTemporal, txt_Codigo2FA.Text.Trim());

            if (resultado.exito)
            {
                // Asignación de variables globales que usabas previamente
                Program.logueado = true;
                Program.usuarioActualId = this.idUsuarioTemporal;
                Program.rol = resultado.nombreRol;
                Program.rolId = resultado.idRol;

                MessageBox.Show($"Inicio de sesión exitoso. Bienvenido ({resultado.nombreRol})", "Acceso Autorizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                frm_Principal mainForm = new frm_Principal();
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show(resultado.mensaje, "Verificación Fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Codigo2FA.Clear();
                txt_Codigo2FA.Focus();
            }
        }

        private void txt_Correo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Correo.Text)) return;

            bool ok = Regex.IsMatch(txt_Correo.Text,
                 @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                 RegexOptions.IgnoreCase);

            if (!ok)
            {
                txt_Correo.Text = "";
                txt_Correo.Focus();
                MessageBox.Show("El correo no tiene el formato correcto", "Formato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}