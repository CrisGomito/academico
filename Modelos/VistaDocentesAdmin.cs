using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Academico.Modelos;

[Keyless]
public partial class VistaDocentesAdmin
{
    [Column("id_docente", TypeName = "int(11)")]
    public int IdDocente { get; set; }

    [Column("nombre")]
    [StringLength(50)]
    public string Nombre { get; set; }

    [Column("apellido")]
    [StringLength(50)]
    public string Apellido { get; set; }

    [Column("cedula_plana")]
    [StringLength(255)]
    public string CedulaPlana { get; set; }

    [Column("correo_plano")]
    [StringLength(255)]
    public string CorreoPlano { get; set; }

    [Column("estado")]
    public bool? Estado { get; set; }
}
