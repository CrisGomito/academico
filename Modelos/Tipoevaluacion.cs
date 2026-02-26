using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Academico.Modelos;

[Table("tipoevaluacion")]
public partial class Tipoevaluacion
{
    [Key]
    [Column("id_tipo_evaluacion", TypeName = "int(11)")]
    public int IdTipoEvaluacion { get; set; }

    [Column("nombre")]
    [StringLength(30)]
    public string Nombre { get; set; } = null!;

    [Column("peso")]
    [Precision(5, 2)]
    public decimal Peso { get; set; }

    [InverseProperty("IdTipoEvaluacionNavigation")]
    public virtual ICollection<Evaluacion> Evaluacions { get; set; } = new List<Evaluacion>();
}
