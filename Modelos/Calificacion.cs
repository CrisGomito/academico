using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Academico.Modelos;

[Table("calificacion")]
[Index("IdEvaluacion", Name = "fk_calif_evaluacion")]
[Index("IdEstudiante", "IdEvaluacion", Name = "uk_calificacion_unica", IsUnique = true)]
public partial class Calificacion
{
    [Key]
    [Column("id_calificacion", TypeName = "int(11)")]
    public int IdCalificacion { get; set; }

    [Column("id_estudiante", TypeName = "int(11)")]
    public int IdEstudiante { get; set; }

    [Column("id_evaluacion", TypeName = "int(11)")]
    public int IdEvaluacion { get; set; }

    [Column("nota")]
    [Precision(5, 2)]
    public decimal Nota { get; set; }

    [Column("fecha_registro", TypeName = "datetime")]
    public DateTime? FechaRegistro { get; set; }

    [Column("activo")]
    public bool? Activo { get; set; }

    [ForeignKey("IdEstudiante")]
    [InverseProperty("Calificacions")]
    public virtual Estudiante IdEstudianteNavigation { get; set; }

    [ForeignKey("IdEvaluacion")]
    [InverseProperty("Calificacions")]
    public virtual Evaluacion IdEvaluacionNavigation { get; set; }
}
