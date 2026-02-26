using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Academico.Modelos;

[Keyless]
public partial class VistaHistorialNota
{
    [Column("id_auditoria", TypeName = "int(11)")]
    public int IdAuditoria { get; set; }

    [Column("usuario_nombre")]
    [StringLength(101)]
    public string? UsuarioNombre { get; set; }

    [Column("rol")]
    [StringLength(30)]
    public string? Rol { get; set; }

    [Column("accion", TypeName = "enum('INSERT','UPDATE','DELETE','LOGIN')")]
    public string Accion { get; set; } = null!;

    [Column("id_calificacion", TypeName = "int(11)")]
    public int? IdCalificacion { get; set; }

    [Column("valor_anterior")]
    [MySqlCollation("utf8mb4_bin")]
    public string? ValorAnterior { get; set; }

    [Column("valor_nuevo")]
    [MySqlCollation("utf8mb4_bin")]
    public string? ValorNuevo { get; set; }

    [Column("fecha", TypeName = "datetime")]
    public DateTime? Fecha { get; set; }
}
