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
        IEnumerable<DFacturaVentaDTO> GetAllDetSaleBills(bool trackChanges);
        DFacturaVentaDTO GetDetSaleBill(Guid Id, bool trackChanges);
    }
}
