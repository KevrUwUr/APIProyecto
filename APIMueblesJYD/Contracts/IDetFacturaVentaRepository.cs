using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IDetFacturaVentaRepository
    {
        IEnumerable<DFacturaVentaDTO> GetAllDetSaleBills(bool trackChanges);
        DFacturaVentaDTO GetDetSaleBill(Guid id, bool trackChanges);
    }
}
