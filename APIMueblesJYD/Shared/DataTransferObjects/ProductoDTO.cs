using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    namespace Shared.DataTransferObjects
    {
        public record ProductoDTO
        {
            public Guid ProductoId { get; init; }
            public string? Nombre { get; init; }
            public float Precio { get; init; }
            public int Stock { get; init; }
            public string? Descripcion { get; init; }
            public string? Color { get; init; }
            public int Tipo { get; init; }
            public string? OrigenMateriaPrima { get; init; }
            public int Estado { get; init; }
        }
    }
}
