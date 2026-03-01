namespace DataBase_First.Views.Users
{
    using global::Academico;
    using global::Academico.Controladores;
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using FontAwesome.Sharp;

    public partial class frm_Usuarios : Form
    {
        private readonly UsuariosController _usuariosController = new UsuariosController();
        int usuarioId_editar = 0;

        public frm_Usuarios()
        {
            InitializeComponent();
        }

        private void frm_Usuarios_Load(object sender, EventArgs e)
        {
            carga_lista();
        }

        // --- BOTÓN CIRCULAR ROJO PARA CERRAR ---
        private void btnCerrar_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath botonCircular = new System.Drawing.Drawing2D.GraphicsPath();
            botonCircular.AddEllipse(0, 0, btnCerrar.Width, btnCerrar.Height);
            btnCerrar.Region = new System.Drawing.Region(botonCircular);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // ---------------------------------------

        private void carga_lista()
        {
            var listaUsuarios = _usuariosController.ObtenerUsuarios();

            // Para que se vea "Nombre Apellido - Rol" en el ListBox
            var dataSource = listaUsuarios.Select(u => new
            {
                IdUsuario = u.IdUsuario,
                DisplayInfo = $"{u.Nombre} {u.Apellido} ({u.Roles})"
            }).ToList();

            lst_Lista_Usuarios.DataSource = dataSource;
            lst_Lista_Usuarios.DisplayMember = "DisplayInfo";
            lst_Lista_Usuarios.ValueMember = "IdUsuario";

            cmb_Rol.DataSource = _usuariosController.ObtenerRoles();
            cmb_Rol.DisplayMember = "Nombre";
            cmb_Rol.ValueMember = "IdRol";
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            usuarioId_editar = 0;
            LimpiarCampos(false);
            activacajas(true); // true = esNuevo
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos(true);
            usuarioId_editar = 0;
        }

        private void txt_Correo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Correo.Text)) return;

            bool ok = Regex.IsMatch(txt_Correo.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
            if (!ok)
            {
                MessageBox.Show("El correo no tiene el formato correcto.", "Formato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Correo.Focus();
                return;
            }

            // Validar si existe en la BD
            if (_usuariosController.EmailExiste(txt_Correo.Text))
            {
                MessageBox.Show("El correo electrónico ya existe en el sistema.", "Correo Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Correo.Text = "";
                txt_Correo.Focus();
            }
        }

        private void chb_Estado_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_Estado.Checked)
            {
                chb_Estado.Text = "Activo";
            }
            else
            {
                chb_Estado.Text = "Inactivo";
            }
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            if (!verificarCampos()) return;

            bool resultado = false;

            if (usuarioId_editar != 0) // EDICIÓN
            {
                int idRolSeleccionado = (int)cmb_Rol.SelectedValue; // Capturamos el rol

                resultado = _usuariosController.ActualizarUsuario(
                    usuarioId_editar,
                    txt_Nombre.Text.Trim(),
                    txt_Apellido.Text.Trim(),
                    chb_Estado.Checked,
                    idRolSeleccionado // Enviamos el rol
                );
            }
            else // NUEVO
            {
                // Validación de contraseña para nuevo usuario (min 8 caracteres)
                if (txt_Contrasenia.Text.Length < 8)
                {
                    MessageBox.Show("La contraseña debe tener mínimo 8 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idRol = (int)cmb_Rol.SelectedValue;
                resultado = _usuariosController.AgregarUsuario(
                    txt_Nombre.Text.Trim(),
                    txt_Apellido.Text.Trim(),
                    txt_Correo.Text.Trim(),
                    txt_Contrasenia.Text,
                    idRol
                );
            }

            if (resultado)
            {
                MessageBox.Show(usuarioId_editar == 0 ? "Usuario agregado con éxito." : "Usuario actualizado con éxito.",
                                "Gestión de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos(true);
                carga_lista();
                usuarioId_editar = 0;
            }
            else
            {
                MessageBox.Show("Error al guardar el usuario en la Base de Datos. Revise los datos.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool verificarCampos()
        {
            // Si es nuevo, todos los campos son obligatorios. Si es editar, correo y contraseña se ignoran
            if (string.IsNullOrWhiteSpace(txt_Nombre.Text) || string.IsNullOrWhiteSpace(txt_Apellido.Text))
            {
                MessageBox.Show("Por favor, complete Nombre y Apellido.");
                return false;
            }

            if (usuarioId_editar == 0) // Si es nuevo
            {
                if (string.IsNullOrWhiteSpace(txt_Correo.Text) || string.IsNullOrWhiteSpace(txt_Contrasenia.Text) || cmb_Rol.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios (Correo, Contraseña, Rol).");
                    return false;
                }
            }

            return true;
        }

        // LIMPIEZA DE CÓDIGO: Al quitar las líneas de Color, respetamos la decisión
        // de que los botones mantengan su color base (azul, verde, naranja) pero se atenúen con "Enabled = false".
        public void LimpiarCampos(bool bloquearCajas)
        {
            txt_Nombre.Text = "";
            txt_Apellido.Text = "";
            txt_Correo.Text = "";
            txt_Contrasenia.Text = "";
            chb_Estado.Checked = false;
            cmb_Rol.SelectedIndex = -1;

            if (bloquearCajas)
            {
                btn_Nuevo.Enabled = true;
                lst_Lista_Usuarios.Enabled = true;
                btn_Editar.Enabled = true;
                btn_Eliminar.Enabled = true;

                btn_Guardar.Enabled = false;
                btn_Cancelar.Enabled = false;

                txt_Nombre.Enabled = false;
                txt_Apellido.Enabled = false;
                txt_Correo.Enabled = false;
                txt_Contrasenia.Enabled = false;
                chb_Estado.Enabled = false;
                cmb_Rol.Enabled = false;
            }
        }

        public void uno(int idAccion)
        {
            if (lst_Lista_Usuarios.SelectedValue == null) return;

            var usuarioId = (int)lst_Lista_Usuarios.SelectedValue;
            var usuario = _usuariosController.ObtenerUsuarioPorId(usuarioId);

            if (usuario != null)
            {
                txt_Nombre.Text = usuario.Nombre;
                txt_Apellido.Text = usuario.Apellido;
                txt_Correo.Text = usuario.CorreoPlano;
                txt_Contrasenia.Text = "********"; // Ocultamos la real por seguridad
                chb_Estado.Checked = usuario.Estado ?? false;

                // Seleccionamos el rol (Ojo: la vista trae roles en texto "Docente", buscaremos su ID)
                var rolAsignado = _usuariosController.ObtenerRoles().FirstOrDefault(r => usuario.Roles.Contains(r.Nombre));
                if (rolAsignado != null) cmb_Rol.SelectedValue = rolAsignado.IdRol;

                if (idAccion == 1) // Modo Editar
                {
                    usuarioId_editar = usuario.IdUsuario;
                    activacajas(false); // false = esEdicion

                    // VALIDACIÓN DE SEGURIDAD (NO AUTO-EDITARSE ROL/ESTADO)
                    if (usuarioId_editar == Program.usuarioActualId)
                    {
                        cmb_Rol.Enabled = false;
                        chb_Estado.Enabled = false;
                        MessageBox.Show("Por motivos de seguridad, no puede modificar su propio nivel de acceso ni desactivar su cuenta mientras tenga la sesión iniciada.\nSolo puede actualizar sus nombres.", "Acción Protegida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        public void activacajas(bool esNuevo)
        {
            btn_Nuevo.Enabled = false;
            lst_Lista_Usuarios.Enabled = false;
            btn_Editar.Enabled = false;
            btn_Eliminar.Enabled = false;

            btn_Guardar.Enabled = true;
            btn_Cancelar.Enabled = true;

            // Nombres, Apellidos y Estado siempre se pueden editar
            txt_Nombre.Enabled = true;
            txt_Apellido.Enabled = true;
            chb_Estado.Enabled = true;
            cmb_Rol.Enabled = true;

            // Por seguridad, el SP de actualización de tu BD NO permite cambiar Correo ni Clave desde este formulario
            txt_Correo.Enabled = esNuevo;
            txt_Contrasenia.Enabled = esNuevo;
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if (lst_Lista_Usuarios.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un usuario para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            uno(1);
        }

        private void lst_Lista_Usuarios_DoubleClick(object sender, EventArgs e)
        {
            uno(0); // Solo para visualizar, no habilita edición
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (lst_Lista_Usuarios.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un usuario para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var usuarioId = (int)lst_Lista_Usuarios.SelectedValue;
            var confirmResult = MessageBox.Show("¿Está seguro de que desea deshabilitar (eliminar lógicamente) este usuario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                var resultado = _usuariosController.EliminarUsuario(usuarioId);
                if (resultado)
                {
                    MessageBox.Show("Usuario eliminado con éxito.", "Gestión de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    carga_lista();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el usuario.", "Gestión de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}