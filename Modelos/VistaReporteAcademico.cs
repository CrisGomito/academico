using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Academico.Modelos;

[Keyless]
public partial class VistaReporteAcademico
{
    [Column("id_estudiante", TypeName = "int(11)")]
    public int IdEstudiante { get; set; }

    [Column("nombres")]
    [StringLength(50)]
    public string Nombres { get; set; }

    [Column("apellidos")]
    [StringLength(50)]
    public string Apellidos { get; set; }

    [Required]
    [Column("asignatura")]
    [StringLength(60)]
    public string Asignatura { get; set; }

    [Column("promedio_final")]
    [Precision(5, 2)]
    public decimal? PromedioFinal { get; set; }

    [Column("estado")]
    [StringLength(15)]
    public string Estado { get; set; }
}
