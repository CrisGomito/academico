namespace _02_CRUD.Vistas
{
    using System;
    using System.Runtime.InteropServices; // AÑADIDO PARA LA LIBRERÍA USER32
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

            // Suscribimos el Label "BIENVENIDO" también para que el usuario pueda arrastrar desde ahí
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTopBar_MouseDown);
        }

        // --- MANEJO DE VENTANA (ARRASTRAR SIN BORDES) ---
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pnlTopBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // --- MANEJO VISUAL DE PANELES ---
        private void MostrarPanel(Panel panelAMostrar)
        {
            pnlLogin.Visible = false;
            pnl2FA.Visible = false;
            pnlRecuperar.Visible = false;

            panelAMostrar.Visible = true;
        }

        // --- BOTÓN CIRCULAR CERRAR ---
        private void btnCerrarForm_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath botonCircular = new System.Drawing.Drawing2D.GraphicsPath();
            botonCircular.AddEllipse(0, 0, btnCerrarForm.Width, btnCerrarForm.Height);
            btnCerrarForm.Region = new System.Drawing.Region(botonCircular);
        }

        private void btnCerrarForm_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // --- PASO 1: LOGIN ---
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

                MostrarPanel(pnl2FA);
                txt_Codigo2FA.Focus();
            }
            else
            {
                MessageBox.Show(resultado.mensaje, "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btn_Ingresar2.Enabled = true;
                btn_Ingresar2.Text = "Ingresar al Sistema";
            }
        }

        // --- PASO 2: 2FA ---
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

        // --- RECUPERACIÓN DE CONTRASEÑA ---
        private void lblOlvidoPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MostrarPanel(pnlRecuperar);
            txtCorreoRecuperacion.Text = txt_Correo.Text;
            txtCorreoRecuperacion.Focus();
        }

        private void btnEnviarRecuperacion_Click(object sender, EventArgs e)
        {
            string correoInput = txtCorreoRecuperacion.Text.Trim();

            if (string.IsNullOrWhiteSpace(correoInput))
            {
                MessageBox.Show("Por favor, ingrese su correo electrónico.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(correoInput, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                MessageBox.Show("El correo no tiene un formato válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string dominio = correoInput.Split('@')[1].ToLower();
            if ((dominio.StartsWith("gmail.") && dominio != "gmail.com") ||
                (dominio.StartsWith("hotmail.") && dominio != "hotmail.com" && dominio != "hotmail.es") ||
                (dominio.StartsWith("outlook.") && dominio != "outlook.com" && dominio != "outlook.es") ||
                (dominio.StartsWith("yahoo.") && dominio != "yahoo.com" && dominio != "yahoo.es"))
            {
                MessageBox.Show("El dominio del correo ingresado parece ser incorrecto (Ej: omitió el '.com').\nPor favor, revise y corrija.", "Posible error tipográfico", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"¿Desea enviar una nueva contraseña temporal al correo:\n{correoInput}?", "Confirmar Recuperación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                btnEnviarRecuperacion.Text = "Procesando...";
                btnEnviarRecuperacion.Enabled = false;

                var resultado = _authController.RecuperarContrasenia(correoInput);

                if (resultado.exito)
                {
                    MessageBox.Show(resultado.mensaje, "Correo Enviado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarPanel(pnlLogin);
                    txt_Contrasenia.Clear();
                    txt_Contrasenia.Focus();
                }
                else
                {
                    MessageBox.Show(resultado.mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                btnEnviarRecuperacion.Text = "Recuperar Contraseña";
                btnEnviarRecuperacion.Enabled = true;
            }
        }

        // --- ENLACES PARA VOLVER AL LOGIN NORMAL ---
        private void lblVolverLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MostrarPanel(pnlLogin);
        }

        private void lblVolverLoginDe2FA_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MostrarPanel(pnlLogin);
            btn_Ingresar2.Enabled = true;
            btn_Ingresar2.Text = "Ingresar al Sistema";
            txt_Contrasenia.Clear();
        }

        private void txt_Correo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Correo.Text)) return;

            bool ok = Regex.IsMatch(txt_Correo.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

            if (!ok)
            {
                txt_Correo.Text = "";
                txt_Correo.Focus();
                MessageBox.Show("El correo no tiene el formato correcto", "Formato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}