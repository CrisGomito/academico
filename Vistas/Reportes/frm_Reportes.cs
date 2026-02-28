namespace DataBase_First.Views.Reportes
{
    using global::Academico.Controladores;
    using Microsoft.Reporting.WinForms;
    using System;
    using System.IO;
    using System.Windows.Forms;

    public partial class frm_Reportes : Form
    {
        private readonly ReportesController _reportesController = new ReportesController();
        private ReportViewer _reportViewer;

        public frm_Reportes()
        {
            InitializeComponent();
            InicializarVisor();
        }

        private void InicializarVisor()
        {
            _reportViewer = new ReportViewer
            {
                Dock = DockStyle.Fill,
                ProcessingMode = ProcessingMode.Local
            };
            pnlContenedorReporte.Controls.Add(_reportViewer);
        }

        private void frm_Reportes_Load(object sender, EventArgs e)
        {
            _reportViewer.RefreshReport();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            _reportViewer.LocalReport.DataSources.Clear();

            try
            {
                if (cmbTipoReporte.SelectedIndex == 0) // Rendimiento Académico
                {
                    var datos = _reportesController.ObtenerReporteAcademico();

                    // RUTA AL ARCHIVO RDLC (Debes crearlo en la carpeta Reportes)
                    string rutaReporte = Path.Combine(Application.StartupPath, @"Vistas\Reportes\RptAcademico.rdlc");
                    _reportViewer.LocalReport.ReportPath = rutaReporte;

                    // El nombre "dsAcademico" debe coincidir EXACTAMENTE con el nombre del Dataset que crees en el RDLC
                    ReportDataSource rds = new ReportDataSource("dsAcademico", datos);
                    _reportViewer.LocalReport.DataSources.Add(rds);
                }
                else if (cmbTipoReporte.SelectedIndex == 1) // Auditoría Seguridad
                {
                    var datos = _reportesController.ObtenerReporteAccesos();

                    string rutaReporte = Path.Combine(Application.StartupPath, @"Vistas\Reportes\RptSeguridad.rdlc");
                    _reportViewer.LocalReport.ReportPath = rutaReporte;

                    ReportDataSource rds = new ReportDataSource("dsSeguridad", datos);
                    _reportViewer.LocalReport.DataSources.Add(rds);   
                }

                _reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte: Asegúrese de haber creado el archivo .rdlc. \n\nDetalle: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Botón Circular
        private void btnCerrarForm_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath botonCircular = new System.Drawing.Drawing2D.GraphicsPath();
            botonCircular.AddEllipse(0, 0, btnCerrarForm.Width, btnCerrarForm.Height);
            btnCerrarForm.Region = new System.Drawing.Region(botonCircular);
        }

        private void btnCerrarForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}