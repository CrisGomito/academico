using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using Academico.Config;
using Academico.Modelos;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace Academico.Controladores
{
    public class UsuariosController
    {
        // 1. OBTENER LISTA DE USUARIOS (Usando la Vista para ver correos desencriptados)
        public List<VistaUsuariosAdmin> ObtenerUsuarios()
        {
            using (var _context = new SistemaAcademicoContext())
            {
                return _context.VistaUsuariosAdmins
                    .Where(u => u.Estado == true)
                    .OrderBy(u => u.Nombre)
                    .ToList();
            }
        }

        public VistaUsuariosAdmin ObtenerUsuarioPorId(int id)
        {
            using (var _context = new SistemaAcademicoContext())
            {
                return _context.VistaUsuariosAdmins.FirstOrDefault(u => u.IdUsuario == id);
            }
        }

        public List<Rol> ObtenerRoles()
        {
            using (var _context = new SistemaAcademicoContext())
            {
                return _context.Rols.OrderBy(r => r.Nombre).ToList();
            }
        }

        // 2. VERIFICAR SI EL EMAIL EXISTE (Lógica adaptada a tu hash)
        public bool EmailExiste(string correo)
        {
            using (var _context = new SistemaAcademicoContext())
            {
                // Encriptamos el correo a Hash para compararlo con el de la BD (como lo hace tu Trigger)
                string salt = "SALT_ACADEMICO_2026";
                string input = correo + salt;
                byte[] hashBytes;
                using (SHA256 sha256 = SHA256.Create())
                {
                    hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                }

                return _context.Usuarios.Any(u => u.CorreoHash == hashBytes);
            }
        }

        // 3. INSERTAR USUARIO (Llamando al Stored Procedure)
        public bool AgregarUsuario(string nombre, string apellido, string correo, string passwordPlana, int idRolNuevo)
        {
            try
            {
                string passwordHash = EncriptarSHA256(passwordPlana);

                using (var _context = new SistemaAcademicoContext())
                {
                    _context.Database.ExecuteSqlRaw(
                        "CALL sp_insertar_usuario({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})",
                        Program.usuarioActualId, // id auditoria
                        Program.rolId,           // rol auditoria
                        nombre,
                        apellido,
                        correo,
                        passwordHash,
                        idRolNuevo,
                        GetLocalIPAddress()
                    );
                    return true;
                }
            }
            catch (Exception ex)
            {
                // Aquí podrías loguear ex.Message
                return false;
            }
        }

        // 4. ACTUALIZAR USUARIO (Llamando al Stored Procedure)
        public bool ActualizarUsuario(int idUsuarioMod, string nombre, string apellido, bool estado)
        {
            try
            {
                using (var _context = new SistemaAcademicoContext())
                {
                    byte estadoTiny = (byte)(estado ? 1 : 0);

                    _context.Database.ExecuteSqlRaw(
                        "CALL sp_actualizar_usuario({0}, {1}, {2}, {3}, {4}, {5}, {6})",
                        Program.usuarioActualId,
                        Program.rolId,
                        idUsuarioMod,
                        nombre,
                        apellido,
                        estadoTiny,
                        GetLocalIPAddress()
                    );
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        // 5. ELIMINAR USUARIO (Borrado Lógico)
        public bool EliminarUsuario(int idUsuarioDel)
        {
            try
            {
                using (var _context = new SistemaAcademicoContext())
                {
                    _context.Database.ExecuteSqlRaw(
                        "CALL sp_eliminar_usuario({0}, {1}, {2}, {3})",
                        Program.usuarioActualId,
                        Program.rolId,
                        idUsuarioDel,
                        GetLocalIPAddress()
                    );
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Metodos Auxiliares
        private string EncriptarSHA256(string texto)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(texto));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
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