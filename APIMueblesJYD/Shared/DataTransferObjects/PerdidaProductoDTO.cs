﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record PerdidaProductoDTO(int Id, float PrecioUnitario, int Cantidad, string Motivo, int IdPerdida, int ProductoId);

}
