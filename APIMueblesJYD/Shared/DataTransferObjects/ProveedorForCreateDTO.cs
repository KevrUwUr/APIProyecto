using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record ProveedorForCreateDTO(Guid IdProveedor, string RazonSocial, int Estado)
        //IEnumerable<ContactoProveedorForCreationDTO> ContactoProveedores,
        //IEnumerable<FacturaCompraForCreationDTO> FacturaCompras);
        //)
    {
    }
}
