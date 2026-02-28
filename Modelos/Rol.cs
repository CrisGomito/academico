using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Academico.Modelos;

[Table("rol")]
[Index("Nombre", Name = "uk_rol_nombre", IsUnique = true)]
public partial class Rol
{
    [Key]
    [Column("id_rol", TypeName = "int(11)")]
    public int IdRol { get; set; }

    [Required]
    [Column("nombre")]
    [StringLength(30)]
    public string Nombre { get; set; }

    [InverseProperty("IdRolNavigation")]
    public virtual ICollection<UsuarioRol> UsuarioRols { get; set; } = new List<UsuarioRol>();
}
