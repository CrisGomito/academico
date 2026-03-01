namespace DataBase_First.Views.Academico.Asignaturas
{
    using global::Academico.Controladores;
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using FontAwesome.Sharp; // Necesario para los íconos si decides modificarlos por código

    public partial class frm_Asignaturas : Form
    {
        // Se corrigió el nombre del controlador para que coincida con el tuyo
        private readonly AsignaturasController _asignaturasController = new AsignaturasController();
        private int idAsignatura_editar = 0;

        public frm_Asignaturas()
        {
            InitializeComponent();
        }

        private void frm_Asignaturas_Load(object sender, EventArgs e)
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
            var listaAsignaturas = _asignaturasController.ObtenerAsignaturas();

            var dataSource = listaAsignaturas.Select(a => new
            {
                IdAsignatura = a.IdAsignatura,
                DisplayInfo = $"{a.Nombre} ({a.Creditos} Créditos)"
            }).ToList();

            lst_Lista_Asignaturas.DataSource = dataSource;
            lst_Lista_Asignaturas.DisplayMember = "DisplayInfo";
            lst_Lista_Asignaturas.ValueMember = "IdAsignatura";
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            idAsignatura_editar = 0;
            LimpiarCampos(false);
            activacajas();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos(true);
            idAsignatura_editar = 0;
        }

        // Restringir el textbox de créditos para que solo acepte números
        private void txt_Creditos_KeyPress(object sender, KeyPressEventArgs e)
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
            int creditos = int.Parse(txt_Creditos.Text.Trim());

            if (idAsignatura_editar != 0) // EDICIÓN
            {
                resultado = _asignaturasController.ActualizarAsignatura(
                    idAsignatura_editar,
                    txt_Nombre.Text.Trim(),
                    creditos
                );
            }
            else // NUEVO
            {
                resultado = _asignaturasController.AgregarAsignatura(
                    txt_Nombre.Text.Trim(),
                    creditos
                );
            }

            if (resultado)
            {
                MessageBox.Show(idAsignatura_editar == 0 ? "Asignatura registrada con éxito." : "Asignatura actualizada con éxito.",
                                "Gestión Académica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos(true);
                carga_lista();
                idAsignatura_editar = 0;
            }
            else
            {
                MessageBox.Show("Error al guardar la Asignatura en la Base de Datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool verificarCampos()
        {
            if (string.IsNullOrWhiteSpace(txt_Nombre.Text))
            {
                MessageBox.Show("El nombre de la asignatura es obligatorio.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_Creditos.Text) || int.Parse(txt_Creditos.Text) <= 0)
            {
                MessageBox.Show("Debe ingresar una cantidad válida de créditos (Mayor a 0).");
                return false;
            }

            return true;
        }

        public void LimpiarCampos(bool bloquearCajas)
        {
            txt_Nombre.Text = "";
            txt_Creditos.Text = "";

            if (bloquearCajas)
            {
                btn_Nuevo.Enabled = true;
                lst_Lista_Asignaturas.Enabled = true;
                btn_Editar.Enabled = true;
                btn_Eliminar.Enabled = true;

                btn_Guardar.Enabled = false;
                btn_Cancelar.Enabled = false;

                txt_Nombre.Enabled = false;
                txt_Creditos.Enabled = false;
            }
        }

        public void uno(int idAccion)
        {
            if (lst_Lista_Asignaturas.SelectedValue == null) return;

            var idAsignatura = (int)lst_Lista_Asignaturas.SelectedValue;
            var asignatura = _asignaturasController.ObtenerAsignaturaPorId(idAsignatura);

            if (asignatura != null)
            {
                txt_Nombre.Text = asignatura.Nombre;
                txt_Creditos.Text = asignatura.Creditos.ToString();

                if (idAccion == 1) // Modo Editar
                {
                    idAsignatura_editar = asignatura.IdAsignatura;
                    activacajas();
                }
            }
        }

        public void activacajas()
        {
            btn_Nuevo.Enabled = false;
            lst_Lista_Asignaturas.Enabled = false;
            btn_Editar.Enabled = false;
            btn_Eliminar.Enabled = false;

            btn_Guardar.Enabled = true;
            btn_Cancelar.Enabled = true;

            txt_Nombre.Enabled = true;
            txt_Creditos.Enabled = true;
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if (lst_Lista_Asignaturas.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione una asignatura para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            uno(1);
        }

        private void lst_Lista_Asignaturas_DoubleClick(object sender, EventArgs e)
        {
            uno(0);
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (lst_Lista_Asignaturas.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione una asignatura para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var idAsignatura = (int)lst_Lista_Asignaturas.SelectedValue;

            var confirmResult = MessageBox.Show("¿Está seguro de que desea eliminar permanentemente esta asignatura?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                // CORRECCIÓN: Manejo de la tupla (bool exito, string mensaje)
                var resultado = _asignaturasController.EliminarAsignatura(idAsignatura);

                if (resultado.exito)
                {
                    MessageBox.Show(resultado.mensaje, "Gestión Académica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    carga_lista();
                }
                else
                {
                    MessageBox.Show(resultado.mensaje, "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}