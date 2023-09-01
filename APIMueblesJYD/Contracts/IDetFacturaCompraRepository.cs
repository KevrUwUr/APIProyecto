using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IDetFacturaCompraRepository
    {
        IEnumerable<DFacturaCompraDTO> GetAllDetBuyBills(bool trackChanges);
        DFacturaCompraDTO GetDetBuyBill(Guid detBuyBillId, bool trackChanges);
    }
}