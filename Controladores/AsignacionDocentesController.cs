using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using Academico.Config;
using Academico.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Academico.Controladores
{
    public class AsignacionDocentesController
    {
        // Clase auxiliar (DTO) para mostrar los datos cruzados en la Vista
        public class AsignacionDTO
        {
            public int IdAsignacion { get; set; }
            public string DocenteInfo { get; set; }
            public string AsignaturaNombre { get; set; }
            public string PeriodoNombre { get; set; }
            public string DisplayInfo => $"{DocenteInfo} - {AsignaturaNombre} ({PeriodoNombre})";
        }

        // 1. Obtener todas las asignaciones con sus relaciones
        public List<AsignacionDTO> ObtenerAsignaciones()
        {
            using (var _context = new SistemaAcademicoContext())
            {
                return _context.Asignaciondocentes
                    .Include(a => a.IdDocenteNavigation).ThenInclude(d => d.IdUsuarioNavigation)
                    .Include(a => a.IdAsignaturaNavigation)
                    .Include(a => a.IdPeriodoNavigation)
                    .Select(a => new AsignacionDTO
                    {
                        IdAsignacion = a.IdAsignacion,
                        DocenteInfo = $"{a.IdDocenteNavigation.IdUsuarioNavigation.Nombre} {a.IdDocenteNavigation.IdUsuarioNavigation.Apellido}",
                        AsignaturaNombre = a.IdAsignaturaNavigation.Nombre,
                        PeriodoNombre = a.IdPeriodoNavigation.Nombre
                    })
                    .ToList();
            }
        }

        // 2. Obtener datos para llenar los ComboBox
        public List<VistaDocentesAdmin> ObtenerDocentesActivos()
        {
            using (var _context = new SistemaAcademicoContext())
            {
                return _context.VistaDocentesAdmins.Where(d => d.Estado == true).OrderBy(d => d.Nombre).ToList();
            }
        }

        public List<Asignatura> ObtenerAsignaturas()
        {
            using (var _context = new SistemaAcademicoContext())
            {
                return _context.Asignaturas.OrderBy(a => a.Nombre).ToList();
            }
        }

        public List<Periodoacademico> ObtenerPeriodosActivos()
        {
            using (var _context = new SistemaAcademicoContext())
            {
                return _context.Periodoacademicos.Where(p => p.Estado == "Activo").OrderByDescending(p => p.FechaInicio).ToList();
            }
        }

        // 3. Insertar Asignación (Usando Procedimiento Almacenado)
        public (bool exito, string mensaje) AgregarAsignacion(int idDocente, int idAsignatura, int idPeriodo)
        {
            try
            {
                using (var _context = new SistemaAcademicoContext())
                {
                    _context.Database.ExecuteSqlRaw(
                        "CALL sp_insertar_asignacion({0}, {1}, {2}, {3}, {4}, {5})",
                        Program.usuarioActualId,
                        Program.rolId,
                        idDocente,
                        idAsignatura,
                        idPeriodo,
                        GetLocalIPAddress()
                    );
                    return (true, "Asignación registrada con éxito.");
                }
            }
            catch (Exception ex)
            {
                // Si salta la restricción UNIQUE KEY (uk_asignacion_concurrencia) de la base de datos
                if (ex.InnerException != null && ex.InnerException.Message.Contains("Duplicate entry"))
                {
                    return (false, "El docente ya se encuentra asignado a esta asignatura en el periodo seleccionado.");
                }
                return (false, "Error al registrar la asignación. Verifique los datos.");
            }
        }

        // 4. Eliminar Asignación (Usando Procedimiento Almacenado)
        public bool EliminarAsignacion(int idAsignacion)
        {
            try
            {
                using (var _context = new SistemaAcademicoContext())
                {
                    _context.Database.ExecuteSqlRaw(
                        "CALL sp_eliminar_asignacion({0}, {1}, {2}, {3})",
                        Program.usuarioActualId,
                        Program.rolId,
                        idAsignacion,
                        GetLocalIPAddress()
                    );
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "127.0.0.1";
        }
    }
}