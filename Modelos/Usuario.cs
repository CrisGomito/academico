using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Academico.Modelos;

[Table("usuario")]
[Index("CorreoHash", Name = "uk_usuario_correo_hash", IsUnique = true)]
public partial class Usuario
{
    [Key]
    [Column("id_usuario", TypeName = "int(11)")]
    public int IdUsuario { get; set; }

    [Column("nombre")]
    [StringLength(50)]
    public string? Nombre { get; set; }

    [Column("apellido")]
    [StringLength(50)]
    public string? Apellido { get; set; }

    [Column("correo")]
    [MaxLength(255)]
    public byte[]? Correo { get; set; }

    [Column("correo_hash")]
    [MaxLength(32)]
    public byte[]? CorreoHash { get; set; }

    [Column("codigo_2fa")]
    [MaxLength(32)]
    public byte[]? Codigo2fa { get; set; }

    [Column("expiracion_2fa", TypeName = "datetime")]
    public DateTime? Expiracion2fa { get; set; }

    [Column("password_hash")]
    [StringLength(255)]
    public string PasswordHash { get; set; } = null!;

    [Column("estado")]
    public bool? Estado { get; set; }

    [Column("fecha_cambio_password", TypeName = "datetime")]
    public DateTime? FechaCambioPassword { get; set; }

    [Column("intentos_fallidos", TypeName = "int(11)")]
    public int? IntentosFallidos { get; set; }

    [Column("bloqueado_hasta", TypeName = "datetime")]
    public DateTime? BloqueadoHasta { get; set; }

    [Column("fecha_creacion", TypeName = "datetime")]
    public DateTime? FechaCreacion { get; set; }

    [InverseProperty("IdUsuarioNavigation")]
    public virtual Docente? Docente { get; set; }

    [InverseProperty("IdUsuarioNavigation")]
    public virtual Estudiante? Estudiante { get; set; }

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<UsuarioRol> UsuarioRols { get; set; } = new List<UsuarioRol>();
}
