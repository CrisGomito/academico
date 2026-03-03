using System;
using System.Collections.Generic;
using System.Linq;
using Academico.Config;
using Academico.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Academico.Controladores
{
    public class DashboardController
    {
        public class EstudianteRendimientoDTO
        {
            public string Codigo { get; set; }
            public string Estudiante { get; set; }
            public decimal PromedioActual { get; set; }
            public decimal NotaRequerida { get; set; } // LO QUE NECESITA SACAR PARA APROBAR
            public string Prediccion { get; set; }
        }

        public int ObtenerIdDocenteActual()
        {
            using (var _context = new SistemaAcademicoContext())
            {
                var docente = _context.Docentes.FirstOrDefault(d => d.IdUsuario == Program.usuarioActualId);
                return docente != null ? docente.IdDocente : 0;
            }
        }

        public List<Periodoacademico> ObtenerPeriodos(int idDocente)
        {
            using (var _context = new SistemaAcademicoContext())
            {
                if (idDocente == 0)
                {
                    return _context.Periodoacademicos.Where(p => p.Estado == "Activo").OrderByDescending(p => p.FechaInicio).ToList();
                }

                var idPeriodos = _context.Asignaciondocentes.Where(a => a.IdDocente == idDocente).Select(a => a.IdPeriodo).Distinct().ToList();
                return _context.Periodoacademicos.Where(p => idPeriodos.Contains(p.IdPeriodo) && p.Estado == "Activo").OrderByDescending(p => p.FechaInicio).ToList();
            }
        }

        public List<Asignatura> ObtenerAsignaturas(int idDocente, int idPeriodo)
        {
            using (var _context = new SistemaAcademicoContext())
            {
                if (idDocente == 0)
                {
                    var idAsignaturasAdmin = _context.Asignaciondocentes.Where(a => a.IdPeriodo == idPeriodo).Select(a => a.IdAsignatura).Distinct().ToList();
                    return _context.Asignaturas.Where(a => idAsignaturasAdmin.Contains(a.IdAsignatura)).OrderBy(a => a.Nombre).ToList();
                }

                var idAsignaturas = _context.Asignaciondocentes.Where(a => a.IdDocente == idDocente && a.IdPeriodo == idPeriodo).Select(a => a.IdAsignatura).ToList();
                return _context.Asignaturas.Where(a => idAsignaturas.Contains(a.IdAsignatura)).OrderBy(a => a.Nombre).ToList();
            }
        }

        // MODELO DE BÚSQUEDA DE META (GOAL-SEEKING)
        public List<EstudianteRendimientoDTO> AnalizarRendimiento(int idAsignatura, int idPeriodo)
        {
            using (var _context = new SistemaAcademicoContext())
            {
                var listaResultados = new List<EstudianteRendimientoDTO>();

                var matriculados = _context.Matriculas
                    .Include(m => m.IdEstudianteNavigation).ThenInclude(e => e.IdUsuarioNavigation)
                    .Where(m => m.IdAsignatura == idAsignatura && m.IdPeriodo == idPeriodo)
                    .ToList();

                var evaluaciones = _context.Evaluacions
                    .Where(e => e.IdAsignatura == idAsignatura && e.IdPeriodo == idPeriodo)
                    .ToList();

                if (evaluaciones.Count == 0 || matriculados.Count == 0) return listaResultados;

                var idEvaluaciones = evaluaciones.Select(e => e.IdEvaluacion).ToList();
                var calificacionesMatriz = _context.Calificacions
                    .Where(c => idEvaluaciones.Contains(c.IdEvaluacion) && c.Activo == true)
                    .ToList();

                foreach (var mat in matriculados)
                {
                    var est = mat.IdEstudianteNavigation;

                    decimal? ef1 = GetNota(calificacionesMatriz, evaluaciones, est.IdEstudiante, 1);
                    decimal? ep1 = GetNota(calificacionesMatriz, evaluaciones, est.IdEstudiante, 2);
                    decimal? ef2 = GetNota(calificacionesMatriz, evaluaciones, est.IdEstudiante, 3);
                    decimal? ep2 = GetNota(calificacionesMatriz, evaluaciones, est.IdEstudiante, 4);
                    decimal? exf = GetNota(calificacionesMatriz, evaluaciones, est.IdEstudiante, 5);

                    // Calculamos los parciales completados
                    decimal p1 = ((ef1 ?? 0) + (ep1 ?? 0)) / (ef1.HasValue || ep1.HasValue ? (ef1.HasValue && ep1.HasValue ? 2m : 1m) : 1m);
                    decimal p2 = ((ef2 ?? 0) + (ep2 ?? 0)) / (ef2.HasValue || ep2.HasValue ? (ef2.HasValue && ep2.HasValue ? 2m : 1m) : 1m);

                    // Promedio actual para la UI
                    int notasRegistradas = (ef1.HasValue || ep1.HasValue ? 1 : 0) + (ef2.HasValue || ep2.HasValue ? 1 : 0) + (exf.HasValue ? 1 : 0);
                    decimal promedioActual = notasRegistradas > 0 ? (p1 * (ef1.HasValue || ep1.HasValue ? 1 : 0) + p2 * (ef2.HasValue || ep2.HasValue ? 1 : 0) + (exf ?? 0)) / notasRegistradas : 0;

                    // LÓGICA DE EXIGENCIA (Necesita llegar a 21 puntos en total)
                    decimal puntosActuales = (ef1.HasValue || ep1.HasValue ? p1 : 0) + (ef2.HasValue || ep2.HasValue ? p2 : 0) + (exf ?? 0);
                    int evaluacionesFaltantes = 3 - notasRegistradas;

                    decimal notaRequeridaPromedio = 0;
                    string estadoPrediccion = "EN CURSO";

                    if (evaluacionesFaltantes > 0)
                    {
                        // ¿Cuántos puntos le faltan para llegar a 21?
                        decimal puntosFaltantes = 21m - puntosActuales;
                        notaRequeridaPromedio = puntosFaltantes / evaluacionesFaltantes;

                        // REGLA DEL 7: Si solo le falta el Examen Final, DEBE sacar al menos 7 aunque matemáticamente necesite menos
                        if (evaluacionesFaltantes == 1 && !exf.HasValue)
                        {
                            notaRequeridaPromedio = Math.Max(notaRequeridaPromedio, 7.0m);
                        }

                        // Clasificamos el nivel de riesgo según lo que necesita sacar
                        if (notaRequeridaPromedio > 10m)
                            estadoPrediccion = "REMEDIAL INMINENTE"; // No le alcanza ni con 10
                        else if (notaRequeridaPromedio >= 8.5m)
                            estadoPrediccion = "ALTO RIESGO"; // Necesita notas casi perfectas
                        else if (notaRequeridaPromedio >= 7.0m)
                            estadoPrediccion = "RIESGO MODERADO"; // Necesita mantener el mínimo
                        else
                            estadoPrediccion = "BUEN RENDIMIENTO"; // Va sobrado
                    }
                    else
                    {
                        // Ya terminó todas las notas
                        if (promedioActual >= 7.0m && (exf ?? 0) >= 7.0m)
                            estadoPrediccion = "APROBADO";
                        else
                            estadoPrediccion = "REPROBADO / REMEDIAL";
                    }

                    listaResultados.Add(new EstudianteRendimientoDTO
                    {
                        Codigo = est.Codigo,
                        Estudiante = $"{est.IdUsuarioNavigation.Apellido} {est.IdUsuarioNavigation.Nombre}",
                        PromedioActual = Math.Round(promedioActual, 2),
                        // Si ya terminó, la nota requerida es 0
                        NotaRequerida = evaluacionesFaltantes == 0 ? 0 : Math.Round(notaRequeridaPromedio, 2),
                        Prediccion = estadoPrediccion
                    });
                }

                return listaResultados.OrderBy(r => r.Estudiante).ToList();
            }
        }

        private decimal? GetNota(List<Calificacion> califs, List<Evaluacion> evals, int idEst, int tipoEval)
        {
            var eval = evals.FirstOrDefault(e => e.IdTipoEvaluacion == tipoEval);
            if (eval == null) return null;
            var c = califs.FirstOrDefault(x => x.IdEstudiante == idEst && x.IdEvaluacion == eval.IdEvaluacion);
            return c?.Nota;
        }
    }
}