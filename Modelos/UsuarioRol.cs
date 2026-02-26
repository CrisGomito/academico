using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Academico.Modelos;

[PrimaryKey("IdUsuario", "IdRol")]
[Table("usuario_rol")]
[Index("IdRol", Name = "fk_ur_rol")]
public partial class UsuarioRol
{
    [Key]
    [Column("id_usuario", TypeName = "int(11)")]
    public int IdUsuario { get; set; }

    [Key]
    [Column("id_rol", TypeName = "int(11)")]
    public int IdRol { get; set; }

    [Column("fecha_asignacion", TypeName = "datetime")]
    public DateTime? FechaAsignacion { get; set; }

    [ForeignKey("IdRol")]
    [InverseProperty("UsuarioRols")]
    public virtual Rol IdRolNavigation { get; set; } = null!;

    [ForeignKey("IdUsuario")]
    [InverseProperty("UsuarioRols")]
    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
