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
    public class CalificacionesController
    {
        public class AlumnoNotaDTO
        {
            public int IdEstudiante { get; set; }
            public string Codigo { get; set; }
            public string NombreCompleto { get; set; }
            public int IdCalificacion { get; set; } // 0 si no tiene nota aún
            public decimal? Nota { get; set; } // Null si no tiene nota
            // NUEVO CAMPO: Evita bloqueos nativos de Windows Forms
            public string NotaUI { get; set; }
        }

        // Obtener el ID del docente a partir del ID de Usuario actual
        public int ObtenerIdDocenteActual()
        {
            using (var _context = new SistemaAcademicoContext())
            {
                var docente = _context.Docentes.FirstOrDefault(d => d.IdUsuario == Program.usuarioActualId);
                return docente != null ? docente.IdDocente : 0;
            }
        }

        // Obtener los periodos donde este docente da clases (o TODOS si es Admin/Testing)
        public List<Periodoacademico> ObtenerPeriodosDelDocente(int idDocente)
        {
            using (var _context = new SistemaAcademicoContext())
            {

  
                // MODO BYPASS  ADMIN / TESTING: Trae todos los periodos activos
                if (idDocente == 0)
                {
                    return _context.Periodoacademicos
                        .Where(p => p.Estado == "Activo")
                        .OrderByDescending(p => p.FechaInicio)
                        .ToList();
                }



                // MODO DOCENTE NORMAL
                var idPeriodos = _context.Asignaciondocentes
                    .Where(a => a.IdDocente == idDocente)
                    .Select(a => a.IdPeriodo)
                    .Distinct()
                    .ToList();

                return _context.Periodoacademicos
                    .Where(p => idPeriodos.Contains(p.IdPeriodo) && p.Estado == "Activo")
                    .OrderByDescending(p => p.FechaInicio)
                    .ToList();
            }
        }

        // Obtener las asignaturas de este docente en un periodo específico
        public List<Asignatura> ObtenerAsignaturasDelDocente(int idDocente, int idPeriodo)
        {
            using (var _context = new SistemaAcademicoContext())
            {


                // MODO BYPASS ADMIN / TESTING: Trae todas las asignaturas de ese periodo sin importar el docente
                if (idDocente == 0)
                {
                    var idAsignaturasAdmin = _context.Asignaciondocentes
                        .Where(a => a.IdPeriodo == idPeriodo)
                        .Select(a => a.IdAsignatura)
                        .Distinct()
                        .ToList();

                    return _context.Asignaturas
                        .Where(a => idAsignaturasAdmin.Contains(a.IdAsignatura))
                        .OrderBy(a => a.Nombre)
                        .ToList();
                }



                // MODO DOCENTE NORMAL
                var idAsignaturas = _context.Asignaciondocentes
                    .Where(a => a.IdDocente == idDocente && a.IdPeriodo == idPeriodo)
                    .Select(a => a.IdAsignatura)
                    .ToList();

                return _context.Asignaturas
                    .Where(a => idAsignaturas.Contains(a.IdAsignatura))
                    .OrderBy(a => a.Nombre)
                    .ToList();
            }
        }

        // Obtener evaluaciones creadas para esa materia en ese periodo
        public List<Evaluacion> ObtenerEvaluaciones(int idAsignatura, int idPeriodo)
        {
            using (var _context = new SistemaAcademicoContext())
            {
                return _context.Evaluacions
                    .Include(e => e.IdTipoEvaluacionNavigation)
                    .Where(e => e.IdAsignatura == idAsignatura && e.IdPeriodo == idPeriodo)
                    .ToList();
            }
        }

        public List<Tipoevaluacion> ObtenerTiposEvaluacion()
        {
            using (var _context = new SistemaAcademicoContext())
            {
                return _context.Tipoevaluacions.ToList();
            }
        }

        // Crear una nueva evaluación (EF Core puro, ya que no hay SP)
        public (bool exito, string mensaje) CrearEvaluacion(int idAsignatura, int idPeriodo, int idTipoEval, string descripcion)
        {
            try
            {
                using (var _context = new SistemaAcademicoContext())
                {
                    var nuevaEval = new Evaluacion
                    {
                        IdAsignatura = idAsignatura,
                        IdPeriodo = idPeriodo,
                        IdTipoEvaluacion = idTipoEval,
                        Descripcion = descripcion
                    };
                    _context.Evaluacions.Add(nuevaEval);
                    _context.SaveChanges();
                    return (true, "Evaluación creada correctamente.");
                }
            }
            catch (DbUpdateException ex)
            {
                // Capturamos si el Trigger de BD lanza error porque los pesos superan el 100%
                if (ex.InnerException != null) return (false, ex.InnerException.Message);
                return (false, ex.Message);
            }
        }

        // ESTO ES CLAVE: Traer a los alumnos de la materia cruzando con sus notas (si existen)
        public List<AlumnoNotaDTO> ObtenerEstudiantesParaCalificar(int idAsignatura, int idPeriodo, int idEvaluacion)
        {
            using (var _context = new SistemaAcademicoContext())
            {
                // 1. Obtenemos alumnos matriculados
                var matriculados = _context.Matriculas
                    .Include(m => m.IdEstudianteNavigation).ThenInclude(e => e.IdUsuarioNavigation)
                    .Where(m => m.IdAsignatura == idAsignatura && m.IdPeriodo == idPeriodo)
                    .ToList();

                // 2. Obtenemos las notas existentes para esta evaluación
                var notasExistentes = _context.Calificacions
                    .Where(c => c.IdEvaluacion == idEvaluacion && c.Activo == true)
                    .ToList();

                var listaFinal = new List<AlumnoNotaDTO>();

                foreach (var mat in matriculados)
                {
                    var estudiante = mat.IdEstudianteNavigation;
                    var calif = notasExistentes.FirstOrDefault(c => c.IdEstudiante == estudiante.IdEstudiante);

                    listaFinal.Add(new AlumnoNotaDTO
                    {
                        IdEstudiante = estudiante.IdEstudiante,
                        Codigo = estudiante.Codigo,
                        NombreCompleto = $"{estudiante.IdUsuarioNavigation.Apellido} {estudiante.IdUsuarioNavigation.Nombre}",
                        IdCalificacion = calif != null ? calif.IdCalificacion : 0,
                        Nota = calif != null ? calif.Nota : (decimal?)null,
                        // Inicializamos la vista UI formateada siempre con punto
                        NotaUI = calif != null ? calif.Nota.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) : ""
                    });
                }

                return listaFinal.OrderBy(l => l.NombreCompleto).ToList();
            }
        }

        // GUARDADO MASIVO DE NOTAS (Usa los SP que ya creaste)
        public (bool exito, string mensaje) GuardarNotas(List<AlumnoNotaDTO> listaNotas, int idEvaluacion)
        {
            try
            {
                using (var _context = new SistemaAcademicoContext())
                {
                    foreach (var alumno in listaNotas)
                    {
                        // Solo procesamos si el docente ingresó una nota
                        if (alumno.Nota.HasValue)
                        {
                            if (alumno.IdCalificacion == 0)
                            {
                                // INSERCIÓN
                                _context.Database.ExecuteSqlRaw(
                                    "CALL sp_insertar_calificacion({0}, {1}, {2}, {3}, {4}, {5})",
                                    Program.usuarioActualId, Program.rolId,
                                    alumno.IdEstudiante, idEvaluacion, alumno.Nota.Value, GetLocalIPAddress()
                                );
                            }
                            else
                            {
                                // ACTUALIZACIÓN
                                _context.Database.ExecuteSqlRaw(
                                    "CALL sp_actualizar_calificacion({0}, {1}, {2}, {3}, {4})",
                                    Program.usuarioActualId, Program.rolId,
                                    alumno.IdCalificacion, alumno.Nota.Value, GetLocalIPAddress()
                                );
                            }
                        }
                    }
                    return (true, "Las calificaciones se han guardado/actualizado correctamente.");
                }
            }
            catch (Exception ex)
            {
                return (false, "Error de validación: Verifique que las notas estén entre 0 y 10. " + ex.Message);
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