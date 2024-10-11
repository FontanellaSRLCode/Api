using System;
using System.Collections.Generic;

namespace apiLogisticafs.Models;

public partial class Remitente
{
    public int IdEnvio { get; set; }

    public string RemitenteNombre { get; set; } = null!;

    public DateOnly Fecha { get; set; }

    public string? EmailRemitente { get; set; }

    public string TelefonoRemitente { get; set; } = null!;

    public string? InfoAdicional { get; set; }

    public byte? Estado { get; set; }

    public string? RangoHorario { get; set; }

    public string? NombreEntrega { get; set; }

    public string? CelularEntrega { get; set; }

    public string DireccionRetiro { get; set; } = null!;

    public string? PisoEntrega { get; set; }

    public string? DeptoEntrega { get; set; }

    public string? LocalidadEntrega { get; set; }

    public string? ProvinciaEntrega { get; set; }

    public DateTime? FechaCarga { get; set; }
}
