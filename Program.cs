using _02_CRUD.Vistas;

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
            Application.Run(new frm_login());
        }
    }
}

//Scaffold-DbContext "Server=.\SQLEXPRESS;Database=Gestion_Academica;Uid=cris;Pwd=12345;TrustServerCertificate = True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Modelos -ContextDir Config -Context GestionAcademicaContext -DataAnnotations -Force


//Scaffold-DbContext "Server=localhost;Port=3306;Database=cursos_online;Uid=root;Pwd=;" Pomelo.EntityFrameworkCore.MySql -OutputDir Modelos -ContextDir Config -Context CursoOnlineContext -DataAnnotations -Force
//Scaffold-DbContext "Server=localhost;Port=3306;Database=sistema_academico;Uid=root;Pwd=;" Pomelo.EntityFrameworkCore.MySql -OutputDir Modelos -ContextDir Config -Context SistemaAcademicoContext -DataAnnotations -Force