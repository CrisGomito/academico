namespace DataBase_First.Views.Perfil
{
    using global::Academico.Controladores;
    using System;
    using System.Windows.Forms;

    public partial class frm_CambiarClave : Form
    {
        private readonly PerfilController _perfil = new PerfilController();

        public frm_CambiarClave() { InitializeComponent(); }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtClaveActual.Text) || string.IsNullOrWhiteSpace(txtNuevaClave.Text))
            {
                MessageBox.Show("Complete todos los campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNuevaClave.Text.Length < 8)
            {
                MessageBox.Show("La nueva contraseña debe tener mínimo 8 caracteres.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNuevaClave.Text != txtConfirmar.Text)
            {
                MessageBox.Show("Las nuevas contraseñas no coinciden.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_perfil.VerificarClaveActual(txtClaveActual.Text))
            {
                MessageBox.Show("La contraseña actual es incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_perfil.CambiarContrasenia(txtNuevaClave.Text))
            {
                MessageBox.Show("Contraseña actualizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Hubo un error al actualizar la contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) { this.Close(); }
    }
}