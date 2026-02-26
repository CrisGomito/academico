using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Academico.Modelos;

[Keyless]
public partial class VistaUsuariosAdmin
{
    [Column("id_usuario", TypeName = "int(11)")]
    public int IdUsuario { get; set; }

    [Column("nombre")]
    [StringLength(50)]
    public string? Nombre { get; set; }

    [Column("apellido")]
    [StringLength(50)]
    public string? Apellido { get; set; }

    [Column("correo_plano")]
    [StringLength(255)]
    public string? CorreoPlano { get; set; }

    [Column("roles", TypeName = "mediumtext")]
    public string? Roles { get; set; }

    [Column("estado")]
    public bool? Estado { get; set; }

    [Column("intentos_fallidos", TypeName = "int(11)")]
    public int? IntentosFallidos { get; set; }

    [Column("bloqueado_hasta", TypeName = "datetime")]
    public DateTime? BloqueadoHasta { get; set; }

    [Column("fecha_cambio_password", TypeName = "datetime")]
    public DateTime? FechaCambioPassword { get; set; }

    [Column("fecha_creacion", TypeName = "datetime")]
    public DateTime? FechaCreacion { get; set; }
}
