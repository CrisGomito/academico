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
    public class EstudiantesController
    {
        // 1. Obtener lista usando la vista
        public List<VistaEstudiantesAdmin> ObtenerEstudiantes()
        {
            using (var _context = new SistemaAcademicoContext())
            {
                return _context.VistaEstudiantesAdmins
                    .Where(e => e.Estado == true)
                    .OrderBy(e => e.Nombre)
                    .ToList();
            }
        }

        public VistaEstudiantesAdmin ObtenerEstudiantePorId(int id)
        {
            using (var _context = new SistemaAcademicoContext())
            {
                return _context.VistaEstudiantesAdmins.FirstOrDefault(e => e.IdEstudiante == id);
            }
        }

        // 2. Obtener usuarios que tienen ROL ESTUDIANTE (Rol = 3) pero que NO ESTÁN en la tabla estudiante
        public List<Usuario> ObtenerUsuariosParaNuevosEstudiantes()
        {
            using (var _context = new SistemaAcademicoContext())
            {
                var usuariosRolEstudiante = _context.Usuarios
                    .Include(u => u.UsuarioRols)
                    .Where(u => u.UsuarioRols.Any(ur => ur.IdRol == 3) && u.Estado == true)
                    .ToList();

                var idsEstudiantesActuales = _context.Estudiantes.Select(e => e.IdUsuario).ToList();

                return usuariosRolEstudiante.Where(u => !idsEstudiantesActuales.Contains(u.IdUsuario)).ToList();
            }
        }

        // 3. Insertar Estudiante
        public bool AgregarEstudiante(int idUsuario, string cedula, string codigo)
        {
            try
            {
                using (var _context = new SistemaAcademicoContext())
                {
                    _context.Database.ExecuteSqlRaw(
                        "CALL sp_insertar_estudiante({0}, {1}, {2}, {3}, {4}, {5})",
                        Program.usuarioActualId,
                        Program.rolId,
                        idUsuario,
                        cedula,
                        codigo,
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

        // 4. Actualizar Estudiante
        public bool ActualizarEstudiante(int idEstudiante, string cedula, string codigo, bool estado)
        {
            try
            {
                using (var _context = new SistemaAcademicoContext())
                {
                    byte estadoTiny = (byte)(estado ? 1 : 0);
                    _context.Database.ExecuteSqlRaw(
                        "CALL sp_actualizar_estudiante({0}, {1}, {2}, {3}, {4}, {5}, {6})",
                        Program.usuarioActualId,
                        Program.rolId,
                        idEstudiante,
                        cedula,
                        codigo,
                        estadoTiny,
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

        // 5. Eliminar (Lógico) usando el SP de actualizar y pasando estado 0
        public bool EliminarEstudiante(int idEstudiante, string cedulaActual, string codigoActual)
        {
            return ActualizarEstudiante(idEstudiante, cedulaActual, codigoActual, false);
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