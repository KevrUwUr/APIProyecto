﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record PerdidaForUpdateDTO(DateTime FechaPerdida, int Estado, float Total,
        IEnumerable<PerdidaProductoForCreationDTO> PerdidaProductos);
}
