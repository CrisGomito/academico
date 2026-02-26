using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Academico.Modelos;

[Keyless]
public partial class VistaDocentesPeriodo
{
    [Column("nombres")]
    [StringLength(50)]
    public string? Nombres { get; set; }

    [Column("apellidos")]
    [StringLength(50)]
    public string? Apellidos { get; set; }

    [Column("asignatura")]
    [StringLength(60)]
    public string Asignatura { get; set; } = null!;

    [Column("periodo")]
    [StringLength(30)]
    public string Periodo { get; set; } = null!;
}
