using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Academico.Modelos;

[Table("docente")]
[Index("CedulaHash", Name = "uk_docente_cedula_hash", IsUnique = true)]
[Index("IdUsuario", Name = "uk_docente_usuario", IsUnique = true)]
public partial class Docente
{
    [Key]
    [Column("id_docente", TypeName = "int(11)")]
    public int IdDocente { get; set; }

    [Column("cedula")]
    [MaxLength(255)]
    public byte[] Cedula { get; set; } = null!;

    [Column("cedula_hash")]
    [MaxLength(32)]
    public byte[]? CedulaHash { get; set; }

    [Column("id_usuario", TypeName = "int(11)")]
    public int IdUsuario { get; set; }

    [Column("fecha_registro", TypeName = "datetime")]
    public DateTime? FechaRegistro { get; set; }

    [Column("estado")]
    public bool? Estado { get; set; }

    [InverseProperty("IdDocenteNavigation")]
    public virtual ICollection<Asignaciondocente> Asignaciondocentes { get; set; } = new List<Asignaciondocente>();

    [ForeignKey("IdUsuario")]
    [InverseProperty("Docente")]
    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
