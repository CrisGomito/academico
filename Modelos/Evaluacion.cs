using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Academico.Modelos;

[Table("evaluacion")]
[Index("IdAsignatura", Name = "fk_eval_asignatura")]
[Index("IdPeriodo", Name = "fk_eval_periodo")]
[Index("IdTipoEvaluacion", Name = "fk_eval_tipoeval")]
public partial class Evaluacion
{
    [Key]
    [Column("id_evaluacion", TypeName = "int(11)")]
    public int IdEvaluacion { get; set; }

    [Column("id_asignatura", TypeName = "int(11)")]
    public int IdAsignatura { get; set; }

    [Column("id_tipo_evaluacion", TypeName = "int(11)")]
    public int IdTipoEvaluacion { get; set; }

    [Column("id_periodo", TypeName = "int(11)")]
    public int IdPeriodo { get; set; }

    [Column("descripcion")]
    [StringLength(80)]
    public string Descripcion { get; set; }

    [InverseProperty("IdEvaluacionNavigation")]
    public virtual ICollection<Calificacion> Calificacions { get; set; } = new List<Calificacion>();

    [ForeignKey("IdAsignatura")]
    [InverseProperty("Evaluacions")]
    public virtual Asignatura IdAsignaturaNavigation { get; set; }

    [ForeignKey("IdPeriodo")]
    [InverseProperty("Evaluacions")]
    public virtual Periodoacademico IdPeriodoNavigation { get; set; }

    [ForeignKey("IdTipoEvaluacion")]
    [InverseProperty("Evaluacions")]
    public virtual Tipoevaluacion IdTipoEvaluacionNavigation { get; set; }
}
