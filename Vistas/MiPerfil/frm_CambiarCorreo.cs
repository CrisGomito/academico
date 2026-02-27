namespace DataBase_First.Views.Perfil
{
    using global::Academico.Controladores;
    using System;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    public partial class frm_CambiarCorreo : Form
    {
        private readonly PerfilController _perfil = new PerfilController();
        private string _correoActualUsuario = "";

        public frm_CambiarCorreo() { InitializeComponent(); }

        private void frm_CambiarCorreo_Load(object sender, EventArgs e)
        {
            var infoUsuario = _perfil.ObtenerInformacionUsuarioActual();
            if (infoUsuario != null)
            {
                _correoActualUsuario = infoUsuario.CorreoPlano;
                // CAMBIO: Mostramos el correo en plano, sin censurar.
                lblCorreoActual.Text = $"Correo vinculado actual: {_correoActualUsuario}";
            }
        }

        private void btnEnviarCodigo_Click(object sender, EventArgs e)
        {
            string correo = txtNuevoCorreo.Text.Trim();

            // 1. Validar que no esté vacío
            if (string.IsNullOrWhiteSpace(correo))
            {
                MessageBox.Show("El campo de correo no puede estar vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validar formato estándar general
            if (!Regex.IsMatch(correo, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                MessageBox.Show("Ingrese un correo electrónico con formato válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. VALIDACIÓN ESTRICTA DE DOMINIOS CONOCIDOS (La solución a .comh y .ed)
            string dominio = correo.Split('@')[1].ToLower();

            if (dominio.StartsWith("gmail.") && dominio != "gmail.com")
            {
                MessageBox.Show("El dominio de Gmail debe ser exactamente '@gmail.com'.\nRevise que no haya letras extra o faltantes.", "Dominio Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dominio.StartsWith("hotmail.") && dominio != "hotmail.com" && dominio != "hotmail.es")
            {
                MessageBox.Show("El dominio de Hotmail debe ser '@hotmail.com' o '@hotmail.es'.\nRevise su escritura.", "Dominio Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dominio.StartsWith("outlook.") && dominio != "outlook.com" && dominio != "outlook.es")
            {
                MessageBox.Show("El dominio de Outlook debe ser '@outlook.com' o '@outlook.es'.\nRevise su escritura.", "Dominio Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dominio.StartsWith("yahoo.") && dominio != "yahoo.com" && dominio != "yahoo.es")
            {
                MessageBox.Show("El dominio de Yahoo debe ser '@yahoo.com' o '@yahoo.es'.\nRevise su escritura.", "Dominio Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Validar que no sea el mismo correo que ya tiene
            if (correo.Equals(_correoActualUsuario, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("El correo ingresado es idéntico a su correo actual. Por favor, ingrese uno nuevo.", "Sin Cambios", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void VolverAlPerfil()
        {
            if (this.MdiParent is DataBase_First.Views.Main.frm_Principal principal)
            {
                principal.AbrirFormularioHijo(new frm_InformacionGeneral());
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text)) return;

            // Fíjate que aquí usamos el método de GuardarPerfilCompleto para que se audite y guarde todo
            // Enviamos nombres vacíos (el método no los usa si no los cambias desde la pantalla principal, 
            // pero para esta pantalla en específico, el GuardarPerfilCompleto asume que siempre guardas nombres.
            // Para no dañar el otro formulario, usaremos un truco: leer los nombres actuales y enviarlos intactos).
            var infoUsuario = _perfil.ObtenerInformacionUsuarioActual();
            if (infoUsuario == null) return;

            // OJO: Usamos GuardarPerfilCompleto en lugar del viejo ConfirmarCambioCorreo
            var resultado = _perfil.ConfirmarCodigoCorreo(txtCodigo.Text.Trim());

            if (resultado.exito)
            {
                // Si el código es correcto, procedemos a guardar (no cambian los nombres, solo el correo)
                bool guardado = _perfil.GuardarPerfilCompleto(infoUsuario.Nombre, infoUsuario.Apellido, txtNuevoCorreo.Text.Trim(), true);

                if (guardado)
                {
                    MessageBox.Show("Correo electrónico actualizado con éxito.\nDeberá usar este nuevo correo la próxima vez que inicie sesión.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    VolverAlPerfil();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al guardar en la Base de Datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(resultado.mensaje, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) { VolverAlPerfil(); }
    }
}