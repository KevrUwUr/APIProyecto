using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record ContactoEmpleadoDTO
    {
        public Guid ContEmpId { get; init; }
        public int Telefono { get; init; }
        public string? Direccion { get; init; }
        public string? Email { get; init; }
        public DateTime FechaCreacion { get; init; }
        public Guid EmpleadoId { get; init; }
    }
}