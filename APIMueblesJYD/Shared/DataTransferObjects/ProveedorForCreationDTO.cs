using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record ProveedorForCreationDTO(string RazonSocial, int Estado,
        IEnumerable<ContactoProveedorForCreationDTO> ContactoProveedor, IEnumerable<FacturaCompraForCreationDTO> FacturaCompra);
}
