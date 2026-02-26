using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Academico.Modelos;

[Table("matricula")]
[Index("IdAsignatura", Name = "fk_mat_asignatura")]
[Index("IdPeriodo", Name = "fk_mat_periodo")]
[Index("IdEstudiante", "IdAsignatura", "IdPeriodo", Name = "uk_matricula_concurrencia", IsUnique = true)]
public partial class Matricula
{
    [Key]
    [Column("id_matricula", TypeName = "int(11)")]
    public int IdMatricula { get; set; }

    [Column("id_estudiante", TypeName = "int(11)")]
    public int IdEstudiante { get; set; }

    [Column("id_asignatura", TypeName = "int(11)")]
    public int IdAsignatura { get; set; }

    [Column("id_periodo", TypeName = "int(11)")]
    public int IdPeriodo { get; set; }

    [ForeignKey("IdAsignatura")]
    [InverseProperty("Matriculas")]
    public virtual Asignatura IdAsignaturaNavigation { get; set; } = null!;

    [ForeignKey("IdEstudiante")]
    [InverseProperty("Matriculas")]
    public virtual Estudiante IdEstudianteNavigation { get; set; } = null!;

    [ForeignKey("IdPeriodo")]
    [InverseProperty("Matriculas")]
    public virtual Periodoacademico IdPeriodoNavigation { get; set; } = null!;
}
