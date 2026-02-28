using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Academico.Modelos;

[Keyless]
public partial class VistaPromediosEstudiante
{
    [Column("cedula_texto")]
    [StringLength(255)]
    public string CedulaTexto { get; set; }

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
}
