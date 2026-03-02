namespace Academico.Controladores
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Academico.Config;
    using Academico.Modelos;

    public class AuditoriaDetalladaController
    {
        // 1. Obtener todo el historial detallado del año en curso
        public List<VistaAuditoriaActual> ObtenerAuditoriaDetallada()
        {
            using (var _context = new SistemaAcademicoContext())
            {
                return _context.VistaAuditoriaActuals
                    .OrderByDescending(a => a.Fecha)
                    .ToList();
            }
        }

        // 2. Método de filtrado múltiple
        public List<VistaAuditoriaActual> FiltrarAuditoriaDetallada(string busqueda)
        {
            using (var _context = new SistemaAcademicoContext())
            {
                return _context.VistaAuditoriaActuals
                    .Where(a =>
                        (a.UsuarioNombre != null && a.UsuarioNombre.Contains(busqueda)) ||
                        (a.Accion != null && a.Accion.Contains(busqueda)) ||
                        (a.TablaAfectada != null && a.TablaAfectada.Contains(busqueda)) ||
                        (a.ValorAnterior != null && a.ValorAnterior.Contains(busqueda)) ||
                        (a.ValorNuevo != null && a.ValorNuevo.Contains(busqueda))
                    )
                    .OrderByDescending(a => a.Fecha)
                    .ToList();
            }
        }
    }
}