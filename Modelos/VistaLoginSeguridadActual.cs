using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Academico.Modelos;

[Keyless]
public partial class VistaLoginSeguridadActual
{
    [Column("nombres")]
    [StringLength(50)]
    public string Nombres { get; set; }

    [Column("apellidos")]
    [StringLength(50)]
    public string Apellidos { get; set; }

    [Column("fecha_ingreso", TypeName = "datetime")]
    public DateTime FechaIngreso { get; set; }

    [Column("ip_user")]
    [StringLength(45)]
    public string IpUser { get; set; }

    [Column("resultado_login")]
    [MySqlCharSet("utf8")]
    [MySqlCollation("utf8_general_ci")]
    public string ResultadoLogin { get; set; }
}
