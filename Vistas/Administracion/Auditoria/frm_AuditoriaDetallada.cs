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
        private const string PLACEHOLDER_TEXT = "Buscar por usuario, acción, tabla, fecha o valores...";

        public frm_AuditoriaDetallada()
        {
            InitializeComponent();
        }

        private void frm_AuditoriaDetallada_Load(object sender, EventArgs e)
        {
            pnlBuscador.Margin = new Padding(0, 0, 0, 15);
            txtBuscar.Text = PLACEHOLDER_TEXT;
            txtBuscar.ForeColor = Color.Gray;

            CargarAuditoria();

            // Auto-refresh inteligente (cada 5 seg)
            tmrAutoRefresh = new System.Windows.Forms.Timer();
            tmrAutoRefresh.Interval = 5000;
            tmrAutoRefresh.Tick += (s, args) =>
            {
                // SOLO recarga si el TextBox tiene el Placeholder o está vacío
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
                // Evitar spam de errores por timer si se corta la conexión
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

            // Fija los anchos para que no se deforme al actualizar
            if (dgvAuditoria.Columns.Count > 0)
            {
                dgvAuditoria.Columns["ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvAuditoria.Columns["ID"].Width = 60;

                dgvAuditoria.Columns["Registro"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvAuditoria.Columns["Registro"].Width = 100;

                dgvAuditoria.Columns["Fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvAuditoria.Columns["Fecha"].Width = 180;

                dgvAuditoria.Columns["Usuario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvAuditoria.Columns["Usuario"].Width = 180;

                dgvAuditoria.Columns["Acción"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvAuditoria.Columns["Acción"].Width = 100;

                dgvAuditoria.Columns["Tabla"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvAuditoria.Columns["Tabla"].Width = 120;
            }

            // LO QUE PEDÍAS: Forzar a la tabla a mostrar siempre la fila de más arriba (la más reciente)
            if (dgvAuditoria.Rows.Count > 0)
            {
                dgvAuditoria.FirstDisplayedScrollingRowIndex = 0;
            }
        }

        // --- LÓGICA BUSCADOR Y PLACEHOLDER ---
        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == PLACEHOLDER_TEXT)
            {
                txtBuscar.TextChanged -= txtBuscar_TextChanged;
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.Black;
                txtBuscar.TextChanged += txtBuscar_TextChanged;
            }
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                txtBuscar.TextChanged -= txtBuscar_TextChanged;
                txtBuscar.Text = PLACEHOLDER_TEXT;
                txtBuscar.ForeColor = Color.Gray;
                txtBuscar.TextChanged += txtBuscar_TextChanged;

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