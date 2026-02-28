using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Academico.Modelos;

[Table("estudiante")]
[Index("CedulaHash", Name = "uk_est_cedula_hash", IsUnique = true)]
[Index("Codigo", Name = "uk_est_codigo", IsUnique = true)]
[Index("IdUsuario", Name = "uk_est_usuario", IsUnique = true)]
public partial class Estudiante
{
    [Key]
    [Column("id_estudiante", TypeName = "int(11)")]
    public int IdEstudiante { get; set; }

    [Required]
    [Column("cedula")]
    [MaxLength(255)]
    public byte[] Cedula { get; set; }

    [Column("cedula_hash")]
    [MaxLength(32)]
    public byte[] CedulaHash { get; set; }

    [Required]
    [Column("codigo")]
    [StringLength(20)]
    public string Codigo { get; set; }

    [Column("id_usuario", TypeName = "int(11)")]
    public int IdUsuario { get; set; }

    [Column("fecha_registro", TypeName = "datetime")]
    public DateTime? FechaRegistro { get; set; }

    [Column("estado")]
    public bool? Estado { get; set; }

    [InverseProperty("IdEstudianteNavigation")]
    public virtual ICollection<Calificacion> Calificacions { get; set; } = new List<Calificacion>();

    [ForeignKey("IdUsuario")]
    [InverseProperty("Estudiante")]
    public virtual Usuario IdUsuarioNavigation { get; set; }

    [InverseProperty("IdEstudianteNavigation")]
    public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
}
