using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions;

public sealed class ProductoCollectionBadRequest : BadRequestException
{
    public ProductoCollectionBadRequest()
        : base("La colección de producto enviada desde un cliente es nula.")
    {
    }
}
