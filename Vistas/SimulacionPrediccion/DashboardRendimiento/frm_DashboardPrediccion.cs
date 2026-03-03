namespace DataBase_First.Views.Dashboard
{
    using global::Academico;
    using global::Academico.Controladores;
    using LiveCharts;
    using LiveCharts.Wpf;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    public partial class frm_DashboardPrediccion : Form
    {
        private readonly DashboardController _dashboardController = new DashboardController();
        private int _idDocenteActual = 0;

        private LiveCharts.WinForms.PieChart _graficoPastel;
        private LiveCharts.WinForms.CartesianChart _graficoBarras;

        public frm_DashboardPrediccion()
        {
            InitializeComponent();
            InicializarGraficos();
        }

        private void InicializarGraficos()
        {
            _graficoPastel = new LiveCharts.WinForms.PieChart
            {
                Dock = DockStyle.Fill,
                LegendLocation = LegendLocation.Bottom,
                BackColor = Color.White
            };
            pnlGraficoPastel.Controls.Add(_graficoPastel);

            _graficoBarras = new LiveCharts.WinForms.CartesianChart
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };
            pnlGraficoBarras.Controls.Add(_graficoBarras);
        }

        private void frm_DashboardPrediccion_Load(object sender, EventArgs e)
        {
            _idDocenteActual = _dashboardController.ObtenerIdDocenteActual();

            if (_idDocenteActual == 0)
            {
                if (Program.rolId == 1 || Program.rolId == 4)
                {
                    _idDocenteActual = 0;
                }
                else
                {
                    MessageBox.Show("Acceso denegado. Solo Docentes y Coordinadores pueden ver el Dashboard.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
            }
            CargarPeriodos();
        }

        private void btnCerrar_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath circulo = new System.Drawing.Drawing2D.GraphicsPath();
            circulo.AddEllipse(0, 0, btnCerrar.Width, btnCerrar.Height);
            btnCerrar.Region = new Region(circulo);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarPeriodos()
        {
            var periodos = _dashboardController.ObtenerPeriodos(_idDocenteActual);
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
                var asignaturas = _dashboardController.ObtenerAsignaturas(_idDocenteActual, idPeriodo);
                cmbAsignatura.DataSource = asignaturas;
                cmbAsignatura.DisplayMember = "Nombre";
                cmbAsignatura.ValueMember = "IdAsignatura";
                cmbAsignatura.SelectedIndex = -1;

                LimpiarDashboard();
            }
        }

        private void btnAnalizar_Click(object sender, EventArgs e)
        {
            if (cmbPeriodo.SelectedIndex == -1 || cmbAsignatura.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el Periodo y la Asignatura para analizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idPeriodo = (int)cmbPeriodo.SelectedValue;
            int idAsignatura = (int)cmbAsignatura.SelectedValue;

            var resultados = _dashboardController.AnalizarRendimiento(idAsignatura, idPeriodo);

            if (resultados.Count == 0)
            {
                MessageBox.Show("No hay datos suficientes para analizar.", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarDashboard();
                return;
            }

            dgvPrediccion.DataSource = resultados;
            FormatearGrilla();

            int total = resultados.Count;
            // Contamos como "Buen Rendimiento" a los que van sobrados o ya aprobaron
            int aprobados = resultados.Count(r => r.Prediccion == "BUEN RENDIMIENTO" || r.Prediccion == "APROBADO");
            int riesgo = total - aprobados;

            lblTotalAlumnos.Text = total.ToString();
            lblAprobados.Text = aprobados.ToString();
            lblRiesgo.Text = riesgo.ToString();

            DibujarGraficos(aprobados, riesgo, resultados);
        }

        private void FormatearGrilla()
        {
            if (dgvPrediccion.Columns.Count > 0)
            {
                dgvPrediccion.Columns["Codigo"].Width = 100;
                dgvPrediccion.Columns["Estudiante"].Width = 180;
                dgvPrediccion.Columns["PromedioActual"].HeaderText = "Promedio Actual";

                // LA COLUMNA MÁS IMPORTANTE PARA EL DOCENTE
                dgvPrediccion.Columns["NotaRequerida"].HeaderText = "Nota Mínima Requerida";

                dgvPrediccion.Columns["Prediccion"].HeaderText = "Estado/Riesgo";
            }
        }

        private void dgvPrediccion_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPrediccion.Columns[e.ColumnIndex].Name == "Prediccion" && e.Value != null)
            {
                string valor = e.Value.ToString();
                if (valor.Contains("REMEDIAL INMINENTE") || valor.Contains("REPROBADO"))
                {
                    dgvPrediccion.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(250, 219, 216);
                    dgvPrediccion.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkRed;
                }
                else if (valor.Contains("ALTO RIESGO"))
                {
                    dgvPrediccion.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(253, 235, 208);
                    dgvPrediccion.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkOrange;
                }
                else if (valor.Contains("RIESGO MODERADO"))
                {
                    dgvPrediccion.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
                    dgvPrediccion.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Olive;
                }
            }
        }

        private void DibujarGraficos(int aprobados, int riesgo, List<DashboardController.EstudianteRendimientoDTO> resultados)
        {
            // 1. Gráfico de Pastel (Salud de la Clase)
            _graficoPastel.Series = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Buen Rendimiento",
                    Values = new ChartValues<int> { aprobados },
                    DataLabels = true,
                    Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(39, 174, 96))
                },
                new PieSeries
                {
                    Title = "En Riesgo",
                    Values = new ChartValues<int> { riesgo },
                    DataLabels = true,
                    Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(231, 76, 60))
                }
            };

            // 2. Gráfico de Barras (Actual vs Exigencia)
            double promClaseActual = resultados.Count > 0 ? (double)resultados.Average(r => r.PromedioActual) : 0;
            // Filtramos los que ya terminaron (requerida=0) para no dañar el promedio de exigencia
            var alumnosEnCurso = resultados.Where(r => r.NotaRequerida > 0).ToList();
            double exigenciaMedia = alumnosEnCurso.Count > 0 ? (double)alumnosEnCurso.Average(r => r.NotaRequerida) : 0;

            _graficoBarras.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Promedio vs Exigencia",
                    Values = new ChartValues<double> { Math.Round(promClaseActual, 2), Math.Round(exigenciaMedia, 2) },
                    Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(52, 152, 219)),
                    DataLabels = true
                }
            };

            _graficoBarras.AxisX.Clear();
            _graficoBarras.AxisX.Add(new Axis
            {
                Labels = new[] { "P. Actual del Curso", "Exigencia Media para Aprobar" }
            });

            _graficoBarras.AxisY.Clear();
            _graficoBarras.AxisY.Add(new Axis
            {
                Title = "Notas (0-10)",
                MinValue = 0,
                // Si la exigencia promedio supera 10, expandimos el eje para que se vea lo grave de la situación
                MaxValue = exigenciaMedia > 10 ? exigenciaMedia + 1 : 10
            });
        }

        private void LimpiarDashboard()
        {
            dgvPrediccion.DataSource = null;
            lblTotalAlumnos.Text = "0";
            lblAprobados.Text = "0";
            lblRiesgo.Text = "0";

            if (_graficoPastel.Series != null) _graficoPastel.Series.Clear();
            if (_graficoBarras.Series != null) _graficoBarras.Series.Clear();
        }
    }
}