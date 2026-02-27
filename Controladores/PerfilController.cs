using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using Academico.Config;
using Academico.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Academico.Controladores
{
    public class PerfilController
    {
        // --- OBTENER INFORMACIÓN DEL USUARIO ACTUAL ---
        public VistaUsuariosAdmin ObtenerInformacionUsuarioActual()
        {
            using (var _context = new SistemaAcademicoContext())
            {
                return _context.VistaUsuariosAdmins.FirstOrDefault(u => u.IdUsuario == Program.usuarioActualId);
            }
        }

        // --- CENSURAR CORREO POR SEGURIDAD ---
        public string ObtenerCorreoCensurado(string correo)
        {
            if (string.IsNullOrEmpty(correo) || !correo.Contains("@")) return "";

            var partes = correo.Split('@');
            string nombre = partes[0];
            string dominio = partes[1];

            if (nombre.Length <= 2) return correo; // Muy corto para censurar

            // Deja la primera y última letra del nombre, y llena de asteriscos el medio
            string censurado = nombre.Substring(0, 1) + new string('*', nombre.Length - 2) + nombre.Substring(nombre.Length - 1);
            return $"{censurado}@{dominio}";
        }
        // --- 1. CAMBIO DE CONTRASEÑA ---
        public bool VerificarClaveActual(string clavePlana)
        {
            string claveHash = EncriptarSHA256(clavePlana);
            using (var _context = new SistemaAcademicoContext())
            {
                var usuario = _context.Usuarios.FirstOrDefault(u => u.IdUsuario == Program.usuarioActualId);
                return usuario != null && usuario.PasswordHash == claveHash;
            }
        }

        public bool CambiarContrasenia(string nuevaClavePlana)
        {
            string claveHash = EncriptarSHA256(nuevaClavePlana);
            try
            {
                using (var _context = new SistemaAcademicoContext())
                {
                    _context.Database.ExecuteSqlRaw(
                        "CALL sp_cambiar_password({0}, {1}, {2}, {3}, {4})",
                        Program.usuarioActualId, Program.rolId, Program.usuarioActualId, claveHash, GetLocalIPAddress()
                    );
                    return true;
                }
            }
            catch { return false; }
        }

        // --- 2. CAMBIO DE CORREO ELECTRÓNICO ---
        public (bool exito, string mensaje) SolicitarCambioCorreo(string nuevoCorreo)
        {
            using (var _context = new SistemaAcademicoContext())
            {
                // Verificamos que el nuevo correo no esté en uso (Simulando el hash de la BD)
                string hashInput = nuevoCorreo + "SALT_ACADEMICO_2026";
                byte[] hashBytes;
                using (SHA256 sha256 = SHA256.Create()) { hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(hashInput)); }

                if (_context.Usuarios.Any(u => u.CorreoHash == hashBytes))
                    return (false, "El correo ingresado ya está asociado a otra cuenta en el sistema.");

                // Generamos código y lo guardamos
                string codigo = new Random().Next(100000, 999999).ToString();
                byte[] codigoHash;
                using (SHA256 sha256 = SHA256.Create()) { codigoHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(codigo)); }

                var usuario = _context.Usuarios.Find(Program.usuarioActualId);
                if (usuario == null) return (false, "Usuario no encontrado.");

                usuario.Codigo2fa = codigoHash;
                usuario.Expiracion2fa = DateTime.Now.AddMinutes(10);
                _context.SaveChanges();

                // Enviamos el correo al NUEVO correo
                bool enviado = EnviarCorreoVerificacion(nuevoCorreo, Program.nombreUsuario, codigo);
                if (enviado) return (true, "Se ha enviado un código de seguridad al nuevo correo.");

                return (false, "Error de red al intentar enviar el correo.");
            }
        }

        public (bool exito, string mensaje) ConfirmarCambioCorreo(string nuevoCorreo, string codigoIngresado)
        {
            using (var _context = new SistemaAcademicoContext())
            {
                var usuario = _context.Usuarios.Find(Program.usuarioActualId);
                if (usuario == null) return (false, "Error interno.");

                byte[] codigoHash;
                using (SHA256 sha256 = SHA256.Create()) { codigoHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(codigoIngresado)); }

                if (usuario.Codigo2fa == null || !usuario.Codigo2fa.SequenceEqual(codigoHash) || DateTime.Now > usuario.Expiracion2fa)
                {
                    return (false, "El código es inválido o ha expirado.");
                }

                // Actualizamos el correo a través de SQL Raw para que el Trigger lo encripte automáticamente
                _context.Database.ExecuteSqlRaw(
                    "UPDATE usuario SET correo = {0}, codigo_2fa = NULL, expiracion_2fa = NULL WHERE id_usuario = {1}",
                    nuevoCorreo, Program.usuarioActualId
                );

                // Auditoría manual
                _context.Database.ExecuteSqlRaw(
                    "INSERT INTO auditoria_sistema(id_usuario, id_rol, accion, tabla_afectada, registro_id, valor_nuevo, ip_user) " +
                    "VALUES({0}, {1}, 'UPDATE', 'usuario', {2}, '{\"correo_modificado\":\"TRUE\"}', {3})",
                    Program.usuarioActualId, Program.rolId, Program.usuarioActualId, GetLocalIPAddress()
                );

                return (true, "Correo electrónico actualizado con éxito.");
            }
        }

        // --- MÉTODOS AUXILIARES ---
        private string EncriptarSHA256(string texto)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(texto));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes) builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }

        private bool EnviarCorreoVerificacion(string destinatario, string nombre, string codigo)
        {
            try
            {
                string miCorreo = "cristianpilco05@gmail.com";
                string miClaveApp = "tbtc qbfn kbvd jmqq";

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(miCorreo, "Sistema Académico UNIANDES");
                mail.To.Add(destinatario);
                mail.Subject = "Verificación de Nuevo Correo - Sistema Académico";
                mail.Body = $"Hola {nombre},<br><br>Has solicitado cambiar tu correo electrónico asociado al sistema.<br><br>Usa el siguiente código para confirmar el cambio: <b>{codigo}</b><br><br>Este código expira en 10 minutos.";
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential(miCorreo, miClaveApp);
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return true;
            }
            catch { return false; }
        }

        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork) return ip.ToString();
            }
            return "127.0.0.1";
        }
    }
}