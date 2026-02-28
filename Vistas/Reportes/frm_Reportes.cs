namespace DataBase_First.Views.Reportes
{
    using global::Academico;
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
                // 1. PREPARAMOS LOS PARÁMETROS
                // Tomamos los datos globales de la sesión actual
                string nombreUsuario = string.IsNullOrEmpty(Program.nombreUsuario) ? "Usuario Desconocido" : Program.nombreUsuario;
                string rolUsuario = string.IsNullOrEmpty(Program.rol) ? "Sin Rol" : Program.rol;
                string textoUsuario = $"Generado por: {nombreUsuario} - {rolUsuario}";
                string textoFecha = $"Fecha de emisión: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}";

                // Creamos el arreglo de parámetros (Deben llamarse EXACTAMENTE igual que en el .rdlc)
                ReportParameter[] parametros = new ReportParameter[]
                {
                    new ReportParameter("UsuarioImpresion", textoUsuario),
                    new ReportParameter("FechaImpresion", textoFecha)
                };

                // 2. CARGAMOS EL REPORTE SEGÚN LA SELECCIÓN
                if (cmbTipoReporte.SelectedIndex == 0) // Rendimiento Académico
                {
                    var datos = _reportesController.ObtenerReporteAcademico();

                    string rutaReporte = Path.Combine(Application.StartupPath, @"Vistas\Reportes\RptAcademico.rdlc");
                    _reportViewer.LocalReport.ReportPath = rutaReporte;

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

                // 3. INYECTAMOS LOS PARÁMETROS AL REPORTE
                // Es muy importante hacer esto DESPUÉS de haber asignado el ReportPath
                _reportViewer.LocalReport.SetParameters(parametros);

                // 4. RENDERIZAMOS
                _reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte.\n\nDetalle: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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