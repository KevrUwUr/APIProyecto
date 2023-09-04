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
        IEnumerable<DFacturaVentaDTO> GetAllDSaleBills(bool trackChanges);
        DFacturaVentaDTO GetDetSaleBill(int id, bool trackChanges);
    }
}
