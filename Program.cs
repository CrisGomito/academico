using _02_CRUD.Vistas;
using Academico.Config;

namespace Academico
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 

        public static int usuarioActualId;
        public static string rol;
        public static string descripcionRol;
        public static int rolId;
        public static string nombreUsuario;
        public static bool logueado;

        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();


            // 1. VERIFICAR LA CONEXIÓN A LA RED / SERVIDOR ANTES DE ARRANCAR
            if (!ProbarConexion())
            {
                MessageBox.Show("No se pudo establecer conexión con el Servidor de Base de Datos.\n\nPor favor, verifique:\n1. Que está conectado a la red local (LAN).\n2. Que la computadora principal (Servidor) esté encendida.\n3. Que su IP sea correcta.",
                    "Error de Conexión Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Cierra la aplicación inmediatamente
            }
            // 2. Si hay conexión, abrimos el Login
            Application.Run(new frm_login());

        }

        // Método auxiliar para probar si EF Core llega a la BD
        static bool ProbarConexion()
        {
            try
            {
                using (var context = new SistemaAcademicoContext())
                {
                    // CanConnect() devuelve true si la base de datos responde
                    return context.Database.CanConnect();
                }
            }
            catch
            {
                return false;
            }
        }
    }
}

//Scaffold-DbContext "Server=.\SQLEXPRESS;Database=Gestion_Academica;Uid=cris;Pwd=12345;TrustServerCertificate = True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Modelos -ContextDir Config -Context GestionAcademicaContext -DataAnnotations -Force


//Scaffold-DbContext "Server=localhost;Port=3306;Database=cursos_online;Uid=root;Pwd=;" Pomelo.EntityFrameworkCore.MySql -OutputDir Modelos -ContextDir Config -Context CursoOnlineContext -DataAnnotations -Force
//Scaffold-DbContext "Server=localhost;Port=3306;Database=sistema_academico;Uid=root;Pwd=;" Pomelo.EntityFrameworkCore.MySql -OutputDir Modelos -ContextDir Config -Context SistemaAcademicoContext -DataAnnotations -Force