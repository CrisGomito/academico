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
    public class MatriculasController
    {
        // Clase auxiliar (DTO) para mostrar los datos cruzados en la Vista
        public class MatriculaDTO
        {
            public int IdMatricula { get; set; }
            public string EstudianteInfo { get; set; }
            public string AsignaturaNombre { get; set; }
            public string PeriodoNombre { get; set; }
            public string DisplayInfo => $"{EstudianteInfo} - {AsignaturaNombre} ({PeriodoNombre})";
        }

        // 1. Obtener todas las matrículas con sus relaciones (Join)
        public List<MatriculaDTO> ObtenerMatriculas()
        {
            using (var _context = new SistemaAcademicoContext())
            {
                return _context.Matriculas
                    .Include(m => m.IdEstudianteNavigation).ThenInclude(e => e.IdUsuarioNavigation)
                    .Include(m => m.IdAsignaturaNavigation)
                    .Include(m => m.IdPeriodoNavigation)
                    .Select(m => new MatriculaDTO
                    {
                        IdMatricula = m.IdMatricula,
                        EstudianteInfo = $"[{m.IdEstudianteNavigation.Codigo}] {m.IdEstudianteNavigation.IdUsuarioNavigation.Nombre} {m.IdEstudianteNavigation.IdUsuarioNavigation.Apellido}",
                        AsignaturaNombre = m.IdAsignaturaNavigation.Nombre,
                        PeriodoNombre = m.IdPeriodoNavigation.Nombre
                    })
                    .ToList();
            }
        }

        // 2. Obtener datos para llenar los ComboBox
        public List<VistaEstudiantesAdmin> ObtenerEstudiantesActivos()
        {
            using (var _context = new SistemaAcademicoContext())
            {
                return _context.VistaEstudiantesAdmins.Where(e => e.Estado == true).OrderBy(e => e.Nombre).ToList();
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

        // 3. Insertar Matrícula
        public (bool exito, string mensaje) AgregarMatricula(int idEstudiante, int idAsignatura, int idPeriodo)
        {
            try
            {
                using (var _context = new SistemaAcademicoContext())
                {
                    _context.Database.ExecuteSqlRaw(
                        "CALL sp_insertar_matricula({0}, {1}, {2}, {3}, {4}, {5})",
                        Program.usuarioActualId,
                        Program.rolId,
                        idEstudiante,
                        idAsignatura,
                        idPeriodo,
                        GetLocalIPAddress()
                    );
                    return (true, "Matrícula registrada con éxito.");
                }
            }
            catch (Exception ex)
            {
                // Si salta la restricción UNIQUE KEY de tu base de datos
                if (ex.InnerException != null && ex.InnerException.Message.Contains("Duplicate entry"))
                {
                    return (false, "El estudiante ya se encuentra matriculado en esta asignatura para el periodo seleccionado.");
                }
                return (false, "Error al registrar la matrícula.");
            }
        }

        // 4. Eliminar Matrícula
        public bool EliminarMatricula(int idMatricula)
        {
            try
            {
                using (var _context = new SistemaAcademicoContext())
                {
                    _context.Database.ExecuteSqlRaw(
                        "CALL sp_eliminar_matricula({0}, {1}, {2}, {3})",
                        Program.usuarioActualId,
                        Program.rolId,
                        idMatricula,
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