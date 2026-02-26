namespace DataBase_First.Views.Administracion.Estudiantes
{
    using global::Academico.Controladores;
    using System;
    using System.Linq;
    using System.Windows.Forms;

    public partial class frm_Estudiantes : Form
    {
        private readonly EstudiantesController _estudiantesController = new EstudiantesController();
        private int idEstudiante_editar = 0;

        // Se guardan para pasarlos al SP de eliminación lógica sin perder el dato
        private string cedula_actual = "";
        private string codigo_actual = "";

        public frm_Estudiantes()
        {
            InitializeComponent();
        }

        private void frm_Estudiantes_Load(object sender, EventArgs e)
        {
            carga_lista();
        }

        private void carga_lista()
        {
            var listaEstudiantes = _estudiantesController.ObtenerEstudiantes();

            var dataSource = listaEstudiantes.Select(e => new
            {
                IdEstudiante = e.IdEstudiante,
                DisplayInfo = $"[{e.Codigo}] {e.Nombre} {e.Apellido} - C.I: {e.CedulaPlana}"
            }).ToList();

            lst_Lista_Estudiantes.DataSource = dataSource;
            lst_Lista_Estudiantes.DisplayMember = "DisplayInfo";
            lst_Lista_Estudiantes.ValueMember = "IdEstudiante";

            // Cargar usuarios disponibles para asignar (Solo en modo "Nuevo")
            CargarUsuariosDisponibles();
        }

        private void CargarUsuariosDisponibles()
        {
            var usuariosParaEstudiante = _estudiantesController.ObtenerUsuariosParaNuevosEstudiantes();

            var sourceUsuarios = usuariosParaEstudiante.Select(u => new
            {
                IdUsuario = u.IdUsuario,
                NombreCompleto = $"{u.Nombre} {u.Apellido}"
            }).ToList();

            cmb_Usuario.DataSource = sourceUsuarios;
            cmb_Usuario.DisplayMember = "NombreCompleto";
            cmb_Usuario.ValueMember = "IdUsuario";
            cmb_Usuario.SelectedIndex = -1;
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            idEstudiante_editar = 0;
            cedula_actual = "";
            codigo_actual = "";
            CargarUsuariosDisponibles(); // Refrescar combos
            LimpiarCampos(false);
            activacajas(true); // esNuevo = true
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos(true);
            idEstudiante_editar = 0;
            cedula_actual = "";
            codigo_actual = "";
        }

        private void chb_Estado_CheckedChanged(object sender, EventArgs e)
        {
            chb_Estado.Text = chb_Estado.Checked ? "Activo" : "Inactivo";
        }

        private void txt_Cedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            if (!verificarCampos()) return;

            bool resultado = false;

            if (idEstudiante_editar != 0) // EDICIÓN
            {
                resultado = _estudiantesController.ActualizarEstudiante(
                    idEstudiante_editar,
                    txt_Cedula.Text.Trim(),
                    txt_Codigo.Text.Trim(),
                    chb_Estado.Checked
                );
            }
            else // NUEVO
            {
                int idUsuarioSeleccionado = (int)cmb_Usuario.SelectedValue;
                resultado = _estudiantesController.AgregarEstudiante(
                    idUsuarioSeleccionado,
                    txt_Cedula.Text.Trim(),
                    txt_Codigo.Text.Trim()
                );
            }

            if (resultado)
            {
                MessageBox.Show(idEstudiante_editar == 0 ? "Estudiante registrado con éxito." : "Estudiante actualizado con éxito.",
                                "Gestión de Estudiantes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos(true);
                carga_lista();
                idEstudiante_editar = 0;
            }
            else
            {
                MessageBox.Show("Error al guardar el estudiante. Es probable que el código ya exista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool verificarCampos()
        {
            if (idEstudiante_editar == 0 && cmb_Usuario.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un Usuario base para registrarlo como estudiante.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_Cedula.Text) || txt_Cedula.Text.Length < 10)
            {
                MessageBox.Show("La cédula debe contener 10 dígitos numéricos.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_Codigo.Text))
            {
                MessageBox.Show("Debe ingresar un Código para el estudiante (Ej: EST-001).");
                return false;
            }

            return true;
        }

        public void LimpiarCampos(bool bloquearCajas)
        {
            cmb_Usuario.SelectedIndex = -1;
            txt_Cedula.Text = "";
            txt_Codigo.Text = "";
            chb_Estado.Checked = false;

            if (bloquearCajas)
            {
                btn_Nuevo.Enabled = true;
                lst_Lista_Estudiantes.Enabled = true;
                btn_Editar.Enabled = true;
                btn_Eliminar.Enabled = true;

                btn_Guardar.Enabled = false;
                btn_Cancelar.Enabled = false;

                cmb_Usuario.Enabled = false;
                txt_Cedula.Enabled = false;
                txt_Codigo.Enabled = false;
                chb_Estado.Enabled = false;
            }
        }

        public void uno(int idAccion)
        {
            if (lst_Lista_Estudiantes.SelectedValue == null) return;

            var idEstudiante = (int)lst_Lista_Estudiantes.SelectedValue;
            var estudiante = _estudiantesController.ObtenerEstudiantePorId(idEstudiante);

            if (estudiante != null)
            {
                // Solo mostrar en el combo el nombre del estudiante actual
                cmb_Usuario.DataSource = new[] { new { Nombre = $"{estudiante.Nombre} {estudiante.Apellido}" } };
                cmb_Usuario.DisplayMember = "Nombre";
                cmb_Usuario.SelectedIndex = 0;

                txt_Cedula.Text = estudiante.CedulaPlana;
                txt_Codigo.Text = estudiante.Codigo;

                cedula_actual = estudiante.CedulaPlana;
                codigo_actual = estudiante.Codigo;

                chb_Estado.Checked = estudiante.Estado ?? false;

                if (idAccion == 1) // Modo Editar
                {
                    idEstudiante_editar = estudiante.IdEstudiante;
                    activacajas(false); // false = esEdicion
                }
            }
        }

        public void activacajas(bool esNuevo)
        {
            btn_Nuevo.Enabled = false;
            lst_Lista_Estudiantes.Enabled = false;
            btn_Editar.Enabled = false;
            btn_Eliminar.Enabled = false;

            btn_Guardar.Enabled = true;
            btn_Cancelar.Enabled = true;

            txt_Cedula.Enabled = true;
            txt_Codigo.Enabled = true;
            chb_Estado.Enabled = true;

            // Solo se elige usuario nuevo si estamos insertando
            cmb_Usuario.Enabled = esNuevo;
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if (lst_Lista_Estudiantes.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un estudiante para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            uno(1);
        }

        private void lst_Lista_Estudiantes_DoubleClick(object sender, EventArgs e)
        {
            uno(0);
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (lst_Lista_Estudiantes.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un estudiante para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var idEstudiante = (int)lst_Lista_Estudiantes.SelectedValue;

            // Cargar datos actuales en las variables por si acaso no hizo doble click antes
            uno(0);

            var confirmResult = MessageBox.Show("¿Está seguro de que desea deshabilitar a este estudiante?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                var resultado = _estudiantesController.EliminarEstudiante(idEstudiante, cedula_actual, codigo_actual);
                if (resultado)
                {
                    MessageBox.Show("Estudiante deshabilitado con éxito.", "Gestión de Estudiantes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    carga_lista();
                }
                else
                {
                    MessageBox.Show("Error al deshabilitar al estudiante.", "Gestión de Estudiantes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}