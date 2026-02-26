using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Academico.Modelos;

[Keyless]
public partial class VistaEstudiantesAdmin
{
    [Column("id_estudiante", TypeName = "int(11)")]
    public int IdEstudiante { get; set; }

    [Column("nombre")]
    [StringLength(50)]
    public string? Nombre { get; set; }

    [Column("apellido")]
    [StringLength(50)]
    public string? Apellido { get; set; }

    [Column("cedula_plana")]
    [StringLength(255)]
    public string? CedulaPlana { get; set; }

    [Column("correo_plano")]
    [StringLength(255)]
    public string? CorreoPlano { get; set; }

    [Column("codigo")]
    [StringLength(20)]
    public string Codigo { get; set; } = null!;

    [Column("estado")]
    public bool? Estado { get; set; }
}
