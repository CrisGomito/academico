namespace DataBase_First.Views.Simulacion
{
    using global::Academico;
    using global::Academico.Controladores;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    public partial class frm_SimuladorNotas : Form
    {
        private readonly SimuladorController _simuladorController = new SimuladorController();
        private int _idEstudianteActual = 0;
        private List<SimuladorController.DetalleSimulacionDTO> _listaSimulacion = new List<SimuladorController.DetalleSimulacionDTO>();

        private Dictionary<int, bool> _filasConError = new Dictionary<int, bool>();

        public frm_SimuladorNotas()
        {
            InitializeComponent();
        }

        private void frm_SimuladorNotas_Load(object sender, EventArgs e)
        {
            _idEstudianteActual = _simuladorController.ObtenerIdEstudianteActual();

            if (_idEstudianteActual == 0)
            {
                if (Program.rolId == 1 || Program.rolId == 4)
                {
                    _idEstudianteActual = _simuladorController.ObtenerPrimerEstudianteParaTesting();
                    if (_idEstudianteActual == 0)
                    {
                        MessageBox.Show("No hay estudiantes matriculados en la base de datos para probar el simulador.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnCargarMateria.Enabled = false;
                        return;
                    }
                    lblEstudianteInfo.Text = $"Simulando como Admin (Estudiante ID: {_idEstudianteActual})";
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

            dgvSimulador.CellPainting += dgvSimulador_CellPainting;

            CargarPeriodos();
        }

        // --- BOTÓN CERRAR ---
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

                dgvSimulador.DataSource = null;
                ResetearResultados();
            }
        }

        private void btnCargarMateria_Click(object sender, EventArgs e)
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

            _filasConError.Clear();
            dgvSimulador.DataSource = null;
            dgvSimulador.DataSource = _listaSimulacion;
            ConfigurarGrilla();
            ResetearResultados();
        }

        private void ConfigurarGrilla()
        {
            if (dgvSimulador.Columns.Count > 0)
            {
                dgvSimulador.Columns["IdEvaluacion"].Visible = false;
                dgvSimulador.Columns["IdTipoEvaluacion"].Visible = false; // Oculto
                dgvSimulador.Columns["NotaSimulada"].Visible = false; // Oculto el decimal interno

                dgvSimulador.Columns["EvaluacionInfo"].HeaderText = "EVALUACIÓN";
                dgvSimulador.Columns["EvaluacionInfo"].ReadOnly = true;

                dgvSimulador.Columns["NotaReal"].HeaderText = "NOTA REAL (Si existe)";
                dgvSimulador.Columns["NotaReal"].ReadOnly = true;
                dgvSimulador.Columns["NotaReal"].DefaultCellStyle.BackColor = Color.LightGray;
                dgvSimulador.Columns["NotaReal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvSimulador.Columns["NotaSimuladaUI"].HeaderText = "SIMULAR NOTA (0.00 - 10.00)";
                dgvSimulador.Columns["NotaSimuladaUI"].ReadOnly = false;// Por defecto editable
                dgvSimulador.Columns["NotaSimuladaUI"].DefaultCellStyle.BackColor = Color.LightYellow;
                dgvSimulador.Columns["NotaSimuladaUI"].DefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                dgvSimulador.Columns["NotaSimuladaUI"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                
                // --- BLOQUEO ESPECÍFICO DEL REMEDIAL ---
                // Iteramos por las filas y bloqueamos la celda de simulación si el Tipo de Evaluación es 6 (Remedial)
                foreach (DataGridViewRow row in dgvSimulador.Rows)
                {
                    if ((int)row.Cells["IdTipoEvaluacion"].Value == 6)
                    {
                        row.Cells["NotaSimuladaUI"].ReadOnly = true;
                        // Opcional: Cambiarle el color para que el estudiante entienda que no se puede editar
                        row.Cells["NotaSimuladaUI"].Style.BackColor = Color.LightGray;
                        row.Cells["NotaSimuladaUI"].Style.ForeColor = Color.Gray;
                    }
                }
            }
        }

        private void dgvSimulador_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvSimulador.Columns[e.ColumnIndex].Name == "NotaSimuladaUI")
            {
                if (_filasConError.ContainsKey(e.RowIndex))
                {
                    _filasConError[e.RowIndex] = false;
                    dgvSimulador.InvalidateCell(e.ColumnIndex, e.RowIndex);
                }
            }
        }

        // PINTADO MANUAL DEL SIGNO DE EXCLAMACIÓN (!)
        private void dgvSimulador_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvSimulador.Columns[e.ColumnIndex].Name == "NotaSimuladaUI")
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                if (_filasConError.ContainsKey(e.RowIndex) && _filasConError[e.RowIndex] == true)
                {
                    using (Brush brush = new SolidBrush(Color.Red))
                    using (Font font = new Font("Arial", 16, FontStyle.Bold))
                    {
                        PointF ubicacion = new PointF(e.CellBounds.Right - 20, e.CellBounds.Top + 4);
                        e.Graphics.DrawString("!", font, brush, ubicacion);
                    }
                }
                e.Handled = true;
            }
        }

        // --- BOTÓN CENTRAL DE CÁLCULO MATEMÁTICO ---
        private void btnSimularFinal_Click(object sender, EventArgs e)
        {
            if (_listaSimulacion.Count == 0) return;

            bool hayErrores = false;
            _filasConError.Clear();

            // 1. VALIDACIÓN
            foreach (DataGridViewRow row in dgvSimulador.Rows)
            {
                var celdaUI = row.Cells["NotaSimuladaUI"].Value;

                if (celdaUI != null && !string.IsNullOrWhiteSpace(celdaUI.ToString()))
                {
                    string strValor = celdaUI.ToString().Replace(",", ".");

                    if (!decimal.TryParse(strValor, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal notaFinal)
                        || notaFinal < 0 || notaFinal > 10)
                    {
                        _filasConError[row.Index] = true;
                        dgvSimulador.InvalidateCell(row.Cells["NotaSimuladaUI"].ColumnIndex, row.Index);
                        hayErrores = true;
                    }
                    else
                    {
                        // Estandarizamos vista y guardamos en la clase modelo (dto) para poder operar
                        row.Cells["NotaSimuladaUI"].Value = notaFinal.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                        int idEval = (int)row.Cells["IdEvaluacion"].Value;
                        var evalDto = _listaSimulacion.First(l => l.IdEvaluacion == idEval);
                        evalDto.NotaSimulada = notaFinal;
                    }
                }
            }

            if (hayErrores)
            {
                MessageBox.Show("Corrige las casillas marcadas con el (!) rojo. Las notas deben estar entre 0 y 10.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. APLICAMOS EL MODELO MATEMÁTICO INSTITUCIONAL EXACTO
            decimal v_ef1 = 0, v_ep1 = 0, v_ef2 = 0, v_ep2 = 0, v_exf = 0;
            decimal? v_rem = null;

            foreach (var item in _listaSimulacion)
            {
                switch (item.IdTipoEvaluacion)
                {
                    case 1: v_ef1 = item.NotaSimulada; break;
                    case 2: v_ep1 = item.NotaSimulada; break;
                    case 3: v_ef2 = item.NotaSimulada; break;
                    case 4: v_ep2 = item.NotaSimulada; break;
                    case 5: v_exf = item.NotaSimulada; break;
                    case 6:
                        // Solo tomamos el remedial en cuenta si escribió algo mayor a 0
                        if (item.NotaSimulada > 0) v_rem = item.NotaSimulada;
                        break;
                }
            }

            // (EF1 + EP1) / 2
            decimal parcial1 = (v_ef1 + v_ep1) / 2m;
            // (EF2 + EP2) / 2
            decimal parcial2 = (v_ef2 + v_ep2) / 2m;

            decimal finalUsar = v_exf;
            if (v_rem.HasValue && v_rem.Value > v_exf)
            {
                finalUsar = v_rem.Value; // El remedial reemplaza al final si es mayor
            }

            // Promedio General
            decimal promedioFinal = (parcial1 + parcial2 + finalUsar) / 3m;

            lblPromedio.Text = Math.Round(promedioFinal, 2).ToString("0.00");

            // CONDICIÓN DE APROBACIÓN
            if (promedioFinal >= 7.0m && finalUsar >= 7.0m)
            {
                lblEstado.Text = "APROBADO";
                lblEstado.ForeColor = Color.FromArgb(39, 174, 96);
            }
            else if (finalUsar < 7.0m && !v_rem.HasValue)
            {
                lblEstado.Text = "REMEDIAL";
                lblEstado.ForeColor = Color.DarkOrange;
            }
            else
            {
                lblEstado.Text = "REPROBADO";
                lblEstado.ForeColor = Color.FromArgb(192, 57, 43);
            }
        }

        private void ResetearResultados()
        {
            lblPromedio.Text = "0.00";
            lblEstado.Text = "";
        }
    }
}