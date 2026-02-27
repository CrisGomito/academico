namespace DataBase_First.Views.Perfil
{
    using global::Academico.Controladores;
    using System;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    public partial class frm_CambiarCorreo : Form
    {
        private readonly PerfilController _perfil = new PerfilController();

        public frm_CambiarCorreo() { InitializeComponent(); }

        private void btnEnviarCodigo_Click(object sender, EventArgs e)
        {
            string correo = txtNuevoCorreo.Text.Trim();
            if (!Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Ingrese un correo válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnEnviarCodigo.Text = "Enviando...";
            btnEnviarCodigo.Enabled = false;

            var resultado = _perfil.SolicitarCambioCorreo(correo);

            if (resultado.exito)
            {
                MessageBox.Show(resultado.mensaje, "Código Enviado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNuevoCorreo.Enabled = false;
                pnlValidacion.Visible = true;
                txtCodigo.Focus();
            }
            else
            {
                MessageBox.Show(resultado.mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnEnviarCodigo.Text = "Enviar Código";
                btnEnviarCodigo.Enabled = true;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text)) return;

            var resultado = _perfil.ConfirmarCambioCorreo(txtNuevoCorreo.Text.Trim(), txtCodigo.Text.Trim());

            if (resultado.exito)
            {
                MessageBox.Show(resultado.mensaje + "\nDeberá usar este nuevo correo la próxima vez que inicie sesión.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(resultado.mensaje, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) { this.Close(); }
    }
}