using System;
using System.Collections.Generic;
using System.Linq;
using Academico.Config;
using Academico.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Academico.Controladores
{
    public class PeriodosController
    {
        // 1. Obtener lista de periodos
        public List<Periodoacademico> ObtenerPeriodos()
        {
            using (var _context = new SistemaAcademicoContext())
            {
                return _context.Periodoacademicos
                    .OrderByDescending(p => p.FechaInicio)
                    .ToList();
            }
        }

        public Periodoacademico ObtenerPeriodoPorId(int id)
        {
            using (var _context = new SistemaAcademicoContext())
            {
                return _context.Periodoacademicos.FirstOrDefault(p => p.IdPeriodo == id);
            }
        }

        // 2. Insertar Periodo (Con EF Core puro)
        public (bool exito, string mensaje) AgregarPeriodo(string nombre, DateTime fechaInicio, DateTime fechaFin, string estado)
        {
            try
            {
                using (var _context = new SistemaAcademicoContext())
                {
                    var nuevoPeriodo = new Periodoacademico
                    {
                        Nombre = nombre,
                        // EF Core 8 en .NET 8 mapea los campos DATE de MySQL a la estructura DateOnly
                        FechaInicio = DateOnly.FromDateTime(fechaInicio),
                        FechaFin = DateOnly.FromDateTime(fechaFin),
                        Estado = estado
                    };

                    _context.Periodoacademicos.Add(nuevoPeriodo);
                    _context.SaveChanges();
                    return (true, "Periodo académico registrado con éxito.");
                }
            }
            catch (DbUpdateException)
            {
                // Este error puede saltar por el Trigger tr_validar_periodo de tu DB
                return (false, "Error en la Base de Datos. Asegúrese de que la fecha final sea mayor a la de inicio.");
            }
            catch (Exception ex)
            {
                return (false, $"Error desconocido: {ex.Message}");
            }
        }

        // 3. Actualizar Periodo
        public (bool exito, string mensaje) ActualizarPeriodo(int idPeriodo, string nombre, DateTime fechaInicio, DateTime fechaFin, string estado)
        {
            try
            {
                using (var _context = new SistemaAcademicoContext())
                {
                    var periodo = _context.Periodoacademicos.Find(idPeriodo);
                    if (periodo != null)
                    {
                        periodo.Nombre = nombre;
                        periodo.FechaInicio = DateOnly.FromDateTime(fechaInicio);
                        periodo.FechaFin = DateOnly.FromDateTime(fechaFin);
                        periodo.Estado = estado;

                        _context.SaveChanges();
                        return (true, "Periodo académico actualizado con éxito.");
                    }
                    return (false, "El periodo no existe.");
                }
            }
            catch (DbUpdateException)
            {
                return (false, "Error en la Base de Datos. Asegúrese de que la fecha final sea mayor a la de inicio.");
            }
            catch (Exception ex)
            {
                return (false, $"Error desconocido: {ex.Message}");
            }
        }

        // 4. Eliminar Periodo (Físico - Protegido por FK)
        public (bool exito, string mensaje) EliminarPeriodo(int idPeriodo)
        {
            try
            {
                using (var _context = new SistemaAcademicoContext())
                {
                    var periodo = _context.Periodoacademicos.Find(idPeriodo);
                    if (periodo != null)
                    {
                        _context.Periodoacademicos.Remove(periodo);
                        _context.SaveChanges();
                        return (true, "Periodo eliminado con éxito.");
                    }
                    return (false, "El periodo no existe.");
                }
            }
            catch (DbUpdateException)
            {
                // Salta gracias a tu esquema relacional si ya hay matriculas o evaluaciones
                return (false, "No se puede eliminar este periodo porque ya tiene matrículas o evaluaciones asignadas.");
            }
            catch (Exception ex)
            {
                return (false, $"Error desconocido: {ex.Message}");
            }
        }
    }
}