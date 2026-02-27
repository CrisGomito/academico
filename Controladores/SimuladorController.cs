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
            public string EvaluacionInfo { get; set; }
            public decimal PesoPorcentaje { get; set; }
            public decimal? NotaReal { get; set; }
            public decimal NotaSimulada { get; set; }
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

        // OBTENER EL MODELO MATEMÁTICO (Las evaluaciones y sus pesos)
        public List<DetalleSimulacionDTO> ObtenerDatosSimulacion(int idEstudiante, int idAsignatura, int idPeriodo)
        {
            using (var _context = new SistemaAcademicoContext())
            {
                // 1. Traer todas las evaluaciones de esa asignatura/periodo
                var evaluaciones = _context.Evaluacions
                    .Include(e => e.IdTipoEvaluacionNavigation)
                    .Where(e => e.IdAsignatura == idAsignatura && e.IdPeriodo == idPeriodo)
                    .ToList();

                // 2. Traer las calificaciones reales del estudiante
                var notasReales = _context.Calificacions
                    .Where(c => c.IdEstudiante == idEstudiante && c.Activo == true)
                    .ToList();

                var listaSimulacion = new List<DetalleSimulacionDTO>();

                foreach (var eval in evaluaciones)
                {
                    var notaRealObj = notasReales.FirstOrDefault(n => n.IdEvaluacion == eval.IdEvaluacion);
                    decimal? notaReal = notaRealObj?.Nota;

                    listaSimulacion.Add(new DetalleSimulacionDTO
                    {
                        IdEvaluacion = eval.IdEvaluacion,
                        EvaluacionInfo = $"{eval.IdTipoEvaluacionNavigation.Nombre} - {eval.Descripcion}",
                        PesoPorcentaje = eval.IdTipoEvaluacionNavigation.Peso,
                        NotaReal = notaReal,
                        // Si hay nota real, la simulada inicia con ese valor, si no, inicia en 0
                        NotaSimulada = notaReal ?? 0
                    });
                }

                return listaSimulacion;
            }
        }
    }
}