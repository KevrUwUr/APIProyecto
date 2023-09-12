using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record ContactoProveedorDTO
    {
        public Guid Id { get; init; }
        public string? NombreProv { get; init; }
        public int Telefono { get; init; }
        public string? Email { get; init; }
        public int Estado { get; init; }
        public DateTime FechaAlta { get; init; }
        public DateTime FechaBaja { get; init; }
        public Guid IdProveedor { get; init; }
    }
}
