namespace DataBase_First.Views.Dashboard
{
    using global::Academico;
    using global::Academico.Controladores;
    using LiveCharts;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    // Quitamos los using genéricos de WinForms y Wpf para evitar la ambigüedad

    public partial class frm_DashboardPrediccion : Form
    {
        private readonly DashboardController _dashboardController = new DashboardController();
        private int _idDocenteActual = 0;

        // DECLARAMOS EXPLÍCITAMENTE EL GRÁFICO DE WINFORMS
        private LiveCharts.WinForms.PieChart _graficoPastel;

        public frm_DashboardPrediccion()
        {
            InitializeComponent();
            InicializarGrafico();
        }

        private void InicializarGrafico()
        {
            // Instanciamos explícitamente el PieChart de WinForms
            _graficoPastel = new LiveCharts.WinForms.PieChart
            {
                Dock = DockStyle.Fill,
                LegendLocation = LegendLocation.Bottom,
                BackColor = Color.White
            };
            pnlGrafico.Controls.Add(_graficoPastel);
        }

        private void frm_DashboardPrediccion_Load(object sender, EventArgs e)
        {
            _idDocenteActual = _dashboardController.ObtenerIdDocenteActual();

            // MODO BYPASS ADMIN/TESTING
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
            // Validación de casteo (igual que hicimos en calificaciones)
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
                MessageBox.Show("No hay datos suficientes (alumnos matriculados o evaluaciones creadas) para analizar.", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarDashboard();
                return;
            }

            // 1. Llenar la Grilla
            dgvPrediccion.DataSource = resultados;
            FormatearGrilla();

            // 2. Calcular KPIs (Contadores)
            int total = resultados.Count;
            int aprobados = resultados.Count(r => r.Prediccion == "BUEN RENDIMIENTO" || r.Prediccion == "APROBADO");
            int riesgo = total - aprobados; // Riesgo o Reprobados

            lblTotalAlumnos.Text = total.ToString();
            lblAprobados.Text = aprobados.ToString();
            lblRiesgo.Text = riesgo.ToString();

            // 3. Dibujar Gráfico LiveCharts
            DibujarGrafico(aprobados, riesgo);
        }

        private void FormatearGrilla()
        {
            if (dgvPrediccion.Columns.Count > 0)
            {
                dgvPrediccion.Columns["Codigo"].Width = 100;
                dgvPrediccion.Columns["Estudiante"].Width = 200;
                dgvPrediccion.Columns["PromedioActual"].HeaderText = "Promedio Actual";
                dgvPrediccion.Columns["NotaMaximaPosible"].HeaderText = "Máximo Posible";
                dgvPrediccion.Columns["Prediccion"].HeaderText = "Estado/Predicción";
            }
        }

        private void dgvPrediccion_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPrediccion.Columns[e.ColumnIndex].Name == "Prediccion" && e.Value != null)
            {
                string valor = e.Value.ToString();
                if (valor.Contains("REPROBADO"))
                {
                    dgvPrediccion.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(250, 219, 216);
                    dgvPrediccion.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkRed;
                }
                else if (valor.Contains("RIESGO"))
                {
                    dgvPrediccion.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(253, 235, 208);
                    dgvPrediccion.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkOrange;
                }
            }
        }

        private void DibujarGrafico(int aprobados, int riesgo)
        {
            // Usamos explícitamente PieSeries de Wpf para las porciones del gráfico
            _graficoPastel.Series = new SeriesCollection
            {
                new LiveCharts.Wpf.PieSeries
                {
                    Title = "Buen Rendimiento",
                    Values = new ChartValues<int> { aprobados },
                    DataLabels = true,
                    Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(39, 174, 96))
                },
                new LiveCharts.Wpf.PieSeries
                {
                    Title = "En Riesgo / Reprobados",
                    Values = new ChartValues<int> { riesgo },
                    DataLabels = true,
                    Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(231, 76, 60))
                }
            };
        }

        private void LimpiarDashboard()
        {
            dgvPrediccion.DataSource = null;
            lblTotalAlumnos.Text = "0";
            lblAprobados.Text = "0";
            lblRiesgo.Text = "0";

            if (_graficoPastel.Series != null)
            {
                _graficoPastel.Series.Clear();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}