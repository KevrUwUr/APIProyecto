using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record CategoriaForUpdateDTO (string Nombre, int Estado,
        IEnumerable<ProductoForCreationDTO>Productos);
}
