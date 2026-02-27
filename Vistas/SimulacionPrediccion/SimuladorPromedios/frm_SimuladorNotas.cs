namespace DataBase_First.Views.Simulacion
{
    using global::Academico;
    using global::Academico.Controladores;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class frm_SimuladorNotas : Form
    {
        private readonly SimuladorController _simuladorController = new SimuladorController();
        private int _idEstudianteActual = 0;
        private List<SimuladorController.DetalleSimulacionDTO> _listaSimulacion = new List<SimuladorController.DetalleSimulacionDTO>();

        public frm_SimuladorNotas()
        {
            InitializeComponent();
        }

        private void frm_SimuladorNotas_Load(object sender, EventArgs e)
        {
            _idEstudianteActual = _simuladorController.ObtenerIdEstudianteActual();

            // MODO BYPASS ADMIN/TESTING
            if (_idEstudianteActual == 0)
            {
                if (Program.rolId == 1 || Program.rolId == 4)
                {
                    _idEstudianteActual = _simuladorController.ObtenerPrimerEstudianteParaTesting();
                    if (_idEstudianteActual == 0)
                    {
                        MessageBox.Show("No hay estudiantes matriculados en la base de datos para probar el simulador.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnSimular.Enabled = false;
                        return;
                    }
                    lblEstudianteInfo.Text = $"Modo Admin - Simulando como Estudiante ID: {_idEstudianteActual}";
                }
                else
                {
                    MessageBox.Show("Debe ser un Estudiante para usar este módulo.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
            }
            else
            {
                lblEstudianteInfo.Text = $"Estudiante: {Program.nombreUsuario}";
            }

            CargarPeriodos();
        }

        private void CargarPeriodos()
        {
            var periodos = _simuladorController.ObtenerPeriodosDelEstudiante(_idEstudianteActual);

            cmbPeriodo.SelectedIndexChanged -= cmbPeriodo_SelectedIndexChanged;
            cmbPeriodo.DataSource = periodos;
            cmbPeriodo.DisplayMember = "Nombre";
            cmbPeriodo.ValueMember = "IdPeriodo";
            cmbPeriodo.SelectedIndex = -1;
            cmbPeriodo.SelectedIndexChanged += cmbPeriodo_SelectedIndexChanged;
        }

        private void cmbPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPeriodo.SelectedIndex != -1 && cmbPeriodo.SelectedValue is int idPeriodo)
            {
                var asignaturas = _simuladorController.ObtenerAsignaturasDelEstudiante(_idEstudianteActual, idPeriodo);

                cmbAsignatura.DataSource = asignaturas;
                cmbAsignatura.DisplayMember = "Nombre";
                cmbAsignatura.ValueMember = "IdAsignatura";
                cmbAsignatura.SelectedIndex = -1;

                dgvSimulador.DataSource = null; // Limpiar grilla
                ResetearResultados();
            }
        }

        private void btnSimular_Click(object sender, EventArgs e)
        {
            if (cmbPeriodo.SelectedIndex == -1 || cmbAsignatura.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el Periodo y la Asignatura para cargar el modelo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idPeriodo = (int)cmbPeriodo.SelectedValue;
            int idAsignatura = (int)cmbAsignatura.SelectedValue;

            _listaSimulacion = _simuladorController.ObtenerDatosSimulacion(_idEstudianteActual, idAsignatura, idPeriodo);

            if (_listaSimulacion.Count == 0)
            {
                MessageBox.Show("No se encontraron evaluaciones configuradas para esta materia.", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvSimulador.DataSource = null;
                return;
            }

            dgvSimulador.DataSource = null;
            dgvSimulador.DataSource = _listaSimulacion;
            ConfigurarGrilla();
            CalcularPromedio(); // Cálculo inicial
        }

        private void ConfigurarGrilla()
        {
            if (dgvSimulador.Columns.Count > 0)
            {
                dgvSimulador.Columns["IdEvaluacion"].Visible = false;

                dgvSimulador.Columns["EvaluacionInfo"].HeaderText = "EVALUACIÓN";
                dgvSimulador.Columns["EvaluacionInfo"].ReadOnly = true;

                dgvSimulador.Columns["PesoPorcentaje"].HeaderText = "PESO (%)";
                dgvSimulador.Columns["PesoPorcentaje"].ReadOnly = true;
                dgvSimulador.Columns["PesoPorcentaje"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvSimulador.Columns["NotaReal"].HeaderText = "NOTA REAL (Si existe)";
                dgvSimulador.Columns["NotaReal"].ReadOnly = true;
                dgvSimulador.Columns["NotaReal"].DefaultCellStyle.BackColor = Color.LightGray;
                dgvSimulador.Columns["NotaReal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // La columna estrella: Donde el estudiante juega
                dgvSimulador.Columns["NotaSimulada"].HeaderText = "SIMULACIÓN DE NOTA";
                dgvSimulador.Columns["NotaSimulada"].ReadOnly = false; // ÚNICA EDITABLE
                dgvSimulador.Columns["NotaSimulada"].DefaultCellStyle.BackColor = Color.LightYellow;
                dgvSimulador.Columns["NotaSimulada"].DefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                dgvSimulador.Columns["NotaSimulada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        // --- VALIDACIÓN AL ESCRIBIR EN LA GRILLA ---
        private void dgvSimulador_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvSimulador.Columns[e.ColumnIndex].Name == "NotaSimulada")
            {
                string valorStr = e.FormattedValue.ToString().Replace(".", ",");

                if (!decimal.TryParse(valorStr, out decimal notaFinal) || notaFinal < 0 || notaFinal > 10)
                {
                    MessageBox.Show("Debe ingresar un número válido entre 0 y 10 para simular.", "Dato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
        }

        // --- RECALCULAR AUTOMÁTICAMENTE CUANDO TERMINA DE ESCRIBIR ---
        private void dgvSimulador_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalcularPromedio();
        }

        private void CalcularPromedio()
        {
            decimal promedioFinal = 0;

            foreach (var item in _listaSimulacion)
            {
                // Fórmula: Nota * (Peso / 100)
                decimal calculoParcial = item.NotaSimulada * (item.PesoPorcentaje / 100m);
                promedioFinal += calculoParcial;
            }

            lblPromedio.Text = Math.Round(promedioFinal, 2).ToString("0.00");

            // Evaluación de Estado
            if (promedioFinal >= 7.0m)
            {
                lblEstado.Text = "APROBADO";
                lblEstado.ForeColor = Color.FromArgb(39, 174, 96); // Verde
            }
            else
            {
                lblEstado.Text = "REPROBADO";
                lblEstado.ForeColor = Color.FromArgb(192, 57, 43); // Rojo
            }
        }

        private void ResetearResultados()
        {
            lblPromedio.Text = "0.00";
            lblEstado.Text = "";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}