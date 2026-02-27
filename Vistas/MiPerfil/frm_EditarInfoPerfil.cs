namespace DataBase_First.Views.Perfil
{
    using global::Academico.Controladores;
    using System;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    public partial class frm_EditarInfoPerfil : Form
    {
        private readonly PerfilController _perfil = new PerfilController();
        private string _correoOriginal;
        private string _nombreOriginal;
        private string _apellidoOriginal;
        private bool _correoValidadoEnEsteFormulario = false;
        private bool _huboCambios = false;

        public frm_EditarInfoPerfil()
        {
            InitializeComponent();
        }

        private void frm_EditarInfoPerfil_Load(object sender, EventArgs e)
        {
            var info = _perfil.ObtenerInformacionUsuarioActual();
            if (info != null)
            {
                txtNombre.Text = info.Nombre;
                txtApellido.Text = info.Apellido;
                txtCorreo.Text = info.CorreoPlano;

                _nombreOriginal = info.Nombre;
                _apellidoOriginal = info.Apellido;
                _correoOriginal = info.CorreoPlano;
            }
        }

        private void campos_TextChanged(object sender, EventArgs e)
        {
            EvaluarCambios();
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            EvaluarCambios();

            // Si el correo cambió respecto al original, mostrar botón validar y esconder check
            if (txtCorreo.Text.Trim() != _correoOriginal)
            {
                _correoValidadoEnEsteFormulario = false;
                lblVerificado.Visible = false;
                btnValidarCorreo.Visible = true;
                txtCodigo.Visible = false;
                btnConfirmarCodigo.Visible = false;
            }
            else
            {
                btnValidarCorreo.Visible = false;
                txtCodigo.Visible = false;
                btnConfirmarCodigo.Visible = false;
                lblVerificado.Visible = false;
                _correoValidadoEnEsteFormulario = true; // El original es válido por defecto
            }
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCorreo.Text)) return;

            if (!Regex.IsMatch(txtCorreo.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("El correo no tiene el formato correcto.", "Formato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
            }
        }

        private void EvaluarCambios()
        {
            _huboCambios = (txtNombre.Text.Trim() != _nombreOriginal) ||
                           (txtApellido.Text.Trim() != _apellidoOriginal) ||
                           (txtCorreo.Text.Trim() != _correoOriginal);

            // Solo permitimos guardar si hubo cambios Y (si cambió el correo, ya lo verificó)
            btnGuardar.Enabled = _huboCambios && (txtCorreo.Text.Trim() == _correoOriginal || _correoValidadoEnEsteFormulario);
        }

        private void btnValidarCorreo_Click(object sender, EventArgs e)
        {
            btnValidarCorreo.Text = "Enviando...";
            btnValidarCorreo.Enabled = false;

            var resultado = _perfil.SolicitarCambioCorreo(txtCorreo.Text.Trim());

            if (resultado.exito)
            {
                MessageBox.Show(resultado.mensaje, "Enviado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigo.Visible = true;
                btnConfirmarCodigo.Visible = true;
                txtCodigo.Focus();
            }
            else
            {
                MessageBox.Show(resultado.mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnValidarCorreo.Text = "Validar";
                btnValidarCorreo.Enabled = true;
            }
        }

        private void btnConfirmarCodigo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text)) return;

            // Este método actualiza el correo físicamente en la BD
            var resultado = _perfil.ConfirmarCambioCorreo(txtCorreo.Text.Trim(), txtCodigo.Text.Trim());

            if (resultado.exito)
            {
                _correoValidadoEnEsteFormulario = true;
                _correoOriginal = txtCorreo.Text.Trim(); // Actualizamos el estado "original"

                btnValidarCorreo.Visible = false;
                txtCodigo.Visible = false;
                btnConfirmarCodigo.Visible = false;

                lblVerificado.Visible = true;
                txtCorreo.Enabled = false; // Bloqueamos como pediste

                EvaluarCambios(); // Rehabilitar botón Guardar
            }
            else
            {
                MessageBox.Show(resultado.mensaje, "Código Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Nombres y apellidos son obligatorios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // El correo ya se guardó en el ConfirmarCodigo_Click. Aquí solo guardamos nombres.
            if (_perfil.ActualizarNombres(txtNombre.Text.Trim(), txtApellido.Text.Trim()))
            {
                _huboCambios = false; // Limpiamos bandera
                MessageBox.Show("Información actualizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                VolverAlPerfil();
            }
            else
            {
                MessageBox.Show("Error al actualizar la información.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VolverAlPerfil()
        {
            if (this.MdiParent is DataBase_First.Views.Main.frm_Principal principal)
            {
                principal.AbrirFormularioHijo(new frm_InformacionGeneral());
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            VolverAlPerfil();
        }

        private void frm_EditarInfoPerfil_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_huboCambios && btnGuardar.Enabled)
            {
                var diag = MessageBox.Show("Tiene cambios sin guardar. ¿Está seguro que desea salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (diag == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}