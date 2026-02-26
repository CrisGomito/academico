namespace DataBase_First.Views.Calificaciones
{
    using global::Academico;
    using global::Academico.Controladores;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    public partial class frm_IngresoNotas : Form
    {
        private readonly CalificacionesController _califController = new CalificacionesController();
        private int _idDocenteActual = 0;
        private List<CalificacionesController.AlumnoNotaDTO> _listaActual = new List<CalificacionesController.AlumnoNotaDTO>();

        public frm_IngresoNotas()
        {
            InitializeComponent();
        }

        private void frm_IngresoNotas_Load(object sender, EventArgs e)
        {
            // 1. Obtener ID del docente autenticado
            _idDocenteActual = _califController.ObtenerIdDocenteActual();

            // BYPASS PARA TESTING
            if (_idDocenteActual == 0)
            {
                if (Program.rolId == 1 || Program.rolId == 4) // ADMIN O COORDINADOR (Testing)
                {
                    MessageBox.Show("Modo Superusuario activado: Podrá visualizar y gestionar las calificaciones de todos los docentes y materias.", "Modo Administración", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _idDocenteActual = 0; // Lo dejamos en 0 para que el Controlador active la vista global
                }
                else
                {
                    MessageBox.Show("Atención: Su usuario no está registrado como Docente. No podrá ingresar notas.", "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnCargar.Enabled = false;
                    btnGuardar.Enabled = false;
                    btnNuevaEval.Enabled = false;
                    return;
                }
            }
            /*

if (_idDocenteActual == 0)

{

    MessageBox.Show("Atención: Su usuario no está registrado como Docente. No podrá ingresar notas.", "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

    btnCargar.Enabled = false;

    btnGuardar.Enabled = false;

    btnNuevaEval.Enabled = false;

    return;

}

*/
            CargarPeriodos();
        }

        private void CargarPeriodos()
        {
            var periodos = _califController.ObtenerPeriodosDelDocente(_idDocenteActual);

            // Apagamos los eventos temporalmente para evitar que se disparen en cadena mientras llenamos
            cmbPeriodo.SelectedIndexChanged -= cmbPeriodo_SelectedIndexChanged;

            cmbPeriodo.DataSource = periodos;
            cmbPeriodo.DisplayMember = "Nombre";
            cmbPeriodo.ValueMember = "IdPeriodo";
            cmbPeriodo.SelectedIndex = -1;

            // Volvemos a encender el evento
            cmbPeriodo.SelectedIndexChanged += cmbPeriodo_SelectedIndexChanged;
        }

        private void cmbPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Validación de seguridad para el casteo: Comprobamos que SelectedValue sea realmente un entero
            if (cmbPeriodo.SelectedIndex != -1 && cmbPeriodo.SelectedValue is int idPeriodo)
            {
                var asignaturas = _califController.ObtenerAsignaturasDelDocente(_idDocenteActual, idPeriodo);

                cmbAsignatura.SelectedIndexChanged -= cmbAsignatura_SelectedIndexChanged;

                cmbAsignatura.DataSource = asignaturas;
                cmbAsignatura.DisplayMember = "Nombre";
                cmbAsignatura.ValueMember = "IdAsignatura";
                cmbAsignatura.SelectedIndex = -1;

                cmbEvaluacion.DataSource = null; // Limpiar evaluaciones

                cmbAsignatura.SelectedIndexChanged += cmbAsignatura_SelectedIndexChanged;
            }
        }

        private void cmbAsignatura_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAsignatura.SelectedIndex != -1 && cmbPeriodo.SelectedIndex != -1)
            {
                CargarEvaluaciones();
            }
        }

        private void CargarEvaluaciones()
        {
            // Validamos casteos antes de consultar a BD
            if (cmbAsignatura.SelectedValue is int idAsignatura && cmbPeriodo.SelectedValue is int idPeriodo)
            {
                var evaluaciones = _califController.ObtenerEvaluaciones(idAsignatura, idPeriodo);
                var source = evaluaciones.Select(ev => new
                {
                    ev.IdEvaluacion,
                    Display = $"{ev.IdTipoEvaluacionNavigation.Nombre} - {ev.Descripcion}"
                }).ToList();

                cmbEvaluacion.DataSource = source;
                cmbEvaluacion.DisplayMember = "Display";
                cmbEvaluacion.ValueMember = "IdEvaluacion";
                cmbEvaluacion.SelectedIndex = -1;
            }
        }

        // --- BOTÓN PARA CREAR UNA EVALUACIÓN RÁPIDA ---
        private void btnNuevaEval_Click(object sender, EventArgs e)
        {
            if (cmbAsignatura.SelectedIndex == -1 || cmbPeriodo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione primero un Periodo y una Asignatura para crearle una evaluación.");
                return;
            }

            string inputDesc = Microsoft.VisualBasic.Interaction.InputBox("Ingrese una descripción para la evaluación (Ej: Examen Parcial 2):", "Nueva Evaluación", "");
            if (string.IsNullOrWhiteSpace(inputDesc)) return;

            var resultado = _califController.CrearEvaluacion((int)cmbAsignatura.SelectedValue, (int)cmbPeriodo.SelectedValue, 1, inputDesc);

            if (resultado.exito)
            {
                MessageBox.Show(resultado.mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarEvaluaciones();
            }
            else
            {
                MessageBox.Show(resultado.mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- CARGAR ALUMNOS Y NOTAS EN LA GRILLA ---
        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (cmbEvaluacion.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una Evaluación para calificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idAsignatura = (int)cmbAsignatura.SelectedValue;
            int idPeriodo = (int)cmbPeriodo.SelectedValue;
            int idEvaluacion = (int)cmbEvaluacion.SelectedValue;

            _listaActual = _califController.ObtenerEstudiantesParaCalificar(idAsignatura, idPeriodo, idEvaluacion);

            dgvAlumnos.DataSource = null; // Reset
            dgvAlumnos.DataSource = _listaActual;

            ConfigurarGrilla();
        }

        private void ConfigurarGrilla()
        {
            if (dgvAlumnos.Columns.Count > 0)
            {
                // Ocultamos IDs internos
                dgvAlumnos.Columns["IdEstudiante"].Visible = false;
                dgvAlumnos.Columns["IdCalificacion"].Visible = false;

                // Nombramos las columnas
                dgvAlumnos.Columns["Codigo"].HeaderText = "CÓDIGO";
                dgvAlumnos.Columns["Codigo"].ReadOnly = true;
                dgvAlumnos.Columns["Codigo"].Width = 150;

                dgvAlumnos.Columns["NombreCompleto"].HeaderText = "ESTUDIANTE";
                dgvAlumnos.Columns["NombreCompleto"].ReadOnly = true;

                // Configurar columna de NOTA (La única editable)
                dgvAlumnos.Columns["Nota"].HeaderText = "CALIFICACIÓN (0-10)";
                dgvAlumnos.Columns["Nota"].DefaultCellStyle.BackColor = Color.LightYellow;
                dgvAlumnos.Columns["Nota"].DefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                dgvAlumnos.Columns["Nota"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvAlumnos.Columns["Nota"].Width = 200;
            }
        }

        // --- VALIDACIÓN ESTRICTA DE LA NOTA AL ESCRIBIR ---
        private void dgvAlumnos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvAlumnos.Columns[e.ColumnIndex].Name == "Nota")
            {
                string valorIngresado = e.FormattedValue.ToString();

                if (!string.IsNullOrWhiteSpace(valorIngresado))
                {
                    valorIngresado = valorIngresado.Replace(".", ",");

                    if (!decimal.TryParse(valorIngresado, out decimal notaFinal) || notaFinal < 0 || notaFinal > 10)
                    {
                        MessageBox.Show("La nota debe ser un número válido entre 0 y 10.", "Valor Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                    }
                }
            }
        }

        // --- GUARDADO MASIVO DE NOTAS ---
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_listaActual.Count == 0 || cmbEvaluacion.SelectedIndex == -1) return;

            foreach (DataGridViewRow row in dgvAlumnos.Rows)
            {
                var celdaNota = row.Cells["Nota"].Value;
                int idEstudiante = (int)row.Cells["IdEstudiante"].Value;

                var alumno = _listaActual.First(a => a.IdEstudiante == idEstudiante);

                if (celdaNota != null && !string.IsNullOrWhiteSpace(celdaNota.ToString()))
                {
                    alumno.Nota = Convert.ToDecimal(celdaNota);
                }
                else
                {
                    alumno.Nota = null;
                }
            }

            int idEvaluacion = (int)cmbEvaluacion.SelectedValue;
            var resultado = _califController.GuardarNotas(_listaActual, idEvaluacion);

            if (resultado.exito)
            {
                MessageBox.Show(resultado.mensaje, "Notas Guardadas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnCargar.PerformClick(); // Recargar
            }
            else
            {
                MessageBox.Show(resultado.mensaje, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}