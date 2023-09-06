using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record CargoDto
    {
        public Guid Id { get; init; }
        public string? NombreCargo { get; init; }
        public int Estado { get; init; }
    }
}
