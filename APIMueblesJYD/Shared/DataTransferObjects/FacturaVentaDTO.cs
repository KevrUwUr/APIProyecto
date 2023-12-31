﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record FacturaVentaDTO(int FacturaVentaId, int NFactura, DateTime FechaGeneracion, DateTime FechaExpedicion, 
        DateTime FechaVencimiento, float TotalBruto, float TotalIVA, float TotalRefuete, float TotalPago, int IdUsuario);

}
