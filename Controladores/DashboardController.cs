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
        // DTO para la tabla de Predicción
        public class EstudianteRendimientoDTO
        {
            public string Codigo { get; set; }
            public string Estudiante { get; set; }
            public decimal PromedioActual { get; set; }
            public decimal NotaMaximaPosible { get; set; }
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

        // Obtener Periodos (Igual que en calificaciones, con Bypass para Admin/Coordinador)
        public List<Periodoacademico> ObtenerPeriodos(int idDocente)
        {
            using (var _context = new SistemaAcademicoContext())
            {
                if (idDocente == 0) // Admin o Coordinador
                {
                    return _context.Periodoacademicos.Where(p => p.Estado == "Activo").OrderByDescending(p => p.FechaInicio).ToList();
                }

                var idPeriodos = _context.Asignaciondocentes.Where(a => a.IdDocente == idDocente).Select(a => a.IdPeriodo).Distinct().ToList();
                return _context.Periodoacademicos.Where(p => idPeriodos.Contains(p.IdPeriodo) && p.Estado == "Activo").OrderByDescending(p => p.FechaInicio).ToList();
            }
        }

        // Obtener Asignaturas
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

        // EL ALGORITMO DE PREDICCIÓN
        public List<EstudianteRendimientoDTO> AnalizarRendimiento(int idAsignatura, int idPeriodo)
        {
            using (var _context = new SistemaAcademicoContext())
            {
                var listaResultados = new List<EstudianteRendimientoDTO>();

                // 1. Obtener todos los alumnos matriculados
                var matriculados = _context.Matriculas
                    .Include(m => m.IdEstudianteNavigation).ThenInclude(e => e.IdUsuarioNavigation)
                    .Where(m => m.IdAsignatura == idAsignatura && m.IdPeriodo == idPeriodo)
                    .ToList();

                // 2. Obtener la estructura de evaluaciones y sus pesos
                var evaluaciones = _context.Evaluacions
                    .Include(e => e.IdTipoEvaluacionNavigation)
                    .Where(e => e.IdAsignatura == idAsignatura && e.IdPeriodo == idPeriodo)
                    .ToList();

                if (evaluaciones.Count == 0 || matriculados.Count == 0) return listaResultados;

                decimal pesoTotalConfigurado = evaluaciones.Sum(e => e.IdTipoEvaluacionNavigation.Peso);

                // 3. Traer todas las calificaciones de esa asignatura en ese periodo
                var idEvaluaciones = evaluaciones.Select(e => e.IdEvaluacion).ToList();
                var calificacionesMatriz = _context.Calificacions
                    .Where(c => idEvaluaciones.Contains(c.IdEvaluacion) && c.Activo == true)
                    .ToList();

                // 4. Procesar matemáticamente estudiante por estudiante
                foreach (var mat in matriculados)
                {
                    var est = mat.IdEstudianteNavigation;
                    decimal promedioActual = 0;
                    decimal pesoEvaluado = 0;

                    foreach (var eval in evaluaciones)
                    {
                        var notaObj = calificacionesMatriz.FirstOrDefault(c => c.IdEstudiante == est.IdEstudiante && c.IdEvaluacion == eval.IdEvaluacion);
                        decimal pesoEval = eval.IdTipoEvaluacionNavigation.Peso;

                        if (notaObj != null)
                        {
                            promedioActual += notaObj.Nota * (pesoEval / 100m);
                            pesoEvaluado += pesoEval;
                        }
                    }

                    decimal pesoFaltante = 100m - pesoEvaluado;

                    // ¿Qué pasa si saca 10 en todo lo que le falta?
                    decimal notaMaximaPosible = promedioActual + (10m * (pesoFaltante / 100m));

                    string estadoPrediccion = "BUEN RENDIMIENTO";

                    if (notaMaximaPosible < 7.0m)
                    {
                        estadoPrediccion = "REPROBADO MATEMÁTICAMENTE";
                    }
                    else if (promedioActual < 4.0m && pesoFaltante < 50m) // Si tiene baja nota y ya pasó más de la mitad del curso
                    {
                        estadoPrediccion = "ALTO RIESGO";
                    }
                    else if (promedioActual < 6.0m && pesoEvaluado > 0)
                    {
                        estadoPrediccion = "EN RIESGO";
                    }
                    else if (promedioActual >= 7.0m)
                    {
                        estadoPrediccion = "APROBADO";
                    }

                    listaResultados.Add(new EstudianteRendimientoDTO
                    {
                        Codigo = est.Codigo,
                        Estudiante = $"{est.IdUsuarioNavigation.Apellido} {est.IdUsuarioNavigation.Nombre}",
                        PromedioActual = Math.Round(promedioActual, 2),
                        NotaMaximaPosible = Math.Round(notaMaximaPosible, 2),
                        Prediccion = estadoPrediccion
                    });
                }

                return listaResultados.OrderBy(r => r.Estudiante).ToList();
            }
        }
    }
}