namespace DataBase_First.Views.Academico.Periodos
{
    using global::Academico.Controladores;
    using System;
    using System.Linq;
    using System.Windows.Forms;

    public partial class frm_Periodos : Form
    {
        private readonly PeriodosController _periodosController = new PeriodosController();
        private int idPeriodo_editar = 0;

        public frm_Periodos()
        {
            InitializeComponent();
        }

        private void frm_Periodos_Load(object sender, EventArgs e)
        {
            carga_lista();
        }

        private void carga_lista()
        {
            var listaPeriodos = _periodosController.ObtenerPeriodos();

            var dataSource = listaPeriodos.Select(p => new
            {
                IdPeriodo = p.IdPeriodo,
                DisplayInfo = $"{p.Nombre} ({p.Estado})"
            }).ToList();

            lst_Lista_Periodos.DataSource = dataSource;
            lst_Lista_Periodos.DisplayMember = "DisplayInfo";
            lst_Lista_Periodos.ValueMember = "IdPeriodo";
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            idPeriodo_editar = 0;
            LimpiarCampos(false);
            activacajas();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos(true);
            idPeriodo_editar = 0;
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            if (!verificarCampos()) return;

            // Extraemos los valores
            string nombre = txt_Nombre.Text.Trim();
            DateTime fechaInicio = dtp_FechaInicio.Value.Date;
            DateTime fechaFin = dtp_FechaFin.Value.Date;
            string estado = cmb_Estado.SelectedItem.ToString();

            var resultado = (exito: false, mensaje: "");

            if (idPeriodo_editar != 0) // EDICIÓN
            {
                resultado = _periodosController.ActualizarPeriodo(
                    idPeriodo_editar, nombre, fechaInicio, fechaFin, estado);
            }
            else // NUEVO
            {
                resultado = _periodosController.AgregarPeriodo(
                    nombre, fechaInicio, fechaFin, estado);
            }

            if (resultado.exito)
            {
                MessageBox.Show(resultado.mensaje, "Gestión Académica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos(true);
                carga_lista();
                idPeriodo_editar = 0;
            }
            else
            {
                MessageBox.Show(resultado.mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool verificarCampos()
        {
            if (string.IsNullOrWhiteSpace(txt_Nombre.Text))
            {
                MessageBox.Show("El nombre del periodo es obligatorio (Ej: Octubre - Marzo 2026).");
                return false;
            }

            // Validar la regla de negocio (La misma que el Trigger de BD)
            if (dtp_FechaFin.Value.Date <= dtp_FechaInicio.Value.Date)
            {
                MessageBox.Show("La fecha de fin debe ser estrictamente mayor que la fecha de inicio.");
                return false;
            }

            if (cmb_Estado.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un Estado para el periodo.");
                return false;
            }

            return true;
        }

        public void LimpiarCampos(bool bloquearCajas)
        {
            txt_Nombre.Text = "";
            dtp_FechaInicio.Value = DateTime.Now;
            dtp_FechaFin.Value = DateTime.Now.AddMonths(5); // Sugerir 5 meses por defecto
            cmb_Estado.SelectedIndex = -1;

            if (bloquearCajas)
            {
                btn_Nuevo.Enabled = true;
                lst_Lista_Periodos.Enabled = true;
                btn_Editar.Enabled = true;
                btn_Eliminar.Enabled = true;

                btn_Guardar.Enabled = false;
                btn_Cancelar.Enabled = false;

                txt_Nombre.Enabled = false;
                dtp_FechaInicio.Enabled = false;
                dtp_FechaFin.Enabled = false;
                cmb_Estado.Enabled = false;
            }
        }

        public void uno(int idAccion)
        {
            if (lst_Lista_Periodos.SelectedValue == null) return;

            var idPeriodo = (int)lst_Lista_Periodos.SelectedValue;
            var periodo = _periodosController.ObtenerPeriodoPorId(idPeriodo);

            if (periodo != null)
            {
                txt_Nombre.Text = periodo.Nombre;

                // Convertimos DateOnly a DateTime para asignarlo al DateTimePicker
                dtp_FechaInicio.Value = periodo.FechaInicio.ToDateTime(TimeOnly.MinValue);
                dtp_FechaFin.Value = periodo.FechaFin.ToDateTime(TimeOnly.MinValue);

                cmb_Estado.SelectedItem = periodo.Estado;

                if (idAccion == 1) // Modo Editar
                {
                    idPeriodo_editar = periodo.IdPeriodo;
                    activacajas();
                }
            }
        }

        public void activacajas()
        {
            btn_Nuevo.Enabled = false;
            lst_Lista_Periodos.Enabled = false;
            btn_Editar.Enabled = false;
            btn_Eliminar.Enabled = false;

            btn_Guardar.Enabled = true;
            btn_Cancelar.Enabled = true;

            txt_Nombre.Enabled = true;
            dtp_FechaInicio.Enabled = true;
            dtp_FechaFin.Enabled = true;
            cmb_Estado.Enabled = true;
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if (lst_Lista_Periodos.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un periodo para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            uno(1);
        }

        private void lst_Lista_Periodos_DoubleClick(object sender, EventArgs e)
        {
            uno(0);
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (lst_Lista_Periodos.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un periodo para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var idPeriodo = (int)lst_Lista_Periodos.SelectedValue;

            var confirmResult = MessageBox.Show("¿Está seguro de que desea eliminar permanentemente este periodo académico?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                var resultado = _periodosController.EliminarPeriodo(idPeriodo);

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