using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiLogisticafs.Models
{
    public class RemitenteProductoDestinatario
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
       
        public string ProDetalle { get; set; } = null!;

        public int ProCantidad { get; set; }

        public string ProEmbalaje { get; set; } = null!;

        public string? ProDimensiones { get; set; }

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
}
