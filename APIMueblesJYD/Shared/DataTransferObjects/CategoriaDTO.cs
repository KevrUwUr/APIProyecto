using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record CategoriaDTO
    {
        public Guid Id { get; init; }
        public string? Nombre { get; init; }
        public int Estado { get; init; }
    }
}
