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

        // 2. Método de filtrado múltiple (incluyendo la fecha)
        public List<VistaAuditoriaActual> FiltrarAuditoriaDetallada(string busqueda)
        {
            using (var _context = new SistemaAcademicoContext())
            {
                // Traemos los datos a memoria primero (es seguro porque la vista limita al año actual)
                var datos = _context.VistaAuditoriaActuals.ToList();

                busqueda = busqueda.ToLower();

                return datos.Where(a =>
                {
                    // Convertimos la fecha a string de forma segura, validando si es nula o no
                    string fechaFormateada = a.Fecha != null ? Convert.ToDateTime(a.Fecha).ToString("dd/MM/yyyy HH:mm:ss") : "";

                    return (a.UsuarioNombre != null && a.UsuarioNombre.ToLower().Contains(busqueda)) ||
                           (a.Accion != null && a.Accion.ToLower().Contains(busqueda)) ||
                           (a.TablaAfectada != null && a.TablaAfectada.ToLower().Contains(busqueda)) ||
                           (a.ValorAnterior != null && a.ValorAnterior.ToLower().Contains(busqueda)) ||
                           (a.ValorNuevo != null && a.ValorNuevo.ToLower().Contains(busqueda)) ||
                           fechaFormateada.Contains(busqueda); // Evaluamos la fecha formateada
                })
                .OrderByDescending(a => a.Fecha)
                .ToList();
            }
        }
    }
}