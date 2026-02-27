using System;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using Academico.Config;
using Microsoft.EntityFrameworkCore;
using MySqlConnector; // Importante: Pomelo usa MySqlConnector

namespace Academico.Controladores
{
    public class AuthController
    {
        // PASO 1: Validar credenciales y enviar correo
        public (bool exito, int idUsuario, string nombre, string mensaje) LoginPaso1(string correo, string passwordPlana)
        {
            // 1. Encriptar la contraseña en SHA256 (como lo requiere tu BD)
            string passwordHash = EncriptarSHA256(passwordPlana);

            using (var context = new SistemaAcademicoContext())
            {
                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_login_paso1_credenciales";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new MySqlParameter("@p_correo", correo));
                    command.Parameters.Add(new MySqlParameter("@p_password_hash", passwordHash));
                    command.Parameters.Add(new MySqlParameter("@p_ip_user", GetLocalIPAddress()));

                    try
                    {
                        context.Database.OpenConnection();
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int idUsuario = reader.GetInt32("id_usuario");
                                string nombre = reader.GetString("nombre");
                                string correoDestino = reader.GetString("correo");
                                string codigo2fa = reader.GetString("codigo_2fa");

                                // 2. Enviar el código por correo electrónico (La Automatización)
                                bool correoEnviado = EnviarCorreo2FA(correoDestino, nombre, codigo2fa);

                                if (correoEnviado)
                                    return (true, idUsuario, nombre, "Credenciales correctas. Código 2FA enviado al correo.");
                                else
                                    return (true, idUsuario, nombre, "Credenciales correctas, pero hubo un error enviando el correo. Revise su conexión.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Si la BD lanza el SIGNAL SQLSTATE '45000' (Credenciales incorrectas o inactivo)
                        return (false, 0, "", ex.Message);
                    }
                }
            }
            return (false, 0, "", "Error desconocido en Paso 1.");
        }

        // PASO 2: Validar el código de 6 dígitos
        public (bool exito, int idRol, string nombreRol, string mensaje) LoginPaso2(int idUsuario, string codigoIngresado)
        {
            using (var context = new SistemaAcademicoContext())
            {
                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_login_paso2_verificar2fa";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new MySqlParameter("@p_id_usuario", idUsuario));
                    command.Parameters.Add(new MySqlParameter("@p_codigo_ingresado", codigoIngresado));
                    command.Parameters.Add(new MySqlParameter("@p_ip_user", GetLocalIPAddress()));

                    try
                    {
                        context.Database.OpenConnection();
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int idRol = reader.GetInt32("id_rol");
                                string rolNombre = reader.GetString("rol_nombre");
                                return (true, idRol, rolNombre, "Login Exitoso.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Lanza "Código inválido o expirado"
                        return (false, 0, "", ex.Message);
                    }
                }
            }
            return (false, 0, "", "Error desconocido en Paso 2.");
        }

        // ---------------- METODOS AUXILIARES ---------------- //

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

        private bool EnviarCorreo2FA(string destinatario, string nombre, string codigo)
        {
            try
            {
                // NOTA: Configura tu correo de Gmail y crea una "Contraseña de Aplicación"
                string miCorreo = "cristianpilco05@gmail.com";
                string miClaveApp = "tbtc qbfn kbvd jmqq";

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(miCorreo, "Sistema Académico UNIANDES");
                mail.To.Add(destinatario);
                mail.Subject = "Código de Verificación - Sistema Académico";
                mail.Body = $"Hola {nombre},<br><br>Su código de verificación (2FA) es: <b>{codigo}</b><br><br>Este código expirará en 5 minutos.<br>";
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential(miCorreo, miClaveApp);
                smtp.EnableSsl = true;
                smtp.Send(mail);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // NUEVA FUNCIÓN: RECUPERAR CONTRASEÑA
        public (bool exito, string mensaje) RecuperarContrasenia(string correoPlano)
        {
            using (var context = new SistemaAcademicoContext())
            {
                // Encriptamos el correo ingresado para buscarlo en la DB (igual que en LoginPaso1)
                string hashInput = correoPlano + "SALT_ACADEMICO_2026";
                byte[] hashBytes;
                using (SHA256 sha256 = SHA256.Create())
                {
                    hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(hashInput));
                }

                var usuario = context.Usuarios.FirstOrDefault(u => u.CorreoHash == hashBytes && u.Estado == true);

                if (usuario == null)
                    return (false, "El correo no está registrado en el sistema o el usuario está inactivo.");

                // Generar nueva clave aleatoria segura (Ej: Uniandes1492*)
                string nuevaClave = "Uniandes" + new Random().Next(1000, 9999).ToString() + "*";
                string claveHash = EncriptarSHA256(nuevaClave);

                try
                {
                    // Buscamos un rol del usuario para la auditoría
                    int idRol = context.UsuarioRols.FirstOrDefault(ur => ur.IdUsuario == usuario.IdUsuario)?.IdRol ?? 3;

                    // El propio usuario se audita a sí mismo en esta operación
                    context.Database.ExecuteSqlRaw(
                        "CALL sp_cambiar_password({0}, {1}, {2}, {3}, {4})",
                        usuario.IdUsuario, idRol, usuario.IdUsuario, claveHash, GetLocalIPAddress()
                    );

                    bool enviado = EnviarCorreoRecuperacion(correoPlano, usuario.Nombre, nuevaClave);
                    if (enviado)
                        return (true, "Se ha enviado una contraseña temporal a su correo electrónico.");
                    else
                        return (false, "Se cambió la clave, pero hubo un problema al enviar el correo.");
                }
                catch (Exception ex)
                {
                    return (false, "Error al actualizar la contraseña: " + ex.Message);
                }
            }
        }

        private bool EnviarCorreoRecuperacion(string destinatario, string nombre, string claveTemp)
        {
            try
            {
                string miCorreo = "cristianpilco05@gmail.com";
                string miClaveApp = "tbtc qbfn kbvd jmqq";

                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.From = new System.Net.Mail.MailAddress(miCorreo, "Sistema Académico UNIANDES");
                mail.To.Add(destinatario);
                mail.Subject = "Recuperación de Contraseña - Sistema Académico";
                mail.Body = $"Hola {nombre},<br><br>Ha solicitado restablecer su contraseña.<br><br>Su nueva contraseña temporal es: <b>{claveTemp}</b><br><br>Por motivos de seguridad, inicie sesión inmediatamente y diríjase a 'Mi Perfil' para crear una nueva contraseña propia.";
                mail.IsBodyHtml = true;

                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential(miCorreo, miClaveApp);
                smtp.EnableSsl = true;
                smtp.Send(mail);

                return true;
            }
            catch (Exception)
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
