using System.Collections.Generic;
using System.Linq;
using Academico.Config;
using Academico.Modelos;

namespace Academico.Controladores
{
    public class AuditoriaController
    {
        // Obtener todo el historial, ordenado del más reciente al más antiguo
        public List<VistaHistorialAuditorium> ObtenerHistorial()
        {
            using (var _context = new SistemaAcademicoContext())
            {
                return _context.VistaHistorialAuditoria
                    .OrderByDescending(a => a.Fecha)
                    .ToList();
            }
        }

        // Método opcional para filtrar si la lista crece mucho
        public List<VistaHistorialAuditorium> FiltrarHistorial(string busqueda)
        {
            using (var _context = new SistemaAcademicoContext())
            {
                return _context.VistaHistorialAuditoria
                    .Where(a => a.UsuarioNombre.Contains(busqueda) ||
                                a.Accion.Contains(busqueda) ||
                                a.TablaAfectada.Contains(busqueda))
                    .OrderByDescending(a => a.Fecha)
                    .ToList();
            }
        }
    }
}
