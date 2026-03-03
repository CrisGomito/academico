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
            ConfigurarPermisosCombo();
            _reportViewer.RefreshReport();
        }

        // LÓGICA DE SEGURIDAD PARA EL COMBOBOX
        private void ConfigurarPermisosCombo()
        {
            cmbTipoReporte.Items.Clear();

            // Todos tienen acceso a su Rendimiento Académico (Filtrado en el controlador)
            cmbTipoReporte.Items.Add("Rendimiento Académico Final");

            // Solo Administradores (1) y Coordinadores (4) pueden ver Auditoría
            if (Program.rolId == 1 || Program.rolId == 4)
            {
                cmbTipoReporte.Items.Add("Auditoría de Seguridad (Accesos del Año)");
            }

            if (cmbTipoReporte.Items.Count > 0)
            {
                cmbTipoReporte.SelectedIndex = 0; // Seleccionar el primero por defecto
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (cmbTipoReporte.SelectedIndex == -1) return;

            _reportViewer.LocalReport.DataSources.Clear();

            try
            {
                // 1. PREPARAMOS LOS PARÁMETROS (Metadatos del PDF)
                // LLAMAMOS AL NUEVO MÉTODO PARA OBTENER NOMBRE + APELLIDO
                string nombreCompleto = _reportesController.ObtenerNombreCompletoUsuarioActual();

                string nombreFirma = string.IsNullOrEmpty(nombreCompleto) ? "Usuario Desconocido" : nombreCompleto;
                string rolUsuario = string.IsNullOrEmpty(Program.rol) ? "Sin Rol" : Program.rol;

                string textoUsuario = $"Generado por: {nombreFirma} - {rolUsuario}";
                string textoFecha = $"Fecha de emisión: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}";

                ReportParameter[] parametros = new ReportParameter[]
                {
                    new ReportParameter("UsuarioImpresion", textoUsuario),
                    new ReportParameter("FechaImpresion", textoFecha)
                };

                // 2. CARGAMOS EL REPORTE SEGÚN EL TEXTO DEL COMBO (Ya no por index para evitar cruces si se ocultan opciones)
                string opcionSeleccionada = cmbTipoReporte.SelectedItem.ToString();

                if (opcionSeleccionada == "Rendimiento Académico Final")
                {
                    var datos = _reportesController.ObtenerReporteAcademico();

                    if (datos.Count == 0)
                    {
                        MessageBox.Show("No se encontraron registros académicos para mostrar.", "Reporte Vacío", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string rutaReporte = Path.Combine(Application.StartupPath, @"Vistas\Reportes\RptAcademico.rdlc");
                    _reportViewer.LocalReport.ReportPath = rutaReporte;

                    ReportDataSource rds = new ReportDataSource("dsAcademico", datos);
                    _reportViewer.LocalReport.DataSources.Add(rds);
                }
                else if (opcionSeleccionada == "Auditoría de Seguridad (Accesos del Año)")
                {
                    var datos = _reportesController.ObtenerReporteAccesos();

                    string rutaReporte = Path.Combine(Application.StartupPath, @"Vistas\Reportes\RptSeguridad.rdlc");
                    _reportViewer.LocalReport.ReportPath = rutaReporte;

                    ReportDataSource rds = new ReportDataSource("dsSeguridad", datos);
                    _reportViewer.LocalReport.DataSources.Add(rds);
                }

                // 3. INYECTAMOS LOS PARÁMETROS AL REPORTE
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