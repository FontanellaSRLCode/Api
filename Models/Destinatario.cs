using System;
using System.Collections.Generic;

namespace apiLogisticafs.Models;

public partial class Destinatario
{
    public int DesId { get; set; }

    public int DesRemId { get; set; }

    public string DesNombre { get; set; } = null!;

    public string DesCelular { get; set; } = null!;

    public string DesDireccion { get; set; } = null!;

    public string? DesTransporte { get; set; }

    public string? InfoAdicionalDest { get; set; }

    public string? FechaEntregaDest { get; set; }

    public string? RangoHorarioDest { get; set; }

    public string? PisoDest { get; set; }

    public string? DeptoDest { get; set; }

    public string? LocalidadDest { get; set; }

    public string? ProvinciaDest { get; set; }
}
