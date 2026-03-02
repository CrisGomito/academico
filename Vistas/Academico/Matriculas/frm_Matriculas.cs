namespace DataBase_First.Views.Academico.Matriculas
{
    using global::Academico.Controladores;
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using FontAwesome.Sharp;

    public partial class frm_Matriculas : Form
    {
        private readonly MatriculasController _matriculasController = new MatriculasController();

        public frm_Matriculas()
        {
            InitializeComponent();
        }

        private void frm_Matriculas_Load(object sender, EventArgs e)
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
            // Cargar Estudiantes
            var estudiantes = _matriculasController.ObtenerEstudiantesActivos()
                .Select(e => new { e.IdEstudiante, NombreCombo = $"[{e.Codigo}] {e.Nombre} {e.Apellido}" }).ToList();
            cmb_Estudiante.DataSource = estudiantes;
            cmb_Estudiante.DisplayMember = "NombreCombo";
            cmb_Estudiante.ValueMember = "IdEstudiante";
            cmb_Estudiante.SelectedIndex = -1;

            // Cargar Asignaturas
            var asignaturas = _matriculasController.ObtenerAsignaturas();
            cmb_Asignatura.DataSource = asignaturas;
            cmb_Asignatura.DisplayMember = "Nombre";
            cmb_Asignatura.ValueMember = "IdAsignatura";
            cmb_Asignatura.SelectedIndex = -1;

            // Cargar Periodos Activos
            var periodos = _matriculasController.ObtenerPeriodosActivos();
            cmb_Periodo.DataSource = periodos;
            cmb_Periodo.DisplayMember = "Nombre";
            cmb_Periodo.ValueMember = "IdPeriodo";
            cmb_Periodo.SelectedIndex = -1;
        }

        private void carga_lista()
        {
            var listaMatriculas = _matriculasController.ObtenerMatriculas();

            lst_Lista_Matriculas.DataSource = listaMatriculas;
            lst_Lista_Matriculas.DisplayMember = "DisplayInfo";
            lst_Lista_Matriculas.ValueMember = "IdMatricula";
        }

        // --- MÉTODO CORREGIDO PARA RELLENAR DATOS EN DOBLE CLIC (SOLO LECTURA) ---
        private void lst_Lista_Matriculas_DoubleClick(object sender, EventArgs e)
        {
            if (lst_Lista_Matriculas.SelectedValue == null) return;

            int idMatricula = (int)lst_Lista_Matriculas.SelectedValue;

            // Obtenemos la matrícula DTO de la lista cargada
            var matricula = _matriculasController.ObtenerMatriculas().FirstOrDefault(m => m.IdMatricula == idMatricula);

            if (matricula != null)
            {
                // Limpiamos la UI pero mantenemos los controles bloqueados (modo vista)
                LimpiarCampos(true);

                // IMPORTANTE: Como el DTO trae los nombres (Strings) y no los IDs, usamos .Text 
                // para que el ComboBox seleccione automáticamente el item que coincida con el texto.
                cmb_Estudiante.Text = matricula.EstudianteInfo;
                cmb_Asignatura.Text = matricula.AsignaturaNombre;
                cmb_Periodo.Text = matricula.PeriodoNombre;

                // Forzamos a que sigan bloqueados (Solo lectura)
                cmb_Estudiante.Enabled = false;
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

            int idEstudiante = (int)cmb_Estudiante.SelectedValue;
            int idAsignatura = (int)cmb_Asignatura.SelectedValue;
            int idPeriodo = (int)cmb_Periodo.SelectedValue;

            var resultado = _matriculasController.AgregarMatricula(idEstudiante, idAsignatura, idPeriodo);

            if (resultado.exito)
            {
                MessageBox.Show(resultado.mensaje, "Gestión Académica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos(true);
                carga_lista();
            }
            else
            {
                MessageBox.Show(resultado.mensaje, "Validación de Matrícula", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public bool verificarCampos()
        {
            if (cmb_Estudiante.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un Estudiante.");
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
            cmb_Estudiante.SelectedIndex = -1;
            cmb_Asignatura.SelectedIndex = -1;
            cmb_Periodo.SelectedIndex = -1;

            if (bloquearCajas)
            {
                btn_Nuevo.Enabled = true;
                lst_Lista_Matriculas.Enabled = true;
                btn_Eliminar.Enabled = true;

                btn_Guardar.Enabled = false;
                btn_Cancelar.Enabled = false;

                cmb_Estudiante.Enabled = false;
                cmb_Asignatura.Enabled = false;
                cmb_Periodo.Enabled = false;
            }
        }

        public void activacajas()
        {
            btn_Nuevo.Enabled = false;
            lst_Lista_Matriculas.Enabled = false;
            btn_Eliminar.Enabled = false;

            btn_Guardar.Enabled = true;
            btn_Cancelar.Enabled = true;

            cmb_Estudiante.Enabled = true;
            cmb_Asignatura.Enabled = true;
            cmb_Periodo.Enabled = true;
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (lst_Lista_Matriculas.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione una matrícula del listado para eliminarla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var idMatricula = (int)lst_Lista_Matriculas.SelectedValue;

            var confirmResult = MessageBox.Show("¿Está seguro de que desea anular esta matrícula?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                var resultado = _matriculasController.EliminarMatricula(idMatricula);

                if (resultado)
                {
                    MessageBox.Show("La matrícula ha sido eliminada con éxito.", "Gestión Académica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    carga_lista();
                    LimpiarCampos(true); // Limpia la vista si se eliminó la que estaba seleccionada
                }
                else
                {
                    MessageBox.Show("Error al eliminar la matrícula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}