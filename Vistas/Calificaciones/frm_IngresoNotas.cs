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

        // Usamos un diccionario para rastrear qué filas fueron editadas para no enviar datos innecesarios
        private Dictionary<int, bool> _filasEditadas = new Dictionary<int, bool>();
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

            // Reseteamos el control de cambios
            _filasEditadas.Clear();
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

                dgvAlumnos.Columns["Nota"].HeaderText = "CALIFICACIÓN (0,00 - 10,00)"; // Modificado encabezado
                dgvAlumnos.Columns["Nota"].DefaultCellStyle.BackColor = Color.LightYellow;
                dgvAlumnos.Columns["Nota"].DefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                dgvAlumnos.Columns["Nota"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvAlumnos.Columns["Nota"].Width = 250;
            }
        }

        // Detecta qué filas fueron editadas realmente y si hubo un cambio (Incluso si escribió lo mismo)
        private void dgvAlumnos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvAlumnos.Columns[e.ColumnIndex].Name == "Nota")
            {
                _filasEditadas[e.RowIndex] = true;
                _hayCambiosSinGuardar = true;
            }
        }

        // Quita la alerta roja de la celda en cuanto el usuario corrige y sale de ella
        private void dgvAlumnos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvAlumnos.Columns[e.ColumnIndex].Name == "Nota")
            {
                // Limpia el mensaje de error temporalmente para ver si al guardar pasa
                dgvAlumnos.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = string.Empty;
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

            // 1. VALIDACIÓN PREVIA MASIVA
            foreach (DataGridViewRow row in dgvAlumnos.Rows)
            {
                // Solo validamos las filas que realmente intentó modificar el usuario
                if (_filasEditadas.ContainsKey(row.Index) && _filasEditadas[row.Index] == true)
                {
                    var celdaNota = row.Cells["Nota"].Value;

                    if (celdaNota != null && !string.IsNullOrWhiteSpace(celdaNota.ToString()))
                    {
                        string valorIngresado = celdaNota.ToString().Replace(".", ",");

                        if (!decimal.TryParse(valorIngresado, out decimal notaFinal) || notaFinal < 0 || notaFinal > 10)
                        {
                            // Le ponemos el icono rojo en la esquina de la celda
                            row.Cells["Nota"].ErrorText = "La nota debe ser un número válido entre 0 y 10 (Use coma para decimales).";
                            hayErrores = true;
                        }
                        else
                        {
                            row.Cells["Nota"].ErrorText = string.Empty;
                            row.Cells["Nota"].Value = notaFinal; // Normaliza la vista en caso de usar punto
                        }
                    }
                }
            }

            if (hayErrores)
            {
                MessageBox.Show("Se han encontrado formatos incorrectos en las casillas marcadas con el ícono rojo (!). Por favor, corríjalas antes de guardar.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Bloqueamos el guardado hasta que corrija
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
                        alumno.Nota = Convert.ToDecimal(celdaNota);
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
                btnCargar.PerformClick(); // Recargar para obtener los IDs nuevos insertados
            }
            else
            {
                MessageBox.Show(resultado.mensaje, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}