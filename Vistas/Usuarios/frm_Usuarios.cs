
namespace DataBase_First.Views.Users
{
    using Academico.Modelos;
    using Academico.Controladores;

    public partial class frm_Usuarios : Form
    {
        /*
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
        private void carga_lista()
        {
            var listaUsuarios = _usuariosController.ObtenerUsuarios();

            lst_Lista_Usuarios.DataSource = listaUsuarios;
            lst_Lista_Usuarios.DisplayMember = "NombreCompleto";
            lst_Lista_Usuarios.ValueMember = "UsuarioId";

            cmb_Rol.DataSource = _usuariosController.ObtenerRoles();
            cmb_Rol.DisplayMember = "NombreRol";
            cmb_Rol.ValueMember = "RolId";
        }
        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            activacajas();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void txt_Correo_Leave(object sender, EventArgs e)
        {
            if (_usuariosController.EmailExiste(txt_Correo.Text))
            {
                MessageBox.Show("El correo electrónico ya existe en el sistema.");
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
            if (!verificarCampos())
            {
                return;
            }

            var rolSeleccionado = _usuariosController.ObtenerRolPorId((int)cmb_Rol.SelectedValue);

            if (rolSeleccionado == null)
            {
                MessageBox.Show("El rol seleccionado no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var resultado = false;
            var nuevoUsuario = new Usuario
            {
                NombreUsuario = txt_Nombre.Text,
                Apellidos = txt_Apellido.Text,
                Email = txt_Correo.Text,
                PasswordHash = txt_Contrasenia.Text,
                EsActivo = chb_Estado.Checked,
                Rols = new List<Role> { rolSeleccionado }
            };
            if (usuarioId_editar != 0)
            {
                //editar
                nuevoUsuario.UsuarioId = usuarioId_editar;
                resultado = _usuariosController.ActualizarUsuario(nuevoUsuario);
            }
            else
            {
                //nuevo
                resultado = _usuariosController.AgregarUsuario(nuevoUsuario);
            }
            if (resultado)
            {
                MessageBox.Show("Usuario agregado con éxito.", "Gestion de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                carga_lista();
                usuarioId_editar = 0;
            }
            else
            {
                MessageBox.Show("Error al agregar el usuario. Por favor, intente nuevamente.", "Gestion de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool verificarCampos()
        {
            if (string.IsNullOrWhiteSpace(txt_Nombre.Text) ||
                string.IsNullOrWhiteSpace(txt_Apellido.Text) ||
                string.IsNullOrWhiteSpace(txt_Correo.Text) ||
                string.IsNullOrWhiteSpace(txt_Contrasenia.Text) ||
                cmb_Rol.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.");
                return false;
            }
            return true;
        }
        public void LimpiarCampos()
        {
            txt_Nombre.Text = "";
            txt_Apellido.Text = "";
            txt_Correo.Text = "";
            txt_Contrasenia.Text = "";
            chb_Estado.Checked = false;
            cmb_Rol.SelectedIndex = -1;

            btn_Nuevo.Enabled = true;
            lst_Lista_Usuarios.Enabled = true;
            btn_Editar.Enabled = true;

            btn_Guardar.Enabled = false;
            btn_Cancelar.Enabled = true;

            txt_Nombre.Enabled = false;
            txt_Apellido.Enabled = false;
            txt_Correo.Enabled = false;
            txt_Contrasenia.Enabled = false;
            chb_Estado.Enabled = false;
            cmb_Rol.Enabled = false;
        }
        public void uno(int id)
        {
            var usuarioId = (int)lst_Lista_Usuarios.SelectedValue;
            var usuario = _usuariosController.ObtenerUsuarioPorId(usuarioId);
            if (usuario != null)
            {
                txt_Nombre.Text = usuario.NombreUsuario;
                txt_Apellido.Text = usuario.Apellidos;
                txt_Correo.Text = usuario.Email;
                txt_Contrasenia.Text = usuario.PasswordHash;
                chb_Estado.Checked = usuario.EsActivo;
                if (usuario.Rols != null && usuario.Rols.Count > 0)
                {
                    cmb_Rol.SelectedValue = usuario.Rols.First().RolId;
                }
                else
                {
                    cmb_Rol.SelectedIndex = -1;
                }
                if (id == 1)
                {
                    usuarioId_editar = usuario.UsuarioId;
                    activacajas();
                }
            }
        }
        public void activacajas()
        {
            btn_Nuevo.Enabled = false;
            lst_Lista_Usuarios.Enabled = false;
            btn_Editar.Enabled = false;

            btn_Guardar.Enabled = true;
            btn_Cancelar.Enabled = true;

            txt_Nombre.Enabled = true;
            txt_Apellido.Enabled = true;
            txt_Correo.Enabled = true;
            txt_Contrasenia.Enabled = true;
            chb_Estado.Enabled = true;
            cmb_Rol.Enabled = true;

        }
        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if (lst_Lista_Usuarios.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un usuario para editar.");
                return;
            }
            uno(1);
        }

        private void lst_Lista_Usuarios_DoubleClick(object sender, EventArgs e)
        {
            uno(0);
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (lst_Lista_Usuarios.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un usuario para eliminar.");
                return;
            }
            var usuarioId = (int)lst_Lista_Usuarios.SelectedValue;
            var confirmResult = MessageBox.Show("¿Está seguro de que desea eliminar este usuario?", "Confirmar eliminación", MessageBoxButtons.YesNo);
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
                    MessageBox.Show("Error al eliminar el usuario. Por favor, intente nuevamente.", "Gestión de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        */
    }
}
