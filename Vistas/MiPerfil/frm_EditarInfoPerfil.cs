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

        // ESTADOS LÓGICOS
        private bool _correoVerificado = false; // ¿Metió el código bien?
        private bool _enProcesoDeVerificacion = false; // ¿Está esperando el código?

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
            EvaluarEstadoGuardar();
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            if (_enProcesoDeVerificacion) return;

            string correoActual = txtCorreo.Text.Trim();

            if (correoActual == _correoOriginal)
            {
                RestablecerUI_Correo();
            }
            else
            {
                btnValidarCorreo.Visible = true;
                lblVerificado.Visible = false;
                _correoVerificado = false;
            }

            EvaluarEstadoGuardar();
        }

        private void EvaluarEstadoGuardar()
        {
            bool hayCambiosNombres = (txtNombre.Text.Trim() != _nombreOriginal) || (txtApellido.Text.Trim() != _apellidoOriginal);
            bool correoCambioYVerificado = (txtCorreo.Text.Trim() != _correoOriginal) && _correoVerificado;

            // Si el correo está a medio cambiar (no verificado) o en proceso, SE BLOQUEA TODO GUARDADO
            if ((txtCorreo.Text.Trim() != _correoOriginal && !_correoVerificado) || _enProcesoDeVerificacion)
            {
                btnGuardar.Enabled = false;
            }
            else
            {
                // Si cambió nombres, o cambió y verificó correo, puede guardar
                btnGuardar.Enabled = hayCambiosNombres || correoCambioYVerificado;
            }
        }

        private void btnValidarCorreo_Click(object sender, EventArgs e)
        {
            string correoNuevo = txtCorreo.Text.Trim();

            if (string.IsNullOrWhiteSpace(correoNuevo))
            {
                MessageBox.Show("El correo no puede estar vacío.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(correoNuevo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("El correo no tiene un formato válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnValidarCorreo.Text = "Enviando...";
            btnValidarCorreo.Enabled = false;

            var resultado = _perfil.SolicitarCambioCorreo(correoNuevo);

            if (resultado.exito)
            {
                MessageBox.Show(resultado.mensaje, "Código Enviado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _enProcesoDeVerificacion = true;
                txtCorreo.Enabled = false; // Se bloquea el campo como pediste
                btnValidarCorreo.Visible = false;

                txtCodigo.Visible = true;
                txtCodigo.Clear();
                btnConfirmarCodigo.Visible = true;
                btnCancelarValidacion.Visible = true; // La 'X' Roja

                txtCodigo.Focus();
                EvaluarEstadoGuardar(); // Asegura bloquear el botón guardar
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

            // SOLO VERIFICA. EL CORREO NO SE GUARDA HASTA QUE DE CLICK EN "GUARDAR"
            var resultado = _perfil.ConfirmarCodigoCorreo(txtCodigo.Text.Trim());

            if (resultado.exito)
            {
                txtCodigo.Visible = false;
                btnConfirmarCodigo.Visible = false;
                btnCancelarValidacion.Visible = false;

                lblVerificado.Visible = true; // Check verde
                _correoVerificado = true;
                _enProcesoDeVerificacion = false;
                txtCorreo.Enabled = false; // Sigue bloqueado para que no lo edite y arruine la verificación

                EvaluarEstadoGuardar(); // Habilita el Guardar
            }
            else
            {
                MessageBox.Show(resultado.mensaje, "Código Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // LA 'X' ROJA PARA CANCELAR VERIFICACIÓN
        private void btnCancelarValidacion_Click(object sender, EventArgs e)
        {
            RestablecerUI_Correo();
            EvaluarEstadoGuardar();
        }

        private void RestablecerUI_Correo()
        {
            _enProcesoDeVerificacion = false;
            _correoVerificado = false;

            txtCorreo.Text = _correoOriginal;
            txtCorreo.Enabled = true;

            txtCodigo.Visible = false;
            btnConfirmarCodigo.Visible = false;
            btnCancelarValidacion.Visible = false;
            lblVerificado.Visible = false;

            btnValidarCorreo.Visible = false;
            btnValidarCorreo.Text = "Validar";
            btnValidarCorreo.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Nombres y apellidos son obligatorios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool guardarCorreo = (txtCorreo.Text.Trim() != _correoOriginal) && _correoVerificado;

            // Llama a GuardarPerfilCompleto que ejecuta SP y Updates finales
            bool exito = _perfil.GuardarPerfilCompleto(
                txtNombre.Text.Trim(),
                txtApellido.Text.Trim(),
                txtCorreo.Text.Trim(),
                guardarCorreo
            );

            if (exito)
            {
                _nombreOriginal = txtNombre.Text;
                _apellidoOriginal = txtApellido.Text;
                _correoOriginal = txtCorreo.Text;

                btnGuardar.Enabled = false;
                _huboCambios = false;

                MessageBox.Show("Información actualizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                VolverAlPerfil();
            }
            else
            {
                MessageBox.Show("Error de base de datos al guardar la información.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.Close();
        }

        private void frm_EditarInfoPerfil_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Solo pregunta si hay cambios reales que se perderían
            bool hayCambios = (txtNombre.Text.Trim() != _nombreOriginal) || (txtApellido.Text.Trim() != _apellidoOriginal) || (txtCorreo.Text.Trim() != _correoOriginal);

            if (hayCambios)
            {
                var diag = MessageBox.Show("Tiene cambios sin guardar o verificaciones pendientes.\n¿Está seguro que desea cancelar? Sus cambios se perderán.", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (diag == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}