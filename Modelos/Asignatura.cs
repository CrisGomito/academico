using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Academico.Modelos;

[Table("asignatura")]
public partial class Asignatura
{
    [Key]
    [Column("id_asignatura", TypeName = "int(11)")]
    public int IdAsignatura { get; set; }

    [Required]
    [Column("nombre")]
    [StringLength(60)]
    public string Nombre { get; set; }

    [Column("creditos", TypeName = "tinyint(4)")]
    public sbyte Creditos { get; set; }

    [InverseProperty("IdAsignaturaNavigation")]
    public virtual ICollection<Asignaciondocente> Asignaciondocentes { get; set; } = new List<Asignaciondocente>();

    [InverseProperty("IdAsignaturaNavigation")]
    public virtual ICollection<Evaluacion> Evaluacions { get; set; } = new List<Evaluacion>();

    [InverseProperty("IdAsignaturaNavigation")]
    public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
}
