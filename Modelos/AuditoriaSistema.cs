using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Academico.Modelos;

[Table("auditoria_sistema")]
[Index("TablaAfectada", "Accion", "Fecha", Name = "idx_audit_completo")]
[Index("Fecha", Name = "idx_audit_fecha")]
[Index("IdUsuario", "Fecha", Name = "idx_audit_usuario")]
public partial class AuditoriaSistema
{
    [Key]
    [Column("id_auditoria", TypeName = "int(11)")]
    public int IdAuditoria { get; set; }

    [Column("ip_user")]
    [StringLength(45)]
    public string? IpUser { get; set; }

    [Column("id_usuario", TypeName = "int(11)")]
    public int? IdUsuario { get; set; }

    [Column("id_rol", TypeName = "int(11)")]
    public int? IdRol { get; set; }

    [Column("accion", TypeName = "enum('INSERT','UPDATE','DELETE','LOGIN')")]
    public string Accion { get; set; } = null!;

    [Column("tabla_afectada")]
    [StringLength(50)]
    public string? TablaAfectada { get; set; }

    [Column("registro_id", TypeName = "int(11)")]
    public int? RegistroId { get; set; }

    [Column("valor_anterior", TypeName = "json")]
    public string? ValorAnterior { get; set; }

    [Column("valor_nuevo", TypeName = "json")]
    public string? ValorNuevo { get; set; }

    [Column("fecha", TypeName = "datetime")]
    public DateTime? Fecha { get; set; }
}
