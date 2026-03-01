namespace DataBase_First.Views.Administracion.Auditoria
{
    using global::Academico.Controladores;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    public partial class frm_Auditoria : Form
    {
        private readonly AuditoriaController _auditoriaController = new AuditoriaController();
        private const string PLACEHOLDER_TEXT = "Buscar por usuario, acción o tabla afectada...";

        public frm_Auditoria()
        {
            InitializeComponent();
        }

        private void frm_Auditoria_Load(object sender, EventArgs e)
        {
            // Agregamos un margen visual entre el buscador y la tabla
            pnlBuscador.Margin = new Padding(0, 0, 0, 15);
            CargarAuditoria(); // Carga inicial usando ObtenerHistorial()
            // Configurar auto-actualización silenciosa cada 5 segundos
            tmrAutoRefresh = new System.Windows.Forms.Timer();
            tmrAutoRefresh.Interval = 5000; // 5000 milisegundos = 5 segundos
            tmrAutoRefresh.Tick += (s, args) =>
            {
                // Solo auto-actualiza si la caja de búsqueda está vacía o tiene el placeholder
                if (txtBuscar.Text == PLACEHOLDER_TEXT || string.IsNullOrWhiteSpace(txtBuscar.Text))
                {
                    CargarAuditoria();
                }
            };
            tmrAutoRefresh.Start();
        }

        // --- BOTÓN CIRCULAR ROJO PARA CERRAR ---
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
        // ---------------------------------------

        private void CargarAuditoria()
        {
            try
            {
                // Usando TU método exacto del repositorio
                var datos = _auditoriaController.ObtenerHistorial();
                MapearYMostrarGrid(datos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la auditoría: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método auxiliar para dar formato a los datos antes de enviarlos a la tabla
        private void MapearYMostrarGrid(IEnumerable<dynamic> datos)
        {
            // Mapeamos a un objeto dinámico para darle formato legible a las columnas
            var listaMapeada = datos.Select(a => new
            {
                ID = a.IdAuditoria,
                Usuario = a.UsuarioNombre ?? "Sistema",
                Rol = a.Rol ?? "N/A",
                Acción = a.Accion,
                Tabla = a.TablaAfectada,
                Registro = a.RegistroId,
                Fecha = a.Fecha != null ? a.Fecha.ToString("dd/MM/yyyy HH:mm:ss") : ""
            }).ToList();

            dgvAuditoria.DataSource = null;
            dgvAuditoria.DataSource = listaMapeada;

            if (dgvAuditoria.Columns.Count > 0)
            {
                // Ajustamos anchos para que se vea estético
                dgvAuditoria.Columns["ID"].Width = 60;
                dgvAuditoria.Columns["Registro"].Width = 80;
                dgvAuditoria.Columns["Fecha"].Width = 160;
            }
        }

        // =========================================================
        // LÓGICA DEL PLACEHOLDER (Texto Atenuado)
        // =========================================================
        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == PLACEHOLDER_TEXT)
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.Black; // Color activo
            }
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                txtBuscar.Text = PLACEHOLDER_TEXT;
                txtBuscar.ForeColor = Color.Gray; // Color atenuado
                CargarAuditoria(); // Restauramos la lista completa
            }
        }

        // =========================================================
        // LÓGICA DE BÚSQUEDA EN TIEMPO REAL CON TU MÉTODO
        // =========================================================
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim();

            // Si el texto es vacío o es el placeholder, mostramos todo
            if (string.IsNullOrWhiteSpace(filtro) || filtro == PLACEHOLDER_TEXT)
            {
                CargarAuditoria();
                return;
            }

            // Usando TU método FiltrarHistorial del repositorio
            var datosFiltrados = _auditoriaController.FiltrarHistorial(filtro);
            MapearYMostrarGrid(datosFiltrados);
        }
    }
}