namespace DataBase_First.Views.Administracion.Docentes
{
    using global::Academico.Controladores;
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using FontAwesome.Sharp;

    public partial class frm_Docentes : Form
    {
        private readonly DocentesController _docentesController = new DocentesController();
        private int idDocente_editar = 0;
        private string cedula_actual = "";

        public frm_Docentes()
        {
            InitializeComponent();
        }

        private void frm_Docentes_Load(object sender, EventArgs e)
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
            var listaDocentes = _docentesController.ObtenerDocentes();

            var dataSource = listaDocentes.Select(d => new
            {
                IdDocente = d.IdDocente,
                DisplayInfo = $"{d.Nombre} {d.Apellido} - C.I: {d.CedulaPlana}"
            }).ToList();

            lst_Lista_Docentes.DataSource = dataSource;
            lst_Lista_Docentes.DisplayMember = "DisplayInfo";
            lst_Lista_Docentes.ValueMember = "IdDocente";

            CargarUsuariosDisponibles();
        }

        private void CargarUsuariosDisponibles()
        {
            var usuariosParaDocente = _docentesController.ObtenerUsuariosParaNuevosDocentes();

            var sourceUsuarios = usuariosParaDocente.Select(u => new
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
            idDocente_editar = 0;
            cedula_actual = "";
            CargarUsuariosDisponibles();
            LimpiarCampos(false);
            activacajas(true);
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos(true);
            idDocente_editar = 0;
            cedula_actual = "";
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

            if (idDocente_editar != 0) // EDICIÓN
            {
                resultado = _docentesController.ActualizarDocente(
                    idDocente_editar,
                    txt_Cedula.Text.Trim(),
                    chb_Estado.Checked
                );
            }
            else // NUEVO
            {
                int idUsuarioSeleccionado = (int)cmb_Usuario.SelectedValue;
                resultado = _docentesController.AgregarDocente(
                    idUsuarioSeleccionado,
                    txt_Cedula.Text.Trim()
                );
            }

            if (resultado)
            {
                MessageBox.Show(idDocente_editar == 0 ? "Docente registrado con éxito." : "Docente actualizado con éxito.",
                                "Gestión de Docentes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos(true);
                carga_lista();
                idDocente_editar = 0;
            }
            else
            {
                MessageBox.Show("Error al guardar el docente en la Base de Datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool verificarCampos()
        {
            if (idDocente_editar == 0 && cmb_Usuario.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un Usuario base para registrarlo como docente.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_Cedula.Text) || txt_Cedula.Text.Length < 10)
            {
                MessageBox.Show("La cédula debe contener 10 dígitos numéricos.");
                return false;
            }

            return true;
        }

        public void LimpiarCampos(bool bloquearCajas)
        {
            cmb_Usuario.SelectedIndex = -1;
            txt_Cedula.Text = "";
            chb_Estado.Checked = false;

            if (bloquearCajas)
            {
                btn_Nuevo.Enabled = true;
                lst_Lista_Docentes.Enabled = true;
                btn_Editar.Enabled = true;
                btn_Eliminar.Enabled = true;

                btn_Guardar.Enabled = false;
                btn_Cancelar.Enabled = false;

                cmb_Usuario.Enabled = false;
                txt_Cedula.Enabled = false;
                chb_Estado.Enabled = false;
            }
        }

        public void uno(int idAccion)
        {
            if (lst_Lista_Docentes.SelectedValue == null) return;

            var idDocente = (int)lst_Lista_Docentes.SelectedValue;
            var docente = _docentesController.ObtenerDocentePorId(idDocente);

            if (docente != null)
            {
                cmb_Usuario.DataSource = new[] { new { Nombre = $"{docente.Nombre} {docente.Apellido}" } };
                cmb_Usuario.DisplayMember = "Nombre";
                cmb_Usuario.SelectedIndex = 0;

                txt_Cedula.Text = docente.CedulaPlana;
                cedula_actual = docente.CedulaPlana;
                chb_Estado.Checked = docente.Estado ?? false;

                if (idAccion == 1) // Modo Editar
                {
                    idDocente_editar = docente.IdDocente;
                    activacajas(false); // false = esEdicion
                }
            }
        }

        public void activacajas(bool esNuevo)
        {
            btn_Nuevo.Enabled = false;
            lst_Lista_Docentes.Enabled = false;
            btn_Editar.Enabled = false;
            btn_Eliminar.Enabled = false;

            btn_Guardar.Enabled = true;
            btn_Cancelar.Enabled = true;

            txt_Cedula.Enabled = true;
            chb_Estado.Enabled = true;

            cmb_Usuario.Enabled = esNuevo;
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if (lst_Lista_Docentes.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un docente para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            uno(1);
        }

        private void lst_Lista_Docentes_DoubleClick(object sender, EventArgs e)
        {
            uno(0);
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (lst_Lista_Docentes.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un docente para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var idDocente = (int)lst_Lista_Docentes.SelectedValue;
            uno(0);

            var confirmResult = MessageBox.Show("¿Está seguro de que desea deshabilitar a este docente?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                var resultado = _docentesController.EliminarDocente(idDocente, cedula_actual);
                if (resultado)
                {
                    MessageBox.Show("Docente deshabilitado con éxito.", "Gestión de Docentes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    carga_lista();
                }
                else
                {
                    MessageBox.Show("Error al deshabilitar al docente.", "Gestión de Docentes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}