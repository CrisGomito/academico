namespace _02_CRUD.Vistas
{
    using System;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using Academico;
    using Academico.Controladores;
    using DataBase_First.Views.Main;

    public partial class frm_login : Form
    {
        private readonly AuthController _authController = new AuthController();
        private int idUsuarioTemporal = 0;
        private string nombreUsuarioTemporal = "";

        public frm_login()
        {
            InitializeComponent();
        }

        private void btn_Ingresar2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Correo.Text) || string.IsNullOrWhiteSpace(txt_Contrasenia.Text))
            {
                MessageBox.Show("Por favor, ingrese el correo y la contraseña.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btn_Ingresar2.Enabled = false;
            btn_Ingresar2.Text = "Validando...";

            var resultado = _authController.LoginPaso1(txt_Correo.Text.Trim(), txt_Contrasenia.Text);

            if (resultado.exito)
            {
                this.idUsuarioTemporal = resultado.idUsuario;
                this.nombreUsuarioTemporal = resultado.nombre;
                MessageBox.Show(resultado.mensaje, "Código Enviado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                pnlLogin.Visible = false;
                pnl2FA.Visible = true;
                txt_Codigo2FA.Focus();
            }
            else
            {
                MessageBox.Show(resultado.mensaje, "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btn_Ingresar2.Enabled = true;
                btn_Ingresar2.Text = "Ingresar al Sistema";
            }
        }

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
                Program.logueado = true;
                Program.usuarioActualId = this.idUsuarioTemporal;
                Program.nombreUsuario = this.nombreUsuarioTemporal;
                Program.rol = resultado.nombreRol;
                Program.rolId = resultado.idRol;

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

        // EVENTO DEL LINK LABEL (Olvidé mi contraseña)
        private void lblOlvidoPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string correoInput = txt_Correo.Text.Trim();

            if (string.IsNullOrWhiteSpace(correoInput))
            {
                MessageBox.Show("Para restablecer su contraseña, primero ingrese su Correo Electrónico en la caja de texto y luego haga clic aquí.", "Información Requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_Correo.Focus();
                return;
            }

            var confirm = MessageBox.Show($"¿Desea enviar una nueva contraseña temporal al correo: {correoInput}?", "Confirmar Recuperación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                lblOlvidoPass.Text = "Procesando...";
                lblOlvidoPass.Enabled = false;

                var resultado = _authController.RecuperarContrasenia(correoInput);

                if (resultado.exito)
                {
                    MessageBox.Show(resultado.mensaje, "Correo Enviado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(resultado.mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                lblOlvidoPass.Text = "¿Olvidó su contraseña?";
                lblOlvidoPass.Enabled = true;
            }
        }

        private void txt_Correo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Correo.Text)) return;

            bool ok = Regex.IsMatch(txt_Correo.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);

            if (!ok)
            {
                txt_Correo.Text = "";
                txt_Correo.Focus();
                MessageBox.Show("El correo no tiene el formato correcto", "Formato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}