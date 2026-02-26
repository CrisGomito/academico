namespace DataBase_First.Views.Administracion.Auditoria
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Academico.Controladores;

    public partial class frm_Auditoria : Form
    {
        private readonly AuditoriaController _auditoriaController = new AuditoriaController();

        public frm_Auditoria()
        {
            InitializeComponent();
        }

        private void frm_Auditoria_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            ConfigurarColumnas();
        }

        private void CargarGrilla()
        {
            var historial = _auditoriaController.ObtenerHistorial();

            // Usamos una proyección anónima para formatear los nombres de las columnas que verá el Admin
            dgv_Auditoria.DataSource = historial.Select(a => new
            {
                ID = a.IdAuditoria,
                Fecha = a.Fecha,
                Usuario = a.UsuarioNombre,
                Rol = a.Rol,
                Accion = a.Accion,
                Tabla = a.TablaAfectada,
                RegistroID = a.RegistroId,
                ValorAnterior = a.ValorAnterior,
                ValorNuevo = a.ValorNuevo
            }).ToList();
        }

        private void ConfigurarColumnas()
        {
            if (dgv_Auditoria.Columns.Count > 0)
            {
                dgv_Auditoria.Columns["ID"].Width = 50;
                dgv_Auditoria.Columns["Fecha"].Width = 150;
                dgv_Auditoria.Columns["Usuario"].Width = 150;
                dgv_Auditoria.Columns["Rol"].Width = 100;
                dgv_Auditoria.Columns["Accion"].Width = 80;
                dgv_Auditoria.Columns["Tabla"].Width = 100;
                dgv_Auditoria.Columns["RegistroID"].Width = 80;
                // Dejamos que ValorAnterior y ValorNuevo usen el espacio restante por defecto (AutoSizeColumnsMode = Fill)
            }
        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            txt_Buscar.Clear();
            CargarGrilla();
        }

        private void txt_Buscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txt_Buscar.Text.Trim();
            if (string.IsNullOrEmpty(filtro))
            {
                CargarGrilla();
            }
            else
            {
                var historialFiltrado = _auditoriaController.FiltrarHistorial(filtro);
                dgv_Auditoria.DataSource = historialFiltrado.Select(a => new
                {
                    ID = a.IdAuditoria,
                    Fecha = a.Fecha,
                    Usuario = a.UsuarioNombre,
                    Rol = a.Rol,
                    Accion = a.Accion,
                    Tabla = a.TablaAfectada,
                    RegistroID = a.RegistroId,
                    ValorAnterior = a.ValorAnterior,
                    ValorNuevo = a.ValorNuevo
                }).ToList();
            }
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}