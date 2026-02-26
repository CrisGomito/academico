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
    public class DocentesController
    {
        // 1. Obtener lista usando la vista (que ya desencripta la cédula)
        public List<VistaDocentesAdmin> ObtenerDocentes()
        {
            using (var _context = new SistemaAcademicoContext())
            {
                return _context.VistaDocentesAdmins
                    .Where(d => d.Estado == true)
                    .OrderBy(d => d.Nombre)
                    .ToList();
            }
        }

        public VistaDocentesAdmin ObtenerDocentePorId(int id)
        {
            using (var _context = new SistemaAcademicoContext())
            {
                return _context.VistaDocentesAdmins.FirstOrDefault(d => d.IdDocente == id);
            }
        }

        // 2. Obtener usuarios que tienen ROL DOCENTE pero que NO ESTÁN en la tabla docente
        public List<Usuario> ObtenerUsuariosParaNuevosDocentes()
        {
            using (var _context = new SistemaAcademicoContext())
            {
                // Usuarios activos que tienen el rol 2 (Docente)
                var usuariosRolDocente = _context.Usuarios
                    .Include(u => u.UsuarioRols)
                    .Where(u => u.UsuarioRols.Any(ur => ur.IdRol == 2) && u.Estado == true)
                    .ToList();

                // IDs de usuarios que ya están en la tabla docente
                var idsDocentesActuales = _context.Docentes.Select(d => d.IdUsuario).ToList();

                // Filtramos para que solo aparezcan los que faltan por registrar como docentes
                return usuariosRolDocente.Where(u => !idsDocentesActuales.Contains(u.IdUsuario)).ToList();
            }
        }

        // 3. Insertar Docente
        public bool AgregarDocente(int idUsuario, string cedula)
        {
            try
            {
                using (var _context = new SistemaAcademicoContext())
                {
                    _context.Database.ExecuteSqlRaw(
                        "CALL sp_insertar_docente({0}, {1}, {2}, {3}, {4})",
                        Program.usuarioActualId,
                        Program.rolId,
                        idUsuario,
                        cedula,
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

        // 4. Actualizar Docente
        public bool ActualizarDocente(int idDocente, string cedula, bool estado)
        {
            try
            {
                using (var _context = new SistemaAcademicoContext())
                {
                    byte estadoTiny = (byte)(estado ? 1 : 0);
                    _context.Database.ExecuteSqlRaw(
                        "CALL sp_actualizar_docente({0}, {1}, {2}, {3}, {4}, {5})",
                        Program.usuarioActualId,
                        Program.rolId,
                        idDocente,
                        cedula,
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
        public bool EliminarDocente(int idDocente, string cedulaActual)
        {
            return ActualizarDocente(idDocente, cedulaActual, false);
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