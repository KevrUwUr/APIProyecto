using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IFacturaVentaService
    {
        IEnumerable<FacturaVentaDTO> GetAllSaleBills(bool trackChanges);
        FacturaVentaDTO GetSaleBill(Guid Id, bool trackChanges);
    }
}
