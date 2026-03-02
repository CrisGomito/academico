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

        private Dictionary<int, bool> _filasEditadas = new Dictionary<int, bool>();
        private Dictionary<int, bool> _filasConError = new Dictionary<int, bool>();
        private bool _hayCambiosSinGuardar = false;

        public frm_IngresoNotas()
        {
            InitializeComponent();
        }

        private void frm_IngresoNotas_Load(object sender, EventArgs e)
        {
            _idDocenteActual = _califController.ObtenerIdDocenteActual();

            if (_idDocenteActual == 0)
            {
                if (Program.rolId == 1 || Program.rolId == 4)
                {
                    MessageBox.Show("Modo Superusuario activado: Podrá visualizar y gestionar las calificaciones de todos los docentes y materias.", "Modo Administración", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _idDocenteActual = 0;
                }
                else
                {
                    MessageBox.Show("Atención: Su usuario no está registrado como Docente. No podrá ingresar notas.", "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnCargar.Enabled = false;
                    btnGuardar.Enabled = false;
                    return;
                }
            }

            // Suscribimos los eventos visuales para el ícono de exclamación
            dgvAlumnos.CellPainting += dgvAlumnos_CellPainting;

            CargarPeriodos();
        }

        // --- BOTÓN CIRCULAR ROJO DE CERRAR ---
        private void btnCerrar_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath botonCircular = new System.Drawing.Drawing2D.GraphicsPath();
            botonCircular.AddEllipse(0, 0, btnCerrar.Width, btnCerrar.Height);
            btnCerrar.Region = new System.Drawing.Region(botonCircular);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (_hayCambiosSinGuardar)
            {
                var confirm = MessageBox.Show("Tiene notas sin guardar. ¿Está seguro que desea salir y perder los cambios?", "Cambios no guardados", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.No)
                {
                    return;
                }
            }
            this.Close();
        }

        private void CargarPeriodos()
        {
            var periodos = _califController.ObtenerPeriodosDelDocente(_idDocenteActual);
            cmbPeriodo.SelectedIndexChanged -= cmbPeriodo_SelectedIndexChanged;
            cmbPeriodo.DataSource = periodos;
            cmbPeriodo.DisplayMember = "Nombre";
            cmbPeriodo.ValueMember = "IdPeriodo";
            cmbPeriodo.SelectedIndex = -1;
            cmbPeriodo.SelectedIndexChanged += cmbPeriodo_SelectedIndexChanged;
        }

        private void cmbPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPeriodo.SelectedIndex != -1 && cmbPeriodo.SelectedValue is int idPeriodo)
            {
                var asignaturas = _califController.ObtenerAsignaturasDelDocente(_idDocenteActual, idPeriodo);
                cmbAsignatura.SelectedIndexChanged -= cmbAsignatura_SelectedIndexChanged;
                cmbAsignatura.DataSource = asignaturas;
                cmbAsignatura.DisplayMember = "Nombre";
                cmbAsignatura.ValueMember = "IdAsignatura";
                cmbAsignatura.SelectedIndex = -1;
                cmbEvaluacion.DataSource = null;
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
            if (cmbAsignatura.SelectedValue is int idAsignatura && cmbPeriodo.SelectedValue is int idPeriodo)
            {
                var evaluaciones = _califController.ObtenerEvaluaciones(idAsignatura, idPeriodo);
                var source = evaluaciones.Select(ev => new { ev.IdEvaluacion, Display = ev.Descripcion }).ToList();
                cmbEvaluacion.DataSource = source;
                cmbEvaluacion.DisplayMember = "Display";
                cmbEvaluacion.ValueMember = "IdEvaluacion";
                cmbEvaluacion.SelectedIndex = -1;
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (cmbEvaluacion.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una Evaluación para calificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_hayCambiosSinGuardar)
            {
                var confirm = MessageBox.Show("Hay notas sin guardar. Si carga otra lista perderá sus cambios actuales. ¿Desea continuar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.No) return;
            }

            int idAsignatura = (int)cmbAsignatura.SelectedValue;
            int idPeriodo = (int)cmbPeriodo.SelectedValue;
            int idEvaluacion = (int)cmbEvaluacion.SelectedValue;

            _listaActual = _califController.ObtenerEstudiantesParaCalificar(idAsignatura, idPeriodo, idEvaluacion);

            dgvAlumnos.DataSource = null;
            dgvAlumnos.DataSource = _listaActual;

            ConfigurarGrilla();

            _filasEditadas.Clear();
            _filasConError.Clear();
            _hayCambiosSinGuardar = false;
        }

        private void ConfigurarGrilla()
        {
            if (dgvAlumnos.Columns.Count > 0)
            {
                dgvAlumnos.Columns["IdEstudiante"].Visible = false;
                dgvAlumnos.Columns["IdCalificacion"].Visible = false;
                dgvAlumnos.Columns["Nota"].Visible = false; // Ocultamos el campo decimal real

                dgvAlumnos.Columns["Codigo"].HeaderText = "CÓDIGO";
                dgvAlumnos.Columns["Codigo"].ReadOnly = true;
                dgvAlumnos.Columns["Codigo"].Width = 150;

                dgvAlumnos.Columns["NombreCompleto"].HeaderText = "ESTUDIANTE";
                dgvAlumnos.Columns["NombreCompleto"].ReadOnly = true;

                // Mostramos el campo String (NotaUI) para que no crashee al escribir cualquier cosa
                dgvAlumnos.Columns["NotaUI"].HeaderText = "CALIFICACIÓN (Ej: 8.50)";
                dgvAlumnos.Columns["NotaUI"].DefaultCellStyle.BackColor = Color.LightYellow;
                dgvAlumnos.Columns["NotaUI"].DefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                dgvAlumnos.Columns["NotaUI"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvAlumnos.Columns["NotaUI"].Width = 250;
            }
        }

        private void dgvAlumnos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvAlumnos.Columns[e.ColumnIndex].Name == "NotaUI")
            {
                _filasEditadas[e.RowIndex] = true;
                _hayCambiosSinGuardar = true;
            }
        }

        // Quita la marca roja temporalmente si entra a corregir
        private void dgvAlumnos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvAlumnos.Columns[e.ColumnIndex].Name == "NotaUI")
            {
                if (_filasConError.ContainsKey(e.RowIndex))
                {
                    _filasConError[e.RowIndex] = false;
                    dgvAlumnos.InvalidateCell(e.ColumnIndex, e.RowIndex);
                }
            }
        }

        // PINTADO MANUAL DEL SIGNO DE EXCLAMACIÓN (!)
        private void dgvAlumnos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvAlumnos.Columns[e.ColumnIndex].Name == "NotaUI")
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                if (_filasConError.ContainsKey(e.RowIndex) && _filasConError[e.RowIndex] == true)
                {
                    using (Brush brush = new SolidBrush(Color.Red))
                    using (Font font = new Font("Arial", 16, FontStyle.Bold))
                    {
                        PointF ubicacion = new PointF(e.CellBounds.Right - 20, e.CellBounds.Top + 4);
                        e.Graphics.DrawString("!", font, brush, ubicacion);
                    }
                }
                e.Handled = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_listaActual.Count == 0 || cmbEvaluacion.SelectedIndex == -1) return;

            if (!_hayCambiosSinGuardar)
            {
                MessageBox.Show("No se han detectado modificaciones en las notas.", "Sin cambios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool hayErrores = false;
            _filasConError.Clear();

            // 1. VALIDACIÓN PREVIA MASIVA
            foreach (DataGridViewRow row in dgvAlumnos.Rows)
            {
                if (_filasEditadas.ContainsKey(row.Index) && _filasEditadas[row.Index] == true)
                {
                    var celdaNotaUI = row.Cells["NotaUI"].Value;

                    if (celdaNotaUI != null && !string.IsNullOrWhiteSpace(celdaNotaUI.ToString()))
                    {
                        // Transformamos una posible coma a punto
                        string strValor = celdaNotaUI.ToString().Replace(",", ".");

                        // Validamos forzando InvariantCulture (punto como decimal)
                        if (!decimal.TryParse(strValor, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal notaFinal)
                            || notaFinal < 0 || notaFinal > 10)
                        {
                            _filasConError[row.Index] = true;
                            dgvAlumnos.InvalidateCell(row.Cells["NotaUI"].ColumnIndex, row.Index);
                            hayErrores = true;
                        }
                        else
                        {
                            // Actualizamos el string visual a algo correcto (Ej: de "8,5" a "8.50")
                            row.Cells["NotaUI"].Value = notaFinal.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                        }
                    }
                }
            }

            if (hayErrores)
            {
                MessageBox.Show("Existen calificaciones con formato incorrecto (Marcadas con un ! rojo).\nLas notas deben ser números entre 0 y 10.\nUtilice el PUNTO (.) para los decimales.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("¿Está seguro de guardar las calificaciones ingresadas para estos estudiantes?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No) return;

            // 3. ASIGNACIÓN AL CAMPO DECIMAL Y GUARDADO
            foreach (DataGridViewRow row in dgvAlumnos.Rows)
            {
                if (_filasEditadas.ContainsKey(row.Index) && _filasEditadas[row.Index] == true)
                {
                    var celdaNotaUI = row.Cells["NotaUI"].Value;
                    int idEstudiante = (int)row.Cells["IdEstudiante"].Value;
                    var alumno = _listaActual.First(a => a.IdEstudiante == idEstudiante);

                    if (celdaNotaUI != null && !string.IsNullOrWhiteSpace(celdaNotaUI.ToString()))
                    {
                        string strValor = celdaNotaUI.ToString().Replace(",", ".");
                        alumno.Nota = decimal.Parse(strValor, System.Globalization.CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        alumno.Nota = null;
                    }
                }
            }

            int idEvaluacion = (int)cmbEvaluacion.SelectedValue;
            var resultado = _califController.GuardarNotas(_listaActual, idEvaluacion);

            if (resultado.exito)
            {
                MessageBox.Show(resultado.mensaje, "Notas Guardadas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _hayCambiosSinGuardar = false;
                _filasEditadas.Clear();
                _filasConError.Clear();
                btnCargar.PerformClick(); // Recargar para limpiar el DTO
            }
            else
            {
                MessageBox.Show(resultado.mensaje, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}