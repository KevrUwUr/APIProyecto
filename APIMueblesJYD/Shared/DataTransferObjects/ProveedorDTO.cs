using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record ProveedorDTO//(Guid IdProveedor, string RazonSocial, int Estado)
    {
        public Guid IdProveedor { get; init; }
        public string? RazonSocial { get; init; }
        public int Estado { get; init; }
    }

}
