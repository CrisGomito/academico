using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Academico.Modelos;

[Table("periodoacademico")]
public partial class Periodoacademico
{
    [Key]
    [Column("id_periodo", TypeName = "int(11)")]
    public int IdPeriodo { get; set; }

    [Column("nombre")]
    [StringLength(30)]
    public string Nombre { get; set; } = null!;

    [Column("fecha_inicio")]
    public DateOnly FechaInicio { get; set; }

    [Column("fecha_fin")]
    public DateOnly FechaFin { get; set; }

    [Column("estado")]
    [StringLength(15)]
    public string Estado { get; set; } = null!;

    [InverseProperty("IdPeriodoNavigation")]
    public virtual ICollection<Asignaciondocente> Asignaciondocentes { get; set; } = new List<Asignaciondocente>();

    [InverseProperty("IdPeriodoNavigation")]
    public virtual ICollection<Evaluacion> Evaluacions { get; set; } = new List<Evaluacion>();

    [InverseProperty("IdPeriodoNavigation")]
    public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
}
