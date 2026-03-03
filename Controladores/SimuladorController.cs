using System;
using System.Collections.Generic;
using System.Linq;
using Academico.Config;
using Academico.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Academico.Controladores
{
    public class SimuladorController
    {
        // DTO para manejar la fila de simulación
        public class DetalleSimulacionDTO
        {
            public int IdEvaluacion { get; set; }
            public int IdTipoEvaluacion { get; set; } // CRÍTICO: 1=EF1, 2=EP1, 3=EF2, 4=EP2, 5=Final, 6=Remedial
            public string EvaluacionInfo { get; set; }
            public decimal? NotaReal { get; set; }
            public decimal NotaSimulada { get; set; }
            public string NotaSimuladaUI { get; set; } // PUENTE UX: Para que el usuario escriba libremente (Ej: "8,5")
        }

        // Obtener el ID del estudiante a partir del ID de Usuario actual
        public int ObtenerIdEstudianteActual()
        {
            using (var _context = new SistemaAcademicoContext())
            {
                var estudiante = _context.Estudiantes.FirstOrDefault(e => e.IdUsuario == Program.usuarioActualId);
                return estudiante != null ? estudiante.IdEstudiante : 0;
            }
        }

        // Para TESTING del Admin: Obtener el primer estudiante activo
        public int ObtenerPrimerEstudianteParaTesting()
        {
            using (var _context = new SistemaAcademicoContext())
            {
                var est = _context.Estudiantes.FirstOrDefault(e => e.Estado == true);
                return est != null ? est.IdEstudiante : 0;
            }
        }

        // Obtener los periodos donde el estudiante está matriculado
        public List<Periodoacademico> ObtenerPeriodosDelEstudiante(int idEstudiante)
        {
            using (var _context = new SistemaAcademicoContext())
            {
                var idPeriodos = _context.Matriculas
                    .Where(m => m.IdEstudiante == idEstudiante)
                    .Select(m => m.IdPeriodo)
                    .Distinct()
                    .ToList();

                return _context.Periodoacademicos
                    .Where(p => idPeriodos.Contains(p.IdPeriodo) && p.Estado == "Activo")
                    .OrderByDescending(p => p.FechaInicio)
                    .ToList();
            }
        }

        // Obtener asignaturas matriculadas en un periodo
        public List<Asignatura> ObtenerAsignaturasDelEstudiante(int idEstudiante, int idPeriodo)
        {
            using (var _context = new SistemaAcademicoContext())
            {
                var idAsignaturas = _context.Matriculas
                    .Where(m => m.IdEstudiante == idEstudiante && m.IdPeriodo == idPeriodo)
                    .Select(m => m.IdAsignatura)
                    .ToList();

                return _context.Asignaturas
                    .Where(a => idAsignaturas.Contains(a.IdAsignatura))
                    .OrderBy(a => a.Nombre)
                    .ToList();
            }
        }

        // OBTENER EL MODELO ESTRUCTURAL DE EVALUACIONES PARA MONTECARLO
        public List<DetalleSimulacionDTO> ObtenerDatosSimulacion(int idEstudiante, int idAsignatura, int idPeriodo)
        {
            using (var _context = new SistemaAcademicoContext())
            {
                // 1. Traer todas las evaluaciones de esa asignatura/periodo
                var evaluaciones = _context.Evaluacions
                    .Where(e => e.IdAsignatura == idAsignatura && e.IdPeriodo == idPeriodo)
                    .OrderBy(e => e.IdTipoEvaluacion) // Ordenamos lógicamente: EF1, EP1, EF2...
                    .ToList();

                // 2. Traer las calificaciones reales (ya ingresadas por el docente)
                var notasReales = _context.Calificacions
                    .Where(c => c.IdEstudiante == idEstudiante && c.Activo == true)
                    .ToList();

                var listaSimulacion = new List<DetalleSimulacionDTO>();

                foreach (var eval in evaluaciones)
                {
                    var notaRealObj = notasReales.FirstOrDefault(n => n.IdEvaluacion == eval.IdEvaluacion);
                    decimal? notaReal = notaRealObj?.Nota;

                    // Valor inicial de la simulación
                    decimal notaInicialSimulacion = notaReal ?? 0;

                    listaSimulacion.Add(new DetalleSimulacionDTO
                    {
                        IdEvaluacion = eval.IdEvaluacion,
                        IdTipoEvaluacion = eval.IdTipoEvaluacion, // Asignamos la llave maestra del reglamento
                        EvaluacionInfo = eval.Descripcion,
                        NotaReal = notaReal,
                        NotaSimulada = notaInicialSimulacion,
                        // Formateamos visualmente para la grilla usando cultura neutral (punto)
                        NotaSimuladaUI = notaInicialSimulacion.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)
                    });
                }

                return listaSimulacion;
            }
        }
    }
}