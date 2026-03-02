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

        // Rastreo de modificaciones
        private Dictionary<int, bool> _filasEditadas = new Dictionary<int, bool>();
        // Rastreo de celdas con errores manuales (para pintar el ❗)
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
                    btnNuevaEval.Enabled = false;
                    return;
                }
            }

            // Suscribimos el evento de pintado para dibujar el ❗ manualmente
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
        // -------------------------------------

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

                dgvAlumnos.Columns["Codigo"].HeaderText = "CÓDIGO";
                dgvAlumnos.Columns["Codigo"].ReadOnly = true;
                dgvAlumnos.Columns["Codigo"].Width = 150;

                dgvAlumnos.Columns["NombreCompleto"].HeaderText = "ESTUDIANTE";
                dgvAlumnos.Columns["NombreCompleto"].ReadOnly = true;

                // SE ACLARA EL USO DE PUNTO EN EL ENCABEZADO
                dgvAlumnos.Columns["Nota"].HeaderText = "CALIFICACIÓN (Ej: 8.5)";
                dgvAlumnos.Columns["Nota"].DefaultCellStyle.BackColor = Color.LightYellow;
                dgvAlumnos.Columns["Nota"].DefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                dgvAlumnos.Columns["Nota"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvAlumnos.Columns["Nota"].Width = 250;
            }
        }

        // Detecta edición para habilitar el guardado
        private void dgvAlumnos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvAlumnos.Columns[e.ColumnIndex].Name == "Nota")
            {
                _filasEditadas[e.RowIndex] = true;
                _hayCambiosSinGuardar = true;
            }
        }

        // Quita la marca de error inmediatamente si el usuario vuelve a editar la celda
        private void dgvAlumnos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvAlumnos.Columns[e.ColumnIndex].Name == "Nota")
            {
                if (_filasConError.ContainsKey(e.RowIndex))
                {
                    _filasConError[e.RowIndex] = false;
                    dgvAlumnos.InvalidateCell(e.ColumnIndex, e.RowIndex); // Obliga a repintar para quitar el ❗
                }
            }
        }

        // PINTADO MANUAL DEL SIGNO DE EXCLAMACIÓN (❗) EN ROJO
        private void dgvAlumnos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvAlumnos.Columns[e.ColumnIndex].Name == "Nota")
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                // Si la fila está marcada con error, dibujamos el ❗ en la esquina superior derecha
                if (_filasConError.ContainsKey(e.RowIndex) && _filasConError[e.RowIndex] == true)
                {
                    using (Brush brush = new SolidBrush(Color.Red))
                    {
                        using (Font font = new Font("Segoe UI", 14, FontStyle.Bold))
                        {
                            // Ajustar coordenadas para que quede arriba a la derecha
                            PointF ubicacion = new PointF(e.CellBounds.Right - 20, e.CellBounds.Top + 5);
                            e.Graphics.DrawString("!", font, brush, ubicacion);
                        }
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
            _filasConError.Clear(); // Limpiamos errores anteriores

            // 1. VALIDACIÓN PREVIA MASIVA
            foreach (DataGridViewRow row in dgvAlumnos.Rows)
            {
                if (_filasEditadas.ContainsKey(row.Index) && _filasEditadas[row.Index] == true)
                {
                    var celdaNota = row.Cells["Nota"].Value;

                    if (celdaNota != null && !string.IsNullOrWhiteSpace(celdaNota.ToString()))
                    {
                        // Convertimos comas a puntos internamente para que C# no falle según la cultura de la PC
                        string valorIngresado = celdaNota.ToString().Replace(",", ".");

                        // Usamos InvariantCulture para forzar el parseo entendiendo el punto (.) como decimal
                        if (!decimal.TryParse(valorIngresado, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal notaFinal)
                            || notaFinal < 0 || notaFinal > 10)
                        {
                            // Marcamos la fila con error y repintamos para que aparezca el ❗
                            _filasConError[row.Index] = true;
                            dgvAlumnos.InvalidateCell(row.Cells["Nota"].ColumnIndex, row.Index);
                            hayErrores = true;
                        }
                        else
                        {
                            // Formatea visualmente a dos decimales con punto
                            row.Cells["Nota"].Value = notaFinal.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                        }
                    }
                }
            }

            if (hayErrores)
            {
                MessageBox.Show("Existen calificaciones con formato incorrecto (Marcadas con un ! rojo).\nLas notas deben ser números entre 0 y 10.\nUtilice el PUNTO (.) para los decimales.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Se detiene el proceso de guardado
            }

            // 2. CONFIRMACIÓN DE GUARDADO
            var confirm = MessageBox.Show("¿Está seguro de guardar las calificaciones ingresadas para estos estudiantes?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No) return;

            // 3. ASIGNACIÓN AL DTO Y GUARDADO
            foreach (DataGridViewRow row in dgvAlumnos.Rows)
            {
                if (_filasEditadas.ContainsKey(row.Index) && _filasEditadas[row.Index] == true)
                {
                    var celdaNota = row.Cells["Nota"].Value;
                    int idEstudiante = (int)row.Cells["IdEstudiante"].Value;
                    var alumno = _listaActual.First(a => a.IdEstudiante == idEstudiante);

                    if (celdaNota != null && !string.IsNullOrWhiteSpace(celdaNota.ToString()))
                    {
                        string strValor = celdaNota.ToString().Replace(",", ".");
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
                btnCargar.PerformClick(); // Recarga limpia
            }
            else
            {
                MessageBox.Show(resultado.mensaje, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}