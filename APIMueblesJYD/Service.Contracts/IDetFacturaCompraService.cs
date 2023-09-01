using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IDetFacturaCompraService
    {
        IEnumerable<DFacturaCompraDTO> GetAllSaleBoughts(bool trackChanges);
        DFacturaCompraDTO GetSaleBought(Guid Id, bool trackChanges);
    }
}
