using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions;

public sealed class UsuarioCollectionBadRequest : BadRequestException
{
    public UsuarioCollectionBadRequest()
        : base("La colección de usuario enviada desde un cliente es nula.")
    {
    }
}
