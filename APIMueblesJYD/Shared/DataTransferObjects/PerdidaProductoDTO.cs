﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record PerdidaProductoDTO(float PrecioUnitario, int Cantidad, string Motivo, Guid IdPerdida, Guid IdProducto);

}