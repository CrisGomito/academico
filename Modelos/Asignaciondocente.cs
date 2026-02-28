using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Academico.Modelos;

[Table("asignaciondocente")]
[Index("IdAsignatura", Name = "fk_asigdoc_asignatura")]
[Index("IdPeriodo", Name = "fk_asigdoc_periodo")]
[Index("IdDocente", "IdAsignatura", "IdPeriodo", Name = "uk_asignacion_concurrencia", IsUnique = true)]
public partial class Asignaciondocente
{
    [Key]
    [Column("id_asignacion", TypeName = "int(11)")]
    public int IdAsignacion { get; set; }

    [Column("id_docente", TypeName = "int(11)")]
    public int IdDocente { get; set; }

    [Column("id_asignatura", TypeName = "int(11)")]
    public int IdAsignatura { get; set; }

    [Column("id_periodo", TypeName = "int(11)")]
    public int IdPeriodo { get; set; }

    [ForeignKey("IdAsignatura")]
    [InverseProperty("Asignaciondocentes")]
    public virtual Asignatura IdAsignaturaNavigation { get; set; }

    [ForeignKey("IdDocente")]
    [InverseProperty("Asignaciondocentes")]
    public virtual Docente IdDocenteNavigation { get; set; }

    [ForeignKey("IdPeriodo")]
    [InverseProperty("Asignaciondocentes")]
    public virtual Periodoacademico IdPeriodoNavigation { get; set; }
}
