using Academico.Config;
using Academico.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Academico.Controladores
{
    public class ReportesController
    {
        // Reporte 1: Rendimiento Académico Estudiantil (Filtrado por Rol)
        public List<VistaReporteAcademico> ObtenerReporteAcademico()
        {
            using (var _context = new SistemaAcademicoContext())
            {
                var query = _context.VistaReporteAcademicos.AsQueryable();

                // Filtro para Estudiante: Solo ve sus propias notas
                if (Program.rolId == 3)
                {
                    // Buscamos el IdEstudiante asociado al usuario logueado
                    var est = _context.Estudiantes.FirstOrDefault(e => e.IdUsuario == Program.usuarioActualId);
                    if (est != null)
                    {
                        query = query.Where(r => r.IdEstudiante == est.IdEstudiante);
                    }
                }
                // Filtro para Docente: Solo ve los alumnos de sus materias
                else if (Program.rolId == 2)
                {
                    var doc = _context.Docentes.FirstOrDefault(d => d.IdUsuario == Program.usuarioActualId);
                    if (doc != null)
                    {
                        // Extraemos los IDs de las materias que dicta este docente
                        var idAsignaturas = _context.Asignaciondocentes
                                            .Where(a => a.IdDocente == doc.IdDocente)
                                            .Select(a => a.IdAsignatura)
                                            .ToList();

                        // Traemos los nombres de las asignaturas (porque la vista usa nombres, no IDs)
                        var nombresAsignaturas = _context.Asignaturas
                                                 .Where(a => idAsignaturas.Contains(a.IdAsignatura))
                                                 .Select(a => a.Nombre)
                                                 .ToList();

                        // Filtramos el reporte
                        query = query.Where(r => nombresAsignaturas.Contains(r.Asignatura));
                    }
                }
                // Si es Admin (1) o Coordinador (4), no aplicamos filtro (ven todo)

                return query
                    .OrderBy(r => r.Asignatura)
                    .ThenBy(r => r.Apellidos)
                    .ToList();
            }
        }

        // Reporte 2: Historial de Accesos (Auditoría de Seguridad)
        public List<VistaLoginSeguridadActual> ObtenerReporteAccesos()
        {
            using (var _context = new SistemaAcademicoContext())
            {
                return _context.VistaLoginSeguridadActuals
                    .OrderByDescending(r => r.FechaIngreso)
                    .ToList();
            }
        }

        // NUEVO MÉTODO: Obtener el Nombre Completo para la firma del PDF
        public string ObtenerNombreCompletoUsuarioActual()
        {
            using (var _context = new SistemaAcademicoContext())
            {
                var usuario = _context.Usuarios.FirstOrDefault(u => u.IdUsuario == Program.usuarioActualId);
                if (usuario != null)
                {
                    return $"{usuario.Nombre} {usuario.Apellido}";
                }
                return Program.nombreUsuario; // Retorno de seguridad por si no lo encuentra
            }
        }
    }
}