﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record ContactoProveedorDTO (Guid Id, string NombreProveedor, int Telefono, String Email, 
        int Estado, DateTime FechaAlta, DateTime FechaBaja, Guid IdProveedor);
    
}