using System;
using System.Collections.Generic;

namespace apiLogisticafs.Models;

public partial class Producto
{
    public int ProId { get; set; }

    public int ProRemId { get; set; }

    public int ProDesId { get; set; }

    public string ProDetalle { get; set; } = null!;

    public int ProCantidad { get; set; }

    public string ProEmbalaje { get; set; } = null!;

    public string? ProDimensiones { get; set; }
}
