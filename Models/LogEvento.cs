using System;
using System.Collections.Generic;

namespace apiLogisticafs.Models;

public partial class LogEvento
{
    public int Id { get; set; }

    public string Evento { get; set; } = null!;

    public string Mensaje { get; set; } = null!;

    public int? SessionId { get; set; }

    public DateTime Fecha { get; set; }
}
