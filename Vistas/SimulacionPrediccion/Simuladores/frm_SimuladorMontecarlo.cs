namespace DataBase_First.Views.Simulacion
{
    using global::Academico;
    using global::Academico.Controladores;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    public partial class frm_SimuladorMontecarlo : Form
    {
        private readonly SimuladorController _simuladorController = new SimuladorController();
        private int _idEstudianteActual = 0;
        private List<SimuladorController.DetalleSimulacionDTO> _listaSimulacion = new List<SimuladorController.DetalleSimulacionDTO>();

        public frm_SimuladorMontecarlo()
        {
            InitializeComponent();
        }

        private void frm_SimuladorMontecarlo_Load(object sender, EventArgs e)
        {
            _idEstudianteActual = _simuladorController.ObtenerIdEstudianteActual();

            if (_idEstudianteActual == 0)
            {
                if (Program.rolId == 1 || Program.rolId == 4)
                {
                    _idEstudianteActual = _simuladorController.ObtenerPrimerEstudianteParaTesting();
                    if (_idEstudianteActual == 0)
                    {
                        MessageBox.Show("No hay estudiantes matriculados.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnCargarMateria.Enabled = false;
                        return;
                    }
                    lblEstudianteInfo.Text = $"Admin Test (ID: {_idEstudianteActual})";
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
            if (cmbPeriodo.SelectedIndex == -1 || cmbAsignatura.SelectedIndex == -1) return;

            int idPeriodo = (int)cmbPeriodo.SelectedValue;
            int idAsignatura = (int)cmbAsignatura.SelectedValue;

            _listaSimulacion = _simuladorController.ObtenerDatosSimulacion(_idEstudianteActual, idAsignatura, idPeriodo);

            if (_listaSimulacion.Count == 0) return;

            dgvSimulador.DataSource = null;
            dgvSimulador.DataSource = _listaSimulacion;
            ConfigurarGrilla();
            ResetearResultados();
        }

        private void ConfigurarGrilla()
        {
            if (dgvSimulador.Columns.Count > 0)
            {
                // Bloqueo total de edición
                dgvSimulador.ReadOnly = true;

                dgvSimulador.Columns["IdEvaluacion"].Visible = false;
                dgvSimulador.Columns["IdTipoEvaluacion"].Visible = false;
                dgvSimulador.Columns["NotaSimulada"].Visible = false;

                dgvSimulador.Columns["EvaluacionInfo"].HeaderText = "TIPO DE EVALUACIÓN";

                dgvSimulador.Columns["NotaReal"].HeaderText = "NOTA REAL REGISTRADA";
                dgvSimulador.Columns["NotaReal"].DefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                dgvSimulador.Columns["NotaReal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // ACTIVAMOS ESTA COLUMNA PARA MOSTRAR LOS VALORES GENERADOS POR LA I.A.
                dgvSimulador.Columns["NotaSimuladaUI"].Visible = true;
                dgvSimulador.Columns["NotaSimuladaUI"].HeaderText = "PROYECCIÓN DEL MODELO";
                dgvSimulador.Columns["NotaSimuladaUI"].DefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                dgvSimulador.Columns["NotaSimuladaUI"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Limpiamos la columna visualmente al cargar
                foreach (DataGridViewRow row in dgvSimulador.Rows)
                {
                    row.Cells["NotaSimuladaUI"].Value = "-";
                }
            }
        }

        private void ResetearResultados()
        {
            lblEsperado.Text = "0.00";
            lblProbAprobado.Text = "Aprobar Directo: 0%";
            lblProbRemedial.Text = "Ir a Remedial: 0%";
            lblProbReprobado.Text = "Reprobar: 0%";
        }

        // =========================================================================
        // MOTOR DE SIMULACIÓN MONTECARLO CON RETROALIMENTACIÓN VISUAL
        // =========================================================================
        private void btnSimularMontecarlo_Click(object sender, EventArgs e)
        {
            if (_listaSimulacion.Count == 0) return;

            int iteraciones = 10000;
            int aprobados = 0;
            int remediales = 0;
            int reprobados = 0;

            // Sumatorias para encontrar el "Valor Esperado" exacto de cada nota
            decimal sumaPromedios = 0;
            decimal sum_ef1 = 0, sum_ep1 = 0, sum_ef2 = 0, sum_ep2 = 0, sum_exf = 0;

            // 1. Extraemos las notas reales que ya tiene (Fijas, no varían)
            decimal ef1Real = _listaSimulacion.FirstOrDefault(x => x.IdTipoEvaluacion == 1)?.NotaReal ?? -1;
            decimal ep1Real = _listaSimulacion.FirstOrDefault(x => x.IdTipoEvaluacion == 2)?.NotaReal ?? -1;
            decimal ef2Real = _listaSimulacion.FirstOrDefault(x => x.IdTipoEvaluacion == 3)?.NotaReal ?? -1;
            decimal ep2Real = _listaSimulacion.FirstOrDefault(x => x.IdTipoEvaluacion == 4)?.NotaReal ?? -1;
            decimal exfReal = _listaSimulacion.FirstOrDefault(x => x.IdTipoEvaluacion == 5)?.NotaReal ?? -1;

            // Media histórica de la asignatura (Opción A)
            var notasCompletadas = _listaSimulacion.Where(x => x.NotaReal.HasValue).Select(x => (double)x.NotaReal.Value).ToList();
            double mediaEstudiante = notasCompletadas.Count > 0 ? notasCompletadas.Average() : 7.0;

            double desviacionEstandar = 1.5;
            if (notasCompletadas.Count > 1)
            {
                double sumOfSquaresOfDifferences = notasCompletadas.Select(val => (val - mediaEstudiante) * (val - mediaEstudiante)).Sum();
                desviacionEstandar = Math.Sqrt(sumOfSquaresOfDifferences / notasCompletadas.Count);
                if (desviacionEstandar < 0.5) desviacionEstandar = 0.5;
            }

            Random rand = new Random();

            // 2. CICLO MONTECARLO
            for (int i = 0; i < iteraciones; i++)
            {
                decimal sim_ef1 = ef1Real != -1 ? ef1Real : GenerarNotaNormal(rand, mediaEstudiante, desviacionEstandar);
                decimal sim_ep1 = ep1Real != -1 ? ep1Real : GenerarNotaNormal(rand, mediaEstudiante, desviacionEstandar);
                decimal sim_ef2 = ef2Real != -1 ? ef2Real : GenerarNotaNormal(rand, mediaEstudiante, desviacionEstandar);
                decimal sim_ep2 = ep2Real != -1 ? ep2Real : GenerarNotaNormal(rand, mediaEstudiante, desviacionEstandar);
                decimal sim_exf = exfReal != -1 ? exfReal : GenerarNotaNormal(rand, mediaEstudiante, desviacionEstandar);

                // Acumulamos para saber qué valores promedio usó la máquina
                sum_ef1 += sim_ef1;
                sum_ep1 += sim_ep1;
                sum_ef2 += sim_ef2;
                sum_ep2 += sim_ep2;
                sum_exf += sim_exf;

                decimal parcial1 = (sim_ef1 + sim_ep1) / 2m;
                decimal parcial2 = (sim_ef2 + sim_ep2) / 2m;
                decimal promedioFinal = (parcial1 + parcial2 + sim_exf) / 3m;

                sumaPromedios += promedioFinal;

                if (promedioFinal >= 7.0m && sim_exf >= 7.0m) aprobados++;
                else if (sim_exf < 7.0m && promedioFinal >= 4.0m) remediales++;
                else reprobados++;
            }

            // 3. CÁLCULO DE VALORES ESPERADOS
            decimal avg_ef1 = sum_ef1 / iteraciones;
            decimal avg_ep1 = sum_ep1 / iteraciones;
            decimal avg_ef2 = sum_ef2 / iteraciones;
            decimal avg_ep2 = sum_ep2 / iteraciones;
            decimal avg_exf = sum_exf / iteraciones;

            // 4. PINTADO VISUAL EN LA GRILLA
            foreach (DataGridViewRow row in dgvSimulador.Rows)
            {
                int tipoEval = (int)row.Cells["IdTipoEvaluacion"].Value;
                bool esSimulada = _listaSimulacion.FirstOrDefault(x => x.IdTipoEvaluacion == tipoEval)?.NotaReal == null;

                decimal valorMostrar = 0;
                switch (tipoEval)
                {
                    case 1: valorMostrar = avg_ef1; break;
                    case 2: valorMostrar = avg_ep1; break;
                    case 3: valorMostrar = avg_ef2; break;
                    case 4: valorMostrar = avg_ep2; break;
                    case 5: valorMostrar = avg_exf; break;
                    case 6: valorMostrar = -1; break; // Remedial no se proyecta directamente
                }

                if (tipoEval != 6) // Omitimos remedial
                {
                    row.Cells["NotaSimuladaUI"].Value = valorMostrar.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

                    if (esSimulada)
                    {
                        // Color Azul suave para indicar que es un valor generado por la IA/Modelo
                        row.Cells["NotaSimuladaUI"].Style.BackColor = Color.LightCyan;
                        row.Cells["NotaSimuladaUI"].Style.ForeColor = Color.DarkBlue;
                    }
                    else
                    {
                        // Gris normal para indicar que es el valor real estático
                        row.Cells["NotaSimuladaUI"].Style.BackColor = Color.LightGray;
                        row.Cells["NotaSimuladaUI"].Style.ForeColor = Color.Black;
                    }
                }
            }

            // 5. PRESENTACIÓN DE RESULTADOS FINALES
            decimal valorEsperado = sumaPromedios / iteraciones;
            double probAprobar = (aprobados / (double)iteraciones) * 100;
            double probRemedial = (remediales / (double)iteraciones) * 100;
            double probReprobar = (reprobados / (double)iteraciones) * 100;

            lblEsperado.Text = Math.Round(valorEsperado, 2).ToString("0.00");
            lblProbAprobado.Text = $"Aprobar Directo: {Math.Round(probAprobar, 1)}%";
            lblProbRemedial.Text = $"Ir a Remedial: {Math.Round(probRemedial, 1)}%";
            lblProbReprobado.Text = $"Reprobar: {Math.Round(probReprobar, 1)}%";
        }

        private decimal GenerarNotaNormal(Random rand, double mean, double stdDev)
        {
            double u1 = 1.0 - rand.NextDouble();
            double u2 = 1.0 - rand.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            double randNormal = mean + stdDev * randStdNormal;

            if (randNormal > 10.0) randNormal = 10.0;
            if (randNormal < 0.0) randNormal = 0.0;

            return (decimal)randNormal;
        }
    }
}