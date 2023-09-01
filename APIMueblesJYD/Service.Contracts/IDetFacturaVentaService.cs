using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IDetFacturaVentaService
    {
        IEnumerable<EmpleadoDTO> GetAllDetSaleBills(bool trackChanges);
        EmpleadoDTO GetDetSaleBill(Guid Id, bool trackChanges);
    }
}
