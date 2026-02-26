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
    public class AsignaturasController
    {
        // 1. Obtener lista de asignaturas
        public List<Asignatura> ObtenerAsignaturas()
        {
            using (var _context = new SistemaAcademicoContext())
            {
                return _context.Asignaturas
                    .OrderBy(a => a.Nombre)
                    .ToList();
            }
        }

        public Asignatura ObtenerAsignaturaPorId(int id)
        {
            using (var _context = new SistemaAcademicoContext())
            {
                return _context.Asignaturas.FirstOrDefault(a => a.IdAsignatura == id);
            }
        }

        // 2. Insertar Asignatura (Llamando al SP)
        public bool AgregarAsignatura(string nombre, int creditos)
        {
            try
            {
                using (var _context = new SistemaAcademicoContext())
                {
                    _context.Database.ExecuteSqlRaw(
                        "CALL sp_insertar_asignatura({0}, {1}, {2}, {3}, {4})",
                        Program.usuarioActualId,
                        Program.rolId,
                        nombre,
                        (byte)creditos, // El SP espera TINYINT
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

        // 3. Actualizar Asignatura (Llamando al SP)
        public bool ActualizarAsignatura(int idAsignatura, string nombre, int creditos)
        {
            try
            {
                using (var _context = new SistemaAcademicoContext())
                {
                    _context.Database.ExecuteSqlRaw(
                        "CALL sp_actualizar_asignatura({0}, {1}, {2}, {3}, {4}, {5})",
                        Program.usuarioActualId,
                        Program.rolId,
                        idAsignatura,
                        nombre,
                        (byte)creditos,
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

        // 4. Eliminar Asignatura (Físico - Protegido por FK)
        public (bool exito, string mensaje) EliminarAsignatura(int idAsignatura)
        {
            try
            {
                using (var _context = new SistemaAcademicoContext())
                {
                    var asignatura = _context.Asignaturas.Find(idAsignatura);
                    if (asignatura != null)
                    {
                        _context.Asignaturas.Remove(asignatura);
                        _context.SaveChanges();
                        return (true, "Asignatura eliminada con éxito.");
                    }
                    return (false, "La asignatura no existe.");
                }
            }
            catch (DbUpdateException)
            {
                // Este error salta automáticamente gracias a las llaves foráneas de tu SQL (ON UPDATE CASCADE / RESTRICT)
                return (false, "No se puede eliminar esta asignatura porque ya tiene matrículas, evaluaciones o docentes asignados.");
            }
            catch (Exception ex)
            {
                return (false, $"Error desconocido: {ex.Message}");
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