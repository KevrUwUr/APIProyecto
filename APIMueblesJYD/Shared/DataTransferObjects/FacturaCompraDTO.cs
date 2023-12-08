using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record FacturaCompraDTO
    {
        public Guid FacturaCompraId { get; init; }
        public int NFactura { get; init; }
        public DateTime? FechaGeneracion { get; init; }
        public DateTime? FechaExpedicion { get; init; }
        public DateTime? FechaVencimiento { get; init; }
        public float TotalBruto { get; init; }
        public float TotalIVA { get; init; }
        public float TotalRefuete { get; init; }
        public float TotalPago { get; init; }
        public Guid IdProveedor { get; init; }
    }
}
