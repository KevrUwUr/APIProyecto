using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IFacturaVentaRepository
    {
        IEnumerable<FacturaVentaDTO> GetAllSaleBills(bool trackChanges);
        FacturaVentaDTO GetSaleBill(int saleBillId, bool trackChanges);
    }
}
