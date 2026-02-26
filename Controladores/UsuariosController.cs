
using Academico.Config;
using Academico.Modelos;

namespace Academico.Controladores
{
    public class UsuariosController
    {
        private readonly SistemaAcademicoContext _context = new SistemaAcademicoContext();
        /*
        public List<Usuario> ObtenerUsuarios()
        {
            return _context.Usuarios
                .Where(u => u.EsActivo == true)
                .Include(rol => rol.Rols)
                .OrderBy(u => u.NombreUsuario)
                .ToList();
        }
        public Usuario ObtenerUsuarioPorId(int id)
        {
            return _context.Usuarios
                .Where(u => u.EsActivo == true)
                .Include(rol => rol.Rols)
                .FirstOrDefault(u => u.UsuarioId == id);
        }
        public bool AgregarUsuario(Usuario usuario)
        {
            try
            {
                usuario.PasswordHash = PasswordHelper.HashPassword(usuario.PasswordHash);
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool ActualizarUsuario(Usuario usuario)
        {
            try
            {
                //_context.Usuarios.Update(usuario);
                var usu = _context.Usuarios.Find(usuario.UsuarioId);
                if (usu != null)
                {
                    usu.NombreUsuario = usuario.NombreUsuario;
                    usu.PasswordHash = PasswordHelper.HashPassword(usuario.PasswordHash);
                    usu.Email = usuario.Email;
                    usu.EsActivo = usuario.EsActivo;

                    // Limpiar roles anteriores
                    usu.Rols.Clear();

                    // Asignar nuevo rol
                    foreach (var rol in usuario.Rols)
                    {
                        var rolReal = _context.Roles.Find(rol.RolId);
                        usu.Rols.Add(rolReal);
                    }
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool EliminarUsuario(int id)
        {
            try
            {
                var usuario = _context.Usuarios.Find(id);
                if (usuario != null)
                {
                    _context.Usuarios.Remove(usuario);
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Usuario AutenticarUsuario(string correo, string contrasenia)
        {
            var usuario = _context.Usuarios
                .Where(u => u.EsActivo == true)
                .Include(u => u.Rols)
                .FirstOrDefault(u => u.Email == correo);

            if (usuario == null)
                return null;

            bool passwordCorrecta = PasswordHelper.VerifyPassword(contrasenia, usuario.PasswordHash);

            return passwordCorrecta ? usuario : null;
        }
        public bool EmailExiste(string correo)
        {
            return _context.Usuarios.Any(u => u.Email == correo);
        }
        public List<Role> ObtenerRoles()
        {
            return _context.Roles
                .OrderBy(r => r.NombreRol)
                .ToList();
        }
        public Role ObtenerRolPorId(int id)
        {
            return _context.Roles.Find(id);
        }
        */
    }
}
