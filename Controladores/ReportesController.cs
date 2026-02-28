using Academico.Config;
using Academico.Modelos;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Academico.Controladores
{
    public class ReportesController
    {
        // Reporte 1: Rendimiento Académico Estudiantil
        public List<VistaReporteAcademico> ObtenerReporteAcademico()
        {
            using (var _context = new SistemaAcademicoContext())
            {
                return _context.VistaReporteAcademicos
                    .OrderBy(r => r.Asignatura)
                    .ThenBy(r => r.Apellidos)
                    .ToList();
            }
        }

        // Reporte 2: Historial de Accesos (Auditoría)
        public List<VistaLoginSeguridadActual> ObtenerReporteAccesos()
        {
            using (var _context = new SistemaAcademicoContext())
            {
                return _context.VistaLoginSeguridadActuals
                    .OrderByDescending(r => r.FechaIngreso)
                    .ToList();
            }
        }
    }
}