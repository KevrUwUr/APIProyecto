using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record ProductoForUpdateDTO(Guid ProductoId, string Nombre, float Precio, int Stock, string Descripcion,
        int Estado, string Color, int Tipo, string OrigenMateriaPrima, Guid IdCategoria);
}
