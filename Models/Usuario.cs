using System;
using System.Collections.Generic;

namespace apiLogisticafs.Models;

public partial class Usuario
{
    public int UsuId { get; set; }

    public string? UsuNombre { get; set; } = null!;

    public string? UsuEmail { get; set; } = null!;

    public string? UsuTelefono { get; set; } = null!;

    public string UsuUsuario { get; set; } = null!;

    public string UsuPassword { get; set; } = null!;
}
