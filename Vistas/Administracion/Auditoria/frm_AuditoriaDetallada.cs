namespace DataBase_First.Views.Administracion.Auditoria
{
    using global::Academico.Controladores;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    public partial class frm_AuditoriaDetallada : Form
    {
        private readonly AuditoriaDetalladaController _controller = new AuditoriaDetalladaController();
        private const string PLACEHOLDER_TEXT = "Buscar por usuario, acción, tabla o valores cambiados...";

        public frm_AuditoriaDetallada()
        {
            InitializeComponent();
        }

        private void frm_AuditoriaDetallada_Load(object sender, EventArgs e)
        {
            pnlBuscador.Margin = new Padding(0, 0, 0, 15);
            CargarAuditoria();

            // Auto-refresh inteligente (cada 5 seg)
            tmrAutoRefresh = new System.Windows.Forms.Timer();
            tmrAutoRefresh.Interval = 5000;
            tmrAutoRefresh.Tick += (s, args) =>
            {
                if (txtBuscar.Text == PLACEHOLDER_TEXT || string.IsNullOrWhiteSpace(txtBuscar.Text))
                {
                    CargarAuditoria();
                }
            };
            tmrAutoRefresh.Start();
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

        private void CargarAuditoria()
        {
            try
            {
                var datos = _controller.ObtenerAuditoriaDetallada();
                MapearYMostrarGrid(datos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la auditoría: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MapearYMostrarGrid(IEnumerable<dynamic> datos)
        {
            var listaMapeada = datos.Select(a => new
            {
                ID = a.IdAuditoria,
                Fecha = a.Fecha != null ? a.Fecha.ToString("dd/MM/yyyy HH:mm:ss") : "",
                Usuario = a.UsuarioNombre ?? "Sistema",
                Acción = a.Accion,
                Tabla = a.TablaAfectada,
                Registro = a.RegistroId,
                Valor_Anterior = a.ValorAnterior ?? "-",
                Valor_Nuevo = a.ValorNuevo ?? "-"
            }).ToList();

            dgvAuditoria.DataSource = null;
            dgvAuditoria.DataSource = listaMapeada;

            if (dgvAuditoria.Columns.Count > 0)
            {
                dgvAuditoria.Columns["ID"].Width = 40;
                dgvAuditoria.Columns["Registro"].Width = 60;
                dgvAuditoria.Columns["Fecha"].Width = 140;
                dgvAuditoria.Columns["Acción"].Width = 70;
                dgvAuditoria.Columns["Tabla"].Width = 80;
            }
        }

        // --- LÓGICA BUSCADOR Y PLACEHOLDER ---
        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == PLACEHOLDER_TEXT)
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.Black;
            }
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                txtBuscar.Text = PLACEHOLDER_TEXT;
                txtBuscar.ForeColor = Color.Gray;
                CargarAuditoria();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim();

            if (string.IsNullOrWhiteSpace(filtro) || filtro == PLACEHOLDER_TEXT)
            {
                CargarAuditoria();
                return;
            }

            var datosFiltrados = _controller.FiltrarAuditoriaDetallada(filtro);
            MapearYMostrarGrid(datosFiltrados);
        }
    }
}