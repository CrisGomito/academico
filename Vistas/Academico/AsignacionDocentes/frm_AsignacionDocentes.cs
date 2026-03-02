namespace DataBase_First.Views.Academico.AsignacionDocentes
{
    using global::Academico.Controladores;
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using FontAwesome.Sharp;
    using global::Academico.Config;

    public partial class frm_AsignacionDocentes : Form
    {
        private readonly AsignacionDocentesController _asignacionController = new AsignacionDocentesController();

        public frm_AsignacionDocentes()
        {
            InitializeComponent();
        }

        private void frm_AsignacionDocentes_Load(object sender, EventArgs e)
        {
            CargarCombos();
            carga_lista();
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

        private void CargarCombos()
        {
            // Cargar Docentes
            var docentes = _asignacionController.ObtenerDocentesActivos()
                .Select(d => new { d.IdDocente, NombreCombo = $"{d.Nombre} {d.Apellido} (C.I: {d.CedulaPlana})" }).ToList();
            cmb_Docente.DataSource = docentes;
            cmb_Docente.DisplayMember = "NombreCombo";
            cmb_Docente.ValueMember = "IdDocente";
            cmb_Docente.SelectedIndex = -1;

            // Cargar Asignaturas
            var asignaturas = _asignacionController.ObtenerAsignaturas();
            cmb_Asignatura.DataSource = asignaturas;
            cmb_Asignatura.DisplayMember = "Nombre";
            cmb_Asignatura.ValueMember = "IdAsignatura";
            cmb_Asignatura.SelectedIndex = -1;

            // Cargar Periodos Activos
            var periodos = _asignacionController.ObtenerPeriodosActivos();
            cmb_Periodo.DataSource = periodos;
            cmb_Periodo.DisplayMember = "Nombre";
            cmb_Periodo.ValueMember = "IdPeriodo";
            cmb_Periodo.SelectedIndex = -1;
        }

        private void carga_lista()
        {
            var listaAsignaciones = _asignacionController.ObtenerAsignaciones();

            lst_Lista_Asignaciones.DataSource = listaAsignaciones;
            lst_Lista_Asignaciones.DisplayMember = "DisplayInfo";
            lst_Lista_Asignaciones.ValueMember = "IdAsignacion";
        }

        // --- MÉTODO PARA RELLENAR DATOS EN DOBLE CLIC (SOLO LECTURA) ---
        private void lst_Lista_Asignaciones_DoubleClick(object sender, EventArgs e)
        {
            if (lst_Lista_Asignaciones.SelectedValue == null) return;

            int idAsignacion = (int)lst_Lista_Asignaciones.SelectedValue;

            // Obtenemos la asignación DTO
            var asignacionDTO = _asignacionController.ObtenerAsignaciones().FirstOrDefault(a => a.IdAsignacion == idAsignacion);

            if (asignacionDTO != null)
            {
                // Limpiamos la UI pero mantenemos los controles bloqueados (modo vista)
                LimpiarCampos(true);

                // Asignatura y Periodo se pueden mapear por texto porque coinciden exactamente
                cmb_Asignatura.Text = asignacionDTO.AsignaturaNombre;
                cmb_Periodo.Text = asignacionDTO.PeriodoNombre;

                // CORRECCIÓN PARA EL DOCENTE:
                // Como el DTO no trae el ID del Docente ni la cédula, lo buscamos en la base
                using (var _context = new SistemaAcademicoContext())
                {
                    var asignacionOriginal = _context.Asignaciondocentes.FirstOrDefault(a => a.IdAsignacion == idAsignacion);
                    if (asignacionOriginal != null)
                    {
                        // Le decimos al ComboBox que seleccione el ID real del docente
                        cmb_Docente.SelectedValue = asignacionOriginal.IdDocente;
                    }
                }

                // Forzamos a que sigan bloqueados (Solo lectura)
                cmb_Docente.Enabled = false;
                cmb_Asignatura.Enabled = false;
                cmb_Periodo.Enabled = false;
            }
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos(false);
            activacajas();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos(true);
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            if (!verificarCampos()) return;

            int idDocente = (int)cmb_Docente.SelectedValue;
            int idAsignatura = (int)cmb_Asignatura.SelectedValue;
            int idPeriodo = (int)cmb_Periodo.SelectedValue;

            var resultado = _asignacionController.AgregarAsignacion(idDocente, idAsignatura, idPeriodo);

            if (resultado.exito)
            {
                MessageBox.Show(resultado.mensaje, "Gestión Académica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos(true);
                carga_lista();
            }
            else
            {
                MessageBox.Show(resultado.mensaje, "Validación de Asignación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public bool verificarCampos()
        {
            if (cmb_Docente.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un Docente.");
                return false;
            }
            if (cmb_Asignatura.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una Asignatura.");
                return false;
            }
            if (cmb_Periodo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un Periodo Académico.");
                return false;
            }
            return true;
        }

        public void LimpiarCampos(bool bloquearCajas)
        {
            cmb_Docente.SelectedIndex = -1;
            cmb_Asignatura.SelectedIndex = -1;
            cmb_Periodo.SelectedIndex = -1;

            if (bloquearCajas)
            {
                btn_Nuevo.Enabled = true;
                lst_Lista_Asignaciones.Enabled = true;
                btn_Eliminar.Enabled = true;

                btn_Guardar.Enabled = false;
                btn_Cancelar.Enabled = false;

                cmb_Docente.Enabled = false;
                cmb_Asignatura.Enabled = false;
                cmb_Periodo.Enabled = false;
            }
        }

        public void activacajas()
        {
            btn_Nuevo.Enabled = false;
            lst_Lista_Asignaciones.Enabled = false;
            btn_Eliminar.Enabled = false;

            btn_Guardar.Enabled = true;
            btn_Cancelar.Enabled = true;

            cmb_Docente.Enabled = true;
            cmb_Asignatura.Enabled = true;
            cmb_Periodo.Enabled = true;
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (lst_Lista_Asignaciones.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione una asignación del listado para eliminarla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var idAsignacion = (int)lst_Lista_Asignaciones.SelectedValue;

            var confirmResult = MessageBox.Show("¿Está seguro de que desea anular esta asignación?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                var resultado = _asignacionController.EliminarAsignacion(idAsignacion);

                if (resultado)
                {
                    MessageBox.Show("La asignación ha sido eliminada con éxito.", "Gestión Académica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    carga_lista();
                    LimpiarCampos(true);
                }
                else
                {
                    MessageBox.Show("Error al eliminar la asignación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}