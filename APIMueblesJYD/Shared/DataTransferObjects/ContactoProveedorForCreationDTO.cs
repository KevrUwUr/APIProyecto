using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record ContactoProveedorForCreationDTO (string NombreProv, string Telefono,
        string Email, int Estado, DateTime FechaAlta, DateTime FechaBaja);
}
